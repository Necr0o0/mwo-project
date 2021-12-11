using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEntity
{
    private Graph.Node currentPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           transform.position += Vector3.up;
           SetCamera();
        }
    }

    public void SetCamera()
    {
        var offset = new Vector3(0,1,-4);
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

        Vector3 pos = node.worldPos;
        transform.position = pos;
        Debug.Log(transform.position+" :" +node.worldPos);
        SetCamera();

    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }
}
