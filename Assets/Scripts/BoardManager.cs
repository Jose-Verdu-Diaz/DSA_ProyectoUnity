using UnityEngine;
using UnityEngine.UI;
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
        public GameObject followingNPC;
        public GameObject player;

        [Header("Items:")]
        public GameObject brocoli;
        public GameObject papel;
        public GameObject agua;
        public GameObject desinfectante;

        public string[][] mapMatrix;

        private Transform boardHolder;

        [Header("Mapas:")]
        public GameObject[] maps;


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
                        GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

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
                            case "F":
                                toInstantiate = followingNPC;
                                break;
                            case "B":
                                toInstantiate = brocoli;
                                break;
                            case "V":
                                toInstantiate = papel;
                                break;
                            case "A":
                                toInstantiate = agua;
                                break;
                            case "D":
                                toInstantiate = desinfectante;
                                break;
                            default:
                                break;
                        }
                        GameObject instance = Instantiate(toInstantiate, new Vector3(x, mapMatrix.Length - y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                    }
                }
            }
        }

        void ParseMapString(string s)//habrá que adaptarlo, de momento pilla un csv y lo parsea. En el futuro tiene que recibir el string de la BBDD
        {
            var lines = new List<string[]>();

            string[] row = s.Split(';');

            foreach (string r in row)
            {
                string[] Line = r.Split(',');
                lines.Add(Line);
            }

            this.mapMatrix = lines.ToArray();
        }


        public void SetupScene(int level)
        {
            ParseMapString(maps[0].GetComponent<Text>().text);
            BoardSetup();
        }
    }
}