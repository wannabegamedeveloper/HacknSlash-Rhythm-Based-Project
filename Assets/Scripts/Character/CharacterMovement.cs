using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private Transform bodyTiltPivot;
    [SerializeField] private Transform bodyTiltPivotFollower;
    [SerializeField] private float tiltAmount;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private AudioSource music;
    [SerializeField] private PlayerInput playerInput;
    
    private Vector3 _initTiltRotation;
    private Vector3 _playerCameraInitDistance;
    private Vector3 _movement;
    private bool _startMusic;

    private int _horizontalDirection;
    
    private void Start()
    {
        playerInput.actions["Move"].performed += Movement;
        playerInput.actions["Move"].canceled += StopMoving;
        _initTiltRotation = bodyTiltPivot.eulerAngles;
        _playerCameraInitDistance = playerCamera.position - transform.position;
    }

    private void StopMoving(InputAction.CallbackContext obj)
    {
        bodyTiltPivot.eulerAngles = _initTiltRotation;
        _horizontalDirection = 0;
    }

    private void Movement(InputAction.CallbackContext obj)
    {
        var x = _movement.x = obj.ReadValue<Vector2>().x;

        var eulerAngles = _initTiltRotation;
        var rot = eulerAngles;
        rot.y += x * tiltAmount;
        eulerAngles = rot;
        bodyTiltPivot.eulerAngles = eulerAngles;

        _horizontalDirection = (int) x;
    }

    private void Update()
    {
        if (!CheckCanStartMusic()) return;
        
        if (Input.GetKeyDown(KeyCode.R)) //
            SceneManager.LoadScene(0); //
        
        _movement = new Vector3(horizontalSpeed * _horizontalDirection * Time.deltaTime, 
            0f, forwardSpeed * Time.deltaTime);
        transform.Translate(_movement);

        bodyTiltPivotFollower.eulerAngles =
            Vector3.Lerp(bodyTiltPivotFollower.eulerAngles, bodyTiltPivot.eulerAngles, 5f * Time.deltaTime);
        
        FollowCamera();
    }

    private void FollowCamera()
    {
        var playerCameraPos = playerCamera.position;
        playerCameraPos.z = transform.position.z + _playerCameraInitDistance.z;
        playerCamera.position = playerCameraPos;
    }

    private bool CheckCanStartMusic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_startMusic) return true;
            music.Play();
            _startMusic = true;
        }

        return _startMusic;
    }
}
