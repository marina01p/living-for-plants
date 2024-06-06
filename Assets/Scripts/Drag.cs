using System.Collections;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    private Vector3 initialPosition;

    public GameObject dropZoneOne;
    public GameObject dropZoneTwo;

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown called");
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        initialPosition = transform.position; // Store the initial position
    }

    void OnMouseUp()
    {
        Debug.Log("OnMouseUp called");
        dragging = false;
        // Check if the object is within any of the drop zones
        if (!IsWithinDropZone(transform.position, dropZoneOne) && !IsWithinDropZone(transform.position, dropZoneTwo))
        {
            Debug.Log("Dropped outside valid zones, returning to initial position");
            // If not, reset to initial position
            transform.position = initialPosition;
        }
        else
        {
            Debug.Log("Dropped inside a valid zone");
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
        if (dropZone == null)
        {
            Debug.LogError("Drop zone not assigned.");
            return false;
        }

        Collider2D collider = dropZone.GetComponent<Collider2D>();
        if (collider == null)
        {
            Debug.LogError("Drop zone does not have a Collider2D component.");
            return false;
        }
        bool withinBounds = collider.bounds.Contains(position);
        Debug.Log("Checking position: " + position + " within bounds of " + dropZone.name + ": " + withinBounds);
        return withinBounds;
    }
}
