using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CardUI : UIAnimatedObject
    {
        [Header("References")]
        [SerializeField] private Image background = default;
        [SerializeField] private Image backSide = default;
        [SerializeField] private TMP_Text cost = default;
        [SerializeField] private TMP_Text title = default;
        [SerializeField] private TMP_Text explanation = default;

        [Space]
        public CardData data;

        private bool playerCard = true;
        
        private void Awake()
        {
            //transform = GetComponent<RectTransform>();
        }

        private void ApplyStyle()
        {
            if (data.style == null)
            {
                Debug.LogError("Tried to apply null style");
                return;
            }
            background.sprite = data.style.background;
            backSide.sprite = data.style.backSide;
        }

        private void UpdateData()
        {
            //cost.text = data.cost.ToString();
            title.text = data.title;
            explanation.text = data.description;
        }

        public void SetCard(CardData cardData)
        {
            data = cardData;
            gameObject.name = data.title;
            ApplyStyle();
            UpdateData();
        }
    }
}