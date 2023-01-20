using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR;
public class Road_Create : MonoBehaviour//生成規則
{
    public static bool currentstate = true;          //遊戲是否運行 True為是,false為否
    public GameObject[] maps;                       //存放道路
    public GameObject[] truns;                      //轉彎道路
    public List<Transform> TurnCheck = new List<Transform>();
    private Transform saveobj;                      //紀錄位置
    public static int List = 0;                     //切換地圖場景計數
    public GameObject RightHand;

    public GameObject background;
    //public RectTransform CanvaHp;
    public GameObject initialmap;
    public GameObject detectblock;
    public GameObject end;

    private void Awake()
    {

    }
    void Start()
    {

        saveobj = initialmap.transform;
        for (int i = 0; i < 3; i++)
        {
            straightroad();
        }
        /*straightroad();
        straightroad();
        LeftTrunRoad();
        straightroad();
        straightroad();
        RightTrunRoad();*/
        for (int i = 0; i < 10; i++)                                //先生成20格道路作預備跑道
        {
            createmaps(List);
        }
        endmaps();
    }

    // Update is called once per frame
    void Update()
    {
        checkgame();
    }
    public void createmaps(int a)
    {
        int turnSeed = Random.Range(0, 4);                                  //用于确定是否?
        if (turnSeed == 1)
        {
            //回合?更新
            int dictSeed = Random.Range(1, 3);
            if (dictSeed == 1)       //右轉
            {
                RightTrunRoad();
                LeftTrunRoad();
            }
            else if (dictSeed == 2)//左轉
            {
                LeftTrunRoad();
                RightTrunRoad();
            }
        }
        else
        {
            straightroad();
        }
    }
    public void endmaps()
    {
        GameObject a = Instantiate(end, saveobj.position, saveobj.rotation);
        a.name = "End";
        var turnRoad = Instantiate(detectblock, new Vector3(saveobj.position.x, saveobj.position.y + 1, saveobj.position.z), saveobj.rotation);
        turnRoad.tag = "End";
        turnRoad.name = "EndMap";
        turnRoad.AddComponent<end>();
        TurnCheck.Add(turnRoad.transform);
        saveobj.position += saveobj.forward * 10f;          //每生成一次道路，物体的位置改變指定數量

    }
    public void checkgame()
    {
        if (currentstate)
        {
            background.SetActive(true);
            RightHand.SetActive(true);
            Time.timeScale = 1; //當遊戲狀態為正常時，時間正常
        }
        else
        {
            background.SetActive(false);
            RightHand.SetActive(false);
            Time.timeScale = 0;//當遊戲狀態為否時，時間暫停
        }
    }
    void RightTrunRoad()
    {   //生成右轉
        saveobj.position -= saveobj.forward * 0f;
        var tmpRoad = Instantiate(truns[1], saveobj.position, saveobj.rotation);
        tmpRoad.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        var turnRoad = Instantiate(detectblock, new Vector3(saveobj.position.x, saveobj.position.y + 1, saveobj.position.z), saveobj.rotation);
        turnRoad.gameObject.tag = "Right";
        turnRoad.name = "RightTrun";
        TurnCheck.Add(turnRoad.transform);
        saveobj.position += saveobj.forward;
        //改變下次生成方向
        saveobj.position += saveobj.forward * -1f;     //轉向區域生成完成后，引導物體回退2格
        saveobj.position += saveobj.right * 10f;
        saveobj.Rotate(Vector3.up, 90);               //轉向
        saveobj.position += saveobj.forward * 0f;     //轉向后引導物體的forward軸，改軸pos值，到下一道路的生成地

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            straightroad();
        }
    }
    void LeftTrunRoad()
    {
        //生成左轉
        saveobj.position -= saveobj.forward * 0f;
        var tmpRoad = Instantiate(truns[0], saveobj.position, saveobj.rotation);
        tmpRoad.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        var turnRoad = Instantiate(detectblock, new Vector3(saveobj.position.x, saveobj.position.y + 1, saveobj.position.z), saveobj.rotation);
        turnRoad.gameObject.tag = "Left";
        turnRoad.name = "LeftTrun";
        TurnCheck.Add(turnRoad.transform);
        saveobj.position += saveobj.forward;
        //改變下次生成方向
        saveobj.position += saveobj.forward * -1f;     //轉向區域生成完成后，引導物體回退2格
        saveobj.position -= saveobj.right * 10f;
        saveobj.Rotate(Vector3.up, -90);               //轉向
        saveobj.position += saveobj.forward * 0f;     //轉向后引導物體的forward軸，改軸pos值，到下一道路的生成地

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            straightroad();
        }
    }
    void straightroad()
    {
        var tmpRoad = Instantiate(maps[0], saveobj.position, saveobj.rotation);
        saveobj.position += saveobj.forward * 10f;          //每生成一次道路，物体的位置改變指定數量
    }
    /*void stop(){
        if(Random.Range(0,20)==9){
                GameObject stop =  Instantiate(stopcubes,BornPoint[Random.Range(0,BornPoint.Length)]);
                stop.transform.localPosition = Vector3.zero;
                stop.transform.parent = storagepoint.transform;
            }
    }*/
}

