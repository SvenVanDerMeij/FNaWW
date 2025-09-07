using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalt : MonoBehaviour
{
    private float moveTimer = 0;
    private int waltPosition = 0;
    [SerializeField] private GameObject[] walt;
    private bool dead = false;
    [SerializeField] private GameObject CamScript;
    private bool SaulCalled = false;
    [SerializeField] private Methcounter methCounter; 
    [SerializeField] private HighscoreUploader highscoreUploader; 

    void Update()
    {
        if (!dead)
        {
            moveTimer += Time.deltaTime;
        }
        if (moveTimer >= 1)
        {
            moveTimer = 0;
            MovementOpportunity();
        }
    }

    void MovementOpportunity()
    {
        float movement = Random.Range(0f, 3f);
        for (int i = 0; i < walt.Length; i++)
        {
            walt[i].SetActive(false);
        }

        if (movement >= 1f)
        {
            waltPosition += 1;
        }
        else
        {
            waltPosition -= 1;
        }

        if (waltPosition < 0)
        {
            waltPosition = 0;
        }
        walt[waltPosition].SetActive(true);
        if (waltPosition == 8)
        {
            dead = true;
            JumpScare();

            if (methCounter != null)
            {
                int finalScore = methCounter.methcount; 
                GameOver(finalScore); 
            }
        }
    }

    private void JumpScare()
    {
        CamScript.GetComponent<CamControl>().Dead();
    }

    private void GameOver(int finalScore)
    {
        string playerName = "Anthony";
        highscoreUploader.UploadScore(playerName, finalScore);
    }

    public void SaulWasCalled()
    {
        if (!SaulCalled)
        {
            SaulCalled = true;
            waltPosition = 0;
        }
    }
}