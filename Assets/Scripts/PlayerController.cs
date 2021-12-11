using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEntity
{
    private Graph.Node currentPos;

    private void Update()
    {
  
    }

    public void SetCamera()
    {
        var offset = new Vector3(0,4,-4);
        Camera.main.transform.position = transform.position + offset;
        Debug.Log("Gracz jest na: " +transform.position);

    }


    public Graph.Node GetNodePosition()
    {
        return currentPos;
    }

    public void MoveTo(Graph.Node node)
    {
        currentPos = node;

        transform.position = node.worldPos + Vector3.up ;
        SetCamera();

    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }
}
