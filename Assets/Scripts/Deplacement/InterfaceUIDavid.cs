// script pour les apparitions des interfaces de David
// auteur : sammuel
// date : 18 Avril 2026

// desc : ** Interfaces UI **

using UnityEngine;

public class InterfaceUIDavid : MonoBehaviour
{

    [Header("Canvas WASD")]
    public GameObject CanvasTouchesWASD;

    [Header("Canvas Touche E")]
    public GameObject CanvasToucheE;

    private bool interface1DejaActivee = false;
    private bool interface2DejaActivee = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Nova")) return;

        if (gameObject.CompareTag("interface1"))
        {

            if (interface1DejaActivee)
                return;

            interface1DejaActivee = true;

            Invoke("ApparitionWASD", 0.3f);
        }

        if (gameObject.CompareTag("interface2"))
        {
            if (interface2DejaActivee)
                return;

            interface2DejaActivee = true;

            CanvasTouchesWASD.SetActive(false);
            CanvasToucheE.SetActive(true);

            Invoke("MettreFalse", 10f);
        }
    }

    void ApparitionWASD()
    {
        CanvasTouchesWASD.SetActive(true);
    }
    void MettreFalse()
    {
        CanvasToucheE.SetActive(false);
    }
}