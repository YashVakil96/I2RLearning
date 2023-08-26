using UnityEngine;

public class SpriteTo3D : MonoBehaviour
{
    public Sprite sprite;
    public float depth = 1f;
    
    void Start()
    {
        // Create a new GameObject with a SpriteRenderer component
        GameObject spriteObject = new GameObject();
        SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        
        // Set the sprite to the provided sprite
        spriteRenderer.sprite = sprite;
        
        // Calculate the scale of the 3D plane based on the sprite's size
        float spriteWidth = sprite.bounds.size.x;
        float spriteHeight = sprite.bounds.size.y;
        float aspectRatio = spriteWidth / spriteHeight;
        Vector3 scale = new Vector3(depth * aspectRatio, depth, 1f);
        
        // Set the scale and position of the 3D plane
        spriteObject.transform.localScale = scale;
        spriteObject.transform.position = transform.position;
    }
}