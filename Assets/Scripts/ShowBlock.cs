using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBlock : MonoBehaviour
{
    public int index = -1;
    public Block nextBlock;
    public Image block_img;
    // Start is called before the first frame update
    void Start()
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        if (index != -1)
        {
            nextBlock = GameManager.instance.Blocks[index];
        }
        block_img.sprite = nextBlock.gameObject.GetComponent<SpriteRenderer>().sprite;
        block_img.color = nextBlock.gameObject.GetComponent<SpriteRenderer>().color;
    }
}
