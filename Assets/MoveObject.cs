using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;
    public bool isDragging = false;
    private Vector3 offset;

    private Color originalColor;
    private Color hoverColor = new Color(0.7971698f, 1, 0.99776f, 1f);

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = rb.GetComponent<CapsuleCollider2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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
        capsuleCollider.isTrigger = true;
    }

    void OnMouseDrag() {
        if (isDragging) {
            Vector3 mousePos = GetMouseWorldPos() + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            rb.velocity = Vector2.zero;
        }
    }

    void OnMouseUp() {
        isDragging = false;
        capsuleCollider.isTrigger = false;
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
