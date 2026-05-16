using Unity.VisualScripting;
using UnityEngine;

public class SideCollisions : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody.AddForceX(rigidbody.linearVelocityX*-2, ForceMode2D.Impulse);
    }
}
