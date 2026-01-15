using UnityEngine;
using _PROJECT.Scripts.UI;

namespace _PROJECT.Scripts.Items
{
    public class CollectEcusson : MonoBehaviour
    {
        [Header("Paramètres Visuels")]
        [SerializeField] private float rotationSpeed = 100f;

        private WorldUIManager _uiManager;

        private void Start()
        {
            // Recherche du manager d'interface dans la scène
            _uiManager = Object.FindFirstObjectByType<WorldUIManager>();
        }

        private void Update()
        {
            // Rotation locale pour garantir un pivot correct
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
        }

        private void OnTriggerEnter(Collider other)
        {
            // Ramassage automatique si le joueur passe dessus
            if (other.CompareTag("Player"))
            {
                Collect();
            }
        }

        // Mis en PUBLIC pour être accessible par PlayerMovement
        public void Collect() 
        {
            if (_uiManager != null)
            {
                _uiManager.AddEcusson();
            }
            
            Debug.Log("Ecusson collecté avec succès.");
            Destroy(gameObject);
        }
    }
}