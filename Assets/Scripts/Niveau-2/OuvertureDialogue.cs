using UnityEngine;

public class OuvertureDialogue : MonoBehaviour
{
    [Header("Canvas de dialogue")]
    public GameObject CanvasDialogue;

    void Start()
    {
        Invoke("OuvertureC", 0.5f);
    }

    void OuvertureC()
    {
        CanvasDialogue.SetActive(true);
    }
}