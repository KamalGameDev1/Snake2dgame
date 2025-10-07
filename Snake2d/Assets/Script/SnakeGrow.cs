using System.Collections.Generic;
using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
    [Header("References")]
    public Transform bodyPrefab;

    [Header("Movement Settings")]
    public float spacing = 0.5f;      // Distance between body segments
    public float followSpeed = 15f;   // Smoothness of segment movement

    [Header("Score System")]
    public int score = 0;
    public bool scoreMultiplier = false;
    public int multiplier = 2;

    // 🔗 LinkedList for body segments
    private LinkedList<Transform> bodyParts = new LinkedList<Transform>();
    private List<Vector3> positionsHistory = new List<Vector3>();

    void Start()
    {
        // Add head as first body node
        bodyParts.AddFirst(transform);
    }

    void FixedUpdate()
    {
        // Record head position each frame
        positionsHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var segment in bodyParts)
        {
            if (segment == transform) continue; // skip head

            // Move segment toward target position from history
            Vector3 targetPos = positionsHistory[Mathf.Min(index * Mathf.RoundToInt(1 / spacing), positionsHistory.Count - 1)];
            segment.position = Vector3.Lerp(segment.position, targetPos, followSpeed * Time.fixedDeltaTime);

            index++;
        }

        // Trim history list to avoid memory growth
        while (positionsHistory.Count > bodyParts.Count * Mathf.RoundToInt(1 / spacing))
        {
            positionsHistory.RemoveAt(positionsHistory.Count - 1);
        }
    }

    // 🪄 Grow Snake (called by Wrap.cs)
    public void Grow()
    {
        Transform newSegment = Instantiate(bodyPrefab);
        newSegment.position = bodyParts.Last.Value.position; // start at tail position
        bodyParts.AddLast(newSegment);

        // Update score
        if (scoreMultiplier)
            score += multiplier;
        else
            score++;
    }

    // ☠ Shrink Snake (used for poison)
    public void Shrink()
    {
        if (bodyParts.Count > 1)
        {
            Transform tail = bodyParts.Last.Value;
            bodyParts.RemoveLast();
            Destroy(tail.gameObject);

            if (score > 0) score -= 2;
        }
    }

}
