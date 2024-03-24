using UnityEngine;

public class CombineManager : MonoBehaviour {
    public bool combinationInProgress = false;
    private GameObject combinedObject;

    public void CombineItems(ItemPickup ingredient1, ItemPickup ingredient2, CombineSystem combineSystem) {
        if (!combinationInProgress) {
            combinationInProgress = true;
            combinedObject = combineSystem.Combine(ingredient1.itemData, ingredient2.itemData);
            if (combinedObject != null) {
                GameObject instantiatedPrefab = Instantiate(combinedObject, CalculateMiddlePoint(ingredient1.gameObject, ingredient2.gameObject), Quaternion.identity);
                Destroy(ingredient1.gameObject);
                Destroy(ingredient2.gameObject);
            }
            combinationInProgress = false;
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
