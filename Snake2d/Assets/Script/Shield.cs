using UnityEngine;

public class Shield : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject shieldPrefab;
    public float lifeTime = 8f;
    public float spawnDelay = 5f;
    public float spawnInterval = 15f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeController>())
        {
            Destroy(gameObject);
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnShield), spawnDelay, spawnInterval);
    }

    private void SpawnShield()
    {
        Bounds bounds = gridArea.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        Vector3 spawnPos = new Vector3(x, y, 0f);
        Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
    }
}
