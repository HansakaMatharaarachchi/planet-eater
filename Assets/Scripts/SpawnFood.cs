using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{

    public List<GameObject> spawnPool;
    public GameObject quad;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStuff());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnStuff()
    {
        while (true)
        {
            SpawnDRandomly();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnDRandomly()
    {
        int randObj;
        GameObject toSpawn;
        MeshCollider collider = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;

        randObj = Random.Range(0, spawnPool.Count);
        toSpawn = spawnPool[randObj];

        screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

        pos = new Vector2(screenX, screenY);

        GameObject newFood = Instantiate(toSpawn, pos, Quaternion.identity) as GameObject;

        if (newFood.gameObject.tag == "Danger")
        {
            // Destroy(newFood, 5);
        }
        Destroy(newFood, 5);
    }
}
