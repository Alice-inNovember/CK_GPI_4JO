using System.Collections.Generic;
using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
    public float SfxVol = 0.5f;
    public float BgmVol = 0.5f;
    protected override void Awake()
    {
        SfxVol = 0.5f;
        BgmVol = 0.5f;
        dontDestroyOnLoad = true;
        base.Awake();
    }
}

