using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;

    private float gravity = -50f;
    private CharacterController cC;
    private Animator anim;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;

    public static int totalCoins;


    public GameObject level1;

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        cC = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = 1;

        //transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        isGrounded = false;

        foreach(var groundCheck in groundChecks)
        { 
            if(Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {

            velocity.y += gravity * Time.deltaTime;
        }

        var blocked = false;
        foreach(var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }

        if (!blocked)
        {
            cC.Move(new Vector3(horizontalInput * speed, 0, 0) * Time.deltaTime);
        }

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jump * -2 * gravity);
        }

        cC.Move(velocity * Time.deltaTime);

        anim.SetFloat("Speed", horizontalInput);

        anim.SetBool("IsGrounded", isGrounded);

        anim.SetFloat("VerticalSpeed", velocity.y);
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

        if (other.CompareTag("Generator"))
        {
            Instantiate(level1, new Vector3(transform.position.x + 18, transform.position.y - 1.2f, transform.position.z), Quaternion.identity);
        }
    }

}
