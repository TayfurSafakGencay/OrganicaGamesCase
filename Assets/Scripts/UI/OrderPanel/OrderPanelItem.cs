using Managers;
using Product;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.OrderPanel
{
  public class OrderPanelItem : MonoBehaviour
  {
    [SerializeField]
    private Image _productImage;
    
    [SerializeField]
    private TextMeshProUGUI _productNameText;
    
    [SerializeField]
    private TextMeshProUGUI _productPriceText;
    
    [SerializeField]
    private Button _orderButton;

    private ProductName _productName;

    private void Awake()
    {
      PlayerManager.Instance.OnPlayerMoneyChanged += CheckEnoughMoney;
    }

    public void SetProductData(ProductData productData)
    {
      _productName = productData.Name;
      
      _productImage.sprite = productData.Image.sprite;
      _productImage.color = productData.Image.color; 
      _productNameText.text = productData.Name.ToString();
      _productPriceText.text = productData.OrderPrice.ToString("f2") + "$";
      
      CheckEnoughMoney();
    }
    
    private void CheckEnoughMoney()
    {
      float playerMoney = PlayerManager.Instance.GetPlayerMoney();
      float productPrice = ProductManager.Instance.GetSpecificProduct(_productName).Price;
      
      _productPriceText.color = playerMoney < productPrice ? Color.red : Color.white;
      _orderButton.interactable = playerMoney >= productPrice;
    }
    
    public void OrderProduct()
    {
      OrderManager.Instance.OrderProduct(_productName);
    }
  }
}