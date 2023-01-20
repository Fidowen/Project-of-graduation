using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using static HTC.UnityPlugin.Vive.RenderModelHook;
using Valve.VR;
using Valve.VR.Extras;
using UnityEngine.UIElements;

public class PlayerChaster : MonoBehaviour//角色移動設定
{
    private SteamVR_Action_Boolean grip = SteamVR_Input.GetBooleanAction("GrabGrip");
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public Road_Create Road_Create;
    public float speed;
    public bool stash = true;
    public static PlayerChaster This;
    public UiController uiController;
    public int hp;
    int index = 0;
    Camera Cameracam;
    public MusicControll musicControll;
    public RectTransform CanvasHp;
    Vector3 endpostion;
    // Start is called before the first frame update
    void Start()
    {
        hp = 220;
        This = this;
        Cameracam = gameObject.transform.GetChild(2).GetComponent<Camera>();
        musicControll.Running.Play();
        endpostion = Road_Create.TurnCheck[Road_Create.TurnCheck.Count - 1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (grip.GetStateDown(rightHand))
        {
            uiController.GamePasue();
        }
        if (this.transform.position == new Vector3(endpostion.x - 1, endpostion.y, endpostion.z - 1))
        {
            UiController.This.Success();
            Debug.LogError("阿巴阿巴");
        }
        MoveTest(MoveTowardsTest);
        if (hp <= 0)
        {
            this.gameObject.transform.position = new Vector3(0, 1000, 0);
            musicControll.Running.Stop();
            musicControll.Fail.Play();
            UiController.This.GamePasue();
            uiController.Gameover();
            hp = 10;
        }
        Cameracam.DOShakePosition(10, Vector3.Lerp(Vector3.left, Vector3.right, 0.1f), 0, 0, true);

    }
    private void FixedUpdate()
    {
        //fixedCamera();
    }
    public void LeftTrun()
    {
        musicControll.Turn.Play();
        transform.Rotate(Vector3.up, -90);
        Quaternion tmpQuaternion = transform.rotation;                                                      //?��?�V�Z���|��?�}�O�s
        transform.Rotate(Vector3.up, 90);                                                                   //���צ^?
        Tween tween = transform.DORotateQuaternion(tmpQuaternion, 0.3f);
    }
    public void RightTrun()
    {
        musicControll.Turn.Play();
        transform.Rotate(Vector3.up, 90);
        Quaternion tmpQuaternion = transform.rotation;                                                      //?��?�V�Z���|��?�}�O�s
        transform.Rotate(Vector3.up, -90);                                                                   //���צ^?
        Tween tween = transform.DORotateQuaternion(tmpQuaternion, 0.3f);
    }
    public void deduct_blood()
    {
        hp -= 12;
        Debug.Log("剩餘血量" + hp);
        CanvasHp.sizeDelta -= new Vector2(12, 0);
    }
    public void add_blood()
    {
        if (hp < 100)
        {
            hp += 10;
            CanvasHp.sizeDelta += new Vector2(10, 0);
        }
        Debug.Log("剩餘血量" + hp);
    }
    public void MoveTest(FindPath path)
    {
        if (Vector3.Distance(transform.position, Road_Create.TurnCheck[index].position) <= 0.3f)
        {
            if (index < Road_Create.TurnCheck.Count - 1)
            {

                index += 1;
                if (Road_Create.TurnCheck[index - 1].name == "LeftTrun")
                {
                    LeftTrun();
                }
                else if (Road_Create.TurnCheck[index - 1].name == "RightTrun")
                {
                    RightTrun();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        path.Invoke();
    }

    public void MoveTowardsTest()
    {
        transform.position = Vector3.MoveTowards(transform.position, Road_Create.TurnCheck[index].position, 7 * Time.deltaTime);

    }

    public delegate void FindPath();
    void fixedCamera()
    {
        if (Cameracam.transform.position.y < 0)
        {
            Cameracam.transform.position = new Vector3(Cameracam.transform.position.x, Cameracam.transform.position.y + 0.5f, Cameracam.transform.position.z);
            Debug.Log("太低");

        }
        if (Cameracam.transform.position.y > 1.2f)
        {
            Cameracam.transform.position = new Vector3(Cameracam.transform.position.x, Cameracam.transform.position.y - 0.2f, Cameracam.transform.position.z);
            Debug.Log("太高");
        }
    }
}
