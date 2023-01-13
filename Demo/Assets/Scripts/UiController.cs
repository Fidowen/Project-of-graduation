using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    float Volume = 0;
    Scene scene;
    public Text VolumeText;
    [SerializeField]GameObject Setting_Ui;
    [SerializeField]GameObject Pause_Ui;
    [SerializeField]GameObject Die_ui;
    [SerializeField]GameObject Success_Ui;
    [SerializeField]GameObject GameIndex_Ui;
    static public UiController This;
    public MusicControll musicControll;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
        scene = SceneManager.GetActiveScene();
        Application.targetFrameRate= 60;
        QualitySettings.vSyncCount = 0;
        This  = this;
    }
    private void Update()
    {
        if (scene.name == "Fail")
        {
            Time.timeScale = 1;
        }
    }
    public void GamePasue()//遊戲暫停
    {
        musicControll.Pause_and_cancel.Play();
        Road_Create.currentstate=false;
        Pause_Ui.SetActive(true);
    }
    public void Gamestart()//開始遊戲
    {
        musicControll.Pause_and_cancel.Play();
        SceneManager.LoadScene(1);
        Road_Create.currentstate = true;

    }
    public void GameSetting()//開設定
    {
        Time.timeScale = 1;
        if (GameObject.Find("gameindex") != null)
        {
            GameIndex_Ui.SetActive(false);
        }
        if (scene.name == "Main")
        {
            
            Pause_Ui.SetActive(false);
        }
        Setting_Ui.SetActive(true);
        Road_Create.currentstate = false;
    }
    public void GameIndex()//菜單
    {
        Time.timeScale = 1;
        musicControll.Pause_and_cancel.Play();
        SceneManager.LoadScene(0);
    }
    public void GameQuit() //離開遊戲
    {
        Application.Quit();
    }
    public void GameCannel()//取消
    {
        if (scene.name == "Home")
        {
            if(GameObject.Find("gameindex") == null)
            {
                GameIndex_Ui.SetActive(true);
            }
        }
        musicControll.Pause_and_cancel.Play();
        Setting_Ui.SetActive(false);
        Pause_Ui.SetActive(false);
        Road_Create.currentstate = true;
    }
    public void GameAgain()//再玩一次
    {
        Road_Create.currentstate = true;
        SceneManager.LoadScene(1);
        musicControll.Pause_and_cancel.Play();
        
    }
    public void Gameover()
    {
        
        SceneManager.LoadScene("Fail");
    }
    public void Success()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Success");
    }
    public void VolumeDown()
    {
        VolumeText.text =(Volume+80).ToString();
        if(Volume > -80)
        {
            Volume -= 10f;
        }
        audioMixer.SetFloat("Mainmusic", Volume);
    }
    public void VolumeUP()
    {
        VolumeText.text = (Volume+80).ToString();
        if (Volume < 0)
        {
            Volume += 10f;
        }
        audioMixer.SetFloat("Mainmusic", Volume);
    }
    void CheckScene()
    {
        if(scene.name == "Index")
        {

        }
        else if (scene.name == "Pause")
        {

        }
        else if (scene.name == "Main")
        {
            
        }
        else if (scene.name == "Success")
        {

        }
        else if (scene.name == "Fail")
        {

        }
    }
}
