using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCalibration : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    public int positionsLength = 0;
    public int locationInt;
    public new Vector3 newPosition;

     

//public List<Vector3> vector3s = new List<Vector3>() { new Vector2(1, 0), new Vector3(2, 9), new Vector3(5, 7,10) };
    // Start is called before the first frame update
    void Start()
    {
        
        //Top Row
        positions.Add(new Vector3 (-1.5f,1.0f,3f));
        positions.Add(new Vector3 (0f,1.0f,3f));
        positions.Add(new Vector3 (1.5f,1.0f,3f));
        //Middle Top Row
        positions.Add(new Vector3 (-0.7f,0.5f,3f));
        positions.Add(new Vector3 (0.7f,0.5f,3f));
        //Middle Row
        positions.Add(new Vector3 (-1.5f,0f,3f));
        positions.Add(new Vector3 (0f,0f,3f));
        positions.Add(new Vector3 (1.5f,0f,3f));
        //Middle Bottom Row
        positions.Add(new Vector3 (-0.7f,-0.5f,3f));
        positions.Add(new Vector3 (0.7f,-0.5f,3f));
        //Bottom Row
        positions.Add(new Vector3 (-1.5f,-1.0f,3f));
        positions.Add(new Vector3 (0f,-1.0f,3f));
        positions.Add(new Vector3 (1.5f,-1.0f,3f));

        positionsLength = positions.Count;

         
    }

    // Update is called once per frame
    void Update()
    {
    }


    public  IEnumerator ChangeRingLocation()
    {
        while(positions.Count > 0)
        {
            locationInt = Random.Range(0, positionsLength);
            newPosition = positions[locationInt];
            transform.position = newPosition;
            positions.Remove(positions[locationInt]);

            yield return new WaitForSeconds(5);
        }
    }
    public void runManualCalibration()
    {
               StartCoroutine(ChangeRingLocation());

    }
}
