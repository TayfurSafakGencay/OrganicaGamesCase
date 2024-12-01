using System;
using UnityEngine;

namespace Actor
{
  public class PlayerEconomy : MonoBehaviour
  {
    private float _money { get; set; } = 25;

    public Action OnMoneyChanged;
    
    public void AddMoney(float money)
    {
      _money += money;
      
      OnMoneyChanged?.Invoke();
    }
    
    public void RemoveMoney(float money)
    {
      _money -= money;
      
      OnMoneyChanged?.Invoke();
    }

    public float GetMoney()
    {
      return _money;
    }

    public bool CheckEnoughMoney(float price) => _money >= price;
  }
}