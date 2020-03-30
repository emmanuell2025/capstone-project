using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region

    public static PlayerManager instance;
    public GameObject gameOverUI;

    void Awake()
    {
        instance = this;
    }


    #endregion


    public GameObject player;


    public void KillPlayer()
    {
      gameOverUI.SetActive(true);
      Time.timeScale=0f;

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
