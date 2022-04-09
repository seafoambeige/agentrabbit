using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isHidden;
    bool isPressed;
    private float time;
    private State state;
    private enum State
    {
        Normal,
        Hiding,
    }
    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        rb = GetComponent<Rigidbody2D>();
        //isHidden = false;
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Normal:
                //GetComponent<Renderer>().enabled = true;
                break;
            case State.Hiding:
                //GetComponent<Renderer>().enabled = false;
                break;

        }
        //move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3f, 0, 0);

        //move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3f, 0, 0);

        //jump
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(new Vector2(0, 3f));

        //hide
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(state == State.Hiding)
            {
                HideRabbit();
            }
        }
        /*if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            HideRabbit();
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {
            time = 0f;
        }*/






    }
    void HideRabbit() {  
        if (!isHidden)
        {
            GetComponent<Renderer>().enabled = false;
            isHidden = true;
        }
        else {
            GetComponent<Renderer>().enabled = true;
            isHidden = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            state = State.Hiding;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("collision happening");
            Debug.Log("colliding hide");
                if (isPressed)
                {
                    Debug.Log("hiding rabbit");
                   // HideRabbit();
                }
        }
        if (other.gameObject.layer == 7)
        {
            Debug.Log("collision happening");
            Debug.Log("colliding break");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            state = State.Normal;
        }
    }
}
