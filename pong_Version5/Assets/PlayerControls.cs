using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    public float boundY = 5f;
    private Rigidbody2D rb2d;
    public GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveRight)) {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {
            vel.x = -speed;
        }
        else {
            vel.x = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.x > boundY) {
            pos.x = boundY;
        }
        else if (pos.x < -boundY) {
            pos.x = -boundY;
        }
        transform.position = pos;
        
    }

    void creatBall(){
        GameObject clone;
        float rand = Random.Range(-5, 5);
        clone = Instantiate(theBall, new Vector2(rand,2), transform.rotation);//create a new object from: https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
    }
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Ball")){
            creatBall();
        }
    }
}
