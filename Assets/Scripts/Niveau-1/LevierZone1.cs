using UnityEngine;

public class LevierZone1 : MonoBehaviour
{
    public rotationleviertuto1 uiLevier; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            uiLevier.SetLevierActif(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            uiLevier.SetLevierActif(null);
        }
    }
}