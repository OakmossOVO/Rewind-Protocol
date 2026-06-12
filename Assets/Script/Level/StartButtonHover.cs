using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Purpose:
 * Shows or hides status text when the start button is hovered.
 *
 * Attached GameObject:
 * UI start button GameObject with pointer event handling enabled.
 *
 * Main responsibilities:
 * Detect pointer enter and exit events and toggle the assigned status text object.
 *
 * Inputs:
 * Pointer enter and pointer exit events, plus the status text GameObject reference.
 *
 * Outputs or effects:
 * Activates or deactivates the status text GameObject.
 *
 * Authorship or assistance:
 * Project script maintained with AI assistance for documentation comments.
 *
 * Testing notes:
 * Test mouse hover enter and exit on the start button, including missing or inactive status text references.
 */
public class StartButtonHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public GameObject statusText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        statusText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        statusText.SetActive(false);
    }
}
