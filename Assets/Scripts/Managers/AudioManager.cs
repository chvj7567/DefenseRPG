using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Audio.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    float _bgmVolume = 0.2f;
    float _effectVolume = 0.5f;
    public float Ratio { get; private set; } = 0.5f;

    public void Init()
    {
        GameObject root = GameObject.Find("@Audio");
        if (root == null)
        {
            root = new GameObject { name = "@Audio" };


            string[] soundNames = System.Enum.GetNames(typeof(Define.Audio));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Audio.Bgm].loop = true;
        }

        Object.DontDestroyOnLoad(root);
    }

    public void SetVolume(float ratio)
    {
        Ratio = ratio;
        _audioSources[(int)Define.Audio.Bgm].volume = _bgmVolume * Ratio;
    }

    public void Play(string path, Define.Audio type, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);

        AudioSource audioSource = _audioSources[(int)type];

        audioSource.pitch = pitch;

        if (type == Define.Audio.Bgm)
        {
            audioSource.volume = _bgmVolume * Ratio;

            if (audioSource.isPlaying)
                return;

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            audioSource.volume = _effectVolume * Ratio;
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Audio type)
    {
        if (path.Contains("Audio/") == false)
            path = $"Audio/{path}";

        AudioClip audioClip = null;

        if (type == Define.Audio.Bgm)
        {
            audioClip = MainManager.Resource.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = MainManager.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing! {path}");

        return audioClip;
    }
}
