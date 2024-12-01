using UnityEngine;

namespace UI.In_Game
{
  public class InGamePanel : MonoBehaviour
  {
    [SerializeField]
    private GameObject _orderPanel;
    
    [SerializeField]
    private GameObject _stockPanel;
    
    public void OpenOrderPanel()
    {
      _orderPanel.SetActive(true);
    }
    
    public void OpenStockPanel()
    {
      _stockPanel.SetActive(true);
    }
  }
}