using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Äänimanageri : MonoBehaviour
{
    private static Äänimanageri _instance;
    public static Äänimanageri Instance

    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Äänimanageri");
                go.AddComponent<Äänimanageri>();
            }
            return _instance;
        }

    }
    void Awake()
    {
        _instance = this;

    }

    AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public AudioClip räjähdys;

    public void Explosion()
    {
        audiosource.PlayOneShot(räjähdys);
    }

}
