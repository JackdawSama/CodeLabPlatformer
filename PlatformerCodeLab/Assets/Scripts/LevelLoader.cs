using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string fileName;

    public float xOffset;
    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        StreamReader textReader = new StreamReader(fileName);
        string fileContent = textReader.ReadToEnd();
        textReader.Close();

        char[] newLineChar = {'\n'};

        string[] level = fileContent.Split(newLineChar);

        for(int i = 0; i < level.Length; i++)
        {
            MakeRow(level[i], -1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeRow(string rowString, float y)
    {
        char[] rowArray = rowString.ToCharArray();
        for(int x = 0; x < rowString.Length; x++)
        {
            char c = rowArray[x];
            if (c == 'X') 
            {
                GameObject brick = Instantiate(Resources.Load("Cube")) as GameObject;
                brick.transform.position = new Vector3(x * brick.transform.localScale.x + xOffset, y * brick.transform.localScale.y + yOffset, 0);
            }
        }
    }
}
