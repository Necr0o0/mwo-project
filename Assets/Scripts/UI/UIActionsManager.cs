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

    public static bool MakeAction(int pointCost)
    {
        if (pointCost > points)
            return false;
        points -= pointCost;
        ChangeActionPoints(points);
        return true;
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
