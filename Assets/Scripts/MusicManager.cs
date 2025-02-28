using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Singleton yapısı
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu nesneyi sahne geçişlerinde yok etme
        }
        else
        {
            Destroy(gameObject); // Eğer başka bir örneği varsa bu nesneyi yok et
        }
    }

    void Start()
    {
        // Müzik başlatma
        GetComponent<AudioSource>().Play();
    }
}
