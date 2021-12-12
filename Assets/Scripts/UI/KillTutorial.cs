using TMPro;
using UnityEngine;

public class KillTutorial : MonoBehaviour
{
    public static int KillPointsCost;

    [SerializeField] private int killPointCost = 2;
    [SerializeField] private TMP_Text tutorialText;

    private void Awake()
    {
        KillPointsCost = killPointCost;
        UIActionsManager.OnActionPointsChange += ShowTutorial;
    }

    private void ShowTutorial(int totalPoints)
    {
        tutorialText.gameObject.SetActive(totalPoints >= killPointCost);
    }
}
