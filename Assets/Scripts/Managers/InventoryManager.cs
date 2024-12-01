using UnityEngine;

namespace Managers
{
  public class InventoryManager : MonoBehaviour
  {
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }
  }
}