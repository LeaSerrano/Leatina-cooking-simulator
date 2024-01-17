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
    public Material materialOnion;
    public Material materialMushroom;

    private int indexSliceableLayer;
    private string tag;
    private bool hasSliced;

    public AudioClip cutSound;

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
                else if (tag == "Onion") {
                    materialAfterSlice = materialOnion;
                }
                else if (tag == "Mushroom") {
                    materialAfterSlice = materialMushroom;
                }

                SlicedHull slicedObject = SliceObject(isTouchedCollider.gameObject, materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(isTouchedCollider.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(isTouchedCollider.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = isTouchedCollider.transform.position;
                lowerHullGameobject.transform.position = isTouchedCollider.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(isTouchedCollider.gameObject);

                GameObject audioSourceObject = new GameObject("CutSound");
                AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
                audioSource.clip = cutSound;
                audioSource.Play();
                audioSource.volume = 0.5f;

                hasSliced = true;
        }
        else if (hasSliced && isTouchedCollider.gameObject.layer != indexSliceableLayer)
        {
            hasSliced = false;
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
         MeshCollider meshCollider = obj.AddComponent<MeshCollider>();
        meshCollider.convex = true;

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
