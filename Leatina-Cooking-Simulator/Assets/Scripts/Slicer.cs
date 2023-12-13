using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    private Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;
    public Material materialTomato;
    public Material materialBread;


    private int indexSliceableLayer;
    private string tag;

    private void Start() {
        string layoutSliceable = "Sliceable";
        indexSliceableLayer = LayerMask.NameToLayer(layoutSliceable);
    }

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                Debug.Log(objectToBeSliced);

                Renderer collisionRenderer = objectToBeSliced.GetComponent<Renderer>();
                tag = objectToBeSliced.tag;

                if (tag == "Tomato") {
                    materialAfterSlice = materialTomato;
                }
                else if (tag == "Bread")
                {
                    materialAfterSlice = materialBread;
                }

                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(objectToBeSliced.gameObject);
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        
        obj.layer = indexSliceableLayer;
        obj.tag = tag;
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
