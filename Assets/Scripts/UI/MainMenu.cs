using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour {

        public void PlayGame() {
            SceneManager.LoadScene("Game");
        
        }
    
        public void QuitGame()
        {
            Application.Quit();
        }
    
    }
}
