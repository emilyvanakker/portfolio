using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Determine the number of hit points and assign it to the HitsRemaining TMP object
//As a hit is detected, play a sound and reduce the hit points remaining

public class TargetHandler : MonoBehaviour
{

    //Properties
    public TextMeshProUGUI hitsRemaining;
    private int hitPts = 5;

    //Determine the object's hit points as a random number between 4 and 10
    //Call the UpdateHitsRemainingUI method
    void Start()
    {
        hitPts = Random.Range(4, 10);
        UpdateHitRemainingUI();
    }

    //Reduce the hitPts by 1
    //Call UpdateHitsRemainingUI
    //Play the AudioSource for a hit
    //If hitPts are equal to 0, find the GameManager object and call the HandleDestruction method with the instantiated game object
    public void Damage()
    {
        hitPts--;
        UpdateHitRemainingUI();
        GameManager s = GameObject.Find("GameManager").GetComponent<GameManager>();
        s.transform.GetComponent<AudioSource>().Play();
        if (hitPts == 0) {
            s.HandleDestruction(gameObject);
        }
    }

    //Set the text of hitsRemaining to hitPts
    void UpdateHitRemainingUI()
    {
        hitsRemaining.text = hitPts.ToString();
    }
}
