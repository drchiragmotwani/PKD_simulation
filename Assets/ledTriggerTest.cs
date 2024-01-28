using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class ledTriggerTest : MonoBehaviour
{
    public Light lightSource;
    public SerialPort serial = new SerialPort("\\\\.\\COM3",9600);
    public string arduinoText;
    public float arduinoVal;
    public bool serialState = true;

    // Start is called before the first frame update
    void Start()
    {
        // serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            serial.Write("1");
            lightSource.intensity = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            serial.Write("0");
            lightSource.intensity = 0;
        }

        arduinoText = serial.ReadLine();
        float.TryParse(arduinoText, out arduinoVal);

        arduinoVal = arduinoVal / 1000;

        lightSource.spotAngle = arduinoVal;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(400, Screen.height - 100, 80, 30), "Open"))
        {
            serial.Open();
            serialState = true;
        }

        if (GUI.Button(new Rect(400, Screen.height - 130, 80, 30), "Close"))
        {
            serial.Close();
            serialState = false;
        }
    }
}
