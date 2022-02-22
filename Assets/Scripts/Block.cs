using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite image;

    float previousTime;
    float fallTime = 1f;
    
    int width = 10;
    int height = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && gameObject.name != "Yellow")
        {
            transform.eulerAngles += new Vector3(0, 0, 90);
            if (!ValidMove())
            {
                transform.eulerAngles += new Vector3(0, 0, -90);
            }
        }

        //Move
        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.S) ? fallTime/10: fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                this.enabled = false;

                //Spawn new block
                Instantiate(GameManager.instance.GetNewBlock(), new Vector3(5f, 17, 0), Quaternion.identity);
                
            }
            previousTime = Time.time;
        }
    }

    bool ValidMove()
    {
        foreach (Transform transformChild in transform)
        {
            int xpos = Mathf.RoundToInt(transformChild.transform.position.x);
            int ypos = Mathf.RoundToInt(transformChild.transform.position.y);

            if (xpos < 0 || ypos < 0 || xpos >= width || ypos >= height)
            {
                return false;
            }
        }
        
        return true;
    }
}
