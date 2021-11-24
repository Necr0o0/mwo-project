using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEntity
{
    Graph.Node GetNodePosition();

    void MoveTo(Graph.Node position);
    void Attack();

    
}
