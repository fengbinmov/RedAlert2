﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveAI : MonoBehaviour {

    public Vector3 targetPostion;                      //目标当前保存
    private Vector3 targetSith = Vector3.zero;  //目标上一位置保存
    private LineRenderer mLineRenderer;

    public Vector3 dirtionHead = Vector3.zero;  //领队Cube的相对位置
    public Vector3 dirtionFace;                 //Cube望向的方向

    public float speed = 1f;                    //移动速度
    public float rotateSpeed = 5f;              //转向速度

    public int roundCudeNum = 0;                //周围可影响自身的Cube数量
    public float cubeWatchRang = 0.5f;          //可影响自身的范围

    void Start()
    {
        mLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //判断是否受到指挥官的命令      //TODO
        if (GameControl.gameControl.SetNewCommand.GetSelectListCube().IndexOf(transform) > -1)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            //收集[在指挥官的命令中 & 在可见范围内]
            Collider[] collider = Physics.OverlapSphere(transform.position, cubeWatchRang);
            foreach (Collider c in collider)
            {
                if (GameControl.gameControl.SetNewCommand.GetSelectListCube().IndexOf(c.gameObject.transform) > -1)
                {
                    roundCudeNum++;
                }
            }
            GameControl.gameControl.SetNewCommand.AddCube(transform, roundCudeNum);
            roundCudeNum = 0;

            targetPostion = GameControl.gameControl.SetNewCommand.GetTargetPostion(transform);
            //目标位置正常   计算与周围Cube的相对位置，设置Cube望向的方向
            if (targetPostion != Vector3.zero)
            {
                if (targetSith != targetPostion || targetSith == null)
                {
                    targetSith = targetPostion;
                    dirtionFace = targetPostion - transform.position;
                    dirtionHead = transform.position - GameControl.gameControl.SetNewCommand.GetCenterCubePos;
                    NavLineOpenShow();
                }
                float distance = Vector3.Distance(transform.position, targetPostion + dirtionHead);
                if (distance > 0.1f)
                {
                    CubeMove();
                }
                //Debug.DrawLine(transform.position, targetPostion + dirtionHead, Color.green);
            }
        }
        else if (targetPostion != Vector3.zero)
        {
            float distance = Vector3.Distance(transform.position, targetPostion + dirtionHead);
            if (distance > 0.1f)
            {
                CubeMove();
            }
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }

    }
    private void CubeMove() {
        transform.position = Vector3.MoveTowards(transform.position, targetPostion + dirtionHead, Time.deltaTime * speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirtionFace), Time.deltaTime * rotateSpeed);
    }
    private void OnDestroy()
    {
        if (GameControl.gameControl != null)    //防止意外退出GameControl前与销毁
        {
            GameControl.gameControl.SetNewCommand.RemoveCube(transform);
        }
    }
    private void NavLineOpenShow() {
        mLineRenderer.enabled = true;
        mLineRenderer.SetPosition(0, transform.position);
        mLineRenderer.SetPosition(1, targetPostion + dirtionHead);
        Invoke("NavLineCloseShow", 0.1f);
    }
    private void NavLineCloseShow() {
        mLineRenderer.enabled = false;
    }
}