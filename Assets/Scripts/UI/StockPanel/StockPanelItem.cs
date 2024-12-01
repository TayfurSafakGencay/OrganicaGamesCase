using Product;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StockPanel
{
  public class StockPanelItem : MonoBehaviour
  {
    [SerializeField]
    private Image _productImage;
    
    [SerializeField]
    private TextMeshProUGUI _stockCountText;
    
    [SerializeField]
    private TextMeshProUGUI _productNameText;

    public void SetProductData(ProductData productData, int stockCount)
    {
      _productImage.sprite = productData.Image.sprite;
      _productImage.color = productData.Image.color;
      _stockCountText.text = stockCount.ToString();
      _productNameText.text = productData.Name.ToString();
    }
  }
}