using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    string masterKey = "MasterVolume";
    string musicKey = "MusicVolume";
    string sfxKey = "SfxVolume";

    public float MasterVolume { get => _masterVolume; }
    float _masterVolume;
    public float MusicVolume { get => _musicVolume; }
    float _musicVolume;
    public float SfxVolume { get => _sfxVolume; }
    float _sfxVolume;


    private void Start()
    {
        SetMasterVolume(PlayerPrefs.HasKey(masterKey) ? PlayerPrefs.GetFloat(masterKey) : 1);
        SetMusicVolume(PlayerPrefs.HasKey(musicKey) ? PlayerPrefs.GetFloat(musicKey) : 1);
        SetSfxVolume(PlayerPrefs.HasKey(sfxKey) ? PlayerPrefs.GetFloat(sfxKey) : 1);
    }
    public void SetMasterVolume(float volume)
    {
        _masterVolume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        mixer.SetFloat(masterKey, ToDecibel(volume));
            
    }
    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        mixer.SetFloat(musicKey, ToDecibel(volume));

    }
    public void SetSfxVolume(float volume)
    {
        _sfxVolume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
       
        mixer.SetFloat(sfxKey, ToDecibel(volume));

    }
    public float ToDecibel(float volume)
    {
        return Mathf.Log10(volume) * 20;
    }


}
