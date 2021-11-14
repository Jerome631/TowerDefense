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
        Vector3 worldstart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));   
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                PlaceTile(i,j, worldstart);
            }
        }
    }
    
    private void PlaceTile(int i, int j, Vector3 worldstart)
    {
        GameObject newtile = Instantiate(tileprefabs[0]);
        newtile.transform.position = new Vector3(worldstart.x+TileSize * i, worldstart.y-TileSize * j, 0);
    }

}
