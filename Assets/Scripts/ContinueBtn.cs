using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
