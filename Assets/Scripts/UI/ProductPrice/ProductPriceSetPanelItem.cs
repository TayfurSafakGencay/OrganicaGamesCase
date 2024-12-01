using Managers;
using Product;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ProductPrice
{
  public class ProductPriceSetPanelItem : MonoBehaviour
  {
    [SerializeField]
    private Image _productImage;
    
    [SerializeField]
    private TextMeshProUGUI _productNameText;
    
    [SerializeField]
    private TextMeshProUGUI _productPriceText;
    
    [SerializeField]
    private Button _openPriceSetPanelButton;

    [SerializeField]
    private GameObject _priceSetterPanel;
    
    [SerializeField]
    private InputField _priceInputField;
    

    private ProductName _productName;
    public void SetProductData(ProductData productValue)
    {
      _productName = productValue.Name;
      
      _productImage.sprite = productValue.Image.sprite;
      _productImage.color = productValue.Image.color;
      _productNameText.text = productValue.Name.ToString();
      _productPriceText.text = productValue.Price.ToString("f2") + "$";
    }

    public void OpenPriceSetPanel()
    {
      _priceSetterPanel.SetActive(true);
    }
  }
}