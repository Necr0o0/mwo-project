using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
            var gm = GameplayManager.instance;
            var gridNodes = GameplayManager.instance.grid.Nodes;
            
            gm.PlayerModel.MoveTo(gridNodes[Random.Range(0,gridNodes.Count)]);
        }
    }
}