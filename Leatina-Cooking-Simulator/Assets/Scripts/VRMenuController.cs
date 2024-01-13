using UnityEngine;

public class VRMenuController : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            ToggleMenu();
        }

    }


    private void ToggleMenu()
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
