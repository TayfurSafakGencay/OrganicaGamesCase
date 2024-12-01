using UnityEngine;

namespace Managers
{
  public class OrderManager : MonoBehaviour
  { 
    public static OrderManager Instance { get; private set; }
    
    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }

    public void OrderProduct(ProductName productName)
    {
      // TODO: Urunun fiyatini bul ve oyuncuda o kadar para var mi kontrol et?
    }
  }
}