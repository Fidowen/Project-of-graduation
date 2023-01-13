using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    Rigidbody Rigidbodyrb;
    SphereCollider sphereCollider;
    UiController uiController;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<Rigidbody>();
        uiController = GameObject.Find("GameController").GetComponent<UiController>();
        Player = GameObject.Find("player");
        Rigidbodyrb = this.gameObject.GetComponent<Rigidbody>();
        sphereCollider = this.gameObject.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = false;
        Rigidbodyrb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Background")
        {
            Player.transform.position = new Vector3(0, 1000, 0);
            DontDestroyOnLoad(Player);
            uiController.GamePasue();
            uiController.Success();
        }
    }
}
