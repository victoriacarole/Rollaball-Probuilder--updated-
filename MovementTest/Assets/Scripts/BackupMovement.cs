using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool onGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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
}
