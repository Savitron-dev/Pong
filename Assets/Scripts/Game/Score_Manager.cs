using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//This Script is Used to Manage the Score in a Seperate Script for UI Interface and Beter Data Handling

public class Score_Manager : MonoBehaviour
{
    private int PlayerScored = 0; //Value of Player Score
    private int AIScored = 0; //Value of AI Score
    public bool gameover = false; //For Detecting the End of Game
    public TMP_Text PlayerText; //Displays Player Score
    public TMP_Text AIText; //Displays AI Score
    public TMP_Text Win; //For Winner Annoucemnet
    public GameObject restart; //Calls Restart Button
    public GameObject cts; //Calls Click_To_Start Button
    public GameObject pause; //Calls Pause Button
    public Ball_Input ball; //Calls Ball GameObject Script
    public GameObject bg; //Calls the BG
    public AudioSource click; //For Audio Clip "Click"
    public Transform tr; //Calls Ball transform
    public Transform tr1; // Calls Player_Paddle transform
    public Transform tr2; //Calls AI_Paddle transform
    public Rigidbody2D rb; // GameObject "Ball" RigidBody

    private void Start()
    {
        click.mute = Audio_Manager.instance.isMuted;
    }
    public int GetPlayerScore() 
    {
        return PlayerScored;
    }
    public int GetAIScore() 
    {
        return AIScored;
    }
    public void SetPlayerScore(int value) 
    {
        PlayerScored = value;
    }
    public void SetAIScore(int value) 
    {
        AIScored = value;
    }
    public void PlayerScore() 
    {
        PlayerScored++;
        PlayerText.text = PlayerScored.ToString();
        // It displays Winner Message and Restart UI becomes Active
        if (PlayerScored >= 5)
        {
            Win.text = "PLAYER 1 WIN!!!";
            UI_Interface();
            gameover = true;
        }
    }
    public void AIScore() 
    {
        AIScored++;
        AIText.text = AIScored.ToString();
        // It displays Winner Message and Restart UI becomes Active
        if (AIScored >= 5)
        {
            Win.text = "PLAYER 2 WIN!!!";
            UI_Interface();           
            gameover = true;
        }
    }
    public void UI_Interface()
    {
        Win.gameObject.SetActive(true); //Displays Winner Message        
        restart.SetActive(true); //For Displaying the Restart Button
        cts.SetActive(false); //For Disabling the Click_To_Start Button
        bg.SetActive(true); //For Displaying the Background for Buttons
    }
    public void CTS() // For Click_to_Start Button
    {
        Time.timeScale = 1f;
        ball.RestartBall();
        pause.SetActive(true);
    }
    public void Restart() // For Restart Button
    {
        ball.RestartBall();
        //Resetting the Ball to Original Position
        tr.position = new Vector2(0, 0);
        rb.linearVelocity = Vector2.zero;

        //Resetting Paddle to their Respective Position
        tr1.position = new Vector2(-7.88889f, 0);
        tr2.position = new Vector2(7.88889f, 0);

        Win.gameObject.SetActive(false);
        SetPlayerScore(0);
        PlayerText.text = PlayerScored.ToString();
        SetAIScore(0);
        AIText.text = AIScored.ToString();
        cts.SetActive(true); //For Disabling the Click_To_Start Button
        bg.SetActive(true); //For Displaying the Background for Buttons
    }

}
