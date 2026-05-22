using UnityEngine;
using System.Collections;

public class ZonePorteTrigger : MonoBehaviour
{
    [Header("Canvas - Instruction")]
    public GameObject canvas;

    private void Start()
    {
        if (canvas != null)
            canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            StartCoroutine(AfficherCanvasTemporairement());
        }
    }

    IEnumerator AfficherCanvasTemporairement()
    {
        canvas.SetActive(true);

        yield return new WaitForSeconds(5f);

        canvas.SetActive(false);
    }
}