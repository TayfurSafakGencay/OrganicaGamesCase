using Actor;
using UnityEngine;

namespace Managers
{
  public class PlayerManager : MonoBehaviour
  {
    public static PlayerManager Instance { get; private set; }

    public Player Player;
    
    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }
  }
}