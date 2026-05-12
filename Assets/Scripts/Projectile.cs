using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 startPosition;
    private float maxRange = GameParameters.MaxProjectileRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, startPosition) >= maxRange)
        {
            Destroy(gameObject);
        }
    }
}
