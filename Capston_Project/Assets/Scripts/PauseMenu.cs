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

    GameObject[] Piggeh;
    GameObject[] Slime;
    GameObject[] Big;

    public int piggehCount;
    public int bigCount;
    public int slimeCount;

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
    public void KillAllEnemies(){
      Piggeh = GameObject.FindGameObjectsWithTag("Enemy");
      Slime = GameObject.FindGameObjectsWithTag("Slime");
      Big = GameObject.FindGameObjectsWithTag("Big");
      piggehCount = Piggeh.Length;
      bigCount += Big.Length;
      slimeCount += Slime.Length;
      for (int i = 0; i < piggehCount; i++){
        Destroy(Piggeh[i]);
      }
      for (int i = 0; i < bigCount; i++){
        Destroy(Big[i]);
      }
      for (int i = 0; i < slimeCount; i++){
        Destroy(Slime[i]);
      }
    }
}
