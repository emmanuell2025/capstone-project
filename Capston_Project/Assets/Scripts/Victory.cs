using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
  public GameObject victoryUI;
  public GameObject DevUI;
  public GameObject enemySpawn;
  GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      enemies = GameObject.FindGameObjectsWithTag("Boss");
      if (enemySpawn.GetComponent<SpawnEnemies>().bossSpawn == true){
        if (enemies.Length == 0){
          victoryUI.SetActive(true);
          Time.timeScale=0f;
          if (DevUI.activeInHierarchy == true){
            DevUI.SetActive(false);
          }
        }
      }
    }
    public void Continue(){
      victoryUI.SetActive(false);
      enemySpawn.GetComponent<SpawnEnemies>().bossSpawn = false;
      enemySpawn.GetComponent<SpawnEnemies>().spawnedCheck = false;
      Time.timeScale=1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu(){
      victoryUI.SetActive(false);
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
      Debug.Log("Quitting Game...");
      Application.Quit();
    }
}
