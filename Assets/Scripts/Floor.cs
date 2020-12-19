using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        RectTransform rt = GetComponent<RectTransform>();
        boxCollider.size = new Vector2(rt.rect.width, rt.rect.height);
    }
}
