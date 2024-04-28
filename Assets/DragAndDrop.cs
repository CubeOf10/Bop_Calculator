using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static bool TroopMoving = false;
    public Transform tileHolder;
    public float maxDistanceToTile = 0.5f;
    void Start()
    {
        tileHolder = transform.Find("TileHolder");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Beginning");
        TroopMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {

        Debug.Log("Dragging");
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newpos.z = -3f;
        
        transform.position = newpos;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TroopMoving = false;
        Debug.Log("Ended Drag");

        transform.position = FindNearestTile().position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down");
    }

    Transform FindNearestTile()
    {
        float closestTile = 10000f;
        Transform chosenTile = null;
        
        foreach (Transform child in tileHolder)
        {
            float distanceToTile = Vector2.Distance(transform.position, child.position);
            
            //Meets minimum distance threshold and no troop atm in dictionary
            if(distanceToTile < closestTile && tileHolder.GetComponent<TileManager>().TileToTroop[child.gameObject] == null)
            {
                closestTile = distanceToTile;
                chosenTile = child;
            }
        }
        if(chosenTile == null)
            return transform;

        return chosenTile;
    }
}
