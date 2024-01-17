using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMeat : MonoBehaviour
{
    public AudioClip cookSound;
    private Dictionary<GameObject, bool> etatCuissonSteaks = new Dictionary<GameObject, bool>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meat") && GlobalVariables.hotPan)
        {
            if (!etatCuissonSteaks.ContainsKey(other.gameObject))
            {
                etatCuissonSteaks.Add(other.gameObject, false);
            }

            if (!etatCuissonSteaks[other.gameObject]) {
                Debug.Log("la viande cuit");
                
                StartCoroutine(CookAndDarkenMeat(other.gameObject));
                etatCuissonSteaks[other.gameObject] = true;
            }
        }
    }

    private IEnumerator CookAndDarkenMeat(GameObject meatObject)
    {
        GameObject audioSourceObject = new GameObject("CookSound");
        AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = cookSound;
        audioSource.Play();

        yield return new WaitForSeconds(5f);

        audioSource.Stop();
        Destroy(audioSourceObject);

        Renderer rend = meatObject.GetComponent<Renderer>();

        if (rend != null)
        {
            Color currentColor = rend.material.color;

            float darkenFactor = 0.9f;
            Color darkenedColor = new Color(currentColor.r * darkenFactor, currentColor.g * darkenFactor, currentColor.b * darkenFactor, currentColor.a);

            rend.material.color = darkenedColor;

            Debug.Log("la viande a changé de couleur");
        }
    }

    public bool EstSteakCuit(GameObject steak)
    {
        if (etatCuissonSteaks.ContainsKey(steak))
        {
            return etatCuissonSteaks[steak];
        }
        else
        {
            return false;
        }
    }
}
