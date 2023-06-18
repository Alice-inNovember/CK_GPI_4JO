using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = AudioManager.Instance.BgmVol;
    }
}
