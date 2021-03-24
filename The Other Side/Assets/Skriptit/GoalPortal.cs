using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPortal : MonoBehaviour
{

    [SerializeField] private string NextLevelName;
    [SerializeField] private string time_saver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            WinLevel();
        }
    }

    void WinLevel()
    {
        SceneManager.LoadScene(NextLevelName);
        PlayerPrefs.SetFloat(time_saver, Gamemanager.Instance.timer);

    }
}
