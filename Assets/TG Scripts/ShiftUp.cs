using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftUp : MonoBehaviour
{

    public bool shiftUp = false;

    public GameObject targetGem;
    public GameObject hazardGem;
    public GameObject HazardWarningObject;
    public GameObject parentObject;
    public Vector3 basePosition;
    public Vector3 upPosition;



    // Start is called before the first frame update
    void Start()
    {  
        HazardWarningObject = GameObject.Find("HazardWarning");
        if (parentObject == null)
        {
            parentObject = GameObject.Find("VisualTargetAnchor");
        }
        if (parentObject == null)
        {
            parentObject = GameObject.Find("VisualTargetAnchorPractice");

        }

    }

    // Update is called once per frame
    void Update()
    {
        basePosition = parentObject.transform.position;  
        upPosition = basePosition + new Vector3(0f,0.01f,0f);
        hazardGem = GameObject.Find("GhostCubie(Clone)");
        targetGem = GameObject.Find("ScanCubie(Clone)");
       
        if (shiftUp == true)
        {
            transform.position =  upPosition;
        }
        else
        {
            transform.position = basePosition;
        }
     
        if (hazardGem != null)
        {        
            shiftUp = true;
            
        }
        else if (targetGem != null)
        {
            shiftUp = true;

        }
        else 
        {

            shiftUp = false;
        }

       
        
        

    }
    

}
