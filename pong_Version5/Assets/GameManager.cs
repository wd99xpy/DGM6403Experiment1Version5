using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public GUISkin layout;
    public GameObject theBall;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void Score (string wallID) {
        if (wallID == "BottomWall")
        {
            PlayerScore1++;
        } 
    }
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Instantiate(theBall, new Vector2(0,0), transform.rotation);
            //Instantiate(theBall, new Vector2(0,0), transform.rotation);
            //theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (GameObject.FindGameObjectsWithTag("Ball").Length==0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150 + 25, 200, 2000, 1000), "YOU LOSE!");
            //theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } 
    }
}
