using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTargetTrackHazard : MonoBehaviour
{
    public GameObject targetGem;
    public GameObject hazardGem;
    public GameObject HazardWarningObject;
    public GameObject currentTarget;
    public GameObject centreTarget;
    public GameObject thisDot;
    public bool showBar = true;
  
    public float  travelSpeed = 0.05f;


    public MeshRenderer CueMesh;

    public Vector3 basePosition;

    // Start is called before the first frame update
    void Start()
    {
       
        HazardWarningObject = GameObject.Find("HazardWarning");
        basePosition = transform.position;

       
    }

    // Update is called once per frame
    void Update()
    {

        hazardGem = GameObject.Find("GhostCubie(Clone)");
        targetGem = GameObject.Find("ScanCubie(Clone)");
        centreTarget = GameObject.Find("VisualTargetAnchor");
        if (centreTarget == null)
        {
            centreTarget = GameObject.Find("VisualTargetAnchorPractice");
        }
       
     
        if (hazardGem != null)
        {
            
            currentTarget = hazardGem;
            transform.position = Vector3.Lerp(transform.position, new Vector3 (hazardGem.transform.position.x, transform.position.y, transform.position.z), travelSpeed);
            //transform.position = new Vector3(transform.position.x, (transform.position.y - 0.1f), transform.position.z);

            
        }
        else if (targetGem != null)
        {
            currentTarget = targetGem;
            transform.position = Vector3.Lerp(transform.position, new Vector3 (targetGem.transform.position.x, transform.position.y, transform.position.z), travelSpeed);
            //transform.position = new Vector3(transform.position.x, (transform.position.y - 0.1f), transform.position.z);     

        }
        else 
        {
            currentTarget = centreTarget;
            transform.position = Vector3.Lerp(transform.position, new Vector3 (centreTarget.transform.position.x, transform.position.y, transform.position.z), travelSpeed);
        }

        showBar = HazardWarningObject.GetComponent<HazardOnsetManager>().stopwatchRunning;

        if (showBar == false)
            {
                 CueMesh.enabled = false;
            }
        else if (showBar == true)
            {
                CueMesh.enabled = true;
            }
        else
        {
            CueMesh.enabled = true;
        }
        
        

    }
    
}


