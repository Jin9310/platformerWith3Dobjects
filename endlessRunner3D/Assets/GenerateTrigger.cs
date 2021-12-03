using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrigger : MonoBehaviour
{
    [SerializeField] private float xGenerateLevel;
    [SerializeField] private float yGenerateLevel;
    [SerializeField] private float zGenerateLevel;

    public GameObject []levelCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var rand = Random.Range(0, levelCollection.Length);

            Instantiate(levelCollection[rand], new Vector3(transform.position.x + xGenerateLevel, transform.position.y + yGenerateLevel, transform.position.z + zGenerateLevel), Quaternion.identity);
        }
    }
}
