using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    void Start()
    {
        RedefineDraggables();
    }
    public void RedefineDraggables()
    {
        foreach(Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
            RedefineDraggables();
    }
    private void OnDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            Debug.Log(currentDistance + " " + snapPoint.transform.name);

            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                Debug.Log("New Closest: " + snapPoint.name);
                closestSnapPoint= snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= snapRange)
        {
            Debug.Log("found it: " + closestSnapPoint.name);
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}
