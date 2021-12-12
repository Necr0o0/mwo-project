using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Graph
{
    public Vector2Int size;
    public readonly List<Node> Nodes;
    public readonly List<Edge> Edges;
    
    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
    }

    public Node GetRandomFreeNode()
    {
        Node ret;
        do
        {
            var randomId = Random.Range(0, Nodes.Count);
            ret = Nodes[randomId];
        } while (ret.IsOccupied);

        return ret;
    }

    public Node GetNode(Node startPos, Vector2Int direction)
    {
        return GetNode(startPos.index + direction.x + (direction.y * size.x));
    }

    public Node GetNode(int id)
    {
        if (id < 0 || id >= Nodes.Count)
            return null;
        
        return Nodes[id];
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
        public IEntity occupyingEntity = null;
        
        public Vector3 worldPos;
        
        public bool IsOccupied => !(occupyingEntity is null);

        
        public Node(int index, Vector3 worldPos)
        {
            this.index = index;
            this.worldPos = worldPos;
        }

        public void Occupy(IEntity entity)
        {
            occupyingEntity = entity;
        }

        public void Free()
        {
            occupyingEntity = null;
        }
    }
    
    public List<Node> Neighbours(Node of)
    {
        var neighbours = new List<Node>();
        foreach (var edge in Edges)
        {
            if (edge.from == of)
            {
                if (edge.to.IsOccupied)
                    continue;
                neighbours.Add(edge.to);
            }
        }

        return neighbours;
    }

    public int GetDistance(Node from, Node to)
    {
        foreach (var edge in Edges)
        {
            if (edge.from == from && edge.to == to) return edge.GetCost();
        }

        return Int32.MaxValue;
    }

    
    public List<Node> GetPath(Node start, Node end)
    {
        var path = new List<Node>();
        if (start == end)
        {
            path.Add(start);
            return path;
        }
        var openList = new List<Node>();
        Dictionary<Node,Node> previousNode = new Dictionary<Node, Node>();
        Dictionary<Node,float> distances = new Dictionary<Node, float>();

        for (int i = 0; i < Nodes.Count; i++)
        {
            if (Nodes[i].IsOccupied)
                continue;
            openList.Add(Nodes[i]);
            distances.Add(Nodes[i],float.PositiveInfinity);
        }

        distances[start] = 0f;
        while (openList.Count>0)
        {
            openList = openList.OrderBy(x => distances[x]).ToList();
            Node current = openList[0];
            // can't move to those nodes 
            if (float.IsPositiveInfinity(distances[current]))
                break;
            
            openList.Remove(current);

            if (current == end)
            {
                while (previousNode.ContainsKey(current))
                {
                    path.Insert(0,current);
                    current = previousNode[current];
                }
                path.Insert(0,current);
                break;
            }

            foreach (var neighbourNode in Neighbours(current))
            {
                float distance = GetDistance(current, neighbourNode);
                float candidateDistance = distances[current] + distance;

                if (candidateDistance< distances[neighbourNode])
                {
                    distances[neighbourNode] = candidateDistance;
                    previousNode[neighbourNode] = current;
                }
            }
        }

        
        
        return path;
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
        public int GetCost()
        {
            if (to.IsOccupied)
            {
                return Int32.MaxValue;
            }

            return cost;
        }
    }
}
