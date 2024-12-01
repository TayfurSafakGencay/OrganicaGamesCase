using System.Collections.Generic;
using Actor;
using Interface;
using Managers;
using UnityEngine;

namespace Interactables
{
  public class ProductPackage : MonoBehaviour, IInteractable
  {
    [SerializeField]
    private Transform _productContainer;
    
    private const string _interactableLayerName = "Interactable";

    private const string _nonInteractableLayerName = "NonInteractable";
    
    [SerializeField]
    private List<Transform> _productPlaces;
    
    private List<Vector3> _productPlacesPositions = new();
    
    private void Awake()
    {
      ChangeLayerOfChildren(_nonInteractableLayerName);
      SetThePositionsOfProductPlaces();
    }

    public void Interact(Player player)
    {
      if (player.GetPlayerProductControl().IsHandFull()) return;
      
      ChangeLayerOfChildren(_interactableLayerName);

      player.GetPlayerProductControl().GetProductPackageToHand(this);

      if (_productContainer.childCount == 0)
      {
        Destroy(gameObject);
      }
    }

    private void ChangeLayerOfChildren(string layerName)
    {
      int newLayer = LayerMask.NameToLayer(layerName);

      foreach (Transform child in _productContainer)
      {
        child.gameObject.layer = newLayer;
      }
    }

    public void GetProductToPackageAgain(Product product)
    {
      int index = product.transform.GetSiblingIndex();

      product.gameObject.transform.SetParent(_productContainer);
      product.gameObject.transform.localPosition = _productPlacesPositions[index];
      product.gameObject.transform.rotation = _productContainer.rotation;
      product.gameObject.transform.localScale = product.InitialScale;
      
      InventoryManager.Instance.RemoveProduct(product.GetProductData().Name, 1);
    }
    
    private void SetThePositionsOfProductPlaces()
    {
      foreach (Transform productPlace in _productPlaces)
      {
        _productPlacesPositions.Add(productPlace.localPosition);
      }
    }
    
    public Product GetProduct()
    {
      return _productContainer.GetChild(0).gameObject.GetComponent<Product>();
    }
    
    public int GetProductCount() => _productContainer.childCount;
  }
}