using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] tileprefabs;

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

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 worldstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));   
        
        for (int i = 0; i < mapY; i++)
        {
            char[] newtiles = mapData[i].ToCharArray();
            for (int j = 0; j < mapX; j++)
            {
                PlaceTile(newtiles[j].ToString(), j, i, worldstart) ;
            }
        }
    }
    
    private void PlaceTile(string tiletype, int i, int j, Vector3 worldstart)
    {
        int tileindex = int.Parse(tiletype);
        GameObject newtile = Instantiate(tileprefabs[tileindex]);
        newtile.transform.position = new Vector3(worldstart.x+TileSize * i, worldstart.y-TileSize * j, 0);
    }

    private string[] ReadLevelText()
    {
        TextAsset binddata = Resources.Load("Level") as TextAsset;
        string data = binddata.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }

}
