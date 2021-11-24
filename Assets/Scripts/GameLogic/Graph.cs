using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{
    public List<Node> Nodes;
    public List<Edge> Edges;
    
    
    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
    }

    public void AddNode(Vector3 worldPos)
    {
        var node = new Node(Nodes.Count,worldPos);
        Nodes.Add(node);
    }
    public void AddEdge(Node from, Node to, int cost)
    {
        var edge = new Edge(from,to,cost);
        Edges.Add(edge);
    }
    
    public class Node
    {
        public int index;
        public bool isOccupied;
        
        public Vector3 worldPos;
        
        public Node(int index, Vector3 worldPos)
        {
            this.index = index;
            this.worldPos = worldPos;
            isOccupied = false;
        }

        public void SetOccupied(bool val)
        {
            isOccupied = val;
        }
    }
    
    public class Edge
    {
        public Node from;
        public Node to;
        public int cost;
        
        public Edge(Node from, Node to, int cost)
        {
            this.from = from;
            this.to = to;
            this.cost = cost;
        }

    }
    
   
}
