using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
  public class InventoryManager : MonoBehaviour
  {
    public static InventoryManager Instance { get; private set; }
    
    public Dictionary<ProductName, ProductStockVo> ProductStocks = new();

    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }
    
    public void AddProduct(ProductName productName, int count)
    {
      if (ProductStocks.TryGetValue(productName, out ProductStockVo stock))
      {
        stock.StockCount += count;
      }
      else
      {
        ProductStocks.Add(productName, new ProductStockVo
        {
          ProductName = productName,
          StockCount = count
        });
      }
    }
    
    public void RemoveProduct(ProductName productName, int count)
    {
      if (ProductStocks.TryGetValue(productName, out ProductStockVo stock))
      {
        stock.StockCount -= count;
      }
    }
  }

  public class ProductStockVo
  {
    public ProductName ProductName;
    
    public int StockCount; 
  }
}