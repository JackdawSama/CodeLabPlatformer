using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public string fileName;
    const char delimiter = '|';
    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName);
        string newPos = reader.ReadLine();
        reader.Close();
        
        string[] pos = newPos.Split(new char[] { delimiter });
        transform.position = new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2]));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StreamWriter writer = new StreamWriter(fileName);

            writer.Write("" + transform.position.x + delimiter + transform.position.y + delimiter + transform.position.z);
            writer.Close();
        }
    }
}
