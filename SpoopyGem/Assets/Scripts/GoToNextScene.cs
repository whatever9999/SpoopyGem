using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene((int)MenuUIManager.Scenes.MENU);
    }
}
