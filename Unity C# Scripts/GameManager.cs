using System.Collections;
using UnityEngine;
using TMPro;

//Set the default player score
//Run a Coroutine based GameLoop() method
//Create an instance of the target prefab
//Handle the destruction of the prefab

public class GameManager : MonoBehaviour
{

    //Properties
    private int playerScore;
    private bool targetPresent = false;

    public GameObject targetPrefab;
    public TextMeshProUGUI scoreCount;

    //Set the default playerScore to 0
    //update the score UI
    //Start the GameLoop coroutine 
    void Start()
    {
        playerScore = 0;
        UpdateScoreUI();
        StartCoroutine(GameLoop());        
    }

    //Until the player wins the game continue to respawn targets 
    IEnumerator GameLoop()
    {
        while(playerScore < 5)
        {
            if (!targetPresent)
            {
                yield return new WaitForSeconds(2.0f);
                CreateTarget();
            }
            yield return null;
        }
    }

    //Instantiate a targetPrafab object at position (0, 2, 5)
    //Set targetPresent to true
    public void CreateTarget()
    {
        Instantiate(targetPrefab, new Vector3(0, 2, 5), Quaternion.identity);
        targetPresent = true;
    }

    //Destroy the passed in GameObject
    //Play a sound to indicate destruction
    //Increase playerScore and update the score UI
    //Set targetPresent to false
    public void HandleDestruction(GameObject t)
    {
        t.transform.GetComponent<AudioSource>().Play();
        GameObject.Destroy(t.transform.parent.gameObject);
        playerScore++;
        UpdateScoreUI();
        targetPresent = false;
    }

    //Maintainance Function: Update the score
    void UpdateScoreUI()
    {
        scoreCount.text = playerScore.ToString();
    }
}
