using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalComponentVisualizer : MonoBehaviour
{
    private int t = 0;
    public float timeOut = 0.3f;
    public int principalComponent = 1;
    public string fileName;

    private float timeElapsed;
    private List<string[]> addressDatas_W = new List<string[]>();
    private List<string[]> addressDatas_T = new List<string[]>();
    private List<string[]> addressDatas = new List<string[]>();

    private List<float[]> W_list = new List<float[]>();

    //RigControlの部分
    public GameObject humanoid;
    public Vector3 bodyRotation = new Vector3(0, 0, 0);

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

    //クオータニオン作ってみる
    Quaternion leftUpperLeg_quaternion = new Quaternion();
    Quaternion leftLowerLeg_quaternion = new Quaternion();
    Quaternion leftFoot_quaternion = new Quaternion();

    Quaternion leftShoulder_quaternion = new Quaternion();
    Quaternion leftUpperArm_quaternion = new Quaternion();
    Quaternion leftLowerArm_quaternion = new Quaternion();
    Quaternion leftHand_quaternion = new Quaternion();

    Quaternion hips_quaternion = new Quaternion();
    Quaternion spine_quaternion = new Quaternion();
    Quaternion head_quaternion = new Quaternion();

    Quaternion rightShoulder_quaternion = new Quaternion();
    Quaternion rightUpperArm_quaternion = new Quaternion();
    Quaternion rightLowerArm_quaternion = new Quaternion();
    Quaternion rightHand_quaternion = new Quaternion();

    Quaternion rightUpperLeg_quaternion = new Quaternion();
    Quaternion rightLowerLeg_quaternion = new Quaternion();
    Quaternion rightFoot_quaternion = new Quaternion();

    // Use this for initialization
    void Start()
    {
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        /*
        var csvFile_W = Resources.Load("csv/" + fileName + "_W") as TextAsset;
        var csvFile_T = Resources.Load("csv/" + fileName + "_T") as TextAsset;

        Debug.Log(csvFile_W.name);
        Debug.Log(csvFile_T.name);

        // csvファイルの内容をStringReaderに変換
        var reader_W = new StringReader(csvFile_W.text);
        var reader_T = new StringReader(csvFile_T.text);

        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader_W.Peek() > -1)
        {
            // 一行読み込む
            // カンマ(,)区切りのデータを文字列の配列に変換
            var lineData_W = reader_W.ReadLine();
            var address_W = lineData_W.Split(',');
            // リストに追加
            addressDatas_W.Add(address_W);
            // 末尾まで繰り返し...
        }

        while (reader_T.Peek() > -1)
        {
            // 一行読み込む
            // カンマ(,)区切りのデータを文字列の配列に変換
            var lineData_T = reader_T.ReadLine();
            var address_T = lineData_T.Split(',');
            // リストに追加
            addressDatas_T.Add(address_T);
            // 末尾まで繰り返し...
        }

        */

        //ためしにPCAにかける前のモーションデータをそのままアバターに入れてみる
        var csvFile = Resources.Load("csv/" + fileName) as TextAsset;
        var reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            // カンマ(,)区切りのデータを文字列の配列に変換
            var lineData = reader.ReadLine();
            var address = lineData.Split(',');
            // リストに追加
            addressDatas.Add(address);
            // 末尾まで繰り返し...
        }

        //GameObjectにクオータニオンを読み込ませる
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
        
    }

    float Tt;

    private void Update()
    {
        //timeOut秒ごとに処理を行う
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeOut)
        {
            //PCAしたあとにT[t] * Wをするならこんな感じの式になると思う．
            //これをleftUpperLeg_quaternion.Set(float.Parse(addressDatas[t][1]), float.Parse(addressDatas[t][2]), float.Parse(addressDatas[t][3]), float.Parse(addressDatas[t][0]));
            //みたいな感じでクオータニオンにセットしていく
            /*
            Tt = float.Parse(addressDatas_T[t][principalComponent]);
            Debug.Log((float.Parse(addressDatas_W[1][principalComponent])*Tt, float.Parse(addressDatas_W[2][principalComponent]) * Tt, float.Parse(addressDatas_W[3][principalComponent]) * Tt, float.Parse(addressDatas_W[0][principalComponent]) * Tt));
            */




            //クオータニオンにx,y,z,wの順に割り当てる
            leftUpperLeg_quaternion.Set(float.Parse(addressDatas[t][1]), float.Parse(addressDatas[t][2]), float.Parse(addressDatas[t][3]), float.Parse(addressDatas[t][0]));
            leftLowerLeg_quaternion.Set(float.Parse(addressDatas[t][5]), float.Parse(addressDatas[t][6]), float.Parse(addressDatas[t][7]), float.Parse(addressDatas[t][4]));
            leftFoot_quaternion.Set(float.Parse(addressDatas[t][9]), float.Parse(addressDatas[t][10]), float.Parse(addressDatas[t][11]), float.Parse(addressDatas[t][8]));

            leftShoulder_quaternion.Set(float.Parse(addressDatas[t][13]), float.Parse(addressDatas[t][14]), float.Parse(addressDatas[t][15]), float.Parse(addressDatas[t][12]));
            leftUpperArm_quaternion.Set(float.Parse(addressDatas[t][17]), float.Parse(addressDatas[t][18]), float.Parse(addressDatas[t][19]), float.Parse(addressDatas[t][16]));
            leftLowerArm_quaternion.Set(float.Parse(addressDatas[t][21]), float.Parse(addressDatas[t][22]), float.Parse(addressDatas[t][23]), float.Parse(addressDatas[t][20]));
            leftHand_quaternion.Set(float.Parse(addressDatas[t][25]), float.Parse(addressDatas[t][26]), float.Parse(addressDatas[t][27]), float.Parse(addressDatas[t][24]));

            hips_quaternion.Set(float.Parse(addressDatas[t][29]), float.Parse(addressDatas[t][30]), float.Parse(addressDatas[t][31]), float.Parse(addressDatas[t][28]));
            spine_quaternion.Set(float.Parse(addressDatas[t][33]), float.Parse(addressDatas[t][34]), float.Parse(addressDatas[t][35]), float.Parse(addressDatas[t][32]));
            head_quaternion.Set(float.Parse(addressDatas[t][37]), float.Parse(addressDatas[t][38]), float.Parse(addressDatas[t][39]), float.Parse(addressDatas[t][36]));

            rightShoulder_quaternion.Set(float.Parse(addressDatas[t][41]), float.Parse(addressDatas[t][42]), float.Parse(addressDatas[t][43]), float.Parse(addressDatas[t][40]));
            rightUpperArm_quaternion.Set(float.Parse(addressDatas[t][45]), float.Parse(addressDatas[t][46]), float.Parse(addressDatas[t][47]), float.Parse(addressDatas[t][44]));
            rightLowerArm_quaternion.Set(float.Parse(addressDatas[t][49]), float.Parse(addressDatas[t][50]), float.Parse(addressDatas[t][51]), float.Parse(addressDatas[t][48]));
            rightHand_quaternion.Set(float.Parse(addressDatas[t][53]), float.Parse(addressDatas[t][54]), float.Parse(addressDatas[t][55]), float.Parse(addressDatas[t][52]));

            rightUpperLeg_quaternion.Set(float.Parse(addressDatas[t][57]), float.Parse(addressDatas[t][58]), float.Parse(addressDatas[t][59]), float.Parse(addressDatas[t][56]));
            rightLowerLeg_quaternion.Set(float.Parse(addressDatas[t][61]), float.Parse(addressDatas[t][62]), float.Parse(addressDatas[t][63]), float.Parse(addressDatas[t][60]));
            rightFoot_quaternion.Set(float.Parse(addressDatas[t][65]), float.Parse(addressDatas[t][66]), float.Parse(addressDatas[t][67]), float.Parse(addressDatas[t][64]));
            
            
            //クオータニオンをGameObjectに入れていく
            leftUpLeg.transform.localRotation = leftUpperLeg_quaternion;
            leftLeg.transform.localRotation = leftLowerLeg_quaternion;
            leftFoot.transform.localRotation = leftFoot_quaternion;

            leftShoulder.transform.localRotation = leftShoulder_quaternion;
            leftArm.transform.localRotation = leftUpperArm_quaternion;
            leftForeArm.transform.localRotation = leftLowerArm_quaternion;
            leftHand.transform.localRotation = leftHand_quaternion;

            hips.transform.localRotation = hips_quaternion;
            spine.transform.localRotation = spine_quaternion;
            head.transform.localRotation = head_quaternion;



            rightShoulder.transform.localRotation = rightShoulder_quaternion;
            rightArm.transform.localRotation = rightUpperArm_quaternion;
            rightForeArm.transform.localRotation = rightLowerArm_quaternion;
            rightHand.transform.localRotation = rightHand_quaternion;


            rightUpLeg.transform.localRotation = rightUpperLeg_quaternion;
            rightLeg.transform.localRotation = rightLowerLeg_quaternion;
            rightFoot.transform.localRotation = rightFoot_quaternion;
            
            
            //Debug.Log("left");
            //Debug.Log((leftLowerArm_quaternion.x, leftLowerArm_quaternion.y, leftLowerArm_quaternion.z, leftLowerArm_quaternion.w));

            //Debug.Log("right");
            //Debug.Log((rightLowerArm_quaternion.x, rightLowerArm_quaternion.y, rightLowerArm_quaternion.z, rightLowerArm_quaternion.w));
            

            t++;
            //*********************

            
            timeElapsed = 0.0f;
        }
        
    }
}
