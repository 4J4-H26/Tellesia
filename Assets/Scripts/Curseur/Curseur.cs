// script pour le curseur qui survol le bouton des dialogues
// auteur : sammuel
// date :07 avril 2026

// desc : ** un curseur qui est personnalisé..
//           lors du survol sur le bouton pour
//           passer à une dialogue suivante **

using UnityEngine;
using UnityEngine.EventSystems;

public class Curseur : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // ** on déclare les variabes 
        [Header("Texture")]
        public Texture2D cursorTexture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}