using System;
using UnityEngine;

namespace Managers
{
  public class PlayerManager : MonoBehaviour
  {
    public static PlayerManager Instance { get; private set; }
    
    private float _money { get; set; }

    public Action OnPlayerMoneyChanged;

    private void Awake()
    {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
    }
    
    public void AddMoney(float money)
    {
      _money += money;
      OnPlayerMoneyChanged?.Invoke();
    }
    
    public void RemoveMoney(float money)
    {
      _money -= money;
      OnPlayerMoneyChanged?.Invoke();
    }

    public float GetPlayerMoney()
    {
      return _money;
    }
    
    public bool CheckEnoughMoney(float money)
    {
      return !(_money < money);
    }
  }
}