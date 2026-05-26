//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de placer les pièces sur les emplacements
// lorsque la position de celle-ci est moins que 1.5f (elle se snap) et 
// ensuite la pièce ne peut plus bouger, et on incrémente le nombre
// de pièce placée avec la fonction PiecePlaced() du script jigsawFin
// https://www.youtube.com/watch?v=bNBS8ZuzgZo
//------------------------------------------*

using UnityEngine;
using UnityEngine.UI;

public class ScriptJigsawPieces : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    private bool isPlaced = false;

    public ScriptJigsawFin manager;

    private ScriptJigsawEmplacement[] slots;

    void Start()
    {
        slots = FindObjectsOfType<ScriptJigsawEmplacement>();
    }

    //------------------------------------------*
    // FONCTION
    //------------------------------------------*

    //------------------------------------------*
    // Fonction OnMouseUp
    // Description : Cette fonction permet de comparer les tags
    // des emplacement avec le numéro de la pièce pour ensuite
    // activer la fonction SnapTo si la pièce est la bonne et
    // qu'elle est proche
    //------------------------------------------*
    void OnMouseUp()
    {
        if (isPlaced) return;

        foreach (var slot in slots)
        {
            if (CompareTag(slot.tag))
            {
                float distance = Vector2.Distance(transform.position, slot.transform.position);

                if (distance < 3f)
                {
                    SnapTo(slot.transform.position);
                    return;
                }
            }
        }
    }

    //------------------------------------------*
    // Fonction SnapTo
    // Description : Cette fonction permet de placer la pièce
    // à la position de l'emplacement qui correspond et l'empêcher
    // de rebouger ensuite (et la met devant l'emplacement)
    //------------------------------------------*
    public void SnapTo(Vector3 position)
    {
        if(isPlaced) return;

        transform.position = position;
        isPlaced = true;

        // Met la pièce devant l'emplacement
        GetComponent<SpriteRenderer>().sortingOrder = 10;

        // Empêcher la pièce de rebouger
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<ScriptJigsawDrag>().enabled = false;

        manager.PiecePlaced();
    }
}
