using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private AudioSource music;

    private bool _startPlacing;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_startPlacing) return;
            _startPlacing = true;
            music.Play();
        }

        if (!_startPlacing) return;
        
        var movement = new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);
        transform.Translate(movement);
    }
}
