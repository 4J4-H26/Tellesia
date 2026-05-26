using UnityEngine;
using System.Collections;

public class ZoneLevierRobotTrigger : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject canvas1;
    public GameObject canvas2;

    private bool playerInZone = false;
    private bool canInteract = false;

    private Coroutine routine;

    private bool canvas1Used = false;
    private bool canvas2Used = false;

    public GameObject ZonePermission;

    private void Start()
    {
        if (canvas1 != null) canvas1.SetActive(false);
        if (canvas2 != null) canvas2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            playerInZone = true;

            if (!canvas1Used && routine == null)
            {
                routine = StartCoroutine(ShowCanvas1Temporarily());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            playerInZone = false;
            canInteract = false;

            if (canvas1 != null) canvas1.SetActive(false);
            if (canvas2 != null) canvas2.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInZone && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (!canvas2Used)
            {
           
                if (canvas1 != null)
                    canvas1.SetActive(false);

                if (canvas2 != null)
                    canvas2.SetActive(true);

                canvas2Used = true;
            }
        }
    }
    public void FermerCanvas2()
    {
        if (canvas2 != null)
            canvas2.SetActive(false);

        if (ZonePermission != null)
            ZonePermission.SetActive(false);
    }

    private IEnumerator ShowCanvas1Temporarily()
    {
        canvas1Used = true;

        if (canvas1 != null)
            canvas1.SetActive(true);

        canInteract = false; 

        yield return new WaitForSeconds(3f);

        if (canvas1 != null)
            canvas1.SetActive(false);

        canInteract = true; 
    }
}