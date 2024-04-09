using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public int testX, testY;

    public float xStart, yStart;
    public int col = 3;
    public int row = 3;
    public float xSpace, ySpace;
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CheckPositionForObject(testX, testY);
        }
        
    }

    public void CreateGrid()
    {
        for(int i = 0; i < col * row; i++)
        {
            Instantiate(tile, new Vector3(xStart + (xSpace * (i % col)), yStart + (-ySpace * (i / col))), Quaternion.identity);
        }
    }

    void CheckPositionForObject(int x, int y)
    {
        Collider[] colliders;
        if((colliders = Physics.OverlapSphere(new Vector3(x, y, 0), 1f)).Length > 0)
        {
            foreach(var collider in colliders)
            {
                Debug.Log(collider.gameObject.name);
            }
        }
    }
}
