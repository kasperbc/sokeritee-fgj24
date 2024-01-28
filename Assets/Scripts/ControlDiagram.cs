using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDiagram : MonoBehaviour
{
    private bool visible;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        visible = !visible;

        GetComponent<Image>().enabled = visible;
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(visible);
    }
}
