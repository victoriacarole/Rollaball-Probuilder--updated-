using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // used for movement and jump
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool onGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    // used for text
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    // used for material changed
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // for screentext set count = 0;
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        // get material component for color change
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime * 50, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime * 50, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime * 50, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime * 50, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || MAX_JUMP > currentJump))
        {
            rb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime * 50, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        // if onTrigger object is named PickUp1, change player's color to yellow
        if (other.gameObject.name == "PickUp1")
        {
            rend.sharedMaterial = material[1];
        }
        // if onTrigger object is named PickUp2, change player's color to green
        if (other.gameObject.name == "PickUp2")
        {
            rend.sharedMaterial = material[2];
        }
        // if onTrigger object is named PickUp3, change player's color to pink
        if (other.gameObject.name == "PickUp3")
        {
            rend.sharedMaterial = material[3];
        }
        // if onTrigger object is named PickUp4, change player's color to blue
        if (other.gameObject.name == "PickUp4")
        {
            rend.sharedMaterial = material[4];
        }
        // if onTrigger object is named PickUp5, change player's color to purple
        if (other.gameObject.name == "PickUp5")
        {
            rend.sharedMaterial = material[5];
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
    }
}
