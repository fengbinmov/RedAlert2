﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using GameAttrType;
using UnityEngine.SceneManagement;

public class SoldierTypePanel : BasePanel
{
    private bool pause = false;
    private GameObject selectItemPanel;
    private GameObject volumePanel;
    private bool volumePanelActive = false;

    private List<Button> BuildBtnList = new List<Button>();
    private Button DemosBuildBtn;
    private Button SoldierBuildBtn;
    private Button CarBuildBtn;
    private Button WaterBuildBtn;
    private Button AirBuildBtn;
    private GameObject VolumeBtnObject;

    private List<Text> BuildTextList = new List<Text>();
    private Text DemosHasNum;
    private Text SoldierHasNum;
    private Text CarHasNum;
    private Text WaterHasNum;
    private Text AirHasNum;

    //Demos、Soldier、Car、Water、Air   建筑数量
    private int[] activeArr = { 0, 0, 0, 0, 0 };
    private int[] activeArrNow = { 0, 0, 0, 0, 0 };

    public SoldierTypePanel() : base()
    {
        uIPanelType = UIPanelType.SoldierType;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        StartShowAnim();
        Init();
    }

    public override void OnExit()
    {

    }

    public override void OnPause()
    {
        volumePanelActive = false;
        volumePanel.SetActive(volumePanelActive);
        HiteAnim();
    }

