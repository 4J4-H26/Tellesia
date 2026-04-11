//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de déplacer les pièces du puzzle jisaw avec la souris
// https://youtube.com/watch?v=o_qEXZhQR-M&source_ve_path=MjM4NTE&embeds_referring_euri=https%3A%2F%2Fchatgpt.com%2F
//------------------------------------------*

using UnityEngine;

public class ScriptJigsawDrag : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    private Vector3 offset;
    private bool dragging = false;
    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction OnMouseDown
    // Description : Cette fonction permet de bouger la pièce
    // lorsqu'on est entrain de cliquer avec la souris
    //------------------------------------------*
    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        dragging = true;
    }

    //------------------------------------------*
    // Fonction OnMouseUp
    // Description : Cette fonction permet d'arrêter de bouger 
    // la pièce quand on lâche la souris
    //------------------------------------------*
    void OnMouseUp()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    //Suivre la souris
    Vector3 GetMouseWorldPos()
    {
        Vector3 mouse = Input.mousePosition;

        mouse.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mouse);
    }
}
