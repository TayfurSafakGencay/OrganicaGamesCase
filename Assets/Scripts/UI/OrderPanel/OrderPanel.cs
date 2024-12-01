using System.Collections.Generic;
using System.Linq;
using Managers;
using Product;
using UnityEngine;

namespace UI.OrderPanel
{
  public class OrderPanel : MonoBehaviour
  {
    private bool _initialized;
    
    [SerializeField]
    private GameObject _orderItemPrefab;
    
    [SerializeField]
    private Transform _orderItemContainer;
    
    private void Awake()
    {
      gameObject.SetActive(false);
    }

    private void Start()
    {
      GetProducts();
    }

    private void GetProducts()
    {
      if (_initialized) return;
      _initialized = true;
      
      ProductManager instance = ProductManager.Instance;
      for (int i = 0; i < instance.GetAllProducts().Count; i++)
      {
        KeyValuePair<ProductName, ProductData> product = instance.GetAllProducts().ElementAt(i);
        
        GameObject productObject = Instantiate(_orderItemPrefab, _orderItemContainer);
        productObject.GetComponent<OrderPanelItem>().SetProductData(product.Value);
      }
    }

    public void CloseOrderPanel()
    {
      gameObject.SetActive(false);
    }
  }
}