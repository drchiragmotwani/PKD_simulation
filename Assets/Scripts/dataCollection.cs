using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class dataCollection : MonoBehaviour
{
    private bool writeStatus = false;
    public string angleDataPath, velocityDataPath, pathname, firstLine, output;
    public GameObject shank;
    public string dataParam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (writeStatus)
        {
            writeData(dataParam);
        }
    }

    public void writeFirstLine(string dataParam) 
    {
        if (dataParam == "angle")
        {
            firstLine = string.Format("X, Y");
            pathname = angleDataPath;
        }

        if (dataParam == "velocity")
        {
            firstLine = string.Format("velocity");
            pathname = velocityDataPath;
        }

        using(StreamWriter file = new StreamWriter(pathname, true))
        {
            file.WriteLine(firstLine);            
        }
    }

    public void writeData(string dataParam) 
    {
        if (dataParam == "angle")
        {
            output = string.Format("{0}, {1}", shank.transform.localEulerAngles.x, shank.transform.localEulerAngles.y);
            pathname = angleDataPath;
        }

        if (dataParam == "velocity")
        {
            output = string.Format("{0}", shank.GetComponent<Rigidbody>().velocity.magnitude);
            pathname = velocityDataPath;
        }

        using(StreamWriter file = new StreamWriter(pathname, true))
        {
            file.WriteLine(output);
        }
    }

    public void clearData() 
    {
        using(StreamWriter file = new StreamWriter(angleDataPath, true))
        {
            file.WriteLine();
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(400, Screen.height - 100, 80, 30), "Write"))
        {
            writeFirstLine(dataParam);
            writeData(dataParam);
            writeStatus = true;
        }

        if (GUI.Button(new Rect(400, Screen.height - 130, 80, 30), "Clear"))
        {
            clearData();
        }

        if (GUI.Button(new Rect(400, Screen.height - 160, 80, 30), "Stop"))
        {
            writeStatus = false;
        }
    }
}
