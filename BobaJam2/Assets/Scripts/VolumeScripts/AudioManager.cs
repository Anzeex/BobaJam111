using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public float volume = 1f;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
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
        if(PlayerPrefs.HasKey("Volume")){
            volume = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volume;
        }
    }

}
