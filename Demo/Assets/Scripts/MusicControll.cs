using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MusicControll : MonoBehaviour
{
    public AudioSource Turn;
    public AudioSource PlayStart;
    public AudioSource Pause_and_cancel;
    public AudioSource Running;
    public AudioSource Success;
    public AudioSource Fail;
    public AudioSource Carsh;
    public AudioSource fit;
    private void Awake()
    {
        Turn.Stop();
        PlayStart.Stop();
        Pause_and_cancel.Stop();
        Running.Stop();
        Fail.Stop();
        Carsh.Stop(); 
        fit.Stop();
    }
}
