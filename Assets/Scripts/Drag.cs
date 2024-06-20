using System.Collections;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    private Vector3 initialPosition;

    private GameObject dropZoneOne;
    private GameObject dropZoneTwo;

    void Start()
    {
        dropZoneOne = GameObject.Find("shelf_one");
        dropZoneTwo = GameObject.Find("shelf_two");
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        initialPosition = transform.position;
    }

    void OnMouseUp()
    {
        dragging = false;
        if (!IsWithinDropZone(transform.position, dropZoneOne) && !IsWithinDropZone(transform.position, dropZoneTwo))
        {
            transform.position = initialPosition;
        }
        else
        {
            Debug.Log("not a valid zone");
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }

    private bool IsWithinDropZone(Vector3 position, GameObject dropZone)
    {
        Collider2D collider = dropZone.GetComponent<Collider2D>();
        bool withinBounds = collider.OverlapPoint(position);
        return withinBounds;
    }
}
