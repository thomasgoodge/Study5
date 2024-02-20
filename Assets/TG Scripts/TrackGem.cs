using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.RemoteRendering;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackGem : MonoBehaviour
{
    public GameObject targetGem;
    public GameObject hazardGem;
    public GameObject HazardWarningObject;
    public GameObject currentTarget;
    public GameObject centreGem;
    public GameObject thisDot;
    
    public bool showHead = true;
    public bool showMesh = true;

    public bool showDot = true;
  
    public float  travelSpeed = 0.05f;
 

    public Vector3 CentreTarget = new Vector3(0f, 0f, 0.5f);
    public Vector3 basePosition;

    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        print(basePosition);
        thisDot = GameObject.Find("VisualCue");
       
    }

    // Update is called once per frame
    void Update()
    {
     /*
        if (showDot == false)
            {
                RobotHeadMesh.enabled = false;
            }
        else if (showDot == true)
            {
                RobotHeadMesh.enabled = true;
            }
        else
        {
            RobotHeadMesh.enabled = true;
        }
       */


    

        hazardGem = GameObject.Find("GhostCubie(Clone)");
        targetGem = GameObject.Find("ScanCubie(Clone)");
        centreGem = GameObject.Find("/MainManager/ScreenCalibrationCube/Screen/SimObjects/Wall/FOE");
        //centreGem = transform.FindChild("FOE");

        //centreGem = GameObject.Find(Tag == "FOE");



        //SearchTarget = targetGem.transform.position +  new Vector3(0.1f,0.1f,0f);


        if (hazardGem != null)
        {
            currentTarget = hazardGem;
            transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, travelSpeed);
            transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), transform.position.z);

            
        }
        else if (targetGem != null)
        {
            currentTarget = targetGem;
            transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, travelSpeed);
            transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), transform.position.z);

            

        }
        else if (centreGem != null)
        {
            currentTarget = centreGem;
            transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, travelSpeed);
            transform.position = new Vector3(transform.position.x, (transform.position.y + 0.1f), transform.position.z);

            
        }
        else
        {
            currentTarget = null;
            transform.position = Vector3.Lerp(transform.position, basePosition, travelSpeed);
            transform.position = new Vector3(transform.position.x, (transform.position.y - 0.1f), transform.position.z);

          
        }
    }
    
}
