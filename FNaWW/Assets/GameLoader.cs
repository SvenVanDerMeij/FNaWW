using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour

{
    [SerializeField] private GameObject staticFilter;
    [SerializeField] private GameObject uiElements;
    [SerializeField] private GameObject lighting;
    
    public void StartGame()
    {
        gameObject.transform.position = new Vector3(6.56f, 0, 40);
        staticFilter.SetActive(false);
        uiElements.SetActive(false);
        lighting.SetActive(true);
        StartCoroutine(DelayAction( 5f));
    }

    IEnumerator DelayAction(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);
        LoadGame();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }
}
