using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public CameraMovement cameraMovement; 

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
                maxTile=PlaceTile(newtiles[j].ToString(), j, i, worldstart) ;
            }
        }

        cameraMovement.SetLimit(new Vector3(maxTile.x+TileSize, maxTile.y-TileSize));
    }
    
    private Vector3 PlaceTile(string tiletype, int i, int j, Vector3 worldstart)
    {
        //Changes tiletype to int
        int tileindex = int.Parse(tiletype);

        //Creates a new tile and makes a reference to that tile in newtile
        GameObject newtile = Instantiate(tileprefabs[tileindex]);

        //Uses the new tile variable to change the position
        newtile.transform.position = new Vector3(worldstart.x+TileSize * i, worldstart.y-TileSize * j, 0);
        return newtile.transform.position;
    }

    private string[] ReadLevelText()
    {
        TextAsset binddata = Resources.Load("Level") as TextAsset;
        string data = binddata.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }

}
