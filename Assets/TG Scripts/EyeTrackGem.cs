using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.RemoteRendering;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.UIElements;

public class EyeTrackGem : MonoBehaviour
{
    public GameObject targetGem;
    public GameObject hazardGem;
    public float  rotationSpeed = 1.0f;

    public Vector3 SearchTarget;
    public Vector3 basePosition;

    public Vector3 CentreTarget = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        print(basePosition);
    }

    // Update is called once per frame
    void Update()
    {
        hazardGem = GameObject.Find("Cubie(Clone)");
        targetGem = GameObject.Find("Hexgon(Clone)");

        SearchTarget = targetGem.transform.position +  new Vector3(0.1f,0.1f,0f);


        if (hazardGem != null)
        {
            FocusOn(hazardGem.transform.position);
        }
        else if (targetGem != null)
        {
            FocusOn(targetGem.transform.position);
        }
        else
        {
            FocusOn(basePosition);
        }
    }
    


    void FocusOn(Vector3 targetPosition)
    {
        float speed = 0.1f;
        float maxMoveDistance = 0.1f;
        Vector3 targetDirection = targetPosition;
        Vector3 origin = transform.position;
        
        Vector3 movePupil = new Vector3(Mathf.Clamp(targetDirection.x,-0.01f,0.01f), origin.y, origin.z);
       
      
        // Use Lerp to smoothly interpolate between the current rotation and the target rotation
      
             transform.position = Vector3.MoveTowards(transform.position, movePupil, speed * Time.deltaTime);
        
    }
}
