using UnityEngine;
using _PROJECT.Scripts.Items; // Import du namespace de la pièce

namespace _PROJECT.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Déplacement")]
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float sprintSpeed = 9f;

        [Header("Interaction")]
        [SerializeField] private float interactRange = 2f; // Distance de détection
        [SerializeField] private LayerMask interactableLayer; // Doit être sur "Interaction"

        private Rigidbody _rb;
        private Animator _anim;
        private Vector3 _movement;
        private bool _isFrozen;

        private static readonly int MoveX = Animator.StringToHash("MoveX");
        private static readonly int MoveY = Animator.StringToHash("MoveY");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        // Optimisation : Tableau réutilisable pour éviter les allocations mémoire
        private readonly Collider[] _hitResults = new Collider[5];

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _anim = GetComponentInChildren<Animator>();
            _rb.freezeRotation = true;
        }

        private void Update()
        {
            if (_isFrozen) 
            {
                StopMovement();
                return;
            }

            HandleInput();
            HandleInteraction();
        }

        private void HandleInput()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");
            _movement = new Vector3(moveX, 0f, moveZ).normalized;

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

            if (_movement.magnitude > 0.1f)
            {
                _rb.linearVelocity = new Vector3(_movement.x * currentSpeed, _rb.linearVelocity.y, _movement.z * currentSpeed);
            
                if (_anim != null) 
                {
                    _anim.SetFloat(MoveX, moveX);
                    _anim.SetFloat(MoveY, moveZ); 
                    _anim.SetBool(IsMoving, true);
                }

                if (moveX != 0) GetComponentInChildren<SpriteRenderer>().flipX = moveX > 0;
            }
            else
            {
                StopMovement();
            }
        }

        private void HandleInteraction()
        {
            // Déclenchement par touche
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Détecte les objets sur le Layer spécifique dans un rayon défini
                int numColliders = Physics.OverlapSphereNonAlloc(transform.position, interactRange, _hitResults, interactableLayer);
                
                for (int i = 0; i < numColliders; i++)
                {
                    // Vérifie la présence du script CollectEcusson sur l'objet touché
                    if (_hitResults[i].TryGetComponent<CollectEcusson>(out var ecusson))
                    {
                        ecusson.Collect();
                        break; // On ne ramasse qu'un objet à la fois
                    }
                }
            }
        }

        private void StopMovement()
        {
            _rb.linearVelocity = new Vector3(0f, _rb.linearVelocity.y, 0f);
            if (_anim != null) _anim.SetBool(IsMoving, false);
        }

        public void SetFreeze(bool state)
        {
            _isFrozen = state;
            if (state) StopMovement();
        }
    }
}