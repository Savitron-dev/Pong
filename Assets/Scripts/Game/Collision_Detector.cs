using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Collision_Detector : MonoBehaviour
{
    public Transform tr; //Calls Ball transform
    public Transform tr1; // Calls Player_Paddle transform
    public Transform tr2; //Calls AI_Paddle transform
    public Rigidbody2D rb; // GameObject "Ball" RigidBody
    public Score_Manager manager; //Calls Score Manager Script
    public Ball_Input ball; //Calls Score Manager Script
    public bool isPlayerScored; //To Check who Scored
    public GameObject cts; //Calls the Click_To_Start Button
    public GameObject bg; //Calls the BG
    public GameObject pause; //Calls the Pause Button
    public TrailRenderer ballTrail; //Calls the Ball Trail
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name); //Detects the Collision

        //This Condition is for Managing the Scores
        if (collision.CompareTag("Ball")) // Detects the Collision from the GameObject of Tag "Ball"(Not the Name - Ball)
        {
            if (isPlayerScored)
            {
                manager.PlayerScore();
            }
            else
            {
                manager.AIScore();
            }


            //Resetting the Ball to Original Position
            tr.position = new Vector2(0, 0);
            rb.linearVelocity = Vector2.zero;
            if (ballTrail != null) 
            {
                //Clear the Ball Trail
                ballTrail.Clear();
            }

            //Resetting Paddle to their Respective Position
            tr1.position = new Vector2(-7.88889f, 0);
            tr2.position = new Vector2(7.88889f, 0);

            Time.timeScale = 0f;

            //Making the Click_To_Start Active
            cts.SetActive(true);
            bg.SetActive(true);
            pause.SetActive(false);

            //It prevents Click_To_Start to br Active with Restart
            if (manager.gameover == true)
            {
                cts.SetActive(false);
                manager.gameover = false;
            }
        } 
    }        
}
