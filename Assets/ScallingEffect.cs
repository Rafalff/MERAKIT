using UnityEngine;
using DG.Tweening;

public class ScallingEffect : MonoBehaviour {
    public float scaleAmount = 1.2f;
    public float scaleDuration = 0.5f;
    public Ease easeType = Ease.Linear; // Define the ease type

    private RectTransform rectTransform;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();

        // Call the ScaleUp function to start the effect
        float random = Random.Range(0, 1);
        Invoke(nameof(ScaleUp), random);
    }

    private void ScaleUp() {
        // Scale up
        rectTransform.DOScale(Vector3.one * scaleAmount, scaleDuration / 2)
            .SetEase(easeType) // Set the ease type
            .OnComplete(() => {
                // Scale down
                rectTransform.DOScale(Vector3.one, scaleDuration / 2)
                    .SetEase(easeType) // Set the ease type
                    .OnComplete(() => {
                        // Start the scaling again recursively
                        ScaleUp();
                    });
            });
    }
}
