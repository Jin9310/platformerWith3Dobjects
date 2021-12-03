using UnityEngine;

public class DestructionScript : MonoBehaviour
{

    private float fallTimer = 2f;

    private bool startFall = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (startFall == true)
        {
            fallTimer -= Time.deltaTime;
            if(fallTimer <= 0)
            {
                rb.useGravity = true;
                rb.freezeRotation = false;
            }
            /*
            destroyTimer -= Time.deltaTime;
            if(destroyTimer <= 0)
            {
                Destroy(gameObject);
            }*/
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("stomp");
            startFall = true;
        }
    }
}
