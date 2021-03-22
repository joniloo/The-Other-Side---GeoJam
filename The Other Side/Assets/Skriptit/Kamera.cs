using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Kamera : MonoBehaviour
{
    Camera _camera;
    public bool heavenOn;

    public PostProcessingProfile hellProfile;
    public PostProcessingProfile heavenProfile;

    private void Start()
    {
        _camera = Camera.main;

    }


    public void Portal()
    {

            heavenOn = !heavenOn;
        

        if (heavenOn)
        {
            GetComponent<PostProcessingBehaviour>().profile = heavenProfile;
        }
        else if (!heavenOn)
        {

            GetComponent<PostProcessingBehaviour>().profile = hellProfile;
        }

    }
}
