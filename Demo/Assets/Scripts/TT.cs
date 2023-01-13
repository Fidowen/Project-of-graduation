/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR;

public class TT : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public UiController uiController;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }
    private void Start()
    {
        
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "start_game")
        {
            uiController.Gamestart();
            Debug.Log("���}�l");
        }
        else if (e.target.name == "setting")
        {
            uiController.GameSetting();
            Debug.Log("���]�w");
        }
        else if (e.target.name == "Quit")
        {
            uiController.GameQuit();
            Debug.Log("�����}");
        }
        else if (e.target.name == "Pause")
        {
            uiController.GamePasue();
            Debug.Log("���Ȱ�");
        }
        else if (e.target.name == "Again")
        {
            uiController.GameAgain();
            Debug.Log("���A�Ӥ@��");
        }
        else if (e.target.name == "EXIT")
        {
            uiController.GameIndex();
            Debug.Log("����^���D");
        }
        else if (e.target.name == "Cancel"|| e.target.name == "Continue")
        {
            uiController.GameCannel();
            Debug.Log("������");
        }
        else if (e.target.name == "NEXT")
        {
            Debug.Log("�U�@��");
        }
        else if (e.target.name == "VolumeDown")
        {
            uiController.VolumeDown();
            Debug.Log("�n���U��");
        }
        else if (e.target.name == "VolumeUP")
        {
            uiController.VolumeUP();
            Debug.Log("�n���W��");
        }
        else if (e.target.name == "BrightnessUP")
        {
            Debug.Log("�G�פW��");
        }
        else if (e.target.name == "BrightnessDown")
        {
            Debug.Log("�G�פU��");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        laserPointer.color = Color.red;
        print(e.target.name);
        if (e.target.name == "start_game")
        {
            laserPointer.color = Color.red;
        }
        else if (e.target.name == "setting")
        {
            laserPointer.color = Color.red;
        }
        else if (e.target.name == "Quit")
        {
            laserPointer.color = Color.red;
        }
        else if (e.target.name == "Cancel" || e.target.name == "Continue")
        {
            laserPointer.color = Color.red;
            Debug.Log("����");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "start_game")
        {
            laserPointer.color = Color.black;
        }
        else if (e.target.name == "setting")
        {
            laserPointer.color = Color.black;
        }
        else if (e.target.name == "Quit")
        {
            laserPointer.color = Color.black;
        }
        
    }
}