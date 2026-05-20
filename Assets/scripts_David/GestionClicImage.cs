using UnityEngine;
using UnityEngine.UI;

public class GestionClicImage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Récupère le composant Image
        Image img = GetComponent<Image>();

        img.alphaHitTestMinimumThreshold = 0.5f;

        // Debug.Log("caca");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
