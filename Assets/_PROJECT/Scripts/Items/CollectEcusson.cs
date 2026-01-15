using UnityEngine;
using _PROJECT.Scripts.UI; // Nécessaire pour mettre à jour le compteur

namespace _PROJECT.Scripts.Items
{
    /// <summary>
    /// Gère la rotation visuelle et la collecte de l'écusson via Trigger et touche E.
    /// </summary>
    public class CollectEcusson : MonoBehaviour
    {
        [Header("Configuration Visuelle")]
        [SerializeField] private float rotationSpeed = 100f;

        [Header("Configuration Interaction")]
        [SerializeField] private KeyCode interactionKey = KeyCode.E;

        private WorldUIManager _uiManager;

        private void Start()
        {
            // Recherche le manager UI dans la scène pour l'incrémentation du score
            _uiManager = Object.FindFirstObjectByType<WorldUIManager>();
        }

        private void Update()
        {
            // Fait tourner l'objet sur son propre pivot local
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
        }

        /// <summary>
        /// Détection de la présence du joueur et de l'appui sur la touche E.
        /// </summary>
        private void OnTriggerStay(Collider other)
        {
            // Vérifie si l'objet entrant possède le Tag "Player"
            if (other.CompareTag("Player"))
            {
                // Si le joueur est dans la zone et appuie sur E
                if (Input.GetKeyDown(interactionKey))
                {
                    Collect();
                }
            }
        }

        /// <summary>
        /// Exécute la collecte de l'objet. Doit être PUBLIC pour éviter les erreurs CS0122.
        /// </summary>
        public void Collect() 
        {
            if (_uiManager != null)
            {
                _uiManager.AddEcusson();
            }
            
            Debug.Log($"[Items] {gameObject.name} collecté avec succès via la touche {interactionKey}.");
            
            // Détruit la structure complète (Parent + Enfant) pour nettoyer la scène
            if (transform.parent != null) 
            {
                Destroy(transform.parent.gameObject);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}