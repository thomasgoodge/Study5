using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGem : MonoBehaviour
{

    public GameObject targetGem;
    public GameObject hazardGem;
    public float  rotationSpeed = 1.0f;

    public Vector3 SearchTarget;

    public Vector3 CentreTarget = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hazardGem = GameObject.Find("Cubie(Clone)");
        targetGem = GameObject.Find("Hexgon(Clone)");

        SearchTarget = targetGem.transform.position +  new Vector3(0.1f,0.1f,0f);


        if (hazardGem != null)
        {
            RotateTowards(hazardGem.transform.position);
        }
        else if (targetGem != null)
        {
            RotateTowards(targetGem.transform.position);
        }
        else
        {
            RotateTowards(CentreTarget);
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


