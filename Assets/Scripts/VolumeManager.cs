using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    Slider volume;

    public void SetVolume()
    {
        AudioListener.volume = volume.value;
    }
}
