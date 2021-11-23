using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; set; }

    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x+(GetComponent<SpriteRenderer>().bounds.size.x/2), transform.position.y-(GetComponent<SpriteRenderer>().bounds.size.y/2));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridpos, Vector3 worldpos)
    {
        this.GridPosition = gridpos;
        transform.position = worldpos;
    }
}
