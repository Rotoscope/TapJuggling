using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableItem : BaseItem
{
    internal bool isRemoving = false;

    public override void OnClick()
    {
        Vector2 originalVelocity = itemRb.velocity;
        if (originalVelocity.y < 0)
        {
            ScoreManager.Instance.IncrementScore();
            itemRb.velocity = new Vector2(originalVelocity.x, GameConstants.CLICK_BOOST);
        }
    }

    public override void OnFloorCollision(Collision2D collision)
    {
        if (isRemoving) return;

        LifeManager.Instance.DecrementLife();
        StartCoroutine(BeginRemoval());
    }

    internal IEnumerator BeginRemoval()
    {
        isRemoving = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
