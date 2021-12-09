using System;

public static class UIActionsManager
{
    private static int points = 0;
    
    public static event Action<int> OnActionPointsChange;
    public static event Action<bool> OnSetActiveGameplayActions;

    public static void SetPoints(int newPoints)
    {
        points = newPoints;
        ChangeActionPoints(points);
    }

    public static void MakeAction(int pointCost)
    {
        points -= pointCost;
        ChangeActionPoints(points);
    }

    private static void ChangeActionPoints(int newPoints)
    {
        OnActionPointsChange?.Invoke(newPoints);
    }

    public static void SetActiveGameplayActions(bool active)
    {
        OnSetActiveGameplayActions?.Invoke(active);
    }
}
