using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Queue<Block> nextBlocks = new Queue<Block>();
    public List<Block> validBlocks;
    public List<Block> Blocks;
    public List<ShowBlock> ShownBlocks;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < 3; i++)
        {
            GetRandomBlock();
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

    public void GetRandomBlock()
    {
        int blockIndex = Random.Range(0, validBlocks.Count);
        Block rndBlock = validBlocks[blockIndex];

        nextBlocks.Enqueue(rndBlock);
        Blocks.Add(rndBlock);  // Debug only
    }

    public Block GetNewBlock()
    {
        Debug.Log("Help");
        Block temp = Blocks[0];
        Blocks.RemoveAt(0);
        GetRandomBlock();
        foreach (ShowBlock showblock in ShownBlocks)
        {
            showblock.Show();
        }

        return temp;
    }

    public void TestMethod()
    {
        Blocks.RemoveAt(0);
        GetRandomBlock();
        foreach (ShowBlock showblock in ShownBlocks)
        {
            showblock.Show();
        }
    }
}
