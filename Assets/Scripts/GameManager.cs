using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class GameManager : MonoBehaviour {

    private int ByronScore = 0;
    private int SmokeyScore = 0;
    private float ClockTime = 0;
    public float GameDuration = 30f;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowInstructions()
    {
        
    }

    void StartGame()
    {
        ByronScore = 0;
        SmokeyScore = 0;
        ClockTime = GameDuration;
        TimersManager.SetLoopableTimer(this, 1.0f, UpdateClock);
        TimersManager.SetTimer(this, GameDuration, EndGame);
    }

    void UpdateClock()
    {
        ClockTime -= 1;
        Debug.Log("Clock Tick: " + ClockTime);
    }

    void EndGame()
    {
        Debug.Log("End Game");
    }
}
