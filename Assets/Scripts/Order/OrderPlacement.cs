using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Order
{
  public class OrderPlacement : MonoBehaviour
  {
    [SerializeField]
    private List<Transform> _orderPlaces;
    
    private Dictionary<Transform, bool> _orderPlacesChecker = new();

    private void Awake()
    {
      foreach (Transform orderPlace in _orderPlaces)
      {
        _orderPlacesChecker.Add(orderPlace, false);
      }
    }
    
    public Transform GetEmptyOrderPlace()
    {
      foreach (KeyValuePair<Transform, bool> orderPlace in _orderPlacesChecker.Where(orderPlace => !orderPlace.Value))
      {
        return orderPlace.Key;
      }

      return null;
    }

    public void PlaceOrder(GameObject orderObject, Transform orderPlace)
    {
      orderObject.transform.position = orderPlace.position;
      orderObject.transform.rotation = orderPlace.rotation;
      orderObject.transform.SetParent(orderPlace);
      
      _orderPlacesChecker[orderPlace] = true;
    }
    
    public void RemoveOrder(Transform orderPlace)
    {
      _orderPlacesChecker[orderPlace] = false;
    }
  }
}