using UnityEngine;
using System;
using System.Collections.Generic;         //Allows us to use Lists.
using Random = UnityEngine.Random;         //Tells Random to use the Unity Engine random number generator.
using System.IO;

namespace Completed

{

    public class BoardManager : MonoBehaviour
    {
        public GameObject exit;
        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject wanderingNPC;
        public GameObject player;

        public string[][] mapMatrix;

        private Transform boardHolder;


        void BoardSetup()
        {
            boardHolder = GameObject.Find("Board").transform;

            for (int y =0; y < mapMatrix.Length; y++)
            {
                for (int x = 0; x < mapMatrix[y].Length; x++)
                {
                    string[] objects = mapMatrix[y][x].Split('.');

                    foreach (string s in objects)
                    {
                        GameObject toInstantiate = floorTiles[Random.Range(0, wallTiles.Length)];

                        switch (s)
                        {
                            case "X":
                                toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];
                                break;
                            case "P":
                                toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];
                                break;
                            case "E":
                                toInstantiate = exit;
                                break;
                            case "C":
                                toInstantiate = player;
                                break;
                            case "W":
                                toInstantiate = wanderingNPC;
                                break;
                        }
                        GameObject instance = Instantiate(toInstantiate, new Vector3(x, mapMatrix.Length - y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                    }
                }
            }
        }

        void ParseMapString(string filePath)//habrá que adaptarlo, de momento pilla un csv y lo parsea. En el futuro tiene que recibir el string de la BBDD
        {
            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
                Row++;
                Console.WriteLine(Row);
            }

            this.mapMatrix = lines.ToArray();
        }


        public void SetupScene(int level)
        {
            ParseMapString("Assets/Maps/02.csv");
            BoardSetup();
        }
    }
}