using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsScript : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransformText;

    [SerializeField] private string[] newsText;
    [SerializeField] private TextMeshProUGUI newsTextTMP;

    private List<int> usedIndices = new List<int>();
    private void Start() {
        StartCoroutine(StartNews());
    }

    private void TransformUp1() {
        Vector3 target = new Vector3 (0f, 0f,0f);
        rectTransformText.DOAnchorPos(target, 1f);
    }

    private void TransformUp2() {
        Vector3 target = new Vector3(0f, 100f, 0f);
        rectTransformText.DOAnchorPos(target, 1f);
    }

    private void RandomizedText() {
        int randomIndex;

        // If there are unused indices, choose from them
        if (usedIndices.Count < newsText.Length) {
            do {
                // Generate a random index
                randomIndex = Random.Range(0, newsText.Length);
            } while (usedIndices.Contains(randomIndex)); // Ensure the index hasn't been used before
        } else // If all indices have been used at least once, allow repetition
          {
            randomIndex = Random.Range(0, newsText.Length);
        }

        // Add the index to the list of used indices
        usedIndices.Add(randomIndex);

        // If all indices have been used at least once, clear the list for repetition
        if (usedIndices.Count >= newsText.Length) {
            usedIndices.Clear();
        }

        // Retrieve the random string
        string randomNews = newsText[randomIndex];

        // Display the random string
        newsTextTMP.text = randomNews;
    }


    IEnumerator StartNews() {
        ResetRect();
        RandomizedText();
        TransformUp1();
        yield return new WaitForSeconds(5f);
        TransformUp2();
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartNews());
    }

    private void ResetRect() {
        Vector3 target = new Vector3(0f, -103f, 0f);
        rectTransformText.anchoredPosition = target;
    }
}
