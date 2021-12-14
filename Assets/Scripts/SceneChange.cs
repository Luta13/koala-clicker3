using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }
}
