using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {

        PelaajaManageri.instance.pelaaja.GetComponent<CharacterController>().enabled = false;
        PelaajaManageri.instance.pelaaja.GetComponent<Pelaaja>().enabled = false;

        Invoke("WakeUpThePlayer", 2f);
    }

    void WakeUpThePlayer()
    {
        PelaajaManageri.instance.pelaaja.GetComponent<CharacterController>().enabled = true;
        PelaajaManageri.instance.pelaaja.GetComponent<Pelaaja>().enabled = true;
    }

    private void Update()
    {
        if(PelaajaManageri.instance.kamera.GetComponent<Kamera>().heavenOn)
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

}
