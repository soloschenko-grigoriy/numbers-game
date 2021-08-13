using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class StartGameBtn : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
    }
}