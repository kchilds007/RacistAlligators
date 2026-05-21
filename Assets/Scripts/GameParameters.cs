
using System.Numerics;

public static class GameParameters
{
    public static float acceleration = 20f;
    public static float decceleration = 40f;
    public static float velPower = 2f;
    public static float maxJumpPower = 20f;
    public static float minJumpPower = 0.5f;
    public static float variableJumpPower = 0.2f;
    public static bool isJumping = false;

    public static float PatrollingEnemyspeed = 5;
    public static float PlayerAttackCooldown = 1.5f;
    public static float ProjectileForce = 10f;
    public static float MaxProjectileRange = 3f;
    
    public static float SlipFactor = 10f;

    public static float WallBreaktorque = 3f;
    public static Vector2 WallBreakForce = new Vector2(1,1);
    
    public static int MinScoreGoal = 30;
    
}
