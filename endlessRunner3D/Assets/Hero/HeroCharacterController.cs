using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private float gravity = -50f;
    private CharacterController cC;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    public static int totalCoins;
    

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        cC = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = 1;

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {

            velocity.y += gravity * Time.deltaTime;
        }

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jump * -2 * gravity);
        }

        cC.Move(new Vector3(horizontalInput * speed, 0, 0) * Time.deltaTime);

        cC.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropZone"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.tag == "Coin")
        {
            totalCoins += 1;
            Debug.Log(totalCoins);
            Destroy(other.gameObject);
        }
    }

}
