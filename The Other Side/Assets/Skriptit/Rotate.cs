using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 90f;

    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0,0,1), Time.deltaTime * speed);
    }
}
