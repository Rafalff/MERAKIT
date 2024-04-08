using UnityEngine;

public class CombineTrigger : MonoBehaviour {
    public CombineSystem combineSystem;
    public ParticleSystem ColisionEffect;
    private void Awake() {
        combineSystem = GameObject.Find("CombineSystem").GetComponent<CombineSystem>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        ItemPickup ingredient1 = collision.gameObject.GetComponent<ItemPickup>();
        ItemPickup ingredient2 = GetComponent<ItemPickup>();
        if (ingredient1 != null && combineSystem.lastInteractedGameObject == this.gameObject) {
            Combine(ingredient1, ingredient2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (combineSystem.lastInteractedGameObject == this.gameObject) {
            Instantiate(ColisionEffect, collision.gameObject.transform.position, Quaternion.identity);
            AudioManager.instance.PlaySfx("trigger");
        }
    }


    private void Combine(ItemPickup ingredient1, ItemPickup ingredient2) {
        if (ingredient1 != null) {
            GameObject outcomePrefab = combineSystem.Combine(ingredient1.itemData, ingredient2.itemData);
            if (outcomePrefab != null) {


                // Instantiate the outcomePrefab
                GameObject instantiatedPrefab = Instantiate(outcomePrefab, CalculateMiddlePoint(ingredient1.gameObject, ingredient2.gameObject), Quaternion.identity);
                //Instantiate(ColisionEffect, instantiatedPrefab.transform.position, Quaternion.identity);
                // Add debug log to check if the outcomePrefab has a Rigidbody2D component

                ItemPickup itemPickup = instantiatedPrefab.GetComponent<ItemPickup>() ?? instantiatedPrefab.GetComponentInChildren<ItemPickup>();

                NewItemManager.Instance.AwardAchievementForNewItem(itemPickup.itemData.ingredientName,itemPickup.itemData.icon);

                if (instantiatedPrefab.GetComponent<Rigidbody2D>() == null) {
                    Debug.Log("Rigidbody2D component not found on the instantiated prefab.");
                }
                // Destroy the ingredients
                Destroy(ingredient1.gameObject);
                Destroy(ingredient2.gameObject);
            } else {
                Debug.Log("No recipe found for this ingredient.");
            }
        }
    }

    private Vector3 CalculateMiddlePoint(GameObject obj1, GameObject obj2) {
        if (obj1 == null || obj2 == null) {
            Debug.LogError("One or both GameObjects are null.");
            return Vector3.zero; // Return zero vector to indicate an error
        }

        // Get the positions of the two objects
        Vector3 pos1 = obj1.transform.position;
        Vector3 pos2 = obj2.transform.position;

        // Calculate the middle point between the two objects
        Vector3 middlePoint = (pos1 + pos2) / 2f;

        return middlePoint;
    }

}
