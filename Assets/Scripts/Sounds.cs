using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioClip JumpClip;
    public AudioClip LandClip;
    public AudioClip CoinClip;
    
    private AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpClip()
    {
        audioSource.PlayOneShot(JumpClip);
    }
    
    public void PlayLandClip()
    {
        audioSource.PlayOneShot(LandClip);
        
    }

    public void PlayCoinClip()
    {
        audioSource.PlayOneShot(CoinClip);
    }
}
