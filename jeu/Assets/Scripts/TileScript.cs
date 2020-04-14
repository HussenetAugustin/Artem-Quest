using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class TileScript : MonoBehaviour
{
    public Tilemap sol;
    public Tilemap mur;
    public Tile tile1;
    public Tile tile2;
    public Tile tile3;
    public Tile tile4;
    public Tile tile5;
    public Tile tile6;
    public Tile tile7;
    public GameObject player;
    public Camera camera;
    public TextAsset map;
    string[,] array2D = new string[10, 10];
    string[] lines;
    string[] line;
    // Update is called once per frame
    private void Start()
    {

        lines = map.text.Split("\n"[0]);
        char[] splitters = {'\t'};
        line = lines[0].Split(splitters, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(line.Length);
        Debug.Log(line[0]);


        string[,] mapArray = new string[lines.Length, line.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            line = lines[i].Split(new char[] { '\t' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < line.Length; j++)
            {
                mapArray[i, j] = line[j];
            }
        }

        Debug.Log(mapArray[0,0]);

        for (int i = 0; i < mapArray.GetLength(1); i++)
        {
            for (int j = 0; j < mapArray.GetLength(0); j++)
            {
                Vector3Int npos = new Vector3Int(i+15, mapArray.GetLength(0)-j-15, 0);
                switch (mapArray[j, i])
                {
                    case "0":
                        //beton
                        sol.SetTile(npos, tile4);
                        break;
                    case "1":
                        //eau
                        sol.SetTile(npos, tile1);
                        break;
                    case "2":
                        //verriere
                        sol.SetTile(npos, tile2);
                        break;
                    case "3":
                        //herbe
                        sol.SetTile(npos, tile3);
                        break;
                    case "4":
                        //chemin
                        mur.SetTile(npos, tile4);
                        break;
                    case "5":
                        //sol batiment
                        sol.SetTile(npos, tile5);
                        break;
                    case "6":
                        //on sait pas 
                        sol.SetTile(npos, tile1);
                        break;
                    case "7":
                        //mur batiment
                        mur.SetTile(npos, tile7);
                        break;
                    case "8":
                        //terre
                        sol.SetTile(npos, tile4);
                        break;
                }
            }
        }
    }
    void Update()
    {
    }


}
