using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseItem : MonoBehaviour, IItem, IPointerDownHandler
{
    internal bool isRemoving = false;
    internal Rigidbody2D itemRb;
    internal RectTransform rt;

    public abstract void AdjustCollider();

    // Start is called before the first frame update
    private void Start()
    {
        AdjustCollider();
        itemRb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
    }

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRemoving) return;

        if (collision.gameObject.name == "Floor")
        {
            LifeManager.Instance.DecrementLife();
            StartCoroutine(BeginRemoval());
        }
    }

    internal IEnumerator BeginRemoval()
    {
        isRemoving = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        RotateItem();
        KeepItemWithinWidth();
    }

    internal void RotateItem()
    {
        if (itemRb.velocity.x > 0)
        {
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * GameConstants.ROTATION_SPEED));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * GameConstants.ROTATION_SPEED));
        }
    }

    internal void KeepItemWithinWidth()
    {
        if (rt.localPosition.x < GameConstants.LEFT_END ||
            rt.localPosition.x > GameConstants.RIGHT_END)
        {
            Vector2 originalVelocity = itemRb.velocity;
            itemRb.velocity = new Vector2(-originalVelocity.x, originalVelocity.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 originalVelocity = itemRb.velocity;
        if (originalVelocity.y < 0)
        {
            ScoreManager.Instance.IncrementScore();
            itemRb.velocity = new Vector2(originalVelocity.x, GameConstants.CLICK_BOOST);
        }
    }
}
