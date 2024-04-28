using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Dictionary<GameObject, GameObject> TileToTroop = new Dictionary<GameObject, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        UpdateDict();
    }

    public void UpdateDict()
    {
        foreach(Transform child in transform)
        {
            TileToTroop.Add(child.gameObject, null);
        }
    }
}
