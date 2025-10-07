using System.Collections;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [Header("References")]
    public SnakeGrow snakeGrow;
    public GameObject GameOverPanel;

    [Header("Boundaries")]
    public float minX = -9f;
    public float maxX = 9f;
    public float minY = -5f;
    public float maxY = 5f;
    public float wrapOffset = 0.3f;

    [Header("State")]
    public bool isShielded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 🍎 Food
        if (other.GetComponent<FoodController>())
        {
            snakeGrow.Grow();
        }

        // 🌍 Screen Wrapping
        else if (other.CompareTag("Right"))
            transform.position = new Vector3(minX + wrapOffset, transform.position.y, 0f);
        else if (other.CompareTag("Left"))
            transform.position = new Vector3(maxX - wrapOffset, transform.position.y, 0f);
        else if (other.CompareTag("Up"))
            transform.position = new Vector3(transform.position.x, minY + wrapOffset, 0f);
        else if (other.CompareTag("Down"))
            transform.position = new Vector3(transform.position.x, maxY - wrapOffset, 0f);

        // 🛡 Shield
        //else if (other.CompareTag("Shield"))
        //{
        //    StartCoroutine(ShieldOn());
        //    Destroy(other.gameObject);
        //}

        //// ✴ Score Multiplier
        //else if (other.CompareTag("Multiplier"))
        //{
        //    StartCoroutine(ScoreMultiplier());
        //    Destroy(other.gameObject);
        //}

        //// ☠ Poison
        //else if (other.CompareTag("Poison"))
        //{
        //    snakeGrow.Shrink();
        //    if (snakeGrow.score > 0) snakeGrow.score -= 2;
        //}

        //// 💥 Obstacle
        //else if (other.CompareTag("Obstacle"))
        //{
        //    if (!isShielded)
        //    {
        //        GameOver();
        //    }
        //}
    }

    IEnumerator ShieldOn()
    {
        isShielded = true;
        yield return new WaitForSeconds(5f);
        isShielded = false;
    }

    IEnumerator ScoreMultiplier()
    {
        snakeGrow.scoreMultiplier = true;
        yield return new WaitForSeconds(10f);
        snakeGrow.scoreMultiplier = false;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        Debug.Log("💀 Game Over!");
    }
}
