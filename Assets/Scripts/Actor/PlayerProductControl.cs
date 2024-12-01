using Interactables;
using UnityEngine;

namespace Actor
{
  public class PlayerProductControl : MonoBehaviour
  {
    private bool _isHandFull = false;
    
    private ProductPackage _productPackage;

    [SerializeField]
    private Transform _handTransform;
    
    public void GetProductPackageToHand(ProductPackage productPackage)
    {
      if (_isHandFull) return;
      _isHandFull = true;
      
      productPackage.transform.position = _handTransform.position;
      productPackage.transform.rotation = _handTransform.rotation;
      productPackage.transform.SetParent(_handTransform);
      
      _productPackage = productPackage;
    }

    public Interactables.Product GetProduct()
    {
      if (_productPackage == null) return null;
      
      if (_productPackage.GetProductCount() == 0)
      {
        Destroy(_productPackage.gameObject);
        _productPackage = null;
        return null;
      };
      
      Interactables.Product product = _productPackage.GetProduct();
      return product;
    }
    
    public ProductPackage GetProductPackage()
    {
      return _productPackage;
    }
    
    public bool IsHandFull() => _isHandFull;
  }
}