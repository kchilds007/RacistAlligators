using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Launcher : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawnPoint;
    private Vector2 baseVector;
    private float dotProduct;
    private float angle;

    private void Start()
    {
        baseVector = Vector2.up;
    }

    public void Launch(Vector2 aimDirection, int direction)
    {
        GameObject projectileObject = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, Quaternion.identity);
        angle = CalculateAngle(aimDirection, direction);
        projectileObject.transform.Rotate(0, 0, angle-45);
        
    }

    private float CalculateAngle(Vector2 aimDirection, int direction)
    {
        dotProduct = Vector2.Dot(aimDirection, baseVector);
        float mag1 = (float) Math.Sqrt(aimDirection.x * aimDirection.x + aimDirection.y * aimDirection.y);
        float mag2 = (float) Math.Sqrt(baseVector.x * baseVector.x + baseVector.y * baseVector.y);
        float theta = (float) Math.Acos(dotProduct / (mag1 * mag2));
        theta =  theta * 180 / Mathf.PI;
        return theta * direction;
    }
}