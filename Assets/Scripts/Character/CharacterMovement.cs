using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private Transform bodyTiltPivot;
    [SerializeField] private Transform bodyTiltPivotFollower;
    [SerializeField] private float tiltAmount;
    [SerializeField] private Transform playerCamera;
       
    private Vector3 _initTiltRotation;
    private Vector3 _playerCameraInitDistance;
    
    private void Start()
    {
        _initTiltRotation = bodyTiltPivot.eulerAngles;
        _playerCameraInitDistance = playerCamera.position - transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            SceneManager.LoadScene(0);
        
        var movement = new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);
        transform.Translate(movement);
        
        if (Input.GetKeyDown((KeyCode.A)))
        {
            movement.x = -horizontalSpeed * Time.deltaTime;
            bodyTiltPivot.eulerAngles = _initTiltRotation;
            var rot = bodyTiltPivot.eulerAngles;
            rot.y -= tiltAmount;
            bodyTiltPivot.eulerAngles = rot;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movement.x = horizontalSpeed * Time.deltaTime;
            bodyTiltPivot.eulerAngles = _initTiltRotation;
            var rot = bodyTiltPivot.eulerAngles;
            rot.y += tiltAmount;
            bodyTiltPivot.eulerAngles = rot;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-horizontalSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(horizontalSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            bodyTiltPivot.eulerAngles = _initTiltRotation;
        }

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
}
