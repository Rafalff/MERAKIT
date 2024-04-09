using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private ItemPickup _itemPickup;
    private void Start() {
        _itemPickup = GetComponent<ItemPickup>();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        TooltipsManager.instance.ShowRightTooltips(_itemPickup.itemData.ingredientName);
        AudioManager.instance.PlaySfx("hover");
    }

    public void OnPointerExit(PointerEventData eventData) {
        TooltipsManager.instance.HideRightTooltips();
    }
}
