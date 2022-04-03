using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip die, jump;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        die = Resources.Load<AudioClip>("DyingMan");
        jump = Resources.Load<AudioClip>("Jump");
        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    static public void playSound(string clip)
    {
        audioSrc.volume = 0.5f;
        switch (clip) {
            case "die":
                GameObject.Find("AudioManager").GetComponent<AudioManager>().endMusic();
                audioSrc.volume = 0.5f;
                audioSrc.PlayOneShot(die);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
        }
    }

}
