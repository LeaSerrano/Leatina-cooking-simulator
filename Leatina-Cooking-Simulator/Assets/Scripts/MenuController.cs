using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class MenuController : MonoBehaviour
{
    public Transform handTransform;
    private bool isMenuActive = false;

    void Update()
    {
        /*if (OpenXRInput.GetActionHandle(OpenXRDevice.)
        {
            isMenuActive = !isMenuActive;
            SetMenuActive(isMenuActive);

            Debug.Log("bouton appuyé");
        }*/

        if (isMenuActive)
        {
            transform.position = handTransform.position;
            transform.rotation = handTransform.rotation;
        }
    }

    void SetMenuActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
