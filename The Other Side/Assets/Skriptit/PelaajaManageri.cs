using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaManageri : MonoBehaviour
{
    #region Singleton

    public static PelaajaManageri instance;

    #endregion

    private void Awake()
    {
        instance = this;
    }

    public GameObject pelaaja;
    public GameObject kamera;

}
