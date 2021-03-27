using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controller : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 15f;
    public float speed = 10f;
    float xInput;

    private bool isStarted = false;
    
    public Text startText;
    public Text timerText;
    public float startTime;
    public int min;
    public int sec;
    public static int time;
    public bool submitted = false;

    public Controller movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Submit()
    {
        submitted = true;
	}
    // Update is called once per frame
    void Update()
    {
        if(submitted == true)
        {
            if(Input.GetMouseButtonDown(0) && isStarted == false)
            {
                isStarted = true; 
                startText.gameObject.SetActive(false);
                startTime = Time.time;
		    }
        }
        if(isStarted == true)
        {
            xInput = Input.GetAxis("Horizontal");
            rb.AddForce(xInput * speed, 0, 0);

            float t = Time.time - startTime;

            string minutes = ((int) t / 60).ToString();
            string seconds = ((int) t % 60).ToString();

            timerText.text = minutes + ":" + seconds;

            int min = Int32.Parse(minutes);
            int sec = Int32.Parse(seconds);

            time = min * 60 + sec;
        }
    }

    void FixedUpdate()
    {
        if(isStarted ==true)
        {
            rb.velocity = Vector3.forward * forwardForce;
        }

        if(rb.position.y < -0.5f)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            Leaderboard();
		}
    }
    
    void OnCollisionEnter (Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            Leaderboard();
		}
    }

    public void Leaderboard()
    {
        PlayFabManager.SendLeaderboard(time);
	}
}

