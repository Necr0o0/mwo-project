using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMovementControl : MonoBehaviour
    {
        [Serializable]
        public struct DirectionButtonData
        {
            public Vector2 direction;
            public Button button;
        }
        
        [SerializeField] private List<DirectionButtonData> directions;


        private void Awake()
        {
            foreach (DirectionButtonData buttonData in directions)
            {
                buttonData.button.onClick.AddListener(() => MovePlayer(buttonData.direction));
            }
        }

        private void MovePlayer(Vector2 dir)
        {
            //TODO: Player controls
        }
    }
}