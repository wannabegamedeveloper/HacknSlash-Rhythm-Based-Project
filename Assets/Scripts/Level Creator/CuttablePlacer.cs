using UnityEngine;

public class CuttablePlacer : MonoBehaviour
{
    [SerializeField] private GameObject cuttable;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var offset = new Vector3(Random.Range(0f, 2f), 0f, 0f);

            if (Random.Range(0, 2) == 0)
                offset *= -1;
            
            Instantiate(cuttable, transform.position + offset, Quaternion.identity);
        }
    }
}
