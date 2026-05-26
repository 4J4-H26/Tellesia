using UnityEngine;

public class ZoneScriptElement5 : MonoBehaviour
{
    public ScriptDialogue3 dialogue;

    private bool dejaActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (dejaActive)
            return;

        if (other.CompareTag("Nova"))
        {
            dejaActive = true;

            dialogue.ReprendreDepuisElement5();
        }
    }
}