using UnityEngine;

namespace Actor
{
  public class Player : MonoBehaviour
  {
    private PlayerMovement _playerMovement;

    private PlayerEconomy _playerEconomy;

    private PlayerAction _playerAction;

    private PlayerProductControl _playerProductControl;

    private void Awake()
    {
      _playerMovement = GetComponent<PlayerMovement>();
      _playerEconomy = GetComponent<PlayerEconomy>();
      _playerAction = GetComponent<PlayerAction>();
      _playerProductControl = GetComponent<PlayerProductControl>();
    }

    #region Getter & Setter

    public PlayerMovement GetPlayerMovement()
    {
      return _playerMovement;
    }

    public PlayerEconomy GetPlayerEconomy()
    {
      return _playerEconomy;
    }
    
    public PlayerAction GetPlayerAction()
    {
      return _playerAction;
    }
    
    public PlayerProductControl GetPlayerProductControl()
    {
      return _playerProductControl;
    }

    #endregion
  }
}