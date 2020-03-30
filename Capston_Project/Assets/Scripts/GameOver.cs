using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Continue(){
      gameOverUI.SetActive(false);
      Time.timeScale=1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu(){
      gameOverUI.SetActive(false);
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
      Debug.Log("Quitting Game...");
      Application.Quit();
    }
}
