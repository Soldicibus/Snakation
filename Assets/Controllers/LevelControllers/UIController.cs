using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    public void MenuClosing()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MenuOpening()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    } 

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("unlockedLVLs"));
        Time.timeScale = 1.0f;
    }
}
