using UnityEngine;

public class CuttablePlacer : MonoBehaviour
{
    [SerializeField] private GameObject cuttable;
    [SerializeField] private Vector2 fieldRange;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //
        {
            var offset = new Vector3(Random.Range(fieldRange.x, fieldRange.y), 0f, 0f);
            
            Instantiate(cuttable, transform.position + offset, Quaternion.identity);
        }
    }
}
