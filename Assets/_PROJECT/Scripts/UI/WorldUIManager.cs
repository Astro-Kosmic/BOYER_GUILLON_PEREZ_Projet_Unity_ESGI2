using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

// Correction du Namespace pour correspondre au dossier physique
namespace _PROJECT.Scripts.UI
{
    public class WorldUIManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private GameObject sideMenuPanel;
        [SerializeField] private CanvasGroup sideMenuCanvasGroup;

        // "Suggested name is '_isMenuOpen'"
        // "Initializing field by default value is redundant" (false par défaut)
        private bool _isMenuOpen;
        
        [Header("Collectibles")]
        [SerializeField] private TextMeshProUGUI ecussonText;        private int _ecussonCount;

// Ajoutez cette méthode pour gérer l'incrémentation
        public void AddEcusson()
        {
            _ecussonCount++;
            if (ecussonText != null)
            {
                // Formatage "Écussons : 000" conforme à votre UI
                ecussonText.text = $"Écussons : {_ecussonCount:D3}";
            }
        }
        
        // "Suggested name is '_currentAnim'"
        private Coroutine _currentAnim;

        [Header("Animation Settings")]
        [SerializeField] private float animationDuration = 0.2f;
        [SerializeField] private Vector3 closedScale = new Vector3(0.9f, 0.9f, 1f);
        [SerializeField] private Vector3 openScale = Vector3.one;

        private void Start()
        {
            if (sideMenuPanel != null && sideMenuCanvasGroup != null)
            {
                sideMenuPanel.SetActive(true); 
                sideMenuCanvasGroup.alpha = 0f;
                sideMenuCanvasGroup.interactable = false;
                sideMenuCanvasGroup.blocksRaycasts = false;
                sideMenuPanel.transform.localScale = closedScale;
                _isMenuOpen = false;
                Time.timeScale = 1f;
            }
            else
            {
                Debug.LogError("WorldUIManager : Références UI manquantes.");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleSideMenu();
            }
        }

        // "Method 'ToggleSideMenu' can be made private"
        // Note : Si vous l'appelez via un bouton Unity, laissez-la en 'public'.
        // Si elle n'est appelée que par l'Update (Esc), passez-la en 'private'.
        private void ToggleSideMenu()
        {
            if (sideMenuPanel == null || sideMenuCanvasGroup == null) return;

            _isMenuOpen = !_isMenuOpen;
            Time.timeScale = _isMenuOpen ? 0f : 1f;

            if (_currentAnim != null) StopCoroutine(_currentAnim);
            _currentAnim = StartCoroutine(AnimateSideMenu(_isMenuOpen));
        }

        private IEnumerator AnimateSideMenu(bool opening)
        {
            float elapsed = 0f;
            float startAlpha = sideMenuCanvasGroup.alpha;
            float targetAlpha = opening ? 1f : 0f;

            Vector3 startScale = sideMenuPanel.transform.localScale;
            Vector3 targetScale = opening ? openScale : closedScale;

            if (opening)
            {
                sideMenuCanvasGroup.blocksRaycasts = true;
                sideMenuCanvasGroup.interactable = true;
            }

            while (elapsed < animationDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(elapsed / animationDuration));

                sideMenuCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
                sideMenuPanel.transform.localScale = Vector3.Lerp(startScale, targetScale, t);

                yield return null;
            }

            sideMenuCanvasGroup.alpha = targetAlpha;
            sideMenuPanel.transform.localScale = targetScale;

            if (!opening)
            {
                sideMenuCanvasGroup.blocksRaycasts = false;
                sideMenuCanvasGroup.interactable = false;
            }

            _currentAnim = null;
        }

        public void OnBackToMenuClicked()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        public void OnDevmondexClicked() { Debug.Log("DevMonDex ouvert"); }
        public void OnTeamClicked() { Debug.Log("Equipe ouverte"); }
        public void OnBagClicked() { Debug.Log("Sac ouvert"); }
    }
}