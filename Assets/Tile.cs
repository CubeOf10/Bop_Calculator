using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Keeper = true;
    SpriteRenderer SR;
    public List<Color> colours;
    public int tileType = 0;
    public enum TileType 
    {
        PLAINS,
        COAST,
        FOREST,
        MOUNTAIN,
        OCEAN,
        ALGAE,
        FUNGUS
    }
    void Start()
    {        
        SR = GetComponent<SpriteRenderer>();
        ChangeColour(tileType);
    }
    void OnMouseUp()
    {
        if(!DragAndDrop.TroopMoving)
        {    
            tileType++;
            if(tileType > 6)
                tileType = 0;

            ChangeColour(tileType);
        }
    }
    void Update()
    {
        
        
 
    }

    void ChangeColour(int type)
    {
        SR.color = colours[type];
    }
}
