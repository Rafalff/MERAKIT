using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public CombineSystem combineSystem;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Collider2D myCollider;
    public bool isDragging = false;

    private Vector3 offset;

    private Color originalColor;
    private Color hoverColor = new Color(0.7971698f, 1, 0.99776f, 1f);

    // Define the boundaries for the object's movement
    public float maxX;
    public float maxY;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        myCollider = rb.GetComponent<Collider2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        combineSystem = GameObject.Find("CombineSystem").GetComponent<CombineSystem>();
    }

    // Called when the mouse enters the collider of the object
    private void OnMouseEnter() {
        // Change the color to the hoverColor when the mouse enters
        spriteRenderer.color = hoverColor;
    }

    // Called when the mouse exits the collider of the object
    private void OnMouseExit() {
        // Revert the color back to the original color when the mouse exits
        spriteRenderer.color = originalColor;
    }

    void OnMouseDown() {
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPos();
        myCollider.isTrigger = true;
    }

    void OnMouseDrag() {
        if (isDragging) {
            Vector3 mousePos = GetMouseWorldPos() + offset;
            // Limit the position within the boundaries
            mousePos.x = Mathf.Clamp(mousePos.x, -maxX, maxX);
            mousePos.y = Mathf.Clamp(mousePos.y, -maxY, maxY);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            rb.velocity = Vector2.zero;
        }
    }

    void OnMouseUp() {
        combineSystem.lastInteractedGameObject = this.gameObject;
        isDragging = false;
        myCollider.isTrigger = false;
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
