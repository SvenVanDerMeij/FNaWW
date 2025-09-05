using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalt : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveTimer = 0;
    private int waltPosition = 0;
    [SerializeField] private GameObject[] walt;
    private bool dead = false;
    [SerializeField] private GameObject CamScript;
    private bool SaulCalled = false;

    void start()
    {
        
    }
    void Update()
    {
        if (dead == false){
        moveTimer += Time.deltaTime;
        }
        if (moveTimer >= 1)
        {
            moveTimer = 0;
            MovementOppurtunity();
        }
    }

    // Update is called once per frame
    void MovementOppurtunity()
    {
        float movement = Random.Range(0f, 3f);
        for (int i = 0; i < walt.Length; i++)
        {
            walt[i].SetActive(false);
        }

        if ( movement>= 1f)
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
        }
    }

    private void JumpScare()
    {
        CamScript.GetComponent<CamControl>().Dead();
    }

    public void SaulWasCalled()
    {
        if (SaulCalled == false)
        {
            SaulCalled = true;
            waltPosition = 0;
        }
    }
}
