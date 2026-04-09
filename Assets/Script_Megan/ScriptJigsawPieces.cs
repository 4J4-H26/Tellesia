//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de placer les pièces sur les emplacements
// lorsque le script des emplacement détercte une collision
// https://www.youtube.com/watch?v=bNBS8ZuzgZo
//------------------------------------------*

using UnityEngine;

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


    void OnMouseUp()
    {
        if (isPlaced) return;

        foreach (var slot in slots)
        {
            if (CompareTag(slot.tag))
            {
                float distance = Vector2.Distance(transform.position, slot.transform.position);

                if (distance < 1.5f)
                {
                    SnapTo(slot.transform.position);
                    return;
                }
            }
        }
    }

    //------------------------------------------*
    // Fonction SnapTo
    //------------------------------------------*
    public void SnapTo(Vector3 position)
    {
        if(isPlaced) return;

        transform.position = position;
        isPlaced = true;

        // Empêcher la pièce de rebouger
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<ScriptJigsawDrag>().enabled = false;

        manager.PiecePlaced();
    }
}
