using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : ClickableItem
{
    public Sprite[] sprites;

    private CircleCollider2D cirCollider2D;

    public override void AdjustCollider()
    {
        RectTransform rt = GetComponent<RectTransform>();
        cirCollider2D.radius = rt.rect.width / 2;
    }

    public override void Init()
    {
        cirCollider2D = GetComponent<CircleCollider2D>();
        Image image = GetComponent<Image>();
        image.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
