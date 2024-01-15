using UnityEngine;
using EzySlice;
using UnityEngine.XR.Interaction.Toolkit;

public class Slicer : MonoBehaviour
{
    private Material materialAfterSlice;
    public LayerMask sliceMask;

    public bool isTouched;
    public Collider isTouchedCollider;

    public Material materialTomato;
    public Material materialBread;


    private int indexSliceableLayer;
    private string tag;
    private bool hasSliced;

    private void Start() {
        string layoutSliceable = "Sliceable";
        indexSliceableLayer = LayerMask.NameToLayer(layoutSliceable);

        hasSliced = false;
    }

    private void Update()
    {

        if (isTouched == true && !hasSliced && isTouchedCollider.gameObject.layer == indexSliceableLayer && isTouchedCollider!=null)
        {
                isTouched = false;


                tag = isTouchedCollider.tag;

                if (tag == "Tomato")
                {
                    materialAfterSlice = materialTomato;
                }
                else if (tag == "Bread")
                {
                    materialAfterSlice = materialBread;
                }

                SlicedHull slicedObject = SliceObject(isTouchedCollider.gameObject, materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(isTouchedCollider.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(isTouchedCollider.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = isTouchedCollider.transform.position;
                lowerHullGameobject.transform.position = isTouchedCollider.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(isTouchedCollider.gameObject);

                hasSliced = true;
        }
        else if (hasSliced && isTouchedCollider.gameObject.layer != indexSliceableLayer && isTouchedCollider!=null)
        {
            hasSliced = false;
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        
        obj.layer = indexSliceableLayer;
        obj.tag = tag;

        XRGrabInteractable grabInteractableComponent = obj.AddComponent<XRGrabInteractable>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

}
