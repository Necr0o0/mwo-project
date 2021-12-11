using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class UIMovementControl : MonoBehaviour
    {
        [Min(0)]
        [SerializeField] private int pointCost = 1;
        
        [Serializable]
        public struct DirectionButtonData
        {
            public Vector2 direction;
            public UsableWithPoints usableButton;
        }
        
        [SerializeField] private List<DirectionButtonData> directions;


        private void Awake()
        {
            foreach (DirectionButtonData buttonData in directions)
            {
                buttonData.usableButton.button.onClick.AddListener(() => MovePlayer(buttonData.direction));
                buttonData.usableButton.requiredPoints = pointCost;
            }
        }

        private void MovePlayer(Vector2 dir)
        {
            var gm = GameplayManager.instance;
            var gridNodes = GameplayManager.instance.grid.Nodes;

            int destinationNode = gm.PlayerModel.GetNodePosition().index + (int)dir.x +
                                 ( (int)dir.y * GameplayManager.instance.GridGenerator.gridSize.y);

            if (destinationNode >= 0 && destinationNode < GameplayManager.instance.grid.Nodes.Count)
            {
                Debug.Log("IDE NA GRID ID: "+destinationNode);
                gm.PlayerModel.MoveTo(GameplayManager.instance.grid.Nodes[destinationNode]);


            }
            
            UIActionsManager.MakeAction(pointCost);
        }
    }
}