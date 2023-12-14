using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hotPan: "+GlobalVariables.hotPan);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fire")
        {
            Debug.Log("Collision avec la plaque !");
            GlobalVariables.hotPan = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Fire")
        {
            Debug.Log("Le GameObject n'est plus en collision avec la plaque.");
            GlobalVariables.hotPan = false;
        }
    }
}
