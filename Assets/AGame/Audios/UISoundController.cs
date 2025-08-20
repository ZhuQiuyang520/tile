using UnityEngine;
using UnityEngine.Audio;

public class UISoundController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject effectGameObject;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = effectGameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioMixer.SetFloat("BgSoundVolume", -20.0f);
            audioMixer.SetFloat("EffectSoundVolume", 0.0f);
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioMixer.SetFloat("BgSoundVolume", 0.0f);
            audioMixer.SetFloat("EffectSoundVolume", -80.0f);
            audioSource.Stop();
        }
    }
}
