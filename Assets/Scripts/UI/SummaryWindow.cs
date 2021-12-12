using TMPro;
using UnityEngine;

public class SummaryWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    public void ShowEndScreen(bool won)
    {
        if (won)
            ShowWinScreen();
        else
            ShowLoseScreen();
    }

    private void ShowWinScreen()
    {
        title.text = "Wygrana!";
        description.text = "Udało ci się pokonać wszystkich przeciwników!";
    }

    private void ShowLoseScreen()
    {
        title.text = "Przegrana";
        description.text = $"Pozostała ilość przeciwników: {GameplayManager.instance.enemyList.Count}";
    }
}
