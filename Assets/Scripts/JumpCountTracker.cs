using UnityEngine;

public static class JumpCountTracker
{

    public static int TotalJumpCount = 0;

    public static void UpdateTotalJumpCount()
    {
        ++TotalJumpCount;
    }

    public static void ResetTotalJumpCount()
    {
        TotalJumpCount = 0;
    }
}
