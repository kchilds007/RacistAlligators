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
        angle = CalculateAngle(aimDirection);
        //direction == -1 when character is facing left, so projectile needs to be flipped over y axis to keep look
        if (direction == -1)
        {
            projectileObject.transform.Rotate(0, 180, angle-75);
        }
        //base
        else
        {
            projectileObject.transform.Rotate(0, 0, angle-75);
        }
        
        
    }
    //converting vector2 to angle using arccos((1 dot 2)/(magnitude1 * magnitude2)) where 1 is the aiming vector and base vector is (0,1)
    //do not touch unless you want to do a lot of calculations and rework launch
    private float CalculateAngle(Vector2 aimDirection)
    {
        dotProduct = Vector2.Dot(aimDirection, baseVector);
        float mag1 = (float) Math.Sqrt(aimDirection.x * aimDirection.x + aimDirection.y * aimDirection.y);
        float mag2 = (float) Math.Sqrt(baseVector.x * baseVector.x + baseVector.y * baseVector.y);
        float theta = (float) Math.Acos(dotProduct / (mag1 * mag2));
        theta =  theta * 180 / Mathf.PI;
        return theta;
    }
}