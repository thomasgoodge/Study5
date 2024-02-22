using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TMPro;
using System.IO;


using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DateChecker : MonoBehaviour
{

    public StringBuilder sb = new StringBuilder();
    public string date;
    public string condition;
    // Start is called before the first frame update
    void Start()
    {
        condition = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDate()
    {
        date = System.DateTime.UtcNow.ToString();
        print(date);
    }


    public void WriteDate()
    {

        string path = Application.persistentDataPath + "/" + condition + " startTime.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(date);
        writer.WriteLine(condition);

        writer.Close();
    }
}
