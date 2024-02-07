using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChildMesh : MonoBehaviour
{
private MeshRenderer childMeshRenderer;

    void Start()
    {
        // Get the child MeshRenderer component
        childMeshRenderer = GetComponentInChildren<MeshRenderer>();

    
    }

    void Update()
    {
        // Check if the parent's MeshRenderer is active
        if (transform.parent != null && transform.parent.GetComponent<MeshRenderer>() != null)
        {
            bool parentMeshRendererActive = transform.parent.GetComponent<MeshRenderer>().enabled;

            // Toggle the child's MeshRenderer based on the parent's state
            if (childMeshRenderer != null)
            {
                childMeshRenderer.enabled = parentMeshRendererActive;
            }
        }
    }
}