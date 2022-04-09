using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public GameObject rabbit;
    //private Collider2D rcollider;
    private RabbitMovement rm;
    // Start is called before the first frame update
    private void Awake()
    {
        rm = GetComponent<RabbitMovement>();
        //rcollider = rabbit.GetComponent<Collider2D>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerStay2D(Collider2D rcollider)
    {
        Debug.Log("colliding");
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("hiding rabbit");
            rm.HideRabbit();
        }
            
    }*/
}
