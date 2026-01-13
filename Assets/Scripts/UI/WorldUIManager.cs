using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WorldUIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject sideMenuPanel;
    [SerializeField] private CanvasGroup sideMenuCanvasGroup;

    private bool isMenuOpen = false;
    private Coroutine currentAnim;

    [Header("Animation")]
    [SerializeField] private float animationDuration = 0.2f;
    [SerializeField] private Vector3 closedScale = new Vector3(0.9f, 0.9f, 1f);
    [SerializeField] private Vector3 openScale = Vector3.one;

    private void Start()
    {
        if (sideMenuPanel != null && sideMenuCanvasGroup != null)
        {
            sideMenuPanel.SetActive(true);               // on le laisse dans la scène
            sideMenuCanvasGroup.alpha = 0f;              // invisible
            sideMenuCanvasGroup.interactable = false;    // pas cliquable
            sideMenuCanvasGroup.blocksRaycasts = false;  // ne bloque pas la souris
            sideMenuPanel.transform.localScale = closedScale;
            isMenuOpen = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSideMenu();
        }
    }

    private void ToggleSideMenu()
    {
        if (sideMenuPanel == null || sideMenuCanvasGroup == null)
            return;

        isMenuOpen = !isMenuOpen;

        if (currentAnim != null)
            StopCoroutine(currentAnim);

        currentAnim = StartCoroutine(AnimateSideMenu(isMenuOpen));
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
            elapsed += Time.deltaTime;
            float t = elapsed / animationDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

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

        currentAnim = null;
    }

    // Bouton "Retour Menu"
    public void OnBackToMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnDevmondexClicked()
    {
        Debug.Log("Ouverture du DevMonDex (TODO)");
    }

    public void OnTeamClicked()
    {
        Debug.Log("Ouverture de l'équipe (TODO)");
    }

    public void OnBagClicked()
    {
        Debug.Log("Ouverture du Sac à Dos (TODO)");
    }
}

