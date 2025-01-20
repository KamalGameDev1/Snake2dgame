using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private void Start(){
        RandomizePosition();
    }
    private void RandomizePosition(){
        Bounds bounds=this.gridArea.bounds;
        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y,bounds.max.y);
        this.transform.position=new Vector3(Mathf.Round(x),Mathf.Round(y),0f);
    }
    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<SnakeController>()!=null){
          RandomizePosition();
        }
        
    }
}
