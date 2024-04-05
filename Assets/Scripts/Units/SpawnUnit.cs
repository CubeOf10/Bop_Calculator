using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class SpawnUnit : MonoBehaviour
{
    public List<GameObject> UnitList;
    GameObject unitHolder;
    void Start()
    {
        unitHolder = GameObject.Find("UnitHolder");
    }

    public void CreateUnit(string chosenName, int x, int y, int z)//, Vector3 spawnPos)
    {
        foreach(GameObject troop in UnitList)
        {
           
            if(troop.name == chosenName)
            {
                GameObject newTroop = Instantiate(troop, unitHolder.transform);
                newTroop.transform.position = new Vector3(x, y, z);
            }
        }
    }

    public void TestButtons(int yes, int no)
    {
        Debug.Log(yes + no);
    }
}

