using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanControllerv2 : MonoBehaviour
{

    public enum Parts
    {
        spine, chest, neck, rightShoulder, rightElbow, leftShoulder, leftElbow, rightHip, rightKnee, leftHip, leftKnee
    };

    private GameObject cube;
    private GameObject sphere;
    private Animator anim;
    public Parts target;

    private Transform from_bone;
    private Transform to_bone;
    private Quaternion rq;

    // Use this for initialization
    void Start()
    {
        // 必要なオブジェクトを取得
        cube = GameObject.Find("Cube");
        sphere = GameObject.Find("Sphere");
        anim = (Animator)FindObjectOfType(typeof(Animator));

        // Inspector上での入力をもとに操作する関節を決定
        AttachTarget();

        // 操作したい関節とその子の関節の初期クオータニオンの逆を保存
        rq = Quaternion.Inverse(Quaternion.LookRotation(from_bone.localPosition - to_bone.localPosition));
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion c2sqt;
        Vector3 c2svec = cube.transform.position - sphere.transform.position;
        // 胴体の関節を動かす
        if (target == Parts.neck || target == Parts.chest || target == Parts.spine)
        {
            // 胸の関節を動かす
            if (target == Parts.chest)
            {
                if (c2svec.z > 0)
                {
                    c2sqt = Quaternion.LookRotation(c2svec);
                }
                else
                {
                    c2svec.x *= -1.0f;
                    c2sqt = Quaternion.Inverse(Quaternion.LookRotation(c2svec));
                    c2sqt = c2sqt * Quaternion.AngleAxis(180, Vector3.forward);
                }
            }
            // 胸以外の関節を動かす
            else
            {
                if (c2svec.z > 0)
                {
                    c2svec *= -1.0f;
                    c2sqt = Quaternion.LookRotation(c2svec);
                }
                else
                {
                    c2svec.z *= -1.0f;
                    c2sqt = Quaternion.Inverse(Quaternion.LookRotation(c2svec));
                    c2sqt = c2sqt * Quaternion.AngleAxis(180, Vector3.forward);
                }
            }
        }
        // 腕または足の関節を動かす
        else
        {
            // 肘の場合
            if (target == Parts.leftElbow || target == Parts.rightElbow)
            {
                c2svec *= -1.0f;
                c2sqt = Quaternion.LookRotation(c2svec);
            }
            // 肘以外の場合
            else
            {
                c2sqt = Quaternion.LookRotation(c2svec);
            }
        }
        // 回転処理
        from_bone.rotation = c2sqt * rq;
    }

    void AttachTarget()
    {
        switch (target)
        {
            case Parts.neck:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.Neck);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.Head);
                    break;
                }
            case Parts.chest:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.Chest);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.Neck);
                    break;
                }
            case Parts.spine:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.Spine);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.Chest);
                    break;
                }
            case Parts.rightShoulder:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
                    break;
                }
            case Parts.rightElbow:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.RightHand);
                    break;
                }
            case Parts.leftShoulder:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
                    break;
                }
            case Parts.leftElbow:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.LeftHand);
                    break;
                }
            case Parts.rightHip:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
                    break;
                }
            case Parts.rightKnee:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.RightFoot);
                    break;
                }
            case Parts.leftHip:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
                    break;
                }
            case Parts.leftKnee:
                {
                    from_bone = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
                    to_bone = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
                    break;
                }
        }
    }
}