using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnabled : MonoBehaviour
{

    public GameObject thisObject;
    public bool toggleBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    public void ToggleObject()
    {
       toggleBool = !toggleBool;
       thisObject.SetActive(toggleBool);
    }

}
