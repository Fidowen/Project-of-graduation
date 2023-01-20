using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
using static HTC.UnityPlugin.Vive.RenderModelHook;

public class Spawner : MonoBehaviour//生成障礙物
{
    public Road_Create Road_Create;
    public Transform[] BornPoint;
    public GameObject[] cubes;
    public GameObject storagepoint;
    float Timer;
    public float beats =0.3f;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveTest(MoveTowardsTest);
        if (Timer>beats)
        {
            for(int i = 0;i<Random.Range(1, BornPoint.Length-3);i++)
            {
                GameObject go =  SpawnCubes();
                
            }
                
            Timer = 0;
            
        }
        Timer+=Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            Destroy(this.gameObject);
        }
    }
    private GameObject SpawnCubes()
    {
        GameObject go  = Instantiate(cubes[Random.Range(0,cubes.Length)],BornPoint[Random.Range(0,BornPoint.Length)]);
        if (Random.Range(0,2) == 0)
        {
            go.GetComponent<Rigidbody>().isKinematic = true;
        }
        go.transform.localPosition = Vector3.zero;
        go.transform.parent = storagepoint.transform;
        return go;
    }
      public IEnumerator LeftTrun()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(Vector3.up, -90);
        Quaternion tmpQuaternion = transform.rotation;                                                      //?��?�V�Z���|��?�}�O�s
        transform.Rotate(Vector3.up, 90);                                                                   //���צ^?
        Tween tween = transform.DORotateQuaternion(tmpQuaternion, 0.3f);
    }
    public IEnumerator RightTrun()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(Vector3.up, 90);
        Quaternion tmpQuaternion = transform.rotation;                                                      //?��?�V�Z���|��?�}�O�s
        transform.Rotate(Vector3.up,- 90);                                                                   //���צ^?
        Tween tween = transform.DORotateQuaternion(tmpQuaternion, 0.3f);
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
                    UiController.This.Success();
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
}
