using UnityEngine;

namespace Customer
{
  public class Customer : MonoBehaviour
  {
    private int _randomProductCount;

    private void Awake()
    {
      _randomProductCount = Random.Range(1, 4);
    }

    private void CheckItem()
    {
    }
  }
}