using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class imuSensorControl : MonoBehaviour
{
    public SerialPort serial = new SerialPort("\\\\.\\COM3", 115200);
    public string arduinoText;
    public string[] xyzVal;
    static public float arX, arY, arZ;
    public int[] xyzValFloat;
    // Start is called before the first frame update
    void Start()
    {
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        arduinoText = serial.ReadLine();
        xyzVal = arduinoText.Split(',');

        float.TryParse(xyzVal[0], out arX);
        float.TryParse(xyzVal[1], out arY);
        float.TryParse(xyzVal[2], out arZ);

        Debug.Log("X: " + arX + ",Y: " + arY + ",Z: " + arZ);

    }
}
