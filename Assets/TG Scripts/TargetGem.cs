using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGem : MonoBehaviour
{
/*
    public GameObject targetGem;
    public GameObject targetGem2;
    public GameObject hazardGem;
    public GameObject scanGem;
*/
    public GameObject visualCueObject;

    public GameObject centreGem;

    public GameObject thisHead;

    public GameObject HazardWarningObject;

    public MeshRenderer RobotMesh;

    public float  rotationSpeed = 1.0f;

    public Vector3 SearchTarget;

    public Transform targetCamera;

    public bool showHead = true;

    public Vector3 CentreTarget = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(targetCamera);
        thisHead = GameObject.Find("Robot_Guardian");
        showHead = true;
    }

    // Update is called once per frame
    void Update()
    {
        //visualCue = GameObject.Find("VisualCue");
        /*
        hazardGem = GameObject.Find("GhostCubie(Clone)");
        targetGem = GameObject.Find("Hexgon(Clone)");
        targetGem2 = GameObject.Find("Penta(Clone)");
        scanGem = GameObject.Find("ScanCubie(Clone)");
        centreGem = GameObject.Find("FOE");
        */


    //SearchTarget = targetGem.transform.position +  new Vector3(0.1f,0.1f,0f);
    if (visualCueObject != null)
    {
        RotateTowards(visualCueObject.transform.position);
    }

    else
    {
        RotateTowards(targetCamera.transform.position);
    }
        /*
        if (hazardGem != null)
        {
            RotateTowards(hazardGem.transform.position);
        }
        else if (scanGem != null)
        {
            RotateTowards(scanGem.transform.position);
        }
       /* else if (targetGem != null)
        {
            RotateTowards(targetGem.transform.position);
        }
        else if (targetGem2 != null)
        {
            RotateTowards(targetGem2.transform.position);
        }
        else if (centreGem != null)
        {
            RotateTowards(centreGem.transform.position);
        }
        */
    
         showHead = HazardWarningObject.GetComponent<HazardOnsetManager>().stopwatchRunning;

        if (showHead == false)
            {
                 RobotMesh.enabled = false;
            }
        else if (showHead == true)
            {
                RobotMesh.enabled = true;
            }
        else
        {
            RobotMesh.enabled = true;
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 targetDirection = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        
        
        // Use Lerp to smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}


