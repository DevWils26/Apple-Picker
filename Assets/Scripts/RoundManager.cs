using UnityEngine;
using UnityEngine.UI; // To display round number on UI
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour
{
    public Text roundText;  // UI text to show current round
    public float roundDuration = 30f;  // Time in seconds for each round
    private float timeRemaining;  // Time left in current round

    private int currentRound = 1;  // The current round number

    void Start(){
        
        timeRemaining = roundDuration;
        UpdateRoundText();  // Update UI to show starting round
    }

    void Update(){

        timeRemaining -= Time.deltaTime;  // Decrease time remaining in the round

        if (timeRemaining <= 0){

            // Round ended, increase round and reset the timer
            EndRound();
        }

        // Update the round timer UI (if needed)
        // Example: Display the time remaining for the current round
        // roundText.text = "Time Left: " + Mathf.Ceil(timeRemaining).ToString();
    }

    void EndRound(){

        currentRound++;  // Increase round number
        if (currentRound > 4){

            SceneManager.LoadScene("GameOver");
        }
        else{

            timeRemaining = roundDuration;  // Reset round timer
            UpdateRoundText();
        }
    }

    void UpdateRoundText(){

        roundText.text = "Round: " + currentRound.ToString();  // Update UI text
    }
}
