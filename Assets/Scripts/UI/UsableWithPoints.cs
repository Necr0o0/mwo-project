using UnityEngine;
using UnityEngine.UI;

public class UsableWithPoints : MonoBehaviour
{
    public Button button;
    
    [Min(0)]
    public int requiredPoints = 1;

    private void Awake()
    {
        UIActionsManager.OnActionPointsChange += OnActionPointsChange;
        UIActionsManager.OnSetActiveGameplayActions += SetActiveGameplayActions;
        if (!button)
            button = GetComponent<Button>();
    }

    private void OnDestroy()
    {
        UIActionsManager.OnActionPointsChange -= OnActionPointsChange;
        UIActionsManager.OnSetActiveGameplayActions -= SetActiveGameplayActions;
    }

    private void OnActionPointsChange(int newPoints)
    {
        button.interactable = newPoints >= requiredPoints;
    }

    private void SetActiveGameplayActions(bool active)
    {
        button.interactable = active;
    }
}
