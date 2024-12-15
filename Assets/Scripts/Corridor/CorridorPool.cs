using UnityEngine;

public class CorridorPool : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.Translate(0f, 0f, 150f);
        }
    }
}
