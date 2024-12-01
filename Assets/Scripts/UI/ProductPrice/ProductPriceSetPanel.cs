using System.Collections.Generic;
using System.Linq;
using Managers;
using Product;
using UI.OrderPanel;
using UnityEngine;

namespace UI.ProductPrice
{
  public class ProductPriceSetPanel : MonoBehaviour
  {
    [SerializeField]
    private GameObject _productPriceSetPanelItemPrefab;

    [SerializeField]
    private Transform _productPriceSetPanelItemParent;
    
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
      ProductManager instance = ProductManager.Instance;
      for (int i = 0; i < instance.GetAllProducts().Count; i++)
      {
        KeyValuePair<ProductName, ProductData> product = instance.GetAllProducts().ElementAt(i);
        
        GameObject productObject = Instantiate(_productPriceSetPanelItemPrefab, _productPriceSetPanelItemParent);
        productObject.GetComponent<ProductPriceSetPanelItem>().SetProductData(product.Value);
      }
    }

    public void CloseOrderPanel()
    {
      gameObject.SetActive(false);
    }
  }
}