using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIMovementControl : MonoBehaviour
    {
        public static UIMovementControl instance;
        [Min(0)]
        [SerializeField] private int pointCost = 1;
        
        [Serializable]
        public struct DirectionButtonData
        {
            public Vector2Int direction;
            public UsableWithPoints usableButton;
        }
        
        [SerializeField] private List<DirectionButtonData> directions;


        private void Start()
        {
            instance = this;
            foreach (DirectionButtonData buttonData in directions)
            {
                buttonData.usableButton.button.onClick.AddListener(() => MovePlayer(buttonData.direction));
                buttonData.usableButton.requiredPoints = pointCost;
            }
            
            RefreshInputVisual();
        }

        private void MovePlayer(Vector2Int dir)
        {
            GameplayManager.instance.PlayerModel.Move(dir);
            
            UIActionsManager.MakeAction(pointCost);
            
            RefreshInputVisual();
        }
        
        public void RefreshInputVisual(bool _ = true)
        {
            foreach (DirectionButtonData directionButtonData in directions)
            {
                var pos = GameplayManager.instance.PlayerModel.GetNodePosition();
                var neighbourNode = GameplayManager.instance.grid.GetNode(pos, directionButtonData.direction);

                bool canMove = !(neighbourNode is null);
                directionButtonData.usableButton.SetSelfInteractive(canMove);

                if (canMove && neighbourNode.IsOccupied)
                {
                    directionButtonData.usableButton.button.image.color = Color.red;
                }
                else
                {
                    directionButtonData.usableButton.button.image.color = Color.white;
                }
            }
        }
    }
}