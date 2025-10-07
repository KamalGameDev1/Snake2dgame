using UnityEngine;

public class FoodController : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        transform.position = new Vector3(x, y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<SnakeController>())
        {
            RandomizePosition();
        }
    }
}
