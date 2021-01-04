using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonClickableItem : BaseItem
{
    internal bool touchedFloor = false;

    public override void OnClick()
    {
        if (touchedFloor) return;

        LifeManager.Instance.DecrementLife();
        Destroy(gameObject);
    }

    public override void OnFloorCollision(Collision2D collision)
    {
        touchedFloor = true;
        StartCoroutine(BeginRemoval());
    }

    internal IEnumerator BeginRemoval()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
