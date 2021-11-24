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

   public Graph Generate()
    {
        Graph g = new Graph();
        cursorPos = Vector3.zero;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                var x = Instantiate(basicGrid,cursorPos,Quaternion.identity,transform);
                
                g.AddNode(cursorPos);
                
                cursorPos.x += spaceBetween;
                gridBlocks.Add(x);
                
            }

            cursorPos.x = 0.0f;
            cursorPos.z += spaceBetween;
        }
        
        foreach (var from in g.Nodes)
        {
            foreach (var to in g.Nodes)
            {
                if (Vector3.Distance(from.worldPos, to.worldPos) <  spaceBetween * 1.5f && from != to)
                {
                    var edge = new Graph.Edge(from,to,1);
                    g.Edges.Add(edge);
                }
            }
        }
        
        return g;
    }
   
}
