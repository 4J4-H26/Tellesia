using UnityEngine;

public class ZoneSalleTrigger : MonoBehaviour
{
    public ScriptDialogue5 dialogue;
    private bool dejaFait = false;

    private void OnTriggerEnter(Collider other)
    {
        if (dejaFait) return;

        if (other.CompareTag("Nova"))
        {
            dejaFait = true;
            dialogue.ReprendreDialogueDepuisZoneSalle();
        }
    }
}