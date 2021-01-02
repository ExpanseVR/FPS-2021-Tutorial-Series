using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _mouseSensativity = 50f;
    [SerializeField] private float _minCameraview = -70f, _maxCameraview = 80f;

    private CharacterController _charController;
    private Camera _camera;
    private float xRotation = 0f;
    private Vector3 _playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _camera = Camera.main;

        if (_charController == null)
            Debug.Log("No Character Controller attached to Player");

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        //Get mouse position input
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensativity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensativity * Time.deltaTime;
        //Rotate the camera based on the Y input of the mouse
        xRotation -= mouseY;
        //clamp the camera rotation between 80 and -70 degrees
        xRotation = Mathf.Clamp(xRotation, _minCameraview, _maxCameraview);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Rotate the player based on the X input of the mouse.
        transform.Rotate(Vector3.up * mouseX * 3);
    }

    private void FixedUpdate()
    {
        //Detect if player is grounded
        if (_charController.isGrounded)
        {
            _playerVelocity.y = 0f;
        }
        else
        {
            //If not grounded, apply gravity to our player
            _playerVelocity.y += -9.18f * Time.deltaTime;
            _charController.Move(_playerVelocity * Time.deltaTime);
        }
    }

    private void PlayerMovement()
    {
        //Get WASD input for player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Move player based on WASD input
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        _charController.Move(movement * Time.deltaTime * _speed);
    }


}
