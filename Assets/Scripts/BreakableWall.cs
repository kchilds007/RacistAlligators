using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject BrokenWall;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            //do not change these numbers for the position, different pixel art settings and scaling make mapping things really really weird
            SummonBrokenWall();
            Destroy(gameObject);
        }
    }

    private void SummonBrokenWall()
    {
        Vector3 position = new Vector3((float) (transform.position.x + 5.87), (float) (transform.position.y - 3.125), transform.position.z);
        BrokenWall = Instantiate(BrokenWall, position, transform.rotation);
    }
}
