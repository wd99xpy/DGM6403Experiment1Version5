using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Invoke("GoBall", 0);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, 0));
        } else {
            rb2d.AddForce(new Vector2(-20, 0));
        }
    }
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame(){
        ResetBall();
        //Invoke("GoBall", 0);
    } 
    // void CloneBall(){//https://docs.unity3d.com/cn/2018.4/ScriptReference/Object.Instantiate.html
    //     // Instantiate the projectile at the position and rotation of this transform
    //     Rigidbody2D clone;
    //     float rand = Random.Range(-5, 5);
    //     clone = Instantiate(rb2d, new Vector2(rand,2), transform.rotation);
    // }
    public static void DestoryBall(Object obj){
        UnityEngine.Object.Destroy(obj); //https://docs.unity3d.com/cn/2018.4/ScriptReference/Object.Destroy.html
    }
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = (rb2d.velocity.x / 2) + (coll.collider.attachedRigidbody.velocity.x / 3);
            vel.y = rb2d.velocity.y+1;
            rb2d.velocity = vel;
        }
    }
}
