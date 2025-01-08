using UnityEngine;

public class CorridorPool : MonoBehaviour
{
    [SerializeField] private float offset = 150f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.Translate(0f, 0f, offset);
        }
    }
}
