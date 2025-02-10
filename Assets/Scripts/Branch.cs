using UnityEngine;
using UnityEngine.SceneManagement;

public class Branch : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < bottomY){

            Destroy(this.gameObject);

        }

    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Basket")){
            GameOver();

        }

    }

    void GameOver(){

         SceneManager.LoadScene("GameOver");

    }
}
