using UnityEngine;

public class JumpCountTracker : MonoBehaviour
{
    private int totalJumpCount = 0;

    void Start()
    {
        totalJumpCount = 0;
    }

    public void UpdateTotalJumpCount()
    {
        ++totalJumpCount;
    }

    public void ResetTotalJumpCount()
    {
        totalJumpCount = 0;
    }

    public int getTotalJumpCount()
    {
        return totalJumpCount;
    }
}
