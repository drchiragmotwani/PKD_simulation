using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class dataReaderTest : MonoBehaviour
{
    public SerialPort serial = new SerialPort("\\\\.\\COM3", 9600);
    public string dataPacket;
    public string[] dataParse;
    private char[] separator = {'X', 'Y', 'Z'};
    private string dataStringX, dataStringY, dataStringZ;
    public float dataFloatX, dataFloatY, dataFloatZ;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        dataPacket = serial.ReadLine();
        dataParse = dataPacket.Split(separator);
        dataStringX = dataParse[1];
        dataStringY = dataParse[2];
        dataStringZ = dataParse[3];

        float.TryParse(dataStringX, out dataFloatX);
        float.TryParse(dataStringY, out dataFloatY);
        float.TryParse(dataStringZ, out dataFloatZ);

        player.transform.Rotate(dataFloatX, dataFloatY, dataFloatZ);
    }
}
