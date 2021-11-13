using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
   [SerializeField] private GameObject basicGrid;
   [SerializeField] private Vector2Int gridSize;

   private List<GameObject> gridBlocks;
   private Vector3 cursorPos;

   private float spaceBetween = 1.5f;
   private void Awake()
   {
       gridBlocks = new List<GameObject>();
   }

   public Vector2Int Generate()
    {
        cursorPos = Vector3.zero;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                var x = Instantiate(basicGrid,cursorPos,Quaternion.identity);
                cursorPos.x += spaceBetween;
                gridBlocks.Add(x);
            }

            cursorPos.x = 0.0f;
            cursorPos.z += spaceBetween;
        }
        return gridSize;
    }
   
}
