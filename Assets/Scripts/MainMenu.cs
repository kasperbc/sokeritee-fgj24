using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject camera;
    public Button[] buttons;
    private bool _entered = false;

    public void Start() {
        foreach (var button in buttons) {
            button.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData evetData)
    {
        if (!_entered)
        {
            _entered = true;
            camera.GetComponent<AnimationController>().PlayAnimation();
            foreach (var button in buttons) {
                button.enabled = true;
            }
        } 
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
