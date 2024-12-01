using Order;
using Product;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
  public class OrderManager : MonoBehaviour
  { 
    public static OrderManager Instance { get; private set; }

    [SerializeField]
    private OrderPlacement _orderPlacement;
    
    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }

    public void OrderProduct(ProductName productName)
    {
      ProductData productData = ProductManager.Instance.GetSpecificProduct(productName);

      if (productData == null)
      {
        Debug.LogError("[OrderManager] Product data is null!");
        return;
      }

      if (!PlayerManager.Instance.Player.GetPlayerEconomy().CheckEnoughMoney(productData.Price))
      {
        Debug.LogError("[OrderManager] Not enough money to order this product!");
        return;
      }

      Transform orderPlace = _orderPlacement.GetEmptyOrderPlace();
      if (orderPlace == null)
      {
        // TODO: User Interface feedback.
        Debug.LogError("[OrderManager] There is no empty order place!");
        return;
      }
      
      PlayerManager.Instance.Player.GetPlayerEconomy().RemoveMoney(productData.Price);
      
      string productPackage = productName + "Package";
      Addressables.InstantiateAsync(productPackage, orderPlace.position, orderPlace.rotation).Completed += handle =>
      {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
          Debug.LogError("[OrderManager] Product package could not be instantiated!");
          return;
        }
    
        GameObject productPackageObject = handle.Result;

        _orderPlacement.PlaceOrder(productPackageObject, orderPlace);
      };
    }
  }
}