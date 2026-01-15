using UnityEngine;
using System.Collections;
using _PROJECT.Scripts.Player;

namespace _PROJECT.Scripts.PNJ

{
    // Le nom de la classe est maintenant NpcAI pour correspondre au nom du fichier NpcAI.cs
    public class NpcAI : MonoBehaviour
    {
        [Header("Mouvement Aléatoire")]
        [SerializeField] private float walkRadius = 5f;
        [SerializeField] private float waitTime = 3f;
        [SerializeField] private float speed = 2f;

        [Header("Poursuite")]
        [SerializeField] private float followSpeed = 3.5f;
        [SerializeField] private float stopDistance = 1.2f;

        private Vector3 _targetPoint;
        private Transform _playerTransform;
        private bool _isFollowing; 
        private bool _isWaiting;
        private Animator _anim;

        // Optimisation de la performance pour l'Animator
        private static readonly int MoveX = Animator.StringToHash("MoveX");
        private static readonly int MoveY = Animator.StringToHash("MoveY");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        void Start()
        {
            // Récupération de l'animator sur l'enfant "Visual"
            _anim = GetComponentInChildren<Animator>();
            SetNewRandomTarget();
        }

        void Update()
        {
            // Vérification directe de l'objet (plus performant)
            if (_isFollowing && _playerTransform)
            {
                HandleFollow();
            }
            else if (!_isWaiting)
            {
                HandlePatrol();
            }
        }

        private void HandlePatrol()
        {
            float dist = Vector3.Distance(transform.position, _targetPoint);
            
            if (dist > 0.2f)
            {
                MoveTo(_targetPoint, speed);
            }
            else
            {
                StartCoroutine(WaitBeforeNextPoint());
            }
        }

        private void HandleFollow()
        {
            float dist = Vector3.Distance(transform.position, _playerTransform.position);

            if (dist > stopDistance)
            {
                MoveTo(_playerTransform.position, followSpeed);
            }
            else
            {
                StopMovement();
            }
        }

        private void MoveTo(Vector3 target, float currentSpeed)
        {
            Vector3 dir = (new Vector3(target.x, transform.position.y, target.z) - transform.position).normalized;
            // Optimisation de l'ordre des multiplications
            transform.position += dir * (currentSpeed * Time.deltaTime);

            if (_anim)
            {
                _anim.SetFloat(MoveX, dir.x);
                _anim.SetFloat(MoveY, dir.z);
                _anim.SetBool(IsMoving, true);
            }
        }

        private void SetNewRandomTarget()
        {
            Vector2 randomPoint = Random.insideUnitCircle * walkRadius;
            _targetPoint = transform.position + new Vector3(randomPoint.x, 0, randomPoint.y);
        }

        private IEnumerator WaitBeforeNextPoint()
        {
            _isWaiting = true;
            if (_anim) _anim.SetBool(IsMoving, false);
            yield return new WaitForSeconds(waitTime);
            SetNewRandomTarget();
            _isWaiting = false;
        }

        private void StopMovement()
        {
            if (_anim) _anim.SetBool(IsMoving, false);
    
            // Optionnel : Relancer le mouvement du joueur après 3 secondes de dialogue
            StartCoroutine(ReleasePlayerAfterDelay(3f));
        }

        private IEnumerator ReleasePlayerAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
    
            // On cherche le joueur pour le libérer
            if (_playerTransform)
            {
                PlayerMovement pMove = _playerTransform.GetComponent<PlayerMovement>();
                if (pMove) pMove.SetFreeze(false);
            }
    
            // Le PNJ reprend sa patrouille aléatoire
            _isFollowing = false;
            SetNewRandomTarget();
        }

        private void OnTriggerEnter(Collider other)
        {
            // 1. Vérifie si l'objet entrant est le joueur via son Tag
            if (other.CompareTag("Player")) 
            {
                _playerTransform = other.transform;
                _isFollowing = true;
                _isWaiting = false;

                // 2. Coupe la patrouille aléatoire immédiatement
                StopAllCoroutines(); 

                // 3. Immobilise le joueur via son propre script
                PlayerMovement pMove = other.GetComponent<PlayerMovement>();
                if (pMove) pMove.SetFreeze(true);
        
                Debug.Log("Poursuite activée !");
            }
        }
    }
}