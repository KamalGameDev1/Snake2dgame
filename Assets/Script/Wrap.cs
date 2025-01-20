using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{  
    //  public SnakeGrow snakeGrow;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.GetComponent<FoodController>())
        // {
        //     snakeGrow.Grow();
        // }
        if (other.tag == "Right")
        {
            this.transform.position = new Vector3(-(this.transform.position.x - 1), this.transform.position.y, 0.0f);
        }
        else if (other.tag == "Up")
        {
            this.transform.position = new Vector3(this.transform.position.x, -(this.transform.position.y - 1), 0.0f);
        }
        else if (other.tag == "Down")
        {
            this.transform.position = new Vector3(this.transform.position.x, -(this.transform.position.y + 1), 0.0f);
        }
        else if (other.tag == "Left")
        {
            this.transform.position = new Vector3(-(this.transform.position.x + 1), this.transform.position.y, 0.0f);
        }
        // else if (other.tag == "Shield")
        // {
        //     StartCoroutine(Shieldon());
        //     Debug.Log("Shield called!");
        // }
        // else if (other.tag == "Multiplier")
        // {
        //     StartCoroutine(Score());
        //     Debug.Log("Shield called!");
        // }
        // else if (other.gameObject.GetComponent<Poison>())
        // {
        //     SnakePoison();
        // }
        // else if (other.tag == "obstacle")
        // {
        //     if (!isShielded)
        //     {
        //         ResetState();
        //         Time.timeScale = 0;
        //         GameOver.SetActive(true);
        //     }
               
    }
}
