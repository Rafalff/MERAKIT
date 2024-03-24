using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    public Vector3 offset = new Vector3(-0.1f, -0.1f);
    public Color color;
    public Material material;
    GameObject _shadow;
    void Start()
    {
        _shadow = new GameObject("Shadow");
        _shadow.transform.parent = transform;

        _shadow.transform.localPosition = offset;
        _shadow.transform.localRotation = Quaternion.identity;
        _shadow.transform.localScale = Vector3.one;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = _shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = renderer.material;

        sr.color = color;
        sr.material = material;

        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        _shadow.transform.localPosition = offset;
    }
}
