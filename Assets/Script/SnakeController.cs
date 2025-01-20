using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;

    public float runSpeed = 5f;
       
    void Start()
    {
        body = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
        
        if(horizontal>0){
            body.velocity=new Vector2(runSpeed,0f);
            transform.eulerAngles = Vector3.forward *-90;
        }
        else if(horizontal<0){
            body.velocity=new Vector2(-runSpeed,0f);
            transform.eulerAngles = Vector3.forward *90;
        }
        else if(vertical>0){
            body.velocity=new Vector2(0f,runSpeed);
            transform.eulerAngles = Vector3.forward *0;
        }
        else if(vertical<0){
            body.velocity=new Vector2(0f,-runSpeed);
            transform.eulerAngles = Vector3.forward *180;
        }
    }
    
}
