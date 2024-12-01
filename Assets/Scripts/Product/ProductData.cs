using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Product
{
  [CreateAssetMenu(fileName = "Product", menuName = "Tools/Product/Create Product", order = 0)]
  public class ProductData : ScriptableObject
  {
    public ProductName Name;
    
    public Image Image;
    
    public float DefaultPrice;

    public float Price = 0;

    public float OrderPrice;
    
    private const int _packageUnitCount = 16;

    public void SetPriceAsDefault()
    {
      if (Price == 0)
      {
        Price = DefaultPrice;
      }

      if (OrderPrice == 0)
      {
        OrderPrice = Price * _packageUnitCount / 2;
      }
    }

    public float Order()
    {
      return OrderPrice;
    }
    
    public void SetPrice(float price)
    {
      Price = price;
    }
  }
}