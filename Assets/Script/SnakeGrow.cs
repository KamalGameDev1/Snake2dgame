using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
   private List<Transform>_bodySegment;
   public Transform bodyPrefab;

   private void Start(){
       _bodySegment=new List<Transform>();
       _bodySegment.Add(this.transform);
   }
   private void FixedUpdate(){
       for(int i=_bodySegment.Count-1;i>0;i--){
           _bodySegment[i].position=_bodySegment[i-1].position;
       }
        
   }
   public void Grow(){
       Transform body=Instantiate(this.bodyPrefab);
       body.position=_bodySegment[_bodySegment.Count-1].position;
       _bodySegment.Add(body);
        
        // if(scoreMultiplier)
        // {
        //     score +=  (multiplier * 1);
        // }
        // else if(!scoreMultiplier)
        // {
        //     score++;
        // }
   }
   
   public void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<FoodController>()!=null){
          Grow();
        }
        
    }
}
