using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ManualCalibration : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();

    private List<string> positionDisplayOrder = new List<string>();
    public int positionsLength = 0;
    public int locationInt;
    public Vector3 newPosition;
    public Vector3 startPosition;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    public string date;
    public string end;

    

//public List<Vector3> vector3s = new List<Vector3>() { new Vector2(1, 0), new Vector3(2, 9), new Vector3(5, 7,10) };
    // Start is called before the first frame update
    void Start()
    {

        //CheckDate();
        startPosition = transform.position;
        
        //Top Row
        positions.Add(new Vector3 (-0.4f,0.45f,3f));
        positions.Add(new Vector3 (0f,0.45f,3f));
        positions.Add(new Vector3 (0.4f,0.45f,3f));
        //Middle Top Row
        positions.Add(new Vector3 (-0.2f,0.2f,3f));
        positions.Add(new Vector3 (0.2f,0.2f,3f));
        //Middle Row
        positions.Add(new Vector3 (-0.4f,0f,3f));
        positions.Add(new Vector3 (0f,0f,3f));
        positions.Add(new Vector3 (0.4f,0f,3f));
        //Middle Bottom Row
        positions.Add(new Vector3 (-0.2f,-0.2f,3f));
        positions.Add(new Vector3 (0.2f,-0.2f,3f));
        //Bottom Row
        positions.Add(new Vector3 (-0.4f,-0.45f,3f));
        positions.Add(new Vector3 (0f,-0.45f,3f));
        positions.Add(new Vector3 (0.4f,-0.45f,3f));

        positionsLength = positions.Count;

         
    }

    // Update is called once per frame
    void Update()
    {
        positionsLength = positions.Count;

    }

    public void CheckDate()
    {
        date = System.DateTime.UtcNow.ToString();
        //print(date);
    }

    public void CheckEnd()
    {
        end = System.DateTime.UtcNow.ToString();
        //print(date);
    }
    public  IEnumerator ChangeRingLocation()
    {
        
        while(positions.Count > 0)
        {
            locationInt = Random.Range(0, positionsLength);
            newPosition = positions[locationInt];
            transform.position = newPosition;
            positions.Remove(positions[locationInt]);
            positionDisplayOrder.Add(newPosition.ToString());
            yield return new WaitForSeconds(3);
        }
        if(positions.Count == 0)
        {
            transform.position = startPosition;
            PlayCorrectAudio();
            CheckEnd();
            WriteString();
        }

     
    }
    public void runManualCalibration()
    {
        StartCoroutine(ChangeRingLocation());

    }

    void PlayCorrectAudio()
    {
       
        audioSource.PlayOneShot(clip, volume);
        
    }

    
    public void WriteString()
    {

        string path = Application.persistentDataPath + "/" + "calibration.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(date);

        for (int i = 0; i < positionDisplayOrder.Count; i++)
        {
        writer.WriteLine(positionDisplayOrder[i]);
        }
        writer.WriteLine(end);
 
        writer.Close();
        //StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();
    }
}
