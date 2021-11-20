using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button soundButton;
        [SerializeField] private Image soundImage;
        [SerializeField] private Button exitButton;

        [Space]
        [SerializeField] private Sprite soundOn;
        [SerializeField] private Sprite soundOff;
        

        private void Awake()
        {
            resumeButton.onClick.AddListener(HideMenu);
            soundButton.onClick.AddListener(ToggleSound);
            exitButton.onClick.AddListener(ExitGame);

            soundImage.sprite = AudioListener.volume > 0 ? soundOn : soundOff;
        }

        public void ShowMenu()
        {
            gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            gameObject.SetActive(false);
        }

        private void ToggleSound()
        {
            if (AudioListener.volume > 0)
            {
                AudioListener.volume = 0;
                soundImage.sprite = soundOff;
            }
            else
            {
                AudioListener.volume = 1;
                soundImage.sprite = soundOn;
            }
        }
        
        private void ExitGame()
        {
            Application.Quit();
        }
    }
}