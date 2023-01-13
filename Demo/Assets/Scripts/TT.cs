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
            Debug.Log("按開始");
        }
        else if (e.target.name == "setting")
        {
            uiController.GameSetting();
            Debug.Log("按設定");
        }
        else if (e.target.name == "Quit")
        {
            uiController.GameQuit();
            Debug.Log("按離開");
        }
        else if (e.target.name == "Pause")
        {
            uiController.GamePasue();
            Debug.Log("按暫停");
        }
        else if (e.target.name == "Again")
        {
            uiController.GameAgain();
            Debug.Log("按再來一次");
        }
        else if (e.target.name == "EXIT")
        {
            uiController.GameIndex();
            Debug.Log("按返回標題");
        }
        else if (e.target.name == "Cancel"|| e.target.name == "Continue")
        {
            uiController.GameCannel();
            Debug.Log("按取消");
        }
        else if (e.target.name == "NEXT")
        {
            Debug.Log("下一關");
        }
        else if (e.target.name == "VolumeDown")
        {
            uiController.VolumeDown();
            Debug.Log("聲音下降");
        }
        else if (e.target.name == "VolumeUP")
        {
            uiController.VolumeUP();
            Debug.Log("聲音上升");
        }
        else if (e.target.name == "BrightnessUP")
        {
            Debug.Log("亮度上升");
        }
        else if (e.target.name == "BrightnessDown")
        {
            Debug.Log("亮度下降");
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
            Debug.Log("取消");
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