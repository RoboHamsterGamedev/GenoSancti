using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
    [SerializeField] AudioClip mainMusic;

    [SerializeField] AudioClip clickSound = null;
    AudioSource sourceMain = null;
    AudioSource sourceAnothers = null;
    [SerializeField] public bool isMuteon = false;
    [SerializeField] Sprite muteon = null;
    [SerializeField] Sprite muteoff = null;
    [SerializeField] GameObject mute = null;

    void Awake()
    {

        if (instance != null)
        {
            if (instance != this) { Destroy(this.gameObject); }
        }
        else
        {
            instance = this.transform.GetComponent<AudioManager>(); ;
            DontDestroyOnLoad(this);
        }
        
        sourceMain = this.transform.GetComponent<AudioSource>();
        sourceMain.clip = mainMusic;

    }

    private void Start()
    {
        sourceMain.Play();
    }
    public void SourceAnotherPlay(AudioClip clip)
    {
        if (sourceAnothers.isActiveAndEnabled == true)
        {
            sourceAnothers.clip = clip;
            sourceAnothers.Play();
        }
    }

    public void ClickMusic()
    {
        SourceAnotherPlay(clickSound);
    }
   
    public void Mute()
    {

        if (sourceMain.enabled == true)
        {
            sourceAnothers.enabled = false;
            sourceMain.enabled = false;
            isMuteon = true;
            mute.GetComponent<Image>().sprite = muteon;

        }
        else
        {
            sourceAnothers.enabled = true;
            sourceMain.enabled = true;
            isMuteon = false;
            mute.GetComponent<Image>().sprite = muteoff;
        }

    }
}
