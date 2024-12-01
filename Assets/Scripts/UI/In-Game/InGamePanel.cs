using UnityEngine;

namespace UI.In_Game
{
  public class InGamePanel : MonoBehaviour
  {
    [SerializeField]
    private GameObject _orderPanel;
    
    public void OpenOrderPanel()
    {
      _orderPanel.SetActive(true);
    }
  }
}