using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public const string BGM_KEY = "bgm";
    public const string SFX_KEY = "sfx";

    private const float MIN_PITCH = 0.75f;
    private const float MAX_PITCH = 1.25f;
    private static SoundManager _instance;

    public AudioClip click;
    public AudioClip correct;
    public AudioClip wrong;

    [SerializeField]
    private AudioSource loop;

    [SerializeField]
    private GameObject oneshots;

    public static SoundManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<SoundManager>();
            }
            return _instance;
        }
    }

    public void Loop(AudioClip clip) {
        loop.clip = clip;
        loop.Play();
    }

    public void Play(AudioClip clip, bool isNormal = false) {
        StartCoroutine(PlayThenDestroy(clip, isNormal));
    }

    private IEnumerator PlayThenDestroy(AudioClip clip, bool isNormal) {
        GameObject go = new GameObject();
        AudioSource source = go.AddComponent<AudioSource>();

        source.pitch = isNormal ? 1 : Random.Range(MIN_PITCH, MAX_PITCH);
        source.PlayOneShot(clip);
        source.transform.SetParent(oneshots.transform);
        yield return new WaitWhile(() => source.isPlaying);
        Destroy(go);
    }
}