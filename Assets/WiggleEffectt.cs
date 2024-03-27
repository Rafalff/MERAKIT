using UnityEngine;
using DG.Tweening;

public class WiggleEffect : MonoBehaviour {
    public float wiggleAmount = 20f;
    public float wiggleDuration = 0.5f;
    public Ease easeType = Ease.Linear; // Define the ease type

    private void Start() {
        // Call the Wiggle function to start the effect
        float random = Random.Range(0, 1);
        Invoke(nameof(Wiggle), random);
    }

    private void Wiggle() {
        Vector3 rotation = new Vector3(0.0f, 0.0f, wiggleAmount);
        Vector3 rotationBack = new Vector3(0.0f, 0.0f, -wiggleAmount);

        // Add left-right movement using relative position change
        transform.DORotate(rotation, wiggleDuration / 2)
            .SetEase(easeType) // Set the ease type
            .OnComplete(() => {
                // Rotate back to the original rotation
                transform.DORotate(rotationBack, wiggleDuration / 2)
                    .SetEase(easeType) // Set the ease type
                    .OnComplete(() => {
                        // Start the wiggle again recursively
                        Wiggle();
                    });
            });
    }
}

