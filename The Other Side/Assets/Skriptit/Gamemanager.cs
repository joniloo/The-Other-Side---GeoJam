using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;
    public static Gamemanager Instance

    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Gamemanager");
                go.AddComponent<Gamemanager>();
            }
            return _instance;
        }

    }
    void Awake()
    {
        _instance = this;
    }

    public GameObject[] hellPieces;
    public GameObject[] heavenPieces;

    public bool timeIsRunning = true;
    float timer;
    public Text timertext;

    public GameObject portalSphere;

    private void Start()
    {
        DisablePlayer();
        portalSphere.SetActive(true);
        PelaajaManageri.instance.pelaaja.GetComponent<SkinnedMeshRenderer>().enabled = false;
}

    public void DisablePlayer()
    {
        PelaajaManageri.instance.pelaaja.GetComponent<CharacterController>().enabled = false;
        PelaajaManageri.instance.pelaaja.GetComponent<Pelaaja>().enabled = false;
        portalSphere.SetActive(true);
        PelaajaManageri.instance.pelaaja.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Invoke("WakeUpThePlayer", 2f);

    }

    public void WakeUpThePlayer()
    {
        PelaajaManageri.instance.pelaaja.GetComponent<CharacterController>().enabled = true;
        PelaajaManageri.instance.pelaaja.GetComponent<Pelaaja>().enabled = true;
        PelaajaManageri.instance.pelaaja.GetComponent<SkinnedMeshRenderer>().enabled = true;
        portalSphere.SetActive(false);
    }

    private void Update()
    {
        Timer();
        Portalizer();
        
    }

    void Portalizer()
    {
        if (PelaajaManageri.instance.kamera.GetComponent<Kamera>().heavenOn)
        {
            foreach (GameObject piece in heavenPieces)
            {
                if (!piece.activeInHierarchy)
                {
                    piece.SetActive(true);
                }
            }

            foreach (GameObject piecehell in hellPieces)
            {
                if (piecehell.activeInHierarchy)
                {
                    piecehell.SetActive(false);
                }
            }
        }

        else if (!PelaajaManageri.instance.kamera.GetComponent<Kamera>().heavenOn)
        {
            foreach (GameObject piece in heavenPieces)
            {
                if (piece.activeInHierarchy)
                {
                    piece.SetActive(false);
                }
            }

            foreach (GameObject piecehell in hellPieces)
            {
                if (!piecehell.activeInHierarchy)
                {
                    piecehell.SetActive(true);
                }
            }
        }
    }

    void Timer()
    {

        timertext.text = timer.ToString("f2");

        if (timeIsRunning)
        {

            timer += Time.deltaTime;
        }

    }
}


