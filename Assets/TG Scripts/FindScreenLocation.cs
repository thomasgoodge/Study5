using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindScreenLocation : MonoBehaviour
{
    private Vector3 cubeLocation; 

    public float screenXOffset = 0f;
    public float screenYOffset = 0f;
    public float screenZOffset = 0f;

    public GameObject ScreenCalibrationCube;
    // Start is called before the first frame update
    void Update()
    {
        ScreenCalibrationCube = GameObject.Find("AOI(BottomCentre)");
        if (ScreenCalibrationCube != null)
        {
            transform.position = ScreenCalibrationCube.transform.position + new Vector3(screenXOffset, screenYOffset,screenZOffset);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    
}
