using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public CombineSystem combineSystem;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Collider2D myCollider;
    private ItemPickup item;

    public bool isDragging = false;

    private Vector3 offset;

    private Color originalColor;
    private Color hoverColor = new Color(0.7971698f, 1, 0.99776f, 1f);

    // Define the boundaries for the object's movement
    public float minX;
    public float maxX;
    public float maxY;

    private GameObject parent;

    [SerializeField] private GameObject DestroyVfx;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        myCollider = rb.GetComponent<Collider2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        combineSystem = GameObject.Find("CombineSystem").GetComponent<CombineSystem>();
        item  = GetComponent<ItemPickup>();


        if (transform.parent != null) {
            parent = transform.parent.gameObject;
        }
    }

    private void Update() {

    }


    // Called when the mouse enters the collider of the object
    private void OnMouseEnter() {
        // Change the color to the hoverColor when the mouse enters
        spriteRenderer.color = hoverColor;
        TooltipsManager.instance.ShowTooltips(item.itemData.ingredientName);
    }

    // Called when the mouse exits the collider of the object
    private void OnMouseExit() {
        // Revert the color back to the original color when the mouse exits
        spriteRenderer.color = originalColor;
        if (!isDragging) {
            TooltipsManager.instance.HideTooltips();
        }
    }

    void OnMouseDown() {
        combineSystem.lastInteractedGameObject = this.gameObject;
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPos();
        myCollider.isTrigger = true;

        if (transform.parent != null) {
            transform.SetParent(null);
        }

        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        AudioManager.instance.PlaySfx("hover2");
    }

    void OnMouseDrag() {
        if (isDragging) {
            Vector3 mousePos = GetMouseWorldPos() + offset;
            // Limit the position within the boundaries
            mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
            mousePos.y = Mathf.Clamp(mousePos.y, -maxY, maxY);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            rb.velocity = Vector2.zero;

        }
    }

    void OnMouseUp() {
        isDragging = false;
        myCollider.isTrigger = false;

        if (parent != null) {
            parent.transform.position = transform.position;
            transform.SetParent(parent.transform);
        }

        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    private Vector3 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            // Right mouse button clicked over the object
            // Add your action here
            spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
        }
        if (Input.GetMouseButtonUp(1)) {
            DestroyVfxCalled();
            Destroy(gameObject);
            TooltipsManager.instance.HideTooltips();
            AudioManager.instance.PlaySfx("destroy");

        }
    }


    public void DestroyVfxCalled() {
        Instantiate(DestroyVfx,transform.position, DestroyVfx.transform.rotation);
    }

    private void OnDestroy() {
        if (parent != null) {
            Destroy(parent.gameObject);
        }
    }
}
