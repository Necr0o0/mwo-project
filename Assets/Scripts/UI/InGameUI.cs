using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        
        [Space]
        [SerializeField] private Button endTurnButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private UIMovementControl movementControl;

        private void Awake()
        {
            pauseButton.onClick.AddListener(ShowPauseMenu);
            endTurnButton.onClick.AddListener(gameManager.EndTurn);
            
            pauseMenu.HideMenu();
        }

        private void ShowPauseMenu()
        {
            pauseMenu.ShowMenu();
        }
    }
}