using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isHidden;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            state = State.Normal;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) { 
  
        if(other.gameObject.layer == 7)
        {
            Debug.Log("collided");
        }
    }
}
