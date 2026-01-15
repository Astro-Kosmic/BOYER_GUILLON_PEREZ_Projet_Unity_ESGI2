using UnityEngine;

namespace _PROJECT.Scripts
{
    public class CollectÉcusson : MonoBehaviour
    {
        [SerializeField] private float interactionRadius = 2f;
        
        private bool _isPlayerInRange;
        private readonly Collider[] _hitResults = new Collider[5];

        private void Interact()
        {
            if (_isPlayerInRange) Collect();
        }

        private void Collect()
        {
            Debug.Log("Écusson récupéré.");
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _isPlayerInRange) 
            {
                CheckForInteraction();
            }
        }

        private void CheckForInteraction()
        {
            int numColliders = Physics.OverlapSphereNonAlloc(transform.position, interactionRadius, _hitResults);

            for (int i = 0; i < numColliders; i++)
            {
                if (_hitResults[i].CompareTag("Interaction") && 
                    _hitResults[i].TryGetComponent<CollectÉcusson>(out var script))
                {
                    script.Interact();
                }
            }
        }
    }
}