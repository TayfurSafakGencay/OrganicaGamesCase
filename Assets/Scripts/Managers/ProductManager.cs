using System;
using System.Collections.Generic;
using Product;
using UnityEngine;

namespace Managers
{
  public class ProductManager : MonoBehaviour
  {
    public static ProductManager Instance { get; private set; }
    
    [SerializeField]
    private List<ProductData> _productList = new();
    
    private Dictionary<ProductName, ProductData> _products = new();

    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
      
      InitializeProducts();
    }

    private void InitializeProducts()
    {
      for (int i = 0; i < _productList.Count; i++)
      {
        ProductData productData = _productList[i];
        _productList[i].SetPriceAsDefault();
        
        _products.Add(productData.Name, productData);
      }
    }

    public ProductData GetSpecificProduct(ProductName productName)
    {
      return _products[productName];
    }
    
    public Dictionary<ProductName, ProductData> GetAllProducts()
    {
      return _products;
    }
  }
  
  [Flags]
  public enum ProductName
  {
    None = 0,
    Apple = 1 << 0, 
    Orange = 1 << 1, 
    Lemon = 1 << 2
  }
}