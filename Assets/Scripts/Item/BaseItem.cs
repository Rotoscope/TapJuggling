using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour, IItem
{
    internal bool isRemoving = false;
    internal Rotation rotation;

    public abstract void AdjustCollider();

    // Start is called before the first frame update
    private void Start()
    {
        AdjustCollider();
    }

    internal void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogFormat("Collided with {0}", collision.gameObject.name);

        if (isRemoving) return;

        if (collision.gameObject.name == "Floor")
        {
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
    }

    internal void RotateItem()
    {
        if (rotation == Rotation.LEFT)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * Constants.ROTATION_SPEED));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * Constants.ROTATION_SPEED));
        }
    }
}
