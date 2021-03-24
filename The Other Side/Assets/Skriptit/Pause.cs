using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private AudioSource blip;
    public AudioClip blipsound;
    Transform player;

    private void Start()
    {
        blip = GetComponent<AudioSource>();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player = PelaajaManageri.instance.pelaaja.transform;

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();

            }
        }

    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
    }

    void PauseGame()
    {
      
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Reset()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("SampleScene");
    }


    public void GuitGame()
    {
        Application.Quit();

    }

}
