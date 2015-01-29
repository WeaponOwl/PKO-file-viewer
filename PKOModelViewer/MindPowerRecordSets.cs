using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Mindpower
{
    [StructLayout(LayoutKind.Sequential,Pack=4)]
    public class CRawDataInfo
    {
        public int bExist;
        public int nIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 72)]
        public char[] szDataName;
        public uint dwLastUseTick;
        public int bEnable;
        public uint pData;
        public uint dwPackOffset;
        public uint dwDataSize;
        public int nID;
        public uint dwLoadCnt;
    };

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    //  scripts/table/characterinfo
    public class CChaRecord : CRawDataInfo
    {
        public int lID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public char[] szIconName;
        public char chModalType;
        public char chCtrlType;
        public short sModel;
        public short sSuitID;
        public short sSuitNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public short[] sSkinInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public short[] sFeffID;
        public short sEeffID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] sEffectActionID;
        public short sShadow;
        public short sActionID;
        public char chDiaphaneity;
        public short sFootfall;
        public short sWhoop;
        public short sDirge;
        public char chControlAble;
        public char chTerritory;
        public short sSeaHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] sItemType;
        public float fLengh;
        public float fWidth;
        public float fHeight;
        public short sRadii;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] nBirthBehave;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] nDiedBehave;
        public short sBornEff;
        public short sDieEff;
        public short sDormancy;
        public char chDieAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] _nHPEffect;
        public bool _IsFace;
        public bool _IsCyclone;
        public int lScript;
        public int lWeapon;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public int[] lSkill;
        //int lSkill[11][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] lItem;
        //int lItem[10][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] lTaskItem;
        //int lTaskItem[10][2];
        public int lMaxShowItem;
        public float fAllShow;
        public int lPrefix;
        public int lAiNo;
        public char chCanTurn;
        public int lVision;
        public int lNoise;
        public int lGetEXP;
        public bool bLight;
        public int lMobexp;
        public int lLv;
        public int lMxHp;
        public int lHp;
        public int lMxSp;
        public int lSp;
        public int lMnAtk;
        public int lMxAtk;
        public int lPDef;
        public int lDef;
        public int lHit;
        public int lFlee;
        public int lCrt;
        public int lMf;
        public int lHRec;
        public int lSRec;
        public int lASpd;
        public int lADis;
        public int lCDis;
        public int lMSpd;
        public int lCol;
        public int lStr;
        public int lAgi;
        public int lDex;
        public int lCon;
        public int lSta;
        public int lLuk;
        public int lLHandVal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public char[] szGuild;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public char[] szTitle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public char[] szJob;
        public int lCExp;
        public int lNExp;
        public int lFame;
        public int lAp;
        public int lTp;
        public int lGd;
        public int lSpri;
        public int lStor;
        public int lMxSail;
        public int lSail;
        public int lStasa;
        public int lScsm;
        public int lTStr;
        public int lTAgi;
        public int lTDex;
        public int lTCon;
        public int lTSta;
        public int lTLuk;
        public int lTMxHp;
        public int lTMxSp;
        public int lTAtk;
        public int lTDef;
        public int lTHit;
        public int lTFlee;
        public int lTMf;
        public int lTCrt;
        public int lTHRec;
        public int lTSRec;
        public int lTASpd;
        public int lTADis;
        public int lTSpd;
        public int lTSpri;
        public int lTScsm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] scaling;

        //private bool _HaveEffectFog;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/sceneobjinfo
    public class CSceneObjInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szName;
        int nType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] btPointColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] btEnvColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] btFogColor;
        int nRange;
        float Attenuation1;
        int nAnimCtrlID;
        int nStyle;
        int nAttachEffectID;
        int bEnablePointLight;
        int bEnableEnvLight;
        int nFlag;
        int nSizeFlag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        char[] szEnvSound;
        int nEnvSoundDis;
        int nPhotoTexID;
        int bShadeFlag;
        int bIsReallyBig;
        int nFadeObjNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        int[] nFadeObjSeq;
        float fFadeCoefficent;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/sceneffectinfo
    public class CMagicInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szPhotoName;
        int nPhotoTexID;
        int nEffType;
        int nObjType;
        int nDummyNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        int[] nDummy;
        int nDummy2;
        int nHeightOff;
        float fPlayTime;
        int LightID;
        float fBaseSize;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/shadeinfo
    public class CShadeInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szName;
        int nPhotoTexID;
        float fsize;
        int nAni;
        int nRow;
        int nCol;
        int nUseAlphaTest;
        int nAlphaType;
        int nColorR;
        int nColorG;
        int nColorB;
        int nColorA;
        int nType;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/eventsound
    public class CEventSoundInfo : CRawDataInfo
    {
        int nSoundID;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/musicinfo
    public class CMusicInfo : CRawDataInfo
    {
        int nType;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/characterposeinfo
    public class CPoseInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        short[] sRealPoseID;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/selectcha
    public class CChaCreateInfo : CRawDataInfo
    {
        uint type;
        uint bone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        uint[] hair;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        uint[] face;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        uint[] body;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        uint[] hand;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        uint[] foot;
        uint hair_num;
        uint face_num;
        uint body_num;
        uint hand_num;
        uint foot_num;
        uint profession;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        char[] description;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SSkillGridEx
    {
        char chState;
        char chLv;
        short sID;
        short sUseSP;
        short sUseEndure;
        short sUseEnergy;
        int lResumeTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        short[] sRange;
    };
    public enum eSelectCha
    {
        enumSC_NONE = 0x0,
        enumSC_ALL = 0x1,
        enumSC_PLAYER = 0x2,
        enumSC_ENEMY = 0x3,
        enumSC_PLAYER_ASHES = 0x4,
        enumSC_MONS = 0x5,
        enumSC_MONS_REPAIRABLE = 0x6,
        enumSC_MONS_TREE = 0x7,
        enumSC_MONS_MINE = 0x8,
        enumSC_MONS_FISH = 0x9,
        enumSC_MONS_DBOAT = 0xA,
        enumSC_SELF = 0xB,
        enumSC_TEAM = 0xC
    };
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/skillinfo
    public class CSkillRecord : CRawDataInfo
    {
        short sID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        char[] szName;
        char chFightType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        char[] chJobSelect;
        //char chJobSelect[9][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        short[] sItemNeed;
        //short sItemNeed[3][8][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        short[] sConchNeed;
        //short sConchNeed[8][3];
        char chPhase;
        char chType;
        short sLevelDemand;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        short[] sPremissSkill;
        //short sPremissSkill[3][2];
        char chPointExpend;
        char chSrcType;
        char chTarType;
        short sApplyDistance;
        char chApplyTarget;
        char chApplyType;
        char chHelpful;
        short sAngle;
        short sRadii;
        char chRange;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szPrepare;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szUseSP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szUseEndure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szUseEnergy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szSetRange;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szRangeState;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szUse;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szActive;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szInactive;
        int nStateID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        short[] sSelfAttr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        short[] sSelfEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        short[] sItemExpend;
        short sBeingTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        short[] sTargetAttr;
        short sSplashPara;
        short sTargetEffect;
        short sSplashEffect;
        short sVariation;
        short sSummon;
        short sPreTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        char[] szFireSpeed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] chOperate;
        short sActionHarm;
        char chActionPlayType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        short[] sActionPose;
        short sActionKeyFrme;
        short sWhop;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        short[] sActionDummyLink;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        short[] sActionEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        short[] sActionEffectType;
        short sItemDummyLink;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        short[] sItemEffect1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        short[] sItemEffect2;
        short sSkyEffectActionKeyFrame;
        short sSkyEffectActionDummyLink;
        short sSkyEffectItemDummyLink;
        short sSkyEffect;
        short sSkySpd;
        short sWhoped;
        short sTargetDummyLink;
        short sTargetEffectID;
        char chTargetEffectTime;
        short sAgroundEffectID;
        short sWaterEffectID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        char[] szICON;
        char chPlayTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        char[] szDescribeHint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        char[] szEffectHint;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        char[] szExpendHint;
        SSkillGridEx _Skill;
        int _nUpgrade;
        bool _IsActive;
        uint _dwAttackTime;
        [MarshalAs(UnmanagedType.U4)]
        eSelectCha _eSelectCha;
        int _nPoseNum;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/skilleff
    //  THIS STRUCT HAVE WRONG SIZE!!!!
    public class CSkillStateRecord : CRawDataInfo
    {
        char chID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        char[] szName;
        short sFrequency;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        char[] szOnTransfer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        char[] szAddState;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        char[] szSubState;
        char chAddType;
        bool bCanCancel;
        bool bCanMove;
        bool bCanMSkill;
        bool bCanGSkill;
        bool bCanTrade;
        bool bCanItem;
        bool bCanUnbeatable;
        bool bCanItemmed;
        bool bCanSkilled;
        bool bNoHide;
        bool bNoShow;
        bool bOptItem;
        bool bTalkToNPC;
        char bFreeStateID;
        char chScreen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] nActBehave;
        short sChargeLink;
        short sAreaEffect;
        bool IsShowCenter;
        bool IsDizzy;
        short sEffect;
        short sDummy1;
        short sBitEffect;
        short sDummy2;
        short sIcon;
        //int _nActNum;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    //scripts/table/mapinfo
    public class CMapInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szName;
        int nInitX;
        int nInitY;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        float[] fLightDir;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        char[] btLightColor;
        //KILLED FOR SIZEOF
        //bool IsShowSwitch;    
    };

    public enum EItemType
    {
        enumItemTypeSword = 1,
        enumItemTypeGlave = 2,
        enumItemTypeBow = 3,
        enumItemTypeHarquebus = 4,
        enumItemTypeFalchion = 5,
        enumItemTypeMitten = 6,
        enumItemTypeStylet = 7,
        enumItemTypeMoneybag = 8,
        enumItemTypeCosh = 9,
        enumItemTypeSinker = 10,
        enumItemTypeShield = 11,
        enumItemTypeArrow = 12,
        enumItemTypeAmmo = 13,
        enumItemTypeHeadpiece = 19,
        enumItemTypeHair = 20,
        enumItemTypeFace = 21,
        enumItemTypeClothing = 22,
        enumItemTypeGlove = 23,
        enumItemTypeBoot = 24,
        enumItemTypeConch = 29,
        enumItemTypeMedicine = 31,
        enumItemTypeOvum = 32,
        enumItemTypeScroll = 36,
        enumItemTypeGeneral = 41,
        enumItemTypeMission = 42,
        enumItemTypeBoat = 43,
        enumItemTypeWing = 44,
        enumItemTypeTrade = 45,
        enumItemTypeBravery = 46,
        enumItemTypeHull = 51,
        enumItemTypeEmbolon = 52,
        enumItemTypeEngine = 53,
        enumItemTypeArtillery = 54,
        enumItemTypeAirscrew = 55,
        enumItemTypeBoatSign = 56,
        enumItemTypePetFodder = 57,
        enumItemTypePetSock = 58,
        enumItemTypePet = 59
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/iteminfo
    public class CItemRecord : CRawDataInfo
    {
        public int lID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public char[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public char[] szICON;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 95)]
        public char[] chModule;
        //char chModule[5][19];
        public short sShipFlag;
        public short sShipType;
        //[MarshalAs(UnmanagedType.I2)]
        //public EItemType sType;
        public short sType;
        public char chForgeLv;
        public char chForgeSteady;
        public char chExclusiveID;
        public char chIsTrade;
        public char chIsPick;
        public char chIsThrow;
        public char chIsDel;
        public int lPrice;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] chBody;
        public short sNeedLv;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public char[] szWork;
        public int nPileMax;
        public char chInstance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] szAbleLink;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] szNeedLink;
        public char chPickTo;
        public short sStrCoef;
        public short sAgiCoef;
        public short sDexCoef;
        public short sConCoef;
        public short sStaCoef;
        public short sLukCoef;
        public short sASpdCoef;
        public short sADisCoef;
        public short sMnAtkCoef;
        public short sMxAtkCoef;
        public short sDefCoef;
        public short sMxHpCoef;
        public short sMxSpCoef;
        public short sFleeCoef;
        public short sHitCoef;
        public short sCrtCoef;
        public short sMfCoef;
        public short sHRecCoef;
        public short sSRecCoef;
        public short sMSpdCoef;
        public short sColCoef;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sStrValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sAgiValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sDexValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sConValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sStaValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sLukValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sASpdValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sADisValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMnAtkValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMxAtkValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sDefValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMxHpValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMxSpValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sFleeValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sHitValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sCrtValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMfValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sHRecValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sSRecValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sMSpdValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sColValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sPDef;
        public short sLHandValu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sEndure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sEnergy;
        public short sHole;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public char[] szAttrEffect;
        public short sDrap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public short[] sEffect;
        //short sEffect[8][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sItemEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sAreaEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] sUseItemEffect;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 257)]
        public char[] szDescriptor;
        public short sEffNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public bool[] _IsBody;
        //int _isBody;
        //bool _isBody2;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/objevent
    public class CEventRecord : CRawDataInfo
    {
        int lID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        char[] szName;
        short sEventType;
        short sArouseType;
        short sArouseRadius;
        short sEffect;
        short sMusic;
        short sBornEffect;
        short sCursor;
        char chMainChaType;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/AreaSet
    public class CAreaInfo : CRawDataInfo
    {
        uint dwColor;
        int nMusic;
        uint dwEnvColor;
        uint dwLightColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        float[] fLightDir;
        char chType;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/notifyset
    public class CNotifyInfo : CRawDataInfo
    {
        char chType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        char[] szInfo;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/chaticons
    public class CChatIconInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szSmall;
        int nSmallX;
        int nSmallY;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szSmallOff;
        int nSmallOffX;
        int nSmallOffY;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        char[] szBig;
        int nBigX;
        int nBigY;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        char[] szHint;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/itemtype
    public class CItemTypeInfo : CRawDataInfo { };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/itempre
    public class CItemPreSet : CRawDataInfo { };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/forgeitem
    public class CForgeRecord : CRawDataInfo
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        struct FORGE_ITEM
        {
            ushort sItem;
            char byNum;
            char byParam;
        };

        char byLevel;
        char byFailure;
        char byRate;
        char byParam;
        uint dwMoney;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        FORGE_ITEM[] ForgeItem;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/shipinfo
    public class xShipInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        char[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        char[] szDesp;
        ushort sItemID;
        ushort sCharID;
        ushort sPosID;
        char byIsUpdate;
        ushort sNumHeader;
        ushort sNumEngine;
        ushort sNumCannon;
        ushort sNumEquipment;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        ushort[] sHeader;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        ushort[] sEngine;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        ushort[] sCannon;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        ushort[] sEquipment;
        ushort sBody;
        ushort sLvLimit;
        ushort sNumPfLimit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        ushort[] sPfLimit;
        ushort sEndure;
        ushort sResume;
        ushort sDefence;
        ushort sResist;
        ushort sMinAttack;
        ushort sMaxAttack;
        ushort sDistance;
        ushort sTime;
        ushort sScope;
        ushort sCapacity;
        ushort sSupply;
        ushort sConsume;
        ushort sCannonSpeed;
        ushort sSpeed;
        ushort sParam;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/shipiteminfo
    public class xShipPartInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        char[] szName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        char[] szDesp;
        uint dwModel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        ushort[] sMotor;
        uint dwPrice;
        ushort sEndure;
        ushort sResume;
        ushort sDefence;
        ushort sResist;
        ushort sMinAttack;
        ushort sMaxAttack;
        ushort sDistance;
        ushort sTime;
        ushort sScope;
        ushort sCapacity;
        ushort sSupply;
        ushort sConsume;
        ushort sCannonSpeed;
        ushort sSpeed;
        ushort sParam;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //  scripts/table/hairs
    //  HAVE WRONG SIZEOF
    public class CHairRecord : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        char[] szColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        uint[] dwNeedItem;
        //uint dwNeedItem[4][2];
        uint dwMoney;
        uint dwItemID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        uint[] dwFailItemID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        bool[] IsChaUse;
        int _nFailNum;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/TerrainInfo
    public class MPTerrainInfo : CRawDataInfo
    {
        public byte btType;
        public int nTextureID;
        public byte btAttr;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/ItemRefineInfo
    public class CItemRefineInfo : CRawDataInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        short[] Value;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        float[] fChaEffectScale;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/ItemRefineEffectInfo
    public class CItemRefineEffectInfo : CRawDataInfo
    {
        int nLightID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        short[] sEffectID;
        //short sEffectID[4][4];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        char[] chDummy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        int[] _sEffectNum;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/StoneInfo
    public class CStoneInfo : CRawDataInfo
    {
        int nItemID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        int[] nEquipPos;
        int nType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        char[] szHintFunc;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/ResourceInfo
    public class MPResourceInfo : CRawDataInfo
    {
        public enum MPRESOURCEINFO_TYPE
        {
            RT_PAR = 0,
            RT_PATH = 1,
            RT_EFF = 2,
            RT_MESH = 3,
            RT_TEXTURE = 4,
            RT_UNKNOWN = -1
        };

        [MarshalAs(UnmanagedType.U4)]
        public MPRESOURCEINFO_TYPE m_iType;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    //  scripts/table/ElfSkillInfo
    public class CElfSkillInfo : CRawDataInfo
    {
        int nIndex;
        int nTypeID;
    };
    
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CRawDataSet<T>
    {
        //uint vfptr;
        //int _nIDStart;
        //int _nIDCnt;
        //int _nUnusedIndex;
        //uint _dwReleaseInterval;
        //int _nMaxRawDataCnt;
        //int _nLoadedRawDataCnt;
        //uint _dwMaxFrameRawDataSize;
        //int _bEnablePack;
        //[MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        //char[] _szPackName;
        //int _bBinary;
        //CRawDataInfo[] _RawDataArray;
        ////std::map<std::basic_string<char,std::char_traits<char>,std::allocator<char> >,CRawDataInfo *,std::less<std::basic_string<char,std::char_traits<char>,std::allocator<char> > >,std::allocator<std::pair<std::basic_string<char,std::char_traits<char>,std::allocator<char> > const ,CRawDataInfo *> > > _IDIdx;
        //List<int> _RequestList;
        //int _bEnableRequest;
        //int _nIDLast;
        //int _nMaxFieldCnt;

        public static T[] LoadBin(string Filename)
        {
            FileStream fs = new FileStream(Filename,FileMode.Open,FileAccess.Read);
            BinaryReader fp = new BinaryReader(fs);

            long filesize = fs.Length;
            uint infoSize = fp.ReadUInt32();
            int sizeOf = Marshal.SizeOf(typeof(T));

            if ((uint)sizeOf != infoSize)
                ;//System.Windows.Forms.MessageBox.Show("sizeof struct not equal with sizeof in rawData");

            int resCount = (int)filesize / (int)infoSize;

            T[] returnSet = new T[resCount];
            
            for(int i=0;i<resCount;i++)
            {
                byte[] data = fp.ReadBytes((int)infoSize);

                returnSet[i] = StructReader.ReadStructFromArray<T>(data);
            }

            fp.Close();
            fs.Close();

            return returnSet;
        }
    }
}
