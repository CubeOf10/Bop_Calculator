using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    GameObject TileHolder;
    public int testX, testY;
    public GameObject testTarget;
    [Header("Actual Dev")]
    public float xStart, yStart;
    public int col = 3;
    public int row = 3;
    public float xSpace, ySpace;
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        TileHolder = GameObject.Find("TileHolder");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    CheckPositionForObject(testX, testY);
        //}
        
    }

    public void CreateGrid()
    {
        StartCoroutine(Test());
        /*
        for(int i = 0; i < col * row; i++)
        {
            Vector3 newPos = new Vector3(xStart + (xSpace * (i % col)), yStart + (-ySpace * (i / col)), 0);
            if(!CheckPositionForObject(newPos.x, newPos.y))
            {
                Instantiate(tile, new Vector3(xStart + (xSpace * (i % col)), yStart + (-ySpace * (i / col))), Quaternion.identity);
            }
        }
        */
    }

    IEnumerator Test()
    {
        //Potentially remove Tiles
        foreach(Transform child in TileHolder.transform)
            child.GetComponent<Tile>().Keeper = false;
        
        

        for(int i = 0; i < col * row; i++)
        {
            //Determine new spot
            Vector3 newPos = new Vector3(xStart + (xSpace * (i % col)), yStart + (-ySpace * (i / col)), 0);
            GameObject potentialTile = CheckPositionForObject(newPos.x, newPos.y);
            
            // No Tile already present
            if(potentialTile == null)
            {
                GameObject Tile = Instantiate(tile, TileHolder.transform);
                Tile.transform.position = new Vector3(xStart + (xSpace * (i % col)), yStart + (-ySpace * (i / col)));
            }
            // Tile already there
            else
            {
                potentialTile.GetComponent<Tile>().Keeper = true;
            }
            yield return new WaitForSeconds(1/(col*row));
        }


        //Remove un-overlapped Tiles
        foreach(Transform child in TileHolder.transform)
        {
            if(child.GetComponent<Tile>().Keeper == false)
            {
                Destroy(child.gameObject);
            }
        }
    }

    GameObject CheckPositionForObject(float x, float y)
    {
        Collider[] colliders;
        colliders = Physics.OverlapSphere(new Vector3(x, y, 0), 0.75f);
        //Instantiate(testTarget, new Vector3(x, y, 0), Quaternion.identity);
        foreach(var collider in colliders)
        {
            Debug.Log(collider.gameObject.name + x + " " + y);
            if(collider.gameObject.tag == "Tile")
                return collider.gameObject;
        }
        
        return null;
    }
    
}
