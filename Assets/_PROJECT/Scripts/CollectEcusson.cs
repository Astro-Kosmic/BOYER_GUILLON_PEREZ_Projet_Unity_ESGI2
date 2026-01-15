using UnityEngine;

namespace _PROJECT.Scripts
{
    public class CollectEcusson : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private float interactionRadius = 2f;
        
        [Header("Visual Animation")]
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private float floatAmplitude = 0.2f;
        [SerializeField] private float floatFrequency = 1f;

        private bool _isPlayerInRange;
        private Vector3 _startPos;
        private readonly Collider[] _hitResults = new Collider[5];

        private void Start()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            AnimateVisual();

            if (Input.GetKeyDown(KeyCode.E) && _isPlayerInRange) 
            {
                CheckForInteraction();
            }
        }

        private void AnimateVisual()
        {
            // Rotation sur l'axe Y
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Mouvement de lévitation (Sinus)
            float newY = _startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = new Vector3(_startPos.x, newY, _startPos.z);
        }

        private void Interact()
        {
            if (_isPlayerInRange) Collect();
        }

        private void Collect()
        {
            Debug.Log("Ecusson recupere.");
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) _isPlayerInRange = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) _isPlayerInRange = false;
        }

        private void CheckForInteraction()
        {
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, interactionRadius, _hitResults);

            for (int i = 0; i < numColliders; i++)
            {
                if (_hitResults[i].CompareTag("Interactable") && 
                    _hitResults[i].TryGetComponent<CollectEcusson>(out var script))
                {
                    script.Interact();
                }
            }
        }
    }
}