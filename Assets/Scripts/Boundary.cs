using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        RectTransform rt = GetComponent<RectTransform>();
        boxCollider.size = new Vector2(rt.rect.width, rt.rect.height);
    }
}
