using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Kamera : MonoBehaviour
{
    Camera _camera;
    public bool heavenOn = true;

    public PostProcessingProfile hellProfile;
    public PostProcessingProfile heavenProfile;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    public float Y_axis = 0.5f;
    public float X_axis = 0.5f;

    private void Start()
    {
        _camera = Camera.main;

    }

    private void Update()
    {
        if (target)
        {
            Vector3 point = _camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - _camera.ViewportToWorldPoint(new Vector3(X_axis, Y_axis, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
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
