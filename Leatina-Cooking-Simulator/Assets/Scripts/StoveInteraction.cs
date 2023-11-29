using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject button;
    GameObject fire;
        
    void Start()
    {
        button = GameObject.Find("Stove-KnobLeft1");
        fire = GameObject.Find("Fire");
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float rotationZ = button.transform.rotation.eulerAngles.z;
        // Debug.Log("Rotation Z du 'Stove-KnobLeft1': " + rotationZ);
        if (rotationZ == 90){
            GlobalVariables.heatOn = true;
            fire.SetActive(true);
        }else{
            GlobalVariables.heatOn = false;
            fire.SetActive(false);
        }
    }
}
