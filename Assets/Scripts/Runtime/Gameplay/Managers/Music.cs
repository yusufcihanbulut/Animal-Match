using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip backgroundMusic; // Arka plan m�zi�i
    [SerializeField] private AudioClip clickSound;       // Kart t�klama sesi

    void Start()
    {
        // AudioSource bile�enini al
        audioSource = GetComponent<AudioSource>();

        // Arka plan m�zi�ini �almaya ba�la
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        // Arka plan m�zi�ini ayarla ve �al
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // S�rekli tekrar etsin
        audioSource.Play();
    }

    public void StopMusic()
    {
        // M�zi�i durdur
        audioSource.Stop();
    }

    public void PlayClickSound()
    {
        // Kart t�klama sesini �al
        audioSource.PlayOneShot(clickSound);
    }
}
