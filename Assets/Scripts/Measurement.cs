using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Measurement : MonoBehaviour
{
    //上肢
    GameObject rightShoulder;
    GameObject rightArm;
    GameObject rightForeArm;
    GameObject rightHand;
    GameObject leftShoulder;
    GameObject leftArm;
    GameObject leftForeArm;
    GameObject leftHand;

    //腰,頭
    GameObject hips;
    GameObject head;
    GameObject spine;

    //下肢
    GameObject rightUpLeg;
    GameObject rightLeg;
    GameObject rightFoot;
    GameObject rightToeBase;
    GameObject leftUpLeg;
    GameObject leftLeg;
    GameObject leftFoot;
    GameObject leftToeBase;

    //上肢のローカルクォータニオン
    Quaternion rightHandQuaternion, rightShoulderQuaternion, rightForeArmQuaternion, rightArmQuaternion;
    Quaternion leftHandQuaternion, leftShoulderQuaternion, leftForeArmQuaternion, leftArmQuaternion;

    //頭、腰のローカルクォータニオン
    Quaternion hipsQuaternion, headQuaternion,spineQuaternion;

    //下肢のローカルクォータニオン
    Quaternion rightUpLegQuaternion, rightLegQuaternion, rightFootQuaternion, rightToeBaseQuaternion;
    Quaternion leftUpLegQuaternion, leftLegQuaternion, leftFootQuaternion, leftToeBaseQuaternion;

    //初期クォータニオン(全関節共通)
    Quaternion startQuaternion;

    private bool startFlag = false;


    //速さ計算用に一時的に記録しておくための変数
    float[] tmp = new float[16];

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        //上肢割り当て
        rightHand = GameObject.FindWithTag("RightHand");
        rightForeArm = GameObject.FindWithTag("RightForeArm");
        rightArm = GameObject.FindWithTag("RightArm");
        rightShoulder = GameObject.FindWithTag("RightShoulder");
        leftHand = GameObject.FindWithTag("LeftHand");
        leftShoulder = GameObject.FindWithTag("LeftShoulder");
        leftForeArm = GameObject.FindWithTag("LeftForeArm");
        leftArm = GameObject.FindWithTag("LeftArm");

        //腰,頭割り当て
        hips = GameObject.FindWithTag("Hips");
        head = GameObject.FindWithTag("Head");
        spine = GameObject.FindWithTag("Spine");

        //下肢割り当て
        rightUpLeg = GameObject.FindWithTag("RightUpLeg");
        rightLeg = GameObject.FindWithTag("RightLeg");
        rightFoot = GameObject.FindWithTag("RightFoot");
        rightToeBase = GameObject.FindWithTag("RightToeBase");
        leftUpLeg = GameObject.FindWithTag("LeftUpLeg");
        leftLeg = GameObject.FindWithTag("LeftLeg");
        leftFoot = GameObject.FindWithTag("LeftFoot");
        leftToeBase = GameObject.FindWithTag("LeftToeBase");

        //初期クォータニオン割り当て
        startQuaternion = hips.transform.localRotation;
    }



    // Update is called once per frame
    void Update()
    {
        if (startFlag == true)
        {
            SetLocalQuaternion();
            LogSave();
            Savetmp();
        }
    }


    /**
     * @brief 全身のローカルクォータニオンを ?Quaternionに格納する
     */
    public void SetLocalQuaternion()
    {
        //頭のローカルクオータニオン格納
        headQuaternion = head.transform.localRotation;

        //上肢のローカルクオータニオン格納
        rightShoulderQuaternion = rightShoulder.transform.localRotation;
        rightArmQuaternion = rightArm.transform.localRotation;
        rightForeArmQuaternion = rightForeArm.transform.localRotation;
        rightHandQuaternion = rightHand.transform.localRotation;

        leftShoulderQuaternion = leftShoulder.transform.localRotation;
        leftArmQuaternion = leftArm.transform.localRotation;
        leftForeArmQuaternion = leftForeArm.transform.localRotation;
        leftHandQuaternion = leftHand.transform.localRotation;

        //腰のローカルクオータニオン格納
        hipsQuaternion = hips.transform.localRotation;
        spineQuaternion = spine.transform.localRotation;

        //下肢のローカルクオータニオン格納
        rightUpLegQuaternion = rightUpLeg.transform.localRotation;
        rightLegQuaternion = rightLeg.transform.localRotation;
        rightFootQuaternion = rightFoot.transform.localRotation;
        rightToeBaseQuaternion = rightToeBase.transform.localRotation;

        leftUpLegQuaternion = leftUpLeg.transform.localRotation;
        leftLegQuaternion = leftLeg.transform.localRotation;
        leftFootQuaternion = leftFoot.transform.localRotation;
        leftToeBaseQuaternion = leftToeBase.transform.localRotation;
    }


    // ファイル書き出し
    private bool headerWrite = true; //ヘッダー書き込みを一度だけ行うための変数
    public void LogSave()
    {
        StreamWriter sw = new StreamWriter(@"March_Parkinson_normal_sort_Unity.csv", true, Encoding.GetEncoding("Shift_JIS"));
        if (headerWrite == true)
        {
            // ヘッダー出力
            string[] s1 = {
                /*
            "Head_Q",
            "RightShoulder_Q", "RightArm_Q", "RightForeArm_Q", "RightHand_Q",
            "LeftShoulder_Q", "LeftArm_Q", "LeftForeArm_Q", "LeftHand_Q",
            "Hip_Q", "Spine_Q",
            "RightUpLeg_Q", "RightLeg_Q", "RightFoot_Q",
            "LeftUpLeg_Q", "LeftLeg_Q", "LeftFoot_Q",
            */
            
            
            
            
            
            

            
      
         
           
          
       
            
         
           
             
          
       

           
            
           
           
        
       

            //左下肢
            "LeftUpLeg_Q_w", "LeftUpLeg_Q_x",   "LeftUpLeg_Q_y", "LeftUpLeg_Q_z",
            "LeftLeg_Q_w",  "LeftLeg_Q_x", "LeftLeg_Q_y",  "LeftLeg_Q_z",
            "LeftFoot_Q_w",   "LeftFoot_Q_x",  "LeftFoot_Q_y",  "LeftFoot_Q_z",



            //左上肢
            "LeftShoulder_Q_w", "LeftShoulder_Q_x", "LeftShoulder_Q_y","LeftShoulder_Q_z", 
                "LeftArm_Q_w", "LeftArm_Q_x", "LeftArm_Q_y", "LeftArm_Q_z",
                "LeftForeArm_Q_w", "LeftForeArm_Q_x","LeftForeArm_Q_y","LeftForeArm_Q_z",
                "LeftHand_Q_w", "LeftHand_Q_x", "LeftHand_Q_y","LeftHand_Q_z",
                
                //体幹
                 "Hip_Q_w", "Hip_Q_x","Hip_Q_y","Hip_Q_z",
                 "Spine_Q_w", "Spine_Q_x","Spine_Q_y",  "Spine_Q_z",
                "Head_Q_w","Head_Q_x","Head_Q_y", "Head_Q_z",

            //右上肢
            "RightShoulder_Q_w", "RightShoulder_Q_x","RightShoulder_Q_y","RightShoulder_Q_z",
                "RightArm_Q_w", "RightArm_Q_x", "RightArm_Q_y","RightArm_Q_z",
                "RightForeArm_Q_w", "RightForeArm_Q_x", "RightForeArm_Q_y","RightForeArm_Q_z",
                "RightHand_Q_w", "RightHand_Q_x", "RightHand_Q_y","RightHand_Q_z",

            //右下肢
            "RightUpLeg_Q_w", "RightUpLeg_Q_x",  "RightUpLeg_Q_y", "RightUpLeg_Q_z",
                "RightLeg_Q_w","RightLeg_Q_x", "RightLeg_Q_y", "RightLeg_Q_z",
                "RightFoot_Q_w",  "RightFoot_Q_x","RightFoot_Q_y",   "RightFoot_Q_z",





            /*
            "Head_v",
            "RightShoulder_v", "RightArm_v", "RightForeArm_v", "RightHand_v",
            "LeftShoulder_v", "LeftArm_v", "LeftForeArm_v", "LeftHand_v",
            "Hip_v", "Spine_v",
            "RightUpLeg_v", "RightLeg_v", "RightFoot_v",
            "LeftUpLeg_v", "LeftLeg_v", "LeftFoot_v",

            " ",

            "Head_x",
            "RightShoulder_x", "RightArm_x", "RightForeArm_x", "RightHand_x",
            "LeftShoulder_x", "LeftArm_x", "LeftForeArm_x", "LeftHand_x",
            "Hip_x", "Spine_x",
            "RightUpLeg_x", "RightLeg_x", "RightFoot_x",
            "LeftUpLeg_x", "LeftLeg_x", "LeftFoot_x",

            " ",

            "Head_y",
            "RightShoulder_y", "RightArm_y", "RightForeArm_y", "RightHand_y",
            "LeftShoulder_y", "LeftArm_y", "LeftForeArm_y", "LeftHand_y",
            "Hip_y", "Spine_y",
            "RightUpLeg_y", "RightLeg_x", "RightFoot_y",
            "LeftUpLeg_y", "LeftLeg_y", "LeftFoot_y",

            " ",

            "Head_z",
            "RightShoulder_z", "RightArm_z", "RightForeArm_z", "RightHand_z",
            "LeftShoulder_z", "LeftArm_z", "LeftForeArm_z", "LeftHand_z",
            "Hip_z", "Spine_z",
            "RightUpLeg_z", "RightLeg_z", "RightFoot_z",
            "LeftUpLeg_z", "LeftLeg_z", "LeftFoot_z"
            
             */
            };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
            headerWrite = false;
            Savetmp();
        }

        // データ出力
        string[] str = {
            //初期クオータニオンと，現在のクオータニオンの角度を出力
            /*
            GetLocalQuaternion(headQuaternion).ToString(),
            GetLocalQuaternion(rightShoulderQuaternion).ToString(), GetLocalQuaternion(rightArmQuaternion).ToString(), GetLocalQuaternion(rightForeArmQuaternion).ToString(), GetLocalQuaternion(rightHandQuaternion).ToString(),
            GetLocalQuaternion(leftShoulderQuaternion).ToString(), GetLocalQuaternion(leftArmQuaternion).ToString(), GetLocalQuaternion(leftForeArmQuaternion).ToString(), GetLocalQuaternion(leftHandQuaternion).ToString(),
            GetLocalQuaternion(hipsQuaternion).ToString(), GetLocalQuaternion(spineQuaternion).ToString(),
            GetLocalQuaternion(rightUpLegQuaternion).ToString(), GetLocalQuaternion(rightLegQuaternion).ToString(), GetLocalQuaternion(rightFootQuaternion).ToString(),
            GetLocalQuaternion(leftUpLegQuaternion).ToString(), GetLocalQuaternion(leftLegQuaternion).ToString(), GetLocalQuaternion(leftFootQuaternion).ToString(),
            */       
            
            



            //左下肢
            leftUpLegQuaternion.w.ToString(),leftUpLegQuaternion.x.ToString(),leftUpLegQuaternion.y.ToString(),leftUpLegQuaternion.z.ToString(),
            leftLegQuaternion.w.ToString(),leftLegQuaternion.x.ToString(),leftLegQuaternion.y.ToString(),leftLegQuaternion.z.ToString(),
            leftFootQuaternion.w.ToString(),leftFootQuaternion.x.ToString(),leftFootQuaternion.y.ToString(), leftFootQuaternion.z.ToString(),
            //左上肢
            leftShoulderQuaternion.w.ToString(),leftShoulderQuaternion.x.ToString(),leftShoulderQuaternion.y.ToString(),leftShoulderQuaternion.z.ToString(),
            leftArmQuaternion.w.ToString(),leftArmQuaternion.x.ToString(),leftArmQuaternion.y.ToString(),leftArmQuaternion.z.ToString(),
            leftForeArmQuaternion.w.ToString(),leftForeArmQuaternion.x.ToString(),leftForeArmQuaternion.y.ToString(),leftForeArmQuaternion.z.ToString(),
            leftHandQuaternion.w.ToString(), leftHandQuaternion.x.ToString(),leftHandQuaternion.y.ToString(), leftHandQuaternion.z.ToString(),

            //体幹
            hipsQuaternion.w.ToString(),hipsQuaternion.x.ToString(),hipsQuaternion.y.ToString(),hipsQuaternion.z.ToString(),
            spineQuaternion.w.ToString(),spineQuaternion.x.ToString(),spineQuaternion.y.ToString(),spineQuaternion.z.ToString(),
            headQuaternion.w.ToString(),headQuaternion.x.ToString(),headQuaternion.y.ToString(),headQuaternion.z.ToString(),

            //右上肢
            rightShoulderQuaternion.w.ToString(),rightShoulderQuaternion.x.ToString(),rightShoulderQuaternion.y.ToString(),rightShoulderQuaternion.z.ToString(),
            rightArmQuaternion.w.ToString(),rightArmQuaternion.x.ToString(), rightArmQuaternion.y.ToString(), rightArmQuaternion.z.ToString(),
            rightForeArmQuaternion.w.ToString(),rightForeArmQuaternion.x.ToString(),rightForeArmQuaternion.y.ToString(),rightForeArmQuaternion.z.ToString(),
            rightHandQuaternion.w.ToString(),rightHandQuaternion.x.ToString(),rightHandQuaternion.y.ToString(),rightHandQuaternion.z.ToString(),

            //右下肢
            rightUpLegQuaternion.w.ToString(), rightUpLegQuaternion.x.ToString(), rightUpLegQuaternion.y.ToString(), rightUpLegQuaternion.z.ToString(),
            rightLegQuaternion.w.ToString(),rightLegQuaternion.x.ToString(), rightLegQuaternion.y.ToString(),  rightLegQuaternion.z.ToString(),
            rightFootQuaternion.w.ToString(),rightFootQuaternion.x.ToString(),rightFootQuaternion.y.ToString(), rightFootQuaternion.z.ToString(),

            
            

            /*

            //クオータニオンの変化の速さ(正の値)出力
            System.Math.Abs((tmp[0] - GetLocalQuaternion(headQuaternion))).ToString(),
            System.Math.Abs((tmp[1] - GetLocalQuaternion(rightShoulderQuaternion))).ToString(), System.Math.Abs((tmp[2] - GetLocalQuaternion(rightArmQuaternion))).ToString(), System.Math.Abs((tmp[3] - GetLocalQuaternion(rightForeArmQuaternion))).ToString(), System.Math.Abs((tmp[4] - GetLocalQuaternion(rightHandQuaternion))).ToString(),
            System.Math.Abs((tmp[5] - GetLocalQuaternion(leftShoulderQuaternion))).ToString(), System.Math.Abs((tmp[6] - GetLocalQuaternion(leftArmQuaternion))).ToString(), System.Math.Abs((tmp[7] - GetLocalQuaternion(leftForeArmQuaternion))).ToString(), System.Math.Abs((tmp[8] - GetLocalQuaternion(leftHandQuaternion))).ToString(),
            System.Math.Abs((tmp[9] - GetLocalQuaternion(hipsQuaternion))).ToString(), 
            System.Math.Abs((tmp[10] - GetLocalQuaternion(rightUpLegQuaternion))).ToString(), System.Math.Abs((tmp[11] - GetLocalQuaternion(rightLegQuaternion))).ToString(), System.Math.Abs((tmp[12] - GetLocalQuaternion(rightFootQuaternion))).ToString(),
            System.Math.Abs((tmp[13] - GetLocalQuaternion(leftUpLegQuaternion))).ToString(), System.Math.Abs((tmp[14] - GetLocalQuaternion(leftLegQuaternion))).ToString(), System.Math.Abs((tmp[15] - GetLocalQuaternion(leftFootQuaternion))).ToString(),

            " ",

            //オイラー角x出力
            GetDeltaLocalEulerAngles(head.transform.localEulerAngles.x).ToString(),
            GetDeltaLocalEulerAngles(rightShoulder.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(rightArm.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(rightForeArm.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(rightHand.transform.localEulerAngles.x).ToString(),
            GetDeltaLocalEulerAngles(leftShoulder.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(leftArm.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(leftForeArm.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(leftHand.transform.localEulerAngles.x).ToString(),
            GetDeltaLocalEulerAngles(hips.transform.localEulerAngles.x).ToString(),
            GetDeltaLocalEulerAngles(rightUpLeg.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(rightLeg.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(rightFoot.transform.localEulerAngles.x).ToString(),
            GetDeltaLocalEulerAngles(leftUpLeg.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(leftLeg.transform.localEulerAngles.x).ToString(), GetDeltaLocalEulerAngles(leftFoot.transform.localEulerAngles.x).ToString(),

            " ",

            //オイラー角y出力
            GetDeltaLocalEulerAngles(head.transform.localEulerAngles.y).ToString(),
            GetDeltaLocalEulerAngles(rightShoulder.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(rightArm.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(rightForeArm.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(rightHand.transform.localEulerAngles.y).ToString(),
            GetDeltaLocalEulerAngles(leftShoulder.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(leftArm.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(leftForeArm.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(leftHand.transform.localEulerAngles.y).ToString(),
            GetDeltaLocalEulerAngles(hips.transform.localEulerAngles.y).ToString(),
            GetDeltaLocalEulerAngles(rightUpLeg.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(rightLeg.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(rightFoot.transform.localEulerAngles.y).ToString(),
            GetDeltaLocalEulerAngles(leftUpLeg.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(leftLeg.transform.localEulerAngles.y).ToString(), GetDeltaLocalEulerAngles(leftFoot.transform.localEulerAngles.y).ToString(),

            " ",

            //オイラー角z出力
            GetDeltaLocalEulerAngles(head.transform.localEulerAngles.z).ToString(),
            GetDeltaLocalEulerAngles(rightShoulder.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(rightArm.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(rightForeArm.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(rightHand.transform.localEulerAngles.z).ToString(),
            GetDeltaLocalEulerAngles(leftShoulder.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(leftArm.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(leftForeArm.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(leftHand.transform.localEulerAngles.z).ToString(),
            GetDeltaLocalEulerAngles(hips.transform.localEulerAngles.z).ToString(),
            GetDeltaLocalEulerAngles(rightUpLeg.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(rightLeg.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(rightFoot.transform.localEulerAngles.z).ToString(),
            GetDeltaLocalEulerAngles(leftUpLeg.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(leftLeg.transform.localEulerAngles.z).ToString(), GetDeltaLocalEulerAngles(leftFoot.transform.localEulerAngles.z).ToString(),
        */
        }; 
        string str2 = string.Join(",", str);
        sw.WriteLine(str2);
        // StreamWriterを閉じる
        sw.Close();
    }


    public void Savetmp()
    {
        tmp[0] = GetLocalQuaternion(headQuaternion);
        tmp[1] = GetLocalQuaternion(rightShoulderQuaternion); tmp[2] = GetLocalQuaternion(rightArmQuaternion); tmp[3] = GetLocalQuaternion(rightForeArmQuaternion); tmp[4] = GetLocalQuaternion(rightHandQuaternion);
        tmp[5] = GetLocalQuaternion(leftShoulderQuaternion); tmp[6] = GetLocalQuaternion(leftArmQuaternion); tmp[7] = GetLocalQuaternion(leftForeArmQuaternion); tmp[8] = GetLocalQuaternion(leftHandQuaternion); 
        tmp[9] = GetLocalQuaternion(hipsQuaternion);
        tmp[10] = GetLocalQuaternion(rightUpLegQuaternion); tmp[11] = GetLocalQuaternion(rightLegQuaternion); tmp[12] = GetLocalQuaternion(rightFootQuaternion);
        tmp[13] = GetLocalQuaternion(leftUpLegQuaternion); tmp[14] = GetLocalQuaternion(leftLegQuaternion); tmp[15] = GetLocalQuaternion(leftFootQuaternion);
    }


    /**
     * @brief 初期クォータニオンとtargetQuaternionのクォータニオンを返す関数
     * @return 初期クォータニオンとtargetQuaternionの相対角度
     */
     public float GetLocalQuaternion(Quaternion targetQuaternion)
     {
        return Quaternion.Angle(startQuaternion, targetQuaternion);
     }


    /**
     * @brief オイラー角を+-180の範囲で返す関数
     * @return +-180のオイラー角
     */
    public float GetDeltaLocalEulerAngles(float localEulerAngles)
    {
        return Mathf.DeltaAngle(0, localEulerAngles);
    }


    /**
     * @brief 頭のクォータニオンとtargetQuaternionの角度を返す関数
     * @param targetQuaternion 頭との相対角度を知りたい部位のクォータニオン
     * @return 頭クォータニオンとtargetQuaternionの相対角度
     */
    public float GetAngleWith_headQuaternion(Quaternion targetQuaternion)
    {
        return Quaternion.Angle(headQuaternion, targetQuaternion);
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(50, 20, 100, 50), "Start"))
        {
            startFlag = true;
        }

        if(GUI.Button(new Rect(200, 20, 100, 50), "End"))
        {
            startFlag = false;
        }
    }



