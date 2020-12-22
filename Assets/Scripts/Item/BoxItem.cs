using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : BaseItem
{
    private BoxCollider2D boxCollider2D;

    public override void AdjustCollider()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        RectTransform rt = GetComponent<RectTransform>();
        boxCollider2D.size = new Vector2(rt.rect.width, rt.rect.height);
    }
}
