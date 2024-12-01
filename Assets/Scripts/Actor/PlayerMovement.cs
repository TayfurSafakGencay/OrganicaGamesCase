using UnityEngine;

namespace Actor
{
  public class PlayerMovement : MonoBehaviour
  {
    [Header("Movement Settings")]
    public float moveSpeed = 5f;    

    [Header("Camera Settings")]
    public Transform playerCamera;  
    public float lookSensitivity = 2f;   
    public float maxLookAngle = 80f;     

    private CharacterController controller;
    private float cameraPitch;

    private void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
      HandleMovement();
      HandleMouseLook();
    }

    private void HandleMovement()
    {
      float moveX = Input.GetAxis("Horizontal"); 
      float moveZ = Input.GetAxis("Vertical");  

      Vector3 move = transform.right * moveX + transform.forward * moveZ;

      controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
      float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
      float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

      cameraPitch -= mouseY;
      cameraPitch = Mathf.Clamp(cameraPitch, -maxLookAngle, maxLookAngle);

      playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
      transform.Rotate(Vector3.up * mouseX);
    }
  }
}