using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
   
    public int currentCamera = 20;
    public static bool camOpen = false;
    [SerializeField] GameObject map;
    [SerializeField] GameObject meth;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject dead;
    [SerializeField] GameObject staticFX;
    private float deadTimer = 0;
    private bool startTime = false;
    [SerializeField] private GameObject methScript;


    void Start()
    {
        map.SetActive(false);
        dead.SetActive(false);
        staticFX.SetActive(false);
    }
    void Update()
    {
        if (startTime == true)
        {
            deadTimer += Time.deltaTime;
        }
        if (deadTimer >= 3)
        {
            gameObject.transform.position = new Vector3(6.56f, 0, 120);
            dead.SetActive(true);
        }
    }
    
    public void OpenClose()
    {
        
        if (camOpen == false)
        {
            camOpen = true;
            map.SetActive(true);
            staticFX.SetActive(true);
            meth.SetActive(false);
            gameObject.transform.position = new Vector3(6.56f, 0, currentCamera);
        }
        else
        {
            camOpen = false;
            map.SetActive(false);
            staticFX.SetActive(false);
            meth.SetActive(true);
            gameObject.transform.position = new Vector3(6.56f, 0, 0);
        }
        
        
    }

    public void ChangeCamera(int CamNumber)
    {
        currentCamera = CamNumber;
        gameObject.transform.position = new Vector3(6.56f, 0, currentCamera);
    }

     public void Dead()
    {
        if ((methScript.GetComponent<Methcounter>().methcount) < 100)
        {
            map.SetActive(false);
            
            meth.SetActive(false);
            cam.SetActive(false);
            gameObject.transform.position = new Vector3(6.56f, 0, 100);
            startTime = true;
            deadTimer += Time.deltaTime;
        }
    }

}