using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnUnit : MonoBehaviour
{
    public GameObject unitToSpawn;
    public Vector3 spawnPosition;
    GameObject unitHolder;
    void Start()
    {
        unitHolder = GameObject.Find("UnitHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject newUnit = Instantiate(unitToSpawn, unitHolder.transform);
            newUnit.transform.position = spawnPosition; 
        }
    }
}
