﻿using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UICardsHand : MonoBehaviour
    {
        [Range(0f, 90f)] [SerializeField] private float maxCardRotation;
        [Min(1)] [SerializeField] private int maxCardsForCentering = 6;

        [Space] [SerializeField] private Vector2 cardsAnchor;

        private readonly List<CardUI> cardsInHand = new List<CardUI>(10);

        private new RectTransform transform;

        private float centeringOffset;

        private void Awake()
        {
            transform = GetComponent<RectTransform>();
        }

        public bool CanReceiveCard(CardUI card)
        {
            return true;
        }

        public void ReceiveCard(CardUI card)
        {
            //card.SetParent(this, transform);
            if (cardsInHand.Contains(card))
            {
                MoveCardToPosition(card, cardsInHand.IndexOf(card));
                return;
            }

            cardsInHand.Add(card);
            Refresh();
        }

        public void RemoveCard(CardUI card)
        {
            cardsInHand.Remove(card);
            Refresh();
        }

        public void RemoveCard(int index)
        {
            cardsInHand.RemoveAt(index);
            Refresh();
        }

        private void MoveCardToPosition(CardUI card, int position)
        {
            float xPos = (position + centeringOffset) / Mathf.Max(maxCardsForCentering - 1, cardsInHand.Count - 1);
            Vector2 pos = new Vector2(xPos - cardsAnchor.x, 1 - Mathf.Pow(1 - 2 * xPos, 2) - cardsAnchor.y);

            pos *= transform.sizeDelta;
            //card.SetParent(transform);
            //card.AnchoredPosition = pos;
            //card.RotateCard(maxCardRotation * (0.5f - xPos) * 2);
        }
        
        public void Refresh()
        {
            centeringOffset = Mathf.Clamp((maxCardsForCentering - cardsInHand.Count) / 2f, 0f, Mathf.Infinity);
            for (int i = 0; i < cardsInHand.Count; i++)
            {
                MoveCardToPosition(cardsInHand[i], i);
            }
        }
    }
}