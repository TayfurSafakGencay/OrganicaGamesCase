using System.Collections.Generic;
using Actor;
using Interface;
using Managers;
using UnityEngine;

namespace Interactables
{
  public class Shelf : MonoBehaviour, IInteractable
  {
    [SerializeField]
    private List<Transform> _productPlaces;
    public void Interact(Player player)
    {
      if(!player.GetPlayerProductControl().IsHandFull()) return;

      foreach (Transform productPlace in _productPlaces)
      {
        if (productPlace.childCount == 0)
        {
          Product product = player.GetPlayerProductControl().GetProduct();
          if (product == null) return;
          
          product.transform.position = productPlace.position;
          product.transform.rotation = productPlace.rotation;
          product.transform.SetParent(productPlace);
          
          InventoryManager.Instance.AddProduct(product.GetComponent<Product>().GetProductData().Name, 1);
          break;
        }
      }
    }
  }
}