    public override void OnResume()
    {
        ShowAnim();
    }
    public override void ListPanelRemoveEvent(UIPanelType uIPanelType)
    {
        if (uIPanelType == UIPanelType.SelectItem) {
            VolumeBtnObject.SetActive(true);
        }
    }
    public override void GetBroadInfo<T>(ENUM_MSG_TYPE mSG_TYPE, T info)
    {
        switch (mSG_TYPE)
        {
            case ENUM_MSG_TYPE.OBJECT:
                    MakeMessageOBJ(info);
                break;
            case ENUM_MSG_TYPE.CONTAINER:
                break;
            case ENUM_MSG_TYPE.STRING:
                break;
            case ENUM_MSG_TYPE.ARRAY:
                    InitBuildNum(info);
                break;
            case ENUM_MSG_TYPE.NUMBER:
                break;
            case ENUM_MSG_TYPE.STRUCT:
                break;
            default:
                break;
        }
    }
    private void MakeMessageOBJ<T>(T info) {
        BaseMember baseMember = info as BaseMember;
        List<BaseMember> list = new List<BaseMember>();
        switch (baseMember.selfDataValue.m_data.m_u2ID)
        {
            case 1500:
                OnClickBuildDemos();
                list.Add(new SoldierMem1100());
                list.Add(new SoldierMem1100());
                break;
            case 1502:
                OnClickBuildSoldier();
                list.Add(new SoldierMem1100());
                list.Add(new SoldierMem1100());
                break;
            case 1503:
                OnClickBuildCar();
                break;
            case 1504:
                OnClickBuildWater();
                break;
            case 1505:
                OnClickBuildAir();
                break;
            default:
                return;
        }
        GameControl.gameControl.SendBroadInfoForUI(UIPanelType.SelectItem, ENUM_MSG_TYPE.CONTAINER, list);
    }
    #region 主选项按键事件
    private void OnClickBuildVolume()
    {
        if (GameControl.gameControl.LookPanelListTop() == UIPanelType.SelectItem)
        {
            GameControl.gameControl.RemovePanel(UIPanelType.SelectItem);
        }
        volumePanelActive = !volumePanelActive;
        volumePanel.SetActive(volumePanelActive);

    }
    private void OnClickBuildDemos()
    {
        VolumeBtnObject.SetActive(true);
        OnClickOpenBar();
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.DEMOS);
        //GameControl.gameControl.SendBuildInfoForUI<List<BaseMember>>(UIPanelType.SelectItem,ENUM_MSG_TYPE.CONTAINER,)
    }
    private void OnClickBuildSoldier()
    {
        VolumeBtnObject.SetActive(true);
        OnClickOpenBar();
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.SOLDIER);
    }
    private void OnClickBuildCar()
    {
        VolumeBtnObject.SetActive(true);
        OnClickOpenBar();
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.CAR);
    }
    private void OnClickBuildWater()
    {
        VolumeBtnObject.SetActive(true);
        OnClickOpenBar();
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.WATER);
    }
    private void OnClickBuildAir()
    {
        VolumeBtnObject.SetActive(true);
        OnClickOpenBar();
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.AIR);
    }
    private void OnClickOpenBar()
    {
        volumePanel.SetActive(false);
        if (GameControl.gameControl.LookPanelListTop() == UIPanelType.SelectItem)
        {
            GameControl.gameControl.RemovePanel(UIPanelType.SelectItem);
        }
        GameControl.gameControl.AddPanel(UIPanelType.SelectItem);
    }
    #endregion

    #region Volume按键事件

    public void OnClickBuildSystem() {
        VolumeBtnObject.SetActive(false);
        OnClickOpenBar();
        List<BaseMember> objectItems = new List<BaseMember>();
        objectItems.Add(new Build1500());
        objectItems.Add(new Build1502());
        objectItems.Add(new Build1503());
        objectItems.Add(new Build1504());
        objectItems.Add(new Build1505());
        GameControl.gameControl.SendBroadInfoForUI<List<BaseMember>>(UIPanelType.SelectItem, ENUM_MSG_TYPE.CONTAINER, objectItems);
    }
    #endregion

    #region 动画事件
    private void StartShowAnim()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x + 100f, transform.position.y, transform.position.z);
        transform.DOMoveX(transform.position.x - 100f, 0.4f);
    }
    private void ShowAnim()
    {
        gameObject.SetActive(true);
        transform.DOMoveX(transform.position.x - 100f, 0.1f);
    }
    private void HiteAnim()
    {
        transform.DOMoveX(transform.position.x + 100f, 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
    #endregion

    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 55, 100, 30), "切换场景"))
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            //Debug.Log("切换场景");
            //Debug.Log("ObjectCount:["+GameOperation.gameOperation.GetObjectCount().ToString()+"]");
            //SceneManager.LoadScene(0);
            //GameObject.Instantiate(Resources.Load("Prefabs/Build/CarBuild") as GameObject);
        }
    }
    private void Init() {

        volumePanel = transform.Find("VolumePanel").gameObject;

        VolumeBtnObject = transform.Find("SoldierType/BuildVolume").gameObject;
        VolumeBtnObject.GetComponent<Button>().onClick.AddListener(OnClickBuildVolume);

        DemosBuildBtn = transform.Find("SoldierType/DemosBuild").GetComponent<Button>();
        DemosHasNum = transform.Find("SoldierType/DemosBuild/BuildNum").GetComponent<Text>();
        DemosBuildBtn.onClick.AddListener(OnClickBuildDemos);
        BuildTextList.Add(DemosHasNum);
        BuildBtnList.Add(DemosBuildBtn);

        SoldierBuildBtn = transform.Find("SoldierType/SoldierBuild").GetComponent<Button>();
        SoldierHasNum = transform.Find("SoldierType/SoldierBuild/BuildNum").GetComponent<Text>();
        SoldierBuildBtn.onClick.AddListener(OnClickBuildSoldier);
        BuildTextList.Add(SoldierHasNum);
        BuildBtnList.Add(SoldierBuildBtn);

        CarBuildBtn = transform.Find("SoldierType/CarBuild").GetComponent<Button>();
        CarHasNum = transform.Find("SoldierType/CarBuild/BuildNum").GetComponent<Text>();
        CarBuildBtn.onClick.AddListener(OnClickBuildCar);
        BuildTextList.Add(CarHasNum);
        BuildBtnList.Add(CarBuildBtn);

        WaterBuildBtn = transform.Find("SoldierType/WaterBuild").GetComponent<Button>();
        WaterHasNum = transform.Find("SoldierType/WaterBuild/BuildNum").GetComponent<Text>();
        WaterBuildBtn.onClick.AddListener(OnClickBuildWater);
        BuildTextList.Add(WaterHasNum);
        BuildBtnList.Add(WaterBuildBtn);

        AirBuildBtn = transform.Find("SoldierType/AirBuild").GetComponent<Button>();
        AirHasNum = transform.Find("SoldierType/AirBuild/BuildNum").GetComponent<Text>();
        AirBuildBtn.onClick.AddListener(OnClickBuildAir);
        BuildTextList.Add(AirHasNum);
        BuildBtnList.Add(AirBuildBtn);
    }
    private void InitBuildNum<T>(T info) {
        
        activeArr = info as int[];

        for (int i = 0; i < 5; i++) {
            if (activeArr[i] > 0)
            {
                BuildTextList[i].text = activeArr[i].ToString();
                BuildBtnList[i].interactable = true;
            }
            else {
                BuildTextList[i].text = " ";
                BuildBtnList[i].interactable = false;
            }
        }
    }
    private void UpdateBuildNumLab(ENUM_BUILDLAB_TYPE buildLab) {

        int order = (int)buildLab - 1500;
        if (activeArr[order] > 0)
        {
            activeArrNow[order] = (activeArrNow[order] % activeArr[order]) + 1;
            GameOperation.gameOperation.SetActiveBuild(1, buildLab, activeArrNow[order] - 1);   //设置本地建筑系统的激活建筑为CodeNum号
            GameControl.gameControl.SendBroadInfoForUI<string>(UIPanelType.SelectItem, ENUM_MSG_TYPE.STRING, activeArrNow[order].ToString());
        }
    }
}
