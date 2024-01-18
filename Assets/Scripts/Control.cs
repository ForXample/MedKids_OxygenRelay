using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private Transform originalParent; // To store the original parent of the shape

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
        originalParent = transform.parent; // Store the original parent
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            transform.SetParent(other.transform);
            Debug.Log("Moving in.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Package"))
        {
            //transform.SetParent(null); // Or set to original parent if needed
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
        transform.SetParent(null); // Detach from the parent
    }
    
    void OnMouseUp()
    {
        isDragging = false;
        //transform.SetParent(originalParent); // Re-attach to the original parent, if necessary
    }
    
    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        // Convert mouse screen position to world position
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}

