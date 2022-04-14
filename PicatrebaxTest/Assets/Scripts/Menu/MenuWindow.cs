using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MenuWindow : MonoBehaviour
    {
        public void OnStartClick()
        {
            SceneManager.LoadScene(1);
        }

       public void OnExitClick()
        {
            Application.Quit();
        }

    }
}