using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            WinLevel();
        }
    }

    void WinLevel()
    {


    }
}
