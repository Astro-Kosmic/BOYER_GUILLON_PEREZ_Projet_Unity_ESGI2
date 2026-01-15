using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Déplacement")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 9f;
    [SerializeField] private float smoothTime = 0.1f;

    [Header("Interaction")]
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask interactableLayer;

    private Rigidbody rb;
    private Animator anim;
    private Vector3 movement;
    private bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Récupère l'animateur sur l'enfant "Visual"
        anim = GetComponentInChildren<Animator>();
        
        // Sécurité : Vérifie les contraintes du Rigidbody
        rb.freezeRotation = true; 
    }

    void Update()
    {
        // Si le menu est actif ou si un PNJ nous freeze
        if (isFrozen) 
        {
            StopMovement();
            return;
        }

        HandleInput();
        HandleInteraction();
    }

    private void HandleInput()
    {
        // Lecture des axes (Z pour vertical, X pour horizontal)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveX, 0f, moveZ).normalized;

        // Gestion de l'accélération (Shift)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        if (movement.magnitude > 0.1f)
        {
            // Applique la vélocité en conservant la gravité Y
            rb.linearVelocity = new Vector3(movement.x * currentSpeed, rb.linearVelocity.y, movement.z * currentSpeed);
            
            // Met à jour l'animateur sur le Visual
            if (anim != null) anim.SetFloat("Speed", currentSpeed);
        }
        else
        {
            StopMovement();
        }
    }

    private void HandleInteraction()
    {
        // Déclenche l'interaction avec la touche E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, interactRange, interactableLayer);
            foreach (var target in targets)
            {
                Debug.Log("Objet ramassé : " + target.name);
                // Logique pour détruire l'objet ou l'ajouter à l'inventaire
                // Destroy(target.gameObject);
            }
        }
    }

    private void StopMovement()
    {
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        if (anim != null) anim.SetFloat("Speed", 0f);
    }

    // Fonction publique pour freezer le perso depuis un autre script (PNJ ou Menu)
    public void SetFreeze(bool state)
    {
        isFrozen = state;
        if (state) StopMovement();
    }
}