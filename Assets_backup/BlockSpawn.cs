using System.Transactions;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    // block prefabs
    public GameObject block;
    public GameObject largeBlock;
    public GameObject mediumBlock;
    public double spawnRate = 1.5; // time between spawns
    private float timer = 0;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnBlock();
            timer = 0; // reset timer
        }
    }

    // function to spawn blocks
    void spawnBlock()
    {
        // assigns a random value form 0.0 - 1.0
        float blockNum = Random.value;

        // calculate range for vector
        float bottomScreen = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).y;
        float midScreen = cam.ViewportToWorldPoint(new Vector3(1, 1.0f, 0)).y;
        float y = Random.Range(bottomScreen,midScreen);

        // chooses which block to spawn
        if(blockNum <= 0.33)
        {
            Instantiate(block, new Vector3(transform.position.x, y, 0), transform.rotation);
        } 
        else if(blockNum > 0.33 && blockNum <= 0.66)
        {
            Instantiate(largeBlock, new Vector3(transform.position.x, y, 0), transform.rotation);
        }
        else
        {
            Instantiate(mediumBlock, new Vector3(transform.position.x, y, 0), transform.rotation);
        }
    }
}

