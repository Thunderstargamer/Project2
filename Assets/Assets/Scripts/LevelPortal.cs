using UnityEngine;
using UnityEngine.SceneManagement;

// Goes on Exit (loads a scene when the Player touches it) and on TitleManager (Button On Click).
public class LevelPortal : MonoBehaviour
{
    [SerializeField] string destinationScene = "Menu";
    [SerializeField] bool recordOnEnter = false;

    public void GoToScene(string targetScene)
    {
        if (targetScene == "MainGame") RunState.Chickens = 0;
        SceneManager.LoadScene(targetScene);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (recordOnEnter) RunState.StoreRecord();
        SceneManager.LoadScene(destinationScene);
    }
}
