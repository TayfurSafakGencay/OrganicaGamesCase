using System;
using Actor;
using Interface;
using Product;
using UnityEngine;

namespace Interactables
{
  public class Product : MonoBehaviour, IInteractable
  {
    [SerializeField]
    private ProductData _productData;
    
    public ProductData GetProductData() => _productData;

    [HideInInspector]
    public Vector3 InitialScale;
    
    private void Awake()
    {
      InitialScale = transform.localScale;
    }

    public void Interact(Player player)
    {
      if (!player.GetPlayerProductControl().IsHandFull()) return;

      Product product = player.GetPlayerProductControl().GetProduct();
      if (product == null) return;

      if (product.GetProductData().Name == _productData.Name)
      {
        player.GetPlayerProductControl().GetProductPackage().GetProductToPackageAgain(this);
      }
    } 
  }
}