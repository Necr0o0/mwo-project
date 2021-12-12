using UnityEngine;
using UnityEngine.UI;

public class UsableWithPoints : MonoBehaviour
{
    public Button button;
    
    [Min(0)]
    public int requiredPoints = 1;

    private bool interactive = true;
    private bool active = true;

    private void Awake()
    {
        UIActionsManager.OnActionPointsChange += OnActionPointsChange;
        UIActionsManager.OnSetActiveGameplayActions += SetActiveGameInteraction;
        if (!button)
            button = GetComponent<Button>();
    }

    private void OnDestroy()
    {
        UIActionsManager.OnActionPointsChange -= OnActionPointsChange;
        UIActionsManager.OnSetActiveGameplayActions -= SetActiveGameInteraction;
    }

    private void OnActionPointsChange(int newPoints)
    {
        active = newPoints >= requiredPoints;
        button.interactable = active;
    }

    private void SetActiveGameInteraction(bool active)
    {
        this.active = active;
        button.interactable = active && interactive;
    }

    public void SetSelfInteractive(bool interactive)
    {
        this.interactive = interactive;
        button.interactable = active && interactive;
    }
}
