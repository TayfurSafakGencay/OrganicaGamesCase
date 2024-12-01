using Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Actor
{
  public class PlayerAction : MonoBehaviour
  {
    private Player _player;
    
    [SerializeField]
    private Camera _mainCamera;
    
    [SerializeField]
    private LayerMask _ignoreLayer;
    
    public Key ActionKey = Key.E;

    private void Awake()
    {
      _player = GetComponent<Player>();
    }

    private void Update()
    {
      if (Keyboard.current[ActionKey].wasPressedThisFrame)
      {
        Vector3 screenCenter = new(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _mainCamera.ScreenPointToRay(screenCenter);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 5f, ~_ignoreLayer))
        {
          print(hitInfo.collider.gameObject.name);
          if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
          {
            interactable.Interact(_player);
            // _player.GetPlayerProductControl().GetProductPackageToHand();
          }
        }
      }
    }
  }
}