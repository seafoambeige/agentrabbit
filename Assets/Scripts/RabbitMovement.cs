using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isHidden;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isHidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        //move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3f, 0, 0);

        //move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3f, 0, 0);

        //jump
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(new Vector2(0, 3f));

    }
    public void HideRabbit() {
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("collision happening");
            Debug.Log("colliding hide");
                if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("hiding rabbit");
                    HideRabbit();
                }
        }
        if (other.gameObject.layer == 7)
        {
            Debug.Log("collision happening");
            Debug.Log("colliding break");
        }
    }
}
