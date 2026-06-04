using UnityEngine;
using UnityEngine.EventSystems;

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