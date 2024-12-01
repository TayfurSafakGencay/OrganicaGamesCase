using System;
using System.Collections.Generic;
using Managers;
using Product;
using UnityEngine;

namespace UI.StockPanel
{
  public class StockPanel : MonoBehaviour
  {
    [SerializeField]
    private StockPanelItem _stockPanelItemPrefab;

    [SerializeField]
    private Transform _container;

    private void OnEnable()
    {
      foreach (KeyValuePair<ProductName, ProductStockVo> product in InventoryManager.Instance.ProductStocks)
      {
        ProductData productData = ProductManager.Instance.GetSpecificProduct(product.Key);
        
        StockPanelItem stockPanelItem = Instantiate(_stockPanelItemPrefab, _container);
        
        stockPanelItem.SetProductData(productData, product.Value.StockCount);
      }
    }

    public void ClosePanel()
    {
      gameObject.SetActive(false);
    }
  }
}