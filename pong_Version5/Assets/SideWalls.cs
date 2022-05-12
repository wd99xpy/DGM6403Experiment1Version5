using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name.Substring(0,4) == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            BallControl.DestoryBall(hitInfo.gameObject);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
