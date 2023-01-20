using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteMap : MonoBehaviour//刪除地圖
{
    void OnCollisionExit()
    {
        Destroy(this.gameObject,10f);
    }
}
