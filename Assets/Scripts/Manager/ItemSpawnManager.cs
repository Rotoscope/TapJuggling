using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public BaseItem[] items;

    internal float spawnTime = 0f;
    internal float reductionCheck = 0f;
    internal float spawnDelay = GameConstants.INITIAL_SPAWN_DELAY;
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

        if (spawnDelay >= GameConstants.MINIMUM_SPAWN_DELAY && reductionCheck >= GameConstants.REDUCTION_CHECK)
        {
            spawnDelay -= GameConstants.SPAWN_REDUCTION;
            reductionCheck = 0f;
        }
    }

    private void SpawnItem()
    {
        spawnCount++;
        int itemIndex = Random.Range(0, items.Length);
        GameObject go = Instantiate(items[itemIndex].gameObject);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.SetParent(PlayController.Instance.itemMount.transform, false);
        rt.localPosition = new Vector3(
            Random.Range(GameConstants.SAFE_SPAWN_LEFT, GameConstants.SAFE_SPAWN_RIGHT),
            GameConstants.SAFE_SPAWN_HEIGHT);
        Debug.LogFormat("Spawning at {0}", rt.localPosition.ToString());
        go.SetActive(true);
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-200, 200), -100f), ForceMode2D.Impulse);
    }
}