/*
public void Measure()
{
    //各部位のローカルクオータニオン格納
    SetLocalQuaternion();


    //頭との相対クオータニオンを求める
    //上肢
    GetAngleWith_headQuaternion(rightShoulderQuaternion);
    GetAngleWith_headQuaternion(rightArmQuaternion);
    GetAngleWith_headQuaternion(rightForeArmQuaternion);
    GetAngleWith_headQuaternion(rightHandQuaternion);
    GetAngleWith_headQuaternion(leftShoulderQuaternion);
    GetAngleWith_headQuaternion(leftArmQuaternion);
    GetAngleWith_headQuaternion(leftForeArmQuaternion);
    GetAngleWith_headQuaternion(leftHandQuaternion);

    //腰
    GetAngleWith_headQuaternion(hipsQuaternion);

    //下肢
    GetAngleWith_headQuaternion(rightUpLegQuaternion);
    GetAngleWith_headQuaternion(rightLegQuaternion);
    GetAngleWith_headQuaternion(rightFootQuaternion);
    GetAngleWith_headQuaternion(rightToeBaseQuaternion);
    GetAngleWith_headQuaternion(leftUpLegQuaternion);
    GetAngleWith_headQuaternion(leftLegQuaternion);
    GetAngleWith_headQuaternion(leftFootQuaternion);
    GetAngleWith_headQuaternion(leftToeBaseQuaternion);

}*/


}
