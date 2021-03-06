﻿using GameAttrType;

public class BuildData1503 : ObjectDataValue
{
    public BuildData1503():base()
    {
        m_data.m_u2ID = 1503;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectName = ENUM_OBJECT_NAME.B_ZHANZHENG;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/CarBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/CarBuildHP";
        m_data.selfName = "机械厂";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产机械的基地，可激活机械面板";


        m_atrr.m_u2MakeTime = 2;
    }
}
