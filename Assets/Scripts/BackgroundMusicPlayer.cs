using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    // need list of audio clips/songs to play
    public AudioClip[] songs;
    
    // need an audio source
    private AudioSource audioSource;
    private int currentSongIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (!audioSource.isPlaying)
        {
            PlaySong();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if a song isn't playing, choose a random song and play
        if (!audioSource.isPlaying)
        {
            PlaySong();
        }
    }

    private void PlaySong()
    {
        currentSongIndex = Random.Range(0, songs.Length);
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }
}
