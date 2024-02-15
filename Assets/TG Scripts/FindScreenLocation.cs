using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindScreenLocation : MonoBehaviour
{
    private Vector3 cubeLocation; 

    public float screenOffset = -0.1f;

    public GameObject ScreenCalibrationCube;
    // Start is called before the first frame update
    void Update()
    {
        ScreenCalibrationCube = GameObject.Find("/MainManager/ScreenCalibrationCube");
        if (ScreenCalibrationCube != null)
        {
            transform.position = ScreenCalibrationCube.transform.position + new Vector3(0f, screenOffset,0f);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    
}
