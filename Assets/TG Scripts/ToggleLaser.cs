using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLaser : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Toggle the Object's visibility each second.
    public void EnableLine()
    {

        rend.enabled = true;
    }


    public void DisableLine()
    {

        rend.enabled = false;
    }
}
