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

        if(PlayerPrefs.HasKey(time_saver))
        {
            lasttimer = PlayerPrefs.GetFloat(time_saver);

        }
    }

    public GameObject[] hellPieces;
    public GameObject[] heavenPieces;
    [SerializeField] private string time_saver;
    public bool timeIsRunning = true;
    public float timer;
    public float lasttimer;
    public Text timertext;
    public Text lasttimertext;

    public GameObject portalSphere;

    private void Start()
    {
        DisablePlayer();
        portalSphere.SetActive(true);
        PelaajaManageri.instance.pelaaja.GetComponent<SkinnedMeshRenderer>().enabled = false;
        lasttimertext.text = lasttimer.ToString("f2");
    }

    public void DisablePlayer()
    {
        PelaajaManageri.instance.pelaaja.GetComponent<CharacterController>().enabled = false;
        PelaajaManageri.instance.pelaaja.GetComponent<Pelaaja>().enabled = false;
        portalSphere.SetActive(true);
        PelaajaManageri.instance.pelaaja.GetComponent<SkinnedMeshRenderer>().enabled = false;
        Invoke("WakeUpThePlayer", 1.5f);

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


