using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    //public AudioSource[] _Audio;
    //public AudioSource _KeyPickup;
    //public AudioSource _OpenDoor;


    //public void AudioLib(int i)
    //{
    //    _Audio[i].Play();

    //}

    //private void Start()
    //{
    //    if(transform.childCount > 0)
    //    {
    //        for (int i = 0; i < transform.childCount; i++)
    //        {

    //        }
    //    }
    //}

    //public void KeyPickup()
    //{
    //    _KeyPickup.Play();
    //}
    //public void OpenDoor()
    //{
    //    _OpenDoor.Play();
    //}

    // ****************************
    // How to use ?
    // AudioSystem.Instance.PlaySound("AudioSystem/name");
    // AudioSystem.Instance.PlaySound("OpenDoor");
    // ****************************

    public static AudioSystem Instance;

    private Dictionary<string, AudioSource> soundDictionary = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        // 单例模式初始化
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 收集子物体音频组件
        foreach (Transform child in transform)
        {
            AudioSource audioSource = child.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                soundDictionary[child.name] = audioSource;
            }
            else
            {
                Debug.LogWarning($"子物体 {child.name} 缺少 AudioSource 组件");
            }
        }
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioSource audioSource))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning($"音频名称 {soundName} 不存在");
        }
    }
}
