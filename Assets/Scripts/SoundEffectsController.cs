using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectsController : MonoBehaviour
{
    [Header("Audio Mixer Settings")]
    [SerializeField] private AudioMixer _audioMixer;

    private const string _musicVolumeParam = GameConstantsRepository.VolumeMusicKey;
    private const string _soundVolumeParam = GameConstantsRepository.VolumeSoundKey;

    public void AdjustMusicVolume(float volume)
    {
        ApplyVolumeSetting(_musicVolumeParam, volume);
    }

    public void AdjustSoundVolume(float volume)
    {
        ApplyVolumeSetting(_soundVolumeParam, volume);
    }

    private void ApplyVolumeSetting(string parameterName, float volume)
    {
        _audioMixer.SetFloat(parameterName, volume);
    }
}