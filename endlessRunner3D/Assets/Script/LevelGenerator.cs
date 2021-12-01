using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject level1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(level1, transform.position, Quaternion.identity);
        }
    }
}
