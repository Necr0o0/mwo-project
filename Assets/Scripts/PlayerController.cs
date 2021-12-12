using UnityEngine;

public class PlayerController : MonoBehaviour, IEntity
{
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 4, -4);
    private Graph.Node currentPos;
    
    public Graph.Node GetNodePosition()
    {
        return currentPos;
    }

    public void Move(Vector2Int direction)
    {
        var node = GameplayManager.instance.grid.GetNode(currentPos, direction);
        MoveTo(node);
    }

    public void MoveTo(Graph.Node node)
    {
        currentPos = node;
        if (currentPos.IsOccupied)
            currentPos.occupyingEntity.OnAttacked();

        transform.position = currentPos.worldPos + Vector3.up;
        SetCamera();
    }

    private void SetCamera()
    {
        Camera.main.transform.position = transform.position + cameraOffset;
        Debug.Log("Gracz jest na: " + transform.position);
    }

    public void OnAttacked()
    {
        GameplayManager.instance.GameOver();
    }
}
