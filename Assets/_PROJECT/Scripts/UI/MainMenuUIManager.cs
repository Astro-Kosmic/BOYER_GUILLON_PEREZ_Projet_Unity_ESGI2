using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("WorldMap");
    }

    public void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        // En mode éditeur, ça arrête juste le Play
        UnityEditor.EditorApplication.isPlaying = false;
#else
    // En build, ça ferme l'application
    Application.Quit();
#endif
    }
}
