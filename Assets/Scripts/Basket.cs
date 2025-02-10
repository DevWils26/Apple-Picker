using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // test line
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the ScoreCounter (Script) component of ScoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current scren postion of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCamera in the Inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePad3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x positon of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePad3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){

        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")){

            Destroy(collidedWith);
            // Increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        }
        else if (collidedWith.CompareTag("Branch")){

            SceneManager.LoadScene("GameOver");

        }

    }
}
