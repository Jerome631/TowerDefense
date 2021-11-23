using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public CameraMovement cameraMovement;

    private Point startspawn, endspawn;

    public GameObject startportalprefab;
    public GameObject endportalprefab;

    public Dictionary<Point,TileScript> Tiles { get; set; }
    public float TileSize
    {
        get { return tileprefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    void Start()
    {
        createlevel();         
    }

    void Update()
    {
        
    }

    private void createlevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        //Calculate x and y of map size
        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;

        //Calculates the world start point(Top left of screen)
        Vector3 worldstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));   
        
        for (int i = 0; i < mapY; i++)
        {
            char[] newtiles = mapData[i].ToCharArray();
            for (int j = 0; j < mapX; j++)
            {
                //Palces tile
                PlaceTile(newtiles[j].ToString(), j, i, worldstart) ;
            }
        }
        maxTile = Tiles[new Point(mapX-1,mapY-1)].transform.position;

        //Sets camera movement limits to the max tile position
        cameraMovement.SetLimit(new Vector3(maxTile.x+TileSize, maxTile.y-TileSize));
        
        SpawnPortals();
    }
    
    private void PlaceTile(string tiletype, int i, int j, Vector3 worldstart)
    {
        //Changes tiletype to int
        int tileindex = int.Parse(tiletype);

        //Creates a new tile and makes a reference to that tile in newtile
        TileScript newtile = Instantiate(tileprefabs[tileindex]).GetComponent<TileScript>();

        //Uses the new tile variable to change the position of tile
        newtile.Setup(new Point(i, j), new Vector3(worldstart.x + TileSize * i, worldstart.y - TileSize * j, 0));

        Tiles.Add(new Point(i, j) , newtile);
    }

    private string[] ReadLevelText()
    {
        TextAsset binddata = Resources.Load("Level") as TextAsset;
        string data = binddata.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }

    private void SpawnPortals()
    {
        startspawn = new Point(0, 0);
        Instantiate(startportalprefab, Tiles[startspawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);

        endspawn = new Point(11, 6);
        Instantiate(endportalprefab, Tiles[endspawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}
