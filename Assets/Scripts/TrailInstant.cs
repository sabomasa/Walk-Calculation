using UnityEngine;
using System.Collections;

public class TrailInstant : MonoBehaviour
{

    //生成するゲームオブジェクト
    public GameObject target;

    void Update()
    {
         //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
         Instantiate(target, new Vector3(0, 0, 0), Quaternion.identity);
    }
}