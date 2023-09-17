using UnityEngine;

public class CheckMoleculeCollision : MonoBehaviour
{
    public float raycastDistance = 1f; // Distance to cast the rays

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CheckDirection(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)));
        }
    }

    public Collider2D CheckDirection(Vector3 pos)
    {
        // Perform raycasts in eight directions
        RaycastHit2D up = Physics2D.Raycast(pos, Vector2.up, raycastDistance);
        Debug.DrawRay(transform.position,Vector2.up * raycastDistance);
        
        
        RaycastHit2D down = Physics2D.Raycast(pos, Vector2.down, raycastDistance);
        Debug.DrawRay(transform.position,Vector2.down * raycastDistance);
        
        
        RaycastHit2D left = Physics2D.Raycast(pos, Vector2.left, raycastDistance);
        Debug.DrawRay(transform.position,Vector2.left * raycastDistance);
        
        
        RaycastHit2D right = Physics2D.Raycast(pos, Vector2.right, raycastDistance);
        Debug.DrawRay(transform.position,Vector2.right * raycastDistance);
        
        
        RaycastHit2D upLeft = Physics2D.Raycast(pos, new Vector2(-1, 1), raycastDistance);
        Debug.DrawRay(transform.position,new Vector2(-1, 1) * raycastDistance);
        
        
        RaycastHit2D upRight = Physics2D.Raycast(pos, new Vector2(1, 1), raycastDistance);
        Debug.DrawRay(transform.position,new Vector2(1, 1) * raycastDistance);
        
        
        RaycastHit2D downLeft = Physics2D.Raycast(pos, new Vector2(-1, -1), raycastDistance);
        Debug.DrawRay(transform.position,new Vector2(-1, -1) * raycastDistance);
        
        
        RaycastHit2D downRight = Physics2D.Raycast(pos, new Vector2(1, -1), raycastDistance);
        Debug.DrawRay(transform.position,new Vector2(1, -1) * raycastDistance);
        

        // Check for collision and handle accordingly
        if (up.collider != null)
        {
            Debug.Log("Collision detected upward: " + up.collider.name);
            return up.collider;
        }

        if (down.collider != null)
        {
            Debug.Log("Collision detected downward: " + down.collider.name);
            return down.collider;
        }

        if (left.collider != null)
        {
            Debug.Log("Collision detected to the left: " + left.collider.name);
            return left.collider;
        }

        if (right.collider != null)
        {
            Debug.Log("Collision detected to the right: " + right.collider.name);
            return right.collider;
        }

        if (upLeft.collider != null)
        {
            Debug.Log("Collision detected upward-left: " + upLeft.collider.name);
            return upLeft.collider;
        }

        if (upRight.collider != null)
        {
            Debug.Log("Collision detected upward-right: " + upRight.collider.name);
            return upRight.collider;
        }

        if (downLeft.collider != null)
        {
            Debug.Log("Collision detected downward-left: " + downLeft.collider.name);
            return downLeft.collider;
        }

        if (downRight.collider != null)
        {
            Debug.Log("Collision detected downward-right: " + downRight.collider.name);
            return downRight.collider;
        }

        return null;
    }
}
