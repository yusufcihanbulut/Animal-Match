using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip backgroundMusic; // Arka plan müziði
    [SerializeField] private AudioClip clickSound;       // Kart týklama sesi

    void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();

        // Arka plan müziðini çalmaya baþla
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        // Arka plan müziðini ayarla ve çal
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Sürekli tekrar etsin
        audioSource.Play();
    }

    public void StopMusic()
    {
        // Müziði durdur
        audioSource.Stop();
    }

    public void PlayClickSound()
    {
        // Kart týklama sesini çal
        audioSource.PlayOneShot(clickSound);
    }
}
