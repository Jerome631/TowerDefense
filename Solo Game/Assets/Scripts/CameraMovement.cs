using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraspeed = 5f;

    private float xMax;
    private float yMin;

    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();        
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraspeed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, xMax), Mathf.Clamp(transform.position.y, yMin,0),-10);
    }

    public void SetLimit(Vector3 maxtile)
    {
        Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        xMax = maxtile.x - wp.x;
        yMin = maxtile.y - wp.y;
    }
}
