using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    GameObject level;
    
    string FILE_PATH;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + "/Data/LevelEditor.txt";
        
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        Destroy(level);
        
        level = new GameObject("Level Objects");

        string[] lines = File.ReadAllLines(FILE_PATH);
        
        for (int xLevelPos = 0; xLevelPos < lines.Length; xLevelPos++)
        {

            Debug.Log(lines[xLevelPos]);

            //Get a single line
            string line = lines[xLevelPos].ToUpper();

            //Turn line into a char array
            char[] characters = line.ToCharArray();

            for (int zLevelPos = 0; zLevelPos < characters.Length; zLevelPos++)
            {

                //get the first character
                char c = characters[zLevelPos];

                //Debug.Log(c);

                GameObject newObject = null;

                switch (c)
                {
                    case 'H': 
                        newObject = 
                            Instantiate(Resources.Load<GameObject>("Prefabs/Track"));
                        break;
                    case 'T': 
                        newObject = 
                            Instantiate(Resources.Load<GameObject>("Prefabs/Pole01"));
                        break;
                    case 'I': 
                        newObject = 
                            Instantiate(Resources.Load<GameObject>("Prefabs/Pole02"));
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;
                    //Give it a position based on where it was in the ASCII file
                    newObject.transform.position = new Vector3(xLevelPos, 0, zLevelPos * 31.5f);
                }
            }
        }
    }
}
