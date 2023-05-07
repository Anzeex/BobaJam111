using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public float volume = 1f;
    public AudioSource audioSource;
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0;
            audioSource.Play();
            StartCoroutine(FadeIn(fadeInTime));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        LoadVolume();
    }

    public void SetVolume(float v)
    {
        volume = v;
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    void LoadVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volume;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeOutAndFadeIn(fadeOutTime, fadeInTime));
    }

    private IEnumerator FadeIn(float duration)
    {
        while (audioSource.volume < volume)
        {
            audioSource.volume += Time.deltaTime / duration;
            yield return null;
        }

        audioSource.volume = volume;
    }

    private IEnumerator FadeOut(float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.volume = 0;
    }

    private IEnumerator FadeOutAndFadeIn(float fadeOutDuration, float fadeInDuration)
    {
        yield return StartCoroutine(FadeOut(fadeOutDuration));
        yield return StartCoroutine(FadeIn(fadeInDuration));
    }
}
