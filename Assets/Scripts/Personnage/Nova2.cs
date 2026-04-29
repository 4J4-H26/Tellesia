// script pour le perso de Nova niveau 2
// auteur : sammuel
// date : 21 Avril 2026

// desc : ** Nova **

using UnityEngine;

public class Nova2 : MonoBehaviour
{
    [Header("Déplacement")]
    public float vitesse = 2f;

    [Header("Rotation")]
    public float vitesseRotation = 360f;

    private bool canMove = true;
    private Vector3 direction;
    private Animator anim;
    private Transform cam;
    private Rigidbody rb;

    private bool autoMove = false;

    [Header("Canvas Question sur l'histoire")]
    public GameObject CanvasQuestion;

    private bool dejaActive = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        anim.applyRootMotion = false;
    }

    void Update()
    {
        if (!canMove)
        {
            anim.SetBool("enMarche", false);
            direction = Vector3.zero;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        direction = (forward * vertical + right * horizontal).normalized;

        bool estEnMarche = direction.sqrMagnitude > 0.01f;
        anim.SetBool("enMarche", estEnMarche);

        if (estEnMarche)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                vitesseRotation * Time.deltaTime
            );
        }
    }

    void FixedUpdate()
    {
        if (autoMove)
        {
            Vector3 move = transform.forward * vitesse * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
            anim.SetBool("enMarche", true);
            return;
        }

        if (!canMove) return;

        Vector3 moveNormal = direction * vitesse * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + new Vector3(moveNormal.x, 0, moveNormal.z));
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public bool IsMovementLocked()
    {
        return !canMove;
    }

    public void ActiverAutoMove()
    {
        canMove = false;
        autoMove = true;
        anim.SetTrigger("Sortie");
        FindFirstObjectByType<ChangementCam>().ActiverCameraCinematique();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Speaker") && !dejaActive)
        {
           SetCanMove(false);
            Invoke("OuvrirLeCanvas", 0.5f);
        }
    }

    void OuvrirLeCanvas()
    {
        dejaActive = true;
        CanvasQuestion.SetActive(true);
    }
}