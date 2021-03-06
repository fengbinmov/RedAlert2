﻿using System;
using UnityEngine;
using GameAttrType;

public class ObjectDataValue
{
    public struct selfDataValue
    {
        public UInt16 m_u2ID;
        public UInt32 m_u4IDNum;
        public ENUM_OBJECT_TYPE m_emObjectType;
        public ENUM_OBJECT_NAME m_emObjectName;
        public ENUM_OBJECT_STATE m_emObjectState;
        public string self;
        public string selfHeadP;
        public string selfName;
        public string selfOutlay;
        public string selfIntroduce;
    }
    public struct selfAtrrValue
    {
        public UInt16 m_u2MoveSpeed;    //移动速度
        public UInt16 m_u2RotateSpeed;    //转向速度
        public UInt32 m_u4AttackPlaneR;//地面攻击范围
        public UInt32 m_u4AttackHeight;//攻击高度
        public UInt32 m_u4Blood;       //血量
        public UInt32 m_u4BloodY;
        public UInt32 m_u4Concussion;  //冲击
        public UInt32 m_u4ConcussionY;
        public UInt32 m_u4Laceration;  //撕裂
        public UInt32 m_u4LacerationY;
        public UInt32 m_u4Cauma;       //灼伤
        public UInt32 m_u4CaumaY;
        public UInt32 m_u4Electric;    //电击
        public UInt32 m_u4ElectricY;
        public UInt32 m_u4Infrasonic;  //次声波
        public UInt32 m_u4InfrasonicY;
        public UInt32 m_u4Radiation;   //辐射
        public UInt32 m_u4RadiationY;
        public UInt32 m_u4Soul;        //心灵创伤
        public UInt32 m_u4SoulY;

        public float m_u2MakeTime;

    }
    public struct selfGameData {

        public Vector3 m_v3Postion;
        public Vector3 m_v3Rotation;
        public ENUM_OBJECT_STATE m_emObjectState;
        public UInt32 m_u4Blood;
        public UInt16 m_u2Exp;
    }
    public struct BuildAtrr {
    }

    public selfDataValue m_data;
    public selfAtrrValue m_atrr;

    public ObjectDataValue() {
        this.m_data.m_u2ID = 999;
        this.m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_UNKNOW;
        this.m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_UNKNOW_STATE;

        this.m_atrr.m_u4AttackPlaneR = 1;
        this.m_atrr.m_u4AttackHeight = 1;
        this.m_atrr.m_u4Blood = 0;
        this.m_atrr.m_u4BloodY = 0;
        this.m_atrr.m_u4Concussion = 0;
        this.m_atrr.m_u4ConcussionY = 0;
        this.m_atrr.m_u4Laceration = 0;
        this.m_atrr.m_u4LacerationY = 0;
        this.m_atrr.m_u4Cauma = 0;
        this.m_atrr.m_u4CaumaY = 0;
        this.m_atrr.m_u4Electric = 0;  
        this.m_atrr.m_u4ElectricY = 0;
        this.m_atrr.m_u4Infrasonic = 0;
        this.m_atrr.m_u4InfrasonicY = 0;
        this.m_atrr.m_u4Radiation = 0;
        this.m_atrr.m_u4RadiationY = 0;
        this.m_atrr.m_u4Soul = 0;
        this.m_atrr.m_u4SoulY = 0;
    }
}
