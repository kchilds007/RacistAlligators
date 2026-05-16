using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    private Camera mainCamera ;

    public Transform player;

    private float screenHeight ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        screenHeight = 2f * mainCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        float topEdge = screenHeight / 2 + mainCamera.transform.position.y;
        float bottomEdge = topEdge - screenHeight ;
        
        if (player.position.y > topEdge)
        {
            MoveCameraVertical(1);
        } else if (player.position.y < bottomEdge)
        {
            MoveCameraVertical(-1);
        }
        
        
    }

    public void MoveCameraVertical(int multiplier)
    {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,
            mainCamera.transform.position.y + screenHeight * multiplier, mainCamera.transform.position.z);
    }
    
}