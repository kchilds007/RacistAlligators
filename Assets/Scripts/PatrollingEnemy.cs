using System;
using UnityEngine;

public class PatrollingEnemy : MobileMob
{
    public float speed = GameParameters.PatrollingEnemyspeed;
    public Transform transform;

    protected int direction = 1;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isFacingLeft = false;
        movement.x = direction;
    }

    void Update()
    {
        base.Update();
    }

    void OnTriggerExit2D(Collider2D ground)
    {
        if (ground.tag == "Ground")
        {
            changeDirection();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + speed * direction * Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }

    public void changeDirection()
    {
        direction *= -1;
        transform.localScale = new Vector3(4 * direction, 4, 1);
    }
    
}