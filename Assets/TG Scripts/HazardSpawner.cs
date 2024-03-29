using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;



public class HazardSpawner : MonoBehaviour
{
    // Create containers for the dimensions of the Spawner cube
    public Vector3 centralspawn;
    public Vector3 size;
    public GameObject gemPrefab;
    public GameObject blockPrefab;

    // Create counters for time and number of gems, as well as initialising a respawn time
    public float hazardRespawnTime;
    public float hazardRespawnRate = 1.0f;
    private int gemCount;
    [SerializeField] public bool spawnerActive;
    public bool spawned = false;

    public GameObject HazardOnsetManagerScript;
    public GameObject GetSpawnerLocationScript;
    public GameObject TopCentreAOI;

    public string SpawnerLocation;
    public int selectSpawner;

    public Vector3 spawnVector = new Vector3(0f, 0f, 0f);
    public Vector3 left = new Vector3(-0.25f,0f,0.8f);
    public Vector3 centreleft = new Vector3(-0.1f,0f,0.8f);
    public Vector3 centre = new Vector3(0f,0f,0.8f);
    public Vector3 centreright =new Vector3(0.1f,0f,0.8f);
    public Vector3 right = new Vector3(0.25f,0f,0.8f);
    public string condition;
    
    Transform TopCentreAOITransform;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject TopCentreAOI = GameObject.Find("/MainManager/ScreenCalibrationCube/Screen/AOIs/AOI(BottomCentre)");
        TopCentreAOITransform = TopCentreAOI.GetComponent<Transform>();
        float XCoord = TopCentreAOITransform.position.x;
        float YCoord = TopCentreAOITransform.position.y;
        float ZCoord = TopCentreAOITransform.position.z;
        setSpawnerLocationCongruent();

        //define the vector co-ordinates for the spawner locations
        left = new Vector3((XCoord-0.25f),(YCoord + 0f),ZCoord);
        centreleft = new Vector3((XCoord-0.1f),(YCoord + 0f),ZCoord);
        centre = new Vector3(XCoord,YCoord,ZCoord);
        centreright =new Vector3((XCoord + 0.1f),(YCoord + 0f),ZCoord);
        right = new Vector3((XCoord + 0.25f),(YCoord + 0f) ,ZCoord);
        spawnerActive = false;
        gemCount = 0;     
        centralspawn = new Vector3(XCoord, YCoord, ZCoord); 
        condition = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the respawn time to a random number within range ( smaller range for hazard gems to increase spawn rate)
        hazardRespawnTime = Random.Range(hazardRespawnRate / 2, hazardRespawnRate * 2);        
        selectSpawner =  HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazardLocation;
        
        //spawnerActive = HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard;
        //spawnerActive = CheckHazardStatus();
        spawnerActive = CheckPreHazardStatus();
    
         //if the spawner is active from the HazardOnsetManager script
        if (spawnerActive && spawned == false)
            {  
                StartCoroutine("CorSpawnHazardGem", 0.5f); 
                spawned = true;    
            }

        if (!spawnerActive && spawned == true)
            {
                StopCoroutine("CorSpawnHazardGem");
                spawned = false;
            }
        setSpawnerLocationCongruent();
        //Select which spawner to use
        //if (condition == "GemsCued"|| condition == "AHTest")
           // {
            //    setSpawnerLocationCongruent();
           // }
            /*
        else if (condition == "GemsFocusedIncongruent")
            {
                setSpawnerLocationIncongruent();
            }
            */
    }

    void OnDrawGizmosSelected()
    {
        // Visualise the spawn cubes in the Scene when clicked on (Colour and dimensions)
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(centralspawn, size);    
    }

    IEnumerator CorSpawnHazardGem()
    {
          
        // if there are less than 3 gems, spawn a gem in the range of the spawner
        Vector3 pos = centralspawn + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject alpha = Instantiate(gemPrefab, pos, Quaternion.identity);
        gemCount++;
        yield return new WaitForSeconds(0.5f);
    }
            
            
      
        //yield return new WaitForSeconds(1.0f);

        IEnumerator CorSpawnHazardBlock()
    {
          
        // if there are less than 3 gems, spawn a gem in the range of the spawner
        Vector3 pos = centralspawn;;
        GameObject alpha = Instantiate(blockPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
            
            
      
        //yield return new WaitForSeconds(1.0f);
               
    }     
    

    public void setSpawnerLocationCongruent()
    {
        if (selectSpawner == 5)
            {
                centralspawn.x = right.x; 
            }
        if (selectSpawner == 4)
            {
                centralspawn.x = centreright.x; 
            }
        if (selectSpawner == 3)
            {
                centralspawn.x = centre.x; 
                centralspawn.y = centre.y + 0.1f; 
            }
        if (selectSpawner == 2)
            {
                centralspawn.x = centreleft.x; 
            }
        if (selectSpawner == 1)
            {
                centralspawn.x = left.x; 
            }
    }
    public void setSpawnerLocationIncongruent()
    {
        if (selectSpawner == 5)
            {
                centralspawn.x = left.x; 
            }
        if (selectSpawner == 4)
            {
                centralspawn.x = left.x; 
            }
        if (selectSpawner == 3)
            {
                int coinToss = Random.Range(1,2);
                if (coinToss == 1)
                {
                centralspawn.x = right.x; 
                }
                else
                {
                centralspawn.x = left.x;
                }
            }
        if (selectSpawner == 2)
            {
                centralspawn.x = right.x; 
            }
        if (selectSpawner == 1)
            {
                centralspawn.x = right.x; 
            }
    }
    public bool CheckHazardStatus()
        {
        if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard == true)
            {
                spawnerActive = true;
               // print("Active");
                return spawnerActive;
            }
        else if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().hazard == false)
            {
                spawnerActive = false;
               // print("Inactive");
                return spawnerActive;
            }
            return spawnerActive;
        }

        public bool CheckPreHazardStatus()
        {
        if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().preHazard == true)
            {
                spawnerActive = true;
               // print("Active");
                return spawnerActive;
            }
        else if (HazardOnsetManagerScript.GetComponent<HazardOnsetManager>().preHazard == false)
            {
                spawnerActive = false;
               // print("Inactive");
                return spawnerActive;
            }
            return spawnerActive;
        }
}

