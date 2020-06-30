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
        public GameObject exitB;
        public GameObject[] floorTilesB;
        public GameObject[] wallTilesB;

        public GameObject exitW;
        public GameObject[] floorTilesW;
        public GameObject[] wallTilesW;

        public GameObject[] wallTilesR;

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

        private int levelNumber;

        void BoardSetup()
        {

            boardHolder = GameObject.Find("Board").transform;

            for (int y = 0; y < mapMatrix.Length; y++)
            {
                for (int x = 0; x < mapMatrix[y].Length; x++)
                {
                    string[] objects = mapMatrix[y][x].Split('.');

                    foreach (string s in objects)
                    {
                        GameObject toInstantiate = (levelNumber % 2 == 0) ? floorTilesW[Random.Range(0, floorTilesW.Length)] : floorTilesB[Random.Range(0, floorTilesB.Length)];

                        switch (s)
                        {
                            case "X":
                                toInstantiate = (levelNumber % 5 == 0) ? wallTilesR[Random.Range(0, wallTilesR.Length)] : (levelNumber % 2 == 0) ? wallTilesW[Random.Range(0, wallTilesW.Length)] : wallTilesB[Random.Range(0, wallTilesB.Length)];
                                break;
                            case "P":
                                toInstantiate = (levelNumber % 2 == 0) ? wallTilesW[Random.Range(0, wallTilesW.Length)] : wallTilesB[Random.Range(0, wallTilesB.Length)];
                                break;
                            case "E":
                                toInstantiate = (levelNumber % 2 == 0) ? wallTilesW[Random.Range(0, wallTilesW.Length)] : wallTilesB[Random.Range(0, wallTilesB.Length)];
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


        public void SetupScene(string stringNivel, int levelNumber)
        {
            //ParseMapString(maps[0].GetComponent<Text>().text);
            this.levelNumber = levelNumber;

            ParseMapString(stringNivel);

            BoardSetup();
        }
    }
}
