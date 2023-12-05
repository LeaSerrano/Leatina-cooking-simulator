using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public Slicer slicer;

    void Start() {
        Renderer slicerRenderer = slicer.GetComponent<Renderer>();

        if (slicerRenderer != null) {
            slicerRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
    }
}
