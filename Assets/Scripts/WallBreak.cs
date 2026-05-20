using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private Transform center;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        center = GameObject.FindGameObjectWithTag("BrokenWall").transform;
        applyForce();
        
    }

    private void applyForce()
    {
        Vector2 forceDirection = new Vector2(GameParameters.WallBreakForce.X - center.position.x, GameParameters.WallBreakForce.Y - center.position.y);
        forceDirection.x *= (float) 0.01;
        forceDirection.y *= (float) 0.01;
        rigidbody.AddForce(forceDirection, ForceMode2D.Impulse);
        rigidbody.AddTorque(GameParameters.WallBreaktorque, ForceMode2D.Impulse);
    }
}
