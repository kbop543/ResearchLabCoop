﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    //public GameObject player1;
    //public GameObject player2;
    public float coolDownTime = 10.0f;
    //public Text P1ShrinkCoolDown;
    //public Text P1FrozenCoolDown;
    //public Text P2ShrinkCoolDown;
    //public Text P2FrozenCoolDown;
    public Text gameState;
    //private bool P1Shrank = false;
    //private bool P1Frozen = false;
    //private bool P2Shrank = false;
    //private bool P2Frozen = false;
    public GameObject gmtest;
    public Text wave;
    public Text waveNum;

    public Image progressBarFill;
    public float enemyKilled;
    public float enemyTotal;

    // Use this for initialization
    void Start()
    {
        GameObject gm = GameObject.FindWithTag("GameManager");
        //player1 = gm.GetComponent<LevelManager>().p1;
        //player2 = gm.GetComponent<LevelManager>().p2;

        //P1ShrinkCoolDown.text = "";
        //P1FrozenCoolDown.text = "";

        //P2ShrinkCoolDown.text = "";
        //P2FrozenCoolDown.text = "";
        gmtest = GameObject.FindWithTag("GameManager");

        gameState.text = "";
        waveNum.text = "Wave 1 of 3";

        enemyKilled = gm.GetComponent<GameConstants>().enemyKillCount;
        enemyTotal = gm.GetComponent<GameConstants>().curWaveSpawnLimit;
        progressBarFill.fillAmount = enemyKilled / enemyTotal;
    }

    private void Update()
    {
        //// Update player statuses
        //P1Shrank = player1.GetComponent<P1Status>().shrank;
        //P1Frozen = player1.GetComponent<P1Status>().frozen;
        //P2Shrank = player2.GetComponent<P2Status>().shrank;
        //P2Frozen = player2.GetComponent<P2Status>().frozen;

        //// If player is affected by any status, update and show a cooldown timer
        //if (P1Shrank)
        //{
        //    UpdateShrinkCoolDown(P1ShrinkCoolDown);
        //}

        //if (P1Frozen)
        //{
        //    UpdateFrozenCoolDown(P1FrozenCoolDown);
        //}

        //if (P2Shrank)
        //{
        //    UpdateShrinkCoolDown(P2ShrinkCoolDown);
        //}

        //if (P2Frozen)
        //{
        //    UpdateFrozenCoolDown(P2FrozenCoolDown);
        //}

        // Update enemy kill count and spawn limit of current wave
        enemyKilled = gmtest.GetComponent<GameConstants>().enemyKillCount;
        enemyTotal = gmtest.GetComponent<GameConstants>().curWaveSpawnLimit;
        // Update wave progess bar fill amount using enemyKilled/enemyTotal
        progressBarFill.fillAmount = enemyKilled / enemyTotal;
    }

    private void FixedUpdate()
    {
        if (gmtest.GetComponent<GameConstants>().gameOver)
        {
            gameState.text = "GAME OVER! PRESS Options Button to RESTART GAME!" + System.Environment.NewLine + "PRESS Share to EXIT TO MAIN Menu";

            if (Input.GetKey(KeyCode.JoystickButton9))
            {
                gameState.text = "";
                gmtest.GetComponent<GameConstants>().gameOver = false;
            }
            if ((Input.GetKey("e")) || (Input.GetKey(KeyCode.JoystickButton8)))
            {
                gameState.text = "";
                gmtest.GetComponent<GameConstants>().gameOver = false;
            }

        }
        if ((gmtest.GetComponent<GameConstants>().completeLvl1) && (!gmtest.GetComponent<GameConstants>().gameOver))
        {
            {
                gameState.text = "Level1 Cleared";
                //wave.text = "Wave 2";
                Invoke("dos", 5);
            }
        }
        if ((gmtest.GetComponent<GameConstants>().completeLvl2) && (!gmtest.GetComponent<GameConstants>().gameOver))
        {
            gameState.text = "Level2 Cleared";
            //wave.text = "Wave 3";
            Invoke("dos", 5);
        }
        if (gmtest.GetComponent<GameConstants>().completeLvl3)
        {
            gameState.text = "CONGRATULATIONS! YOU WIN! PRESS options to RESTART GAME." + System.Environment.NewLine + "PRESS Share to EXIT TO MAIN Menu";
            if (Input.GetKey(KeyCode.JoystickButton9))
            {
                gameState.text = "";
                gmtest.GetComponent<GameConstants>().gameOver = false;
            }
            if ((Input.GetKey("e")) || (Input.GetKey(KeyCode.JoystickButton8)))
            {
                gameState.text = "";
                gmtest.GetComponent<GameConstants>().gameOver = false;
            }
        }

    }

    public void UpdateShrinkCoolDown(Text coolDownText)
    {
        coolDownTime -= Time.deltaTime;
        coolDownText.text = "Shrink effect: " + (coolDownTime).ToString("0");

        if (coolDownTime < 0)
        {
            coolDownText.text = "";
            coolDownTime = 10.0f;
        }
    }

    public void UpdateFrozenCoolDown(Text coolDownText)
    {
        coolDownTime -= Time.deltaTime;
        coolDownText.text = "Frozen effect: " + (coolDownTime).ToString("0");

        if (coolDownTime <= 0)
        {
            coolDownText.text = "";
            coolDownTime = 10.0f;
        }
    }
    void dos(){
        gameState.text = "";
    }

}
