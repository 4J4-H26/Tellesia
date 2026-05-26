// script pour le perso de Nova niveau 3
// auteur : sammuel
// date : 10 Mai 2026

// desc : ** Nova **

using UnityEngine;

public class Nova3 : MonoBehaviour
{
    [Header("Déplacement")]
    public float vitesse = 3.2f;

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

    [Header("LaPorte")]
    public AudioSource sonMarche;

    public bool puzzleActif = false;
    private bool forceStopMove = false;
    private bool enSortie = false;

    [Header("Puzzle 4")]
    public Puzzle4QuestionSurLHistoire puzzle;

    [Header("Levier")]
    public ScriptRobotLevier scriptLevier;

    private bool procheSpeaker = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        anim.applyRootMotion = false;

    }

    void Update()
    {
        if (enSortie) return;

        if (procheSpeaker && Input.GetKeyDown(KeyCode.E))
        {
            SetCanMove(false);
            Invoke("OuvrirLeCanvas", 0.5f);
        }


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

        bool canPlayFootstep =
          canMove &&
          direction.sqrMagnitude > 0.01f;

        GererSonMarche(canPlayFootstep);
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Speaker"))
        {
            procheSpeaker = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Speaker"))
        {
            procheSpeaker = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("portesortieniveau3"))
            return;

        if (scriptLevier == null || !scriptLevier.animationTerminee)
            return;

        enSortie = true;
    }

    void OuvrirLeCanvas()
    {

        if (puzzle != null)
            puzzle.OuvrirPuzzle();

        if (sonMarche != null && sonMarche.isPlaying)
            sonMarche.Stop();
    }


    void GererSonMarche(bool estEnMarche)
    {
        if (sonMarche == null) return;

        if (!estEnMarche || forceStopMove)
        {
            if (sonMarche.isPlaying)
                sonMarche.Stop();

            return;
        }

        sonMarche.pitch = 1.5f;

        if (!sonMarche.isPlaying)
            sonMarche.Play();
    }
}