using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private AudioSource music;

    private bool _startPlacing;
    
    private void Update()
    {
        if (!CheckCanStartPlacing()) return;
        
        var movement = new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);
        transform.Translate(movement);
    }

    private bool CheckCanStartPlacing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_startPlacing) return true;
            _startPlacing = true;
            music.Play();
        }

        return _startPlacing;

    }
}
