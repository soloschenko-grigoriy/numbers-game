using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    public void OnClick()
    {
        SaveLoadLocalFile.Erase();
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
