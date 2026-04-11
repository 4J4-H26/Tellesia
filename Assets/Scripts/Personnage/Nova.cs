// script pour le perso de Nova 
// auteur : sammuel
// date : 21 Mars 2026

// desc : ** Nova **

using UnityEngine;

public class Nova : MonoBehaviour
{

    [Header("réf`à la carte")]
    public bool contientLaCarte = false;

    [Header("Déplacement")]
    public float vitesse = 2f;

    [Header("UI Puzzle")]

    [Header("Résultat du Tuto")]
    public ResultatTutoriel resultatTuto;

    [Header("Rotation")]
    public float vitesseRotation = 360f;


    [Header("Les leviers")]
    public GameObject LevierDeCommande1;
    public GameObject LevierDeCommande2;
    public GameObject LevierDeCommande3;


    [Header("LaPorte")]
    public GameObject Porte;
    public Animator porteAnim;

    private bool canMove = true;
    private Vector3 direction;
    private GameObject carteProche;
    private Animator anim;
    private Transform cam;
    private Rigidbody rb;

    private bool aDejaTouche = false;
    private bool aDejaTouche2 = false;
    private bool aDejaTouche3 = false;

    public bool animationToucherTerminee { get; private set; }

    private bool autoMove = false;
    private bool porteOuverte = false;
    private bool enSortie = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        anim.applyRootMotion = false;

        if (porteAnim == null)
        {
            Porte = GameObject.FindGameObjectWithTag("porte-niveau1-anim");

            if (Porte != null)
            {
                porteAnim = Porte.GetComponent<Animator>();
            }
        }
    }
    void Update()
    {
        if (enSortie) return;


        bool tousReussis =
           LevierDeCommande1.CompareTag("reussit") &&
           LevierDeCommande2.CompareTag("reussit") &&
           LevierDeCommande3.CompareTag("reussit");

        if (tousReussis && !porteOuverte && porteAnim != null)
        {
            porteOuverte = true;
            porteAnim.SetTrigger("Ouvrir");
        }


        bool estEnTrainDeToucher = anim.GetCurrentAnimatorStateInfo(0).IsName("toucher");

        if (!canMove || estEnTrainDeToucher)
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
        bool estEnTrainDeToucher = anim.GetCurrentAnimatorStateInfo(0).IsName("toucher");

        if (estEnTrainDeToucher) return;

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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZoneLevierDeCommande1") && !aDejaTouche)
        {
            aDejaTouche = true;
            TriggerTouch();
        }

        if (collision.gameObject.CompareTag("ZoneLevierDeCommande2") && !aDejaTouche2)
        {
            aDejaTouche2 = true;
            TriggerTouch();
        }

        if (collision.gameObject.CompareTag("ZoneLevierDeCommande3") && !aDejaTouche3)
        {
            aDejaTouche3 = true;
            TriggerTouch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("porte-niveau1")) return;

        bool tousReussis =
            LevierDeCommande1.CompareTag("reussit") &&
            LevierDeCommande2.CompareTag("reussit") &&
            LevierDeCommande3.CompareTag("reussit");

        Debug.Log("Porte touchée + check levier = " + tousReussis);

        if (tousReussis)
        {
            enSortie = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZoneLevierDeCommande1"))
            aDejaTouche = false;

        if (collision.gameObject.CompareTag("ZoneLevierDeCommande2"))
            aDejaTouche2 = false;

        if (collision.gameObject.CompareTag("ZoneLevierDeCommande3"))
            aDejaTouche3 = false;
    }

    void TriggerTouch()
    {
        animationToucherTerminee = false;
        anim.SetTrigger("toucher");
    }


    public void ResetToucher()
    {
        animationToucherTerminee = false;
    }

}
