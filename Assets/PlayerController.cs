using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetCamera()
    {
        var offset = new Vector3(0,1,-4);
        Camera.main.transform.position = transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * 1.5f; //between
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= Vector3.forward * 1.5f; //between
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= Vector3.right * 1.5f; //between
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * 1.5f; //between
        }

        SetCamera();
    }
}
