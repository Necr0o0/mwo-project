using TMPro;
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
        [SerializeField] private TMP_Text pointsText;

        
        private void Awake()
        {
            pauseButton.onClick.AddListener(ShowPauseMenu);
            endTurnButton.onClick.AddListener(gameManager.EndTurn);
            
            pauseMenu.HideMenu();
            UIActionsManager.OnActionPointsChange += ChangeActionPoints;
        }

        private void ShowPauseMenu()
        {
            pauseMenu.ShowMenu();
        }

        private void ChangeActionPoints(int newPoints)
        {
            pointsText.text = $"Action Points left: {newPoints}";
        }
    }
}