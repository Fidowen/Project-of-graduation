using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Cube : MonoBehaviour//障礙物移動
{
    public GameObject Explotion;
    public GameObject Player;

    public float speed = 5;
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;

    GameObject AudioControll;
    AudioSource hitaudio;
    AudioSource Injuried;
    void Start()
    {
        AudioControll = GameObject.Find("AudioControll");
        hitaudio = AudioControll.transform.GetChild(0).GetComponent<AudioSource>();
        Injuried = AudioControll.transform.GetChild(1).GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player");
        Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        transform.Rotate(0,0,10f);
        transform.Rotate(0,0,10f);
        transform.localPosition += Time.deltaTime * Vector3.back * speed;
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Background")
        {
            Destroy(this.gameObject);
            hitaudio.Stop();
            Injuried.Play();
            Pulse(0.1f, 150, 75, SteamVR_Input_Sources.RightHand);
            Pulse(0.1f, 150, 75, SteamVR_Input_Sources.LeftHand);
            PlayerChaster.This.deduct_blood();
        }
        if (other.tag == "saber")//打到障礙物tag
        {
            Destroy(this.gameObject);
            Injuried.Stop();
            hitaudio.Play();
            Instantiate(Explotion, transform.position, transform.rotation);
            print("加分");
            PlayerChaster.This.add_blood();
        }
        if (other.tag == "TurnFloor")
        {
            Destroy(this.gameObject);
        }
    }
    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("Pluse");
    }
    
}
