using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IEntity
{
    private Graph.Node currentPos;
    
    public void SetCamera()
    {
        var offset = new Vector3(0,1,-4);
        Camera.main.transform.position = transform.position + offset;
    }


    public Graph.Node GetNodePosition()
    {
        return currentPos;
    }

    public void MoveTo(Graph.Node node)
    {
        gameObject.transform.position= node.worldPos;
        Debug.Log(transform.position+" jestem na node:" +node.worldPos);
        currentPos = node;
        SetCamera();

    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }
}
