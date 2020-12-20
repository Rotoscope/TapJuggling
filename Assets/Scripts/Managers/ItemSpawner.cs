using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public BaseItem[] items;

    internal float spawnTime = 0f;
    internal float reductionCheck = 0f;
    internal float spawnDelay = Constants.INITIAL_SPAWN_DELAY;
    internal int spawnCount = 0;

    private void Start()
    {
        SpawnItem();
    }

    // Update is called once per frame
    private void Update()
    {
        spawnTime += Time.deltaTime;
        reductionCheck += Time.deltaTime;

        if (spawnTime >= spawnDelay)
        {
            SpawnItem();
            spawnTime = 0f;
        }

        if (spawnDelay >= Constants.MINIMUM_SPAWN_DELAY && reductionCheck >= Constants.REDUCTION_CHECK)
        {
            spawnDelay -= Constants.SPAWN_REDUCTION;
            reductionCheck = 0f;
        }
    }

    private void SpawnItem()
    {
        spawnCount++;
        int itemIndex = Random.Range(0, items.Length);
        GameObject go = Instantiate(items[itemIndex].gameObject);
        Transform transform = go.transform;
        float x = Screen.safeArea.width * 3 / 4;
        transform.position = new Vector3(Random.Range(-x, x), Screen.safeArea.height);
        transform.SetParent(PlayManager.Instance.itemMount.transform, false);
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-200, 200), -100f), ForceMode2D.Impulse);
    }
}
