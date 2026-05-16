using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 startPosition;
    private float maxRange = GameParameters.MaxProjectileRange;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void destroy()
    {
        Destroy(gameObject);
    }
    
}
