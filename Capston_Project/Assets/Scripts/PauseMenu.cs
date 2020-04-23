using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenuUI;

    public GameObject developerMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
          if (GameIsPaused){
            if (optionsMenuUI.activeInHierarchy == true){
              optionsMenuUI.SetActive(false);
              pauseMenuUI.SetActive(true);
            }
            else {
              Resume();
            }
          }
          else {
            Pause();
          }
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
          if (GameIsPaused)
            if ((optionsMenuUI.activeInHierarchy == true)){
              optionsMenuUI.SetActive(false);
            }
            else if ((pauseMenuUI.activeInHierarchy == true)){
              pauseMenuUI.SetActive(false);
            }
            else {
              developerMenuUI.SetActive(false);
              Resume();
            }
            else {
              Pause();
              pauseMenuUI.SetActive(false);
              developerMenuUI.SetActive(true);
            }
          }
    }
    public void Resume() {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }
    void Pause() {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }
    public void Options() {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      optionsMenuUI.SetActive(true);
      Time.timeScale = 0f;
    }
    public void LoadMenu(){
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
      Debug.Log("Quitting Game...");
      Application.Quit();
    }
}
