using System;
using System.Collections;

namespace LoginSrv
{
    public class Grobal2
    {
        //john 201206131
        public const int CM_ADDNEWUSER = 2002;

        public const int CM_PROTOCOL = 2000;
        public const int CM_IDPASSWORD = 2001;
        public const int CM_CHANGEPASSWORD = 2003;
        public const int CM_UPDATEUSER = 2004;
        public const int CM_GETBACKPASSWORD = 2010;

        public const int HEROVERSION = 1;

        // ���뿪�� 0=��ҵ�� 1=Ӣ�۰�
        // ALLFUNCTION = 1;
        public const int CLIENT_VERSION_NUMBER = 120090701;

        // �汾��
        // ==============================================================================
        public const int ACCOUNTLEN = 30;

        public const int MAXPATHLEN = 255;
        public const int DIRPATHLEN = 80;
        public const int MAPNAMELEN = 16;
        public const int ACTORNAMELEN = 14;
        public const int DEFBLOCKSIZE = 16;
        public const int BUFFERSIZE = 12000;

        // ��������С
        public const int DATA_BUFSIZE2 = 16348;

        // 8192;
        public const int DATA_BUFSIZE = 8192;

        // 8192;
        public const int GROUPMAX = 11;

        public const int BAGGOLD = 5000000;
        public const int BODYLUCKUNIT = 10;
        public const int MAX_STATUS_ATTRIBUTE = 12;
        public const int DR_UP = 0;
        public const int DR_UPRIGHT = 1;
        public const int DR_RIGHT = 2;
        public const int DR_DOWNRIGHT = 3;
        public const int DR_DOWN = 4;
        public const int DR_DOWNLEFT = 5;
        public const int DR_LEFT = 6;
        public const int DR_UPLEFT = 7;
        public const int AT_FIRE = 1;

        // ��
        public const int AT_ICE = 2;

        // ��
        public const int AT_LIGHT = 3;

        // ��
        public const int AT_WIND = 4;

        // ��
        public const int AT_HOLY = 5;

        // ��ʥ
        public const int AT_DARK = 6;

        // ����
        public const int AT_PHANTOM = 7;

        // ��Ӱ
        public const int U_DRESS = 0;

        // �·�
        public const int U_WEAPON = 1;

        // װ������
        public const int U_RIGHTHAND = 2;

        // ����
        public const int U_NECKLACE = 3;

        // ����
        public const int U_HELMET = 4;

        // ͷ��
        public const int U_ARMRINGL = 5;

        // ��������
        public const int U_ARMRINGR = 6;

        // ��������
        public const int U_RINGL = 7;

        // ���ֽ�ָ
        public const int U_RINGR = 8;

        // ���ֽ�ָ
        public const int U_BUJUK = 9;

        // ��
        public const int U_BELT = 10;

        // ����
        public const int U_BOOTS = 11;

        // Ь
        public const int U_CHARM = 12;

        public const int POISON_DECHEALTH = 0;
        public const int POISON_DAMAGEARMOR = 1;
        public const int POISON_LOCKSPELL = 2;
        public const int POISON_DONTMOVE = 4;
        public const int POISON_STONE = 5;
        public const int STATE_TRANSPARENT = 8;
        public const int STATE_DEFENCEUP = 9;
        public const int STATE_MAGDEFENCEUP = 10;
        public const int STATE_BUBBLEDEFENCEUP = 11;
        public const int USERMODE_PLAYGAME = 1;
        public const int USERMODE_LOGIN = 2;
        public const int USERMODE_LOGOFF = 3;
        public const int USERMODE_NOTICE = 4;
        public const int RUNGATEMAX = 20;
        public const uint RUNGATECODE = 0xAA55AA55;

        // RUNGATECODE = $AA9AAA9A; BLUE
        public const int OS_MOVINGOBJECT = 1;

        public const int OS_ITEMOBJECT = 2;
        public const int OS_EVENTOBJECT = 3;
        public const int OS_GATEOBJECT = 4;
        public const int OS_SWITCHOBJECT = 5;
        public const int OS_MAPEVENT = 6;
        public const int OS_DOOR = 7;
        public const int OS_ROON = 8;
        public const int OS_OBJECTGATE = 9;
        public const int RC_PLAYOBJECT = 0;
        public const int RC_DUMMOBJECT = 1;

        // ����
        public const int RC_MOONOBJECT = 60;

        // ����
        public const int RC_HEROOBJECT = 66;

        // Ӣ��
        public const int RC_GUARD = 11;

        // ������
        public const int RC_PEACENPC = 15;

        public const int RC_ANIMAL = 50;
        public const int RC_MONSTER = 80;
        public const int RC_NPC = 10;
        public const int RC_ARCHERGUARD = 112;
        public const int RC_PLAYMOSTER = 150;

        // ���ι���
        public const int RCC_USERHUMAN = RC_PLAYOBJECT;

        public const int RCC_GUARD = RC_GUARD;
        public const int RCC_MERCHANT = RC_ANIMAL;
        public const int ISM_WHISPER = 1234;
        public const int CM_QUERYCHR = 100;

        // ��ѯ��ɫ
        public const int CM_NEWCHR = 101;

        // ������ɫ
        public const int CM_DELCHR = 102;

        // ɾ����ɫ
        public const int CM_SELCHR = 103;

        // ѡ���ɫ
        public const int CM_SELECTSERVER = 104;

        // ѡ�������
        public const int CM_QUERYDELCHR = 105;

        // ��ѯɾ����ɫ
        public const int CM_RESTORECHR = 106;

        // �ָ���ɫ
        public const int CM_QUERYSERVERNAME = 107;

        // ��ѯ�������б�
        public const int CM_QUERYRANDOMCODE = 108;

        // ��ѯ��֤��
        public const int CM_SENDRANDOMCODE = 109;

        // ��֤��֤��
        public const int SM_RUSH = 6;

        public const int SM_RUSHKUNG = 7;
        public const int SM_FIREHIT = 8;

        // �һ�
        public const int SM_BACKSTEP = 9;

        public const int SM_TURN = 10;

        // ת��
        public const int SM_WALK = 11;

        // ��
        public const int SM_SITDOWN = 12;

        public const int SM_RUN = 13;

        // ��
        public const int SM_HIT = 14;

        // ��
        public const int SM_HEAVYHIT = 15;

        public const int SM_BIGHIT = 16;
        public const int SM_SPELL = 17;

        // ʹ��ħ��
        public const int SM_POWERHIT = 18;

        public const int SM_LONGHIT = 19;

        // ��ɱ
        public const int SM_DIGUP = 20;

        public const int SM_DIGDOWN = 21;
        public const int SM_FLYAXE = 22;
        public const int SM_LIGHTING = 23;

        // ��������
        public const int SM_WIDEHIT = 24;

        public const int SM_CRSHIT = 25;
        public const int SM_TWINHIT = 26;

        // SM_27 = 27;
        // SM_28 = 28;
        // SM_29 = 29;
        // SM_30 = 30;
        // SM_31 = 31;
        // SM_32 = 32;
        //
        // SM_40 = 40;
        // SM_41 = 41;
        // SM_42 = 42;
        // SM_43 = 43;
        // SM_44 = 44;
        // SM_45 = 45;
        public const int SM_40 = 35;

        public const int SM_41 = 36;
        public const int SM_42 = 37;
        public const int SM_43 = 38;
        public const int SM_44 = 39;
        public const int SM_60HIT = 60;
        public const int SM_61HIT = 61;
        public const int SM_62HIT = 62;
        public const int SM_63HIT = 63;
        public const int SM_64HIT = 64;
        public const int SM_65HIT = 65;
        public const int SM_66HIT = 66;
        public const int SM_67HIT = 67;
        public const int SM_68HIT = 68;
        public const int SM_69HIT = 69;
        public const int SM_70HIT = 70;
        public const int SM_PKHIT = SM_66HIT;
        public const int SM_KTHIT = SM_67HIT;
        public const int SM_ZRJFHIT = SM_68HIT;

        // ���ս���
        public const int SM_SUPERFIREHIT = SM_70HIT;

        // 4���һ�
        public const int SM_100HIT = 300;

        // ����ɱ
        public const int SM_101HIT = 301;

        // ׷�Ĵ�
        public const int SM_102HIT = 302;

        // ����ն
        public const int SM_103HIT = 303;

        // ��ɨǧ��
        public const int SM_ALIVE = 27;

        // ����
        public const int SM_MOVEFAIL = 28;

        public const int SM_HIDE = 29;
        public const int SM_DISAPPEAR = 30;
        public const int SM_STRUCK = 31;

        // ����
        public const int SM_DEATH = 32;

        // ����
        public const int SM_SKELETON = 33;

        // ʬ��
        public const int SM_NOWDEATH = 34;

        // ��ɱ
        public const int SM_ACTION_MIN = SM_RUSH;

        public const int SM_ACTION_MAX = SM_WIDEHIT;
        public const int SM_ACTION2_MIN = 65072;
        public const int SM_ACTION2_MAX = 65073;
        public const int SM_HEAR = 40;

        // �ػ�
        public const int SM_FEATURECHANGED = 41;

        public const int SM_USERNAME = 42;
        public const int SM_WINEXP = 44;

        // ��ȡ����
        public const int SM_LEVELUP = 45;

        // ����
        public const int SM_DAYCHANGING = 46;

        // ̫������
        public const int SM_LOGON = 50;

        // ��½
        public const int SM_NEWMAP = 51;

        // �µ�ͼ
        public const int SM_ABILITY = 52;

        // �����ԶԻ���
        public const int SM_HEALTHSPELLCHANGED = 53;

        // ����������Ѫ
        public const int SM_MAPDESCRIPTION = 54;

        // ��ͼ����
        public const int SM_SPELL2 = 117;

        public const int SM_SYSMESSAGE = 100;

        // ϵͳ��Ϣ
        public const int SM_GROUPMESSAGE = 101;

        public const int SM_CRY = 102;

        // ����
        public const int SM_WHISPER = 103;

        // ˽��
        public const int SM_GUILDMESSAGE = 104;

        // �л���Ϣ
        public const int SM_MOVEMESSAGE = 105;

        public const int SM_ADDITEM = 200;
        public const int SM_BAGITEMS = 201;
        public const int SM_DELITEM = 202;
        public const int SM_UPDATEITEM = 203;
        public const int SM_UPDATEITEM2 = 204;
        public const int SM_ADDMAGIC = 210;
        public const int SM_SENDMYMAGIC = 211;
        public const int SM_DELMAGIC = 212;
        public const int SM_CERTIFICATION_FAIL = 501;
        public const int SM_ID_NOTFOUND = 502;
        public const int SM_PASSWD_FAIL = 503;

        // ��֤ʧ��
        public const int SM_NEWID_SUCCESS = 504;

        // �����ʺųɹ�
        public const int SM_NEWID_FAIL = 505;

        // �����ʺ�ʧ��
        public const int SM_CHGPASSWD_SUCCESS = 506;

        // �޸�����ɹ�
        public const int SM_CHGPASSWD_FAIL = 507;

        // �޸�����ʧ��
        public const int SM_GETBACKPASSWD_SUCCESS = 508;

        // �����һسɹ�
        public const int SM_GETBACKPASSWD_FAIL = 509;

        // �����һ�ʧ��
        public const int SM_QUERYCHR = 520;

        // ��ѯ��ɫ��Ϣ
        public const int SM_NEWCHR_SUCCESS = 521;

        // �½���ɫ�ɹ�
        public const int SM_NEWCHR_FAIL = 522;

        // �½���ɫʧ��
        public const int SM_DELCHR_SUCCESS = 523;

        // ɾ����ɫ�ɹ�
        public const int SM_DELCHR_FAIL = 524;

        // ɾ����ɫʧ��
        public const int SM_STARTPLAY = 525;

        // ��ʼ��Ϸ�ɹ�
        public const int SM_STARTFAIL = 526;

        // SM_USERFULL  ��ʼ��Ϸʧ��
        public const int SM_QUERYCHR_FAIL = 527;

        // ��ѯ��ɫʧ��
        public const int SM_OUTOFCONNECTION = 528;

        // ����������� ,ǿ���û�����
        public const int SM_PASSOK_SELECTSERVER = 529;

        public const int SM_SELECTSERVER_OK = 530;

        // ѡ�������
        public const int SM_NEEDUPDATE_ACCOUNT = 531;

        public const int SM_UPDATEID_SUCCESS = 532;
        public const int SM_UPDATEID_FAIL = 533;
        public const int SM_FINDDELCHR = 534;
        public const int SM_FINDDELCHR_SUCCESS = 535;
        public const int SM_FINDDELCHR_FAIL = 536;
        public const int SM_SERVERNAME = 537;

        // �������б�
        public const int SM_SENDRANDOMCODE = 538;

        // ������֤��
        public const int SM_DROPITEM_SUCCESS = 600;

        public const int SM_DROPITEM_FAIL = 601;
        public const int SM_ITEMSHOW = 610;
        public const int SM_ITEMHIDE = 611;

        // SM_DOOROPEN           = 612;
        public const int SM_OPENDOOR_OK = 612;

        // ͨ����
        public const int SM_OPENDOOR_LOCK = 613;

        // ͨ������ ��ǰʢ������ͨ��ȥ���µ���Ҫ5���ӿ�һ��
        public const int SM_CLOSEDOOR = 614;

        // ����
        public const int SM_TAKEON_OK = 615;

        public const int SM_TAKEON_FAIL = 616;
        public const int SM_TAKEOFF_OK = 619;
        public const int SM_TAKEOFF_FAIL = 620;
        public const int SM_SENDUSEITEMS = 621;
        public const int SM_WEIGHTCHANGED = 622;
        public const int SM_CLEAROBJECTS = 633;
        public const int SM_CHANGEMAP = 634;

        // �ı��ͼ
        public const int SM_EAT_OK = 635;

        public const int SM_EAT_FAIL = 636;
        public const int SM_BUTCH = 637;
        public const int SM_MAGICFIRE = 638;
        public const int SM_MAGICFIRE_FAIL = 639;
        public const int SM_MAGIC_LVEXP = 640;
        public const int SM_DURACHANGE = 642;
        public const int SM_MERCHANTSAY = 643;
        public const int SM_MERCHANTDLGCLOSE = 644;
        public const int SM_SENDGOODSLIST = 645;
        public const int SM_SENDUSERSELL = 646;
        public const int SM_SENDBUYPRICE = 647;
        public const int SM_USERSELLITEM_OK = 648;
        public const int SM_USERSELLITEM_FAIL = 649;
        public const int SM_BUYITEM_SUCCESS = 650;

        // ?
        public const int SM_BUYITEM_FAIL = 651;

        // ?
        public const int SM_SENDDETAILGOODSLIST = 652;

        public const int SM_GOLDCHANGED = 653;
        public const int SM_CHANGELIGHT = 654;

        // ���س־�
        public const int SM_LAMPCHANGEDURA = 655;

        // ����־øı�
        public const int SM_CHANGENAMECOLOR = 656;

        // ������ɫ�ı�
        public const int SM_CHARSTATUSCHANGED = 657;

        public const int SM_SENDNOTICE = 658;

        // ������Ϸ����
        public const int SM_GROUPMODECHANGED = 659;

        public const int SM_CREATEGROUP_OK = 660;
        public const int SM_CREATEGROUP_FAIL = 661;
        public const int SM_GROUPADDMEM_OK = 662;
        public const int SM_GROUPDELMEM_OK = 663;
        public const int SM_GROUPADDMEM_FAIL = 664;
        public const int SM_GROUPDELMEM_FAIL = 665;
        public const int SM_GROUPCANCEL = 666;
        public const int SM_GROUPMEMBERS = 667;
        public const int SM_SENDUSERREPAIR = 668;
        public const int SM_USERREPAIRITEM_OK = 669;
        public const int SM_USERREPAIRITEM_FAIL = 670;
        public const int SM_SENDREPAIRCOST = 671;
        public const int SM_DEALMENU = 673;
        public const int SM_DEALTRY_FAIL = 674;
        public const int SM_DEALADDITEM_OK = 675;
        public const int SM_DEALADDITEM_FAIL = 676;
        public const int SM_DEALDELITEM_OK = 677;
        public const int SM_DEALDELITEM_FAIL = 678;
        public const int SM_DEALCANCEL = 681;
        public const int SM_DEALREMOTEADDITEM = 682;
        public const int SM_DEALREMOTEDELITEM = 683;
        public const int SM_DEALCHGGOLD_OK = 684;
        public const int SM_DEALCHGGOLD_FAIL = 685;
        public const int SM_DEALREMOTECHGGOLD = 686;
        public const int SM_DEALSUCCESS = 687;
        public const int SM_SENDUSERSTORAGEITEM = 700;
        public const int SM_STORAGE_OK = 701;
        public const int SM_STORAGE_FULL = 702;
        public const int SM_STORAGE_FAIL = 703;
        public const int SM_SAVEITEMLIST = 704;
        public const int SM_TAKEBACKSTORAGEITEM_OK = 705;
        public const int SM_TAKEBACKSTORAGEITEM_FAIL = 706;
        public const int SM_TAKEBACKSTORAGEITEM_FULLBAG = 707;
        public const int SM_AREASTATE = 708;

        // ��Χ״̬
        public const int SM_MYSTATUS = 766;

        // �ҵ�״̬
        public const int SM_DELITEMS = 709;

        public const int SM_READMINIMAP_OK = 710;
        public const int SM_READMINIMAP_FAIL = 711;
        public const int SM_SENDUSERMAKEDRUGITEMLIST = 712;
        public const int SM_MAKEDRUG_SUCCESS = 713;

        // 714
        // 716
        public const int SM_MAKEDRUG_FAIL = 65036;

        public const int SM_CHANGEGUILDNAME = 750;
        public const int SM_SENDUSERSTATE = 751;
        public const int SM_SUBABILITY = 752;

        // �򿪸������ԶԻ���
        public const int SM_OPENGUILDDLG = 753;

        public const int SM_OPENGUILDDLG_FAIL = 754;
        public const int SM_SENDGUILDMEMBERLIST = 756;
        public const int SM_GUILDADDMEMBER_OK = 757;
        public const int SM_GUILDADDMEMBER_FAIL = 758;
        public const int SM_GUILDDELMEMBER_OK = 759;
        public const int SM_GUILDDELMEMBER_FAIL = 760;
        public const int SM_GUILDRANKUPDATE_FAIL = 761;
        public const int SM_BUILDGUILD_OK = 762;
        public const int SM_BUILDGUILD_FAIL = 763;
        public const int SM_DONATE_OK = 764;
        public const int SM_DONATE_FAIL = 765;
        public const int SM_MENU_OK = 767;

        // ?
        public const int SM_GUILDMAKEALLY_OK = 768;

        public const int SM_GUILDMAKEALLY_FAIL = 769;
        public const int SM_GUILDBREAKALLY_OK = 770;

        // ?
        public const int SM_GUILDBREAKALLY_FAIL = 771;

        // ?
        public const int SM_DLGMSG = 772;

        // Jacky
        public const int SM_SPACEMOVE_HIDE = 800;

        public const int SM_SPACEMOVE_SHOW = 801;
        public const int SM_RECONNECT = 802;

        // ���������������
        public const int SM_GHOST = 803;

        public const int SM_SHOWEVENT = 804;
        public const int SM_HIDEEVENT = 805;
        public const int SM_SPACEMOVE_HIDE2 = 806;
        public const int SM_SPACEMOVE_SHOW2 = 807;
        public const int SM_TIMECHECK_MSG = 810;

        // ʱ�Ӽ������ͻ�������
        public const int SM_ADJUST_BONUS = 811;

        // ?
        public const int SM_OPENHEALTH = 1100;

        public const int SM_CLOSEHEALTH = 1101;
        public const int SM_BREAKWEAPON = 1102;

        // ��������
        public const int SM_INSTANCEHEALGUAGE = 1103;

        // ʵʱ����
        public const int SM_CHANGEFACE = 1104;

        public const int SM_VERSION_FAIL = 1106;

        // ��֤�汾ʧ��
        public const int SM_ITEMUPDATE = 1500;

        public const int SM_MONSTERSAY = 1501;
        public const int SM_EXCHGTAKEON_OK = 65023;
        public const int SM_EXCHGTAKEON_FAIL = 65024;
        public const int SM_TEST = 65037;
        public const int SM_TESTHERO = 65038;
        public const int SM_THROW = 65069;
        public const int RM_DELITEMS = 9000;

        // Jacky
        public const int RM_TURN = 10001;

        public const int RM_WALK = 10002;
        public const int RM_RUN = 10003;
        public const int RM_HIT = 10004;
        public const int RM_SPELL = 10007;
        public const int RM_SPELL2 = 10008;
        public const int RM_POWERHIT = 10009;
        public const int RM_LONGHIT = 10011;
        public const int RM_WIDEHIT = 10012;
        public const int RM_PUSH = 10013;
        public const int RM_FIREHIT = 10014;
        public const int RM_RUSH = 10015;
        public const int RM_STRUCK = 10020;
        public const int RM_DEATH = 10021;
        public const int RM_DISAPPEAR = 10022;
        public const int RM_MAGSTRUCK = 10025;
        public const int RM_MAGHEALING = 10026;
        public const int RM_STRUCK_MAG = 10027;
        public const int RM_MAGSTRUCK_MINE = 10028;
        public const int RM_INSTANCEHEALGUAGE = 10029;

        // jacky
        public const int RM_HEAR = 10030;

        public const int RM_WHISPER = 10031;
        public const int RM_CRY = 10032;
        public const int RM_RIDE = 10033;
        public const int RM_WINEXP = 10044;
        public const int RM_USERNAME = 10043;
        public const int RM_LEVELUP = 10045;
        public const int RM_CHANGENAMECOLOR = 10046;
        public const int RM_LOGON = 10050;
        public const int RM_ABILITY = 10051;
        public const int RM_HEALTHSPELLCHANGED = 10052;
        public const int RM_DAYCHANGING = 10053;
        public const int RM_SYSMESSAGE = 10100;
        public const int RM_GROUPMESSAGE = 10102;

        // �������
        public const int RM_SYSMESSAGE2 = 10103;

        public const int RM_GUILDMESSAGE = 10104;

        // �л�����
        public const int RM_SYSMESSAGE3 = 10105;

        // Jacky
        public const int RM_DELAYMESSAGE = 10106;

        public const int RM_DELETEDELAYMESSAGE = 10107;
        public const int RM_CENTERMESSAGE = 10108;
        public const int RM_ITEMSHOW = 10110;
        public const int RM_ITEMHIDE = 10111;
        public const int RM_DOOROPEN = 10112;
        public const int RM_DOORCLOSE = 10113;
        public const int RM_SENDUSEITEMS = 10114;
        public const int RM_WEIGHTCHANGED = 10115;
        public const int RM_MOVEMESSAGE = 10240;
        public const int RM_FEATURECHANGED = 10116;
        public const int RM_CLEAROBJECTS = 10117;
        public const int RM_CHANGEMAP = 10118;
        public const int RM_BUTCH = 10119;
        public const int RM_MAGICFIRE = 10120;
        public const int RM_SENDMYMAGIC = 10122;
        public const int RM_MAGIC_LVEXP = 10123;
        public const int RM_SKELETON = 10024;
        public const int RM_DURACHANGE = 10125;
        public const int RM_MERCHANTSAY = 10126;
        public const int RM_GOLDCHANGED = 10136;
        public const int RM_CHANGELIGHT = 10137;
        public const int RM_CHARSTATUSCHANGED = 10139;
        public const int RM_DELAYMAGIC = 10154;
        public const int RM_DIGUP = 10200;
        public const int RM_DIGDOWN = 10201;
        public const int RM_FLYAXE = 10202;
        public const int RM_LIGHTING = 10204;
        public const int RM_SUBABILITY = 10302;
        public const int RM_TRANSPARENT = 10308;
        public const int RM_SPACEMOVE_SHOW = 10331;
        public const int RM_RECONNECTION = 11332;
        public const int RM_SPACEMOVE_SHOW2 = 10332;

        // ?
        public const int RM_HIDEEVENT = 10333;

        public const int RM_SHOWEVENT = 10334;
        public const int RM_ZEN_BEE = 10337;
        public const int RM_OPENHEALTH = 10410;
        public const int RM_CLOSEHEALTH = 10411;
        public const int RM_DOOPENHEALTH = 10412;
        public const int RM_CHANGEFACE = 10415;
        public const int RM_ITEMUPDATE = 11000;
        public const int RM_MONSTERSAY = 11001;
        public const int RM_MAKESLAVE = 11002;
        public const int RM_SUPERFIREHIT = 11003;
        public const int RM_MONMOVE = 21004;
        public const int SS_200 = 200;
        public const int SS_201 = 201;
        public const int SS_202 = 202;
        public const int SS_WHISPER = 203;
        public const int SS_204 = 204;
        public const int SS_205 = 205;
        public const int SS_206 = 206;
        public const int SS_207 = 207;
        public const int SS_208 = 208;
        public const int SS_209 = 219;
        public const int SS_210 = 210;
        public const int SS_211 = 211;
        public const int SS_212 = 212;
        public const int SS_213 = 213;
        public const int SS_214 = 214;
        public const int SS_215 = 215;

        public static byte WEAPONfeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static byte DRESSfeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static ushort APPRfeature(int cfeature)
        {
            ushort result = 0;
            return result;
        }

        public static byte HAIRfeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static byte RACEfeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static byte Horsefeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static byte Effectfeature(int cfeature)
        {
            byte result = 0;
            return result;
        }

        public static int MakeHumanFeature(byte btRaceImg, byte btDress, byte btWeapon, byte btHair)
        {
            int result = 0;
            return result;
        }

        public static int MakeMonsterFeature(byte btRaceImg, byte btWeapon, ushort wAppr)
        {
            int result = 0;
            return result;
        }

        public static string GetAtomTypeStr(byte btAtom)
        {
            string result = String.Empty;
            return result;
        }

        public static uint TouLong(string x)
        {
            uint result = 0;
            return result;
        }
    }

    public struct TCartInfo
    {
        public string[] sCharName;
        public int nRecogId;
        public int nX;
        public int nY;
    } // end TCartInfo

    public struct TVarInfo
    {
        public TVarType VarType;
        public TVarAttr VarAttr;
    } // end TVarInfo

    public struct TSendMessage
    {
        public ushort wIdent;
        public int wParam;

        // Word;
        public int nParam1;

        public int nParam2;
        public int nParam3;
        public Object BaseObject;
        public uint dwAddTime;
        public uint dwDeliveryTime;
        public bool boLateDelivery;
        public string Buff;
    } // end TSendMessage

    public struct TProcessMessage
    {
        public ushort wIdent;
        public int wParam;

        // Word;
        public int nParam1;

        public int nParam2;
        public int nParam3;
        public Object BaseObject;
        public bool boLateDelivery;
        public uint dwDeliveryTime;
        public string sMsg;
    } // end TProcessMessage

    public struct TOLoadHuman
    {
        public string[] sAccount;
        public string[] sChrName;
        public string[] sUserAddr;
        public int nSessionID;
    } // end TOLoadHuman

    public struct TLoadHuman
    {
        public string[] sAccount;
        public string[] sChrName;
        public string[] sUserAddr;
        public int nSessionID;
    } // end TLoadHuman

    public struct TShortMessage
    {
        public ushort Ident;
        public ushort wMsg;
    } // end TShortMessage

    public struct TMessageBodyW
    {
        public ushort Param1;
        public ushort Param2;
        public ushort Tag1;
        public ushort Tag2;
    } // end TMessageBodyW

    public struct TMessageBodyWL
    {
        public int lParam1;
        public int lParam2;
        public int lTag1;
        public int lTag2;
    } // end TMessageBodyWL

    public struct TCharDesc
    {
        public int feature;
        public int Status;
        public int Level;
        public int HP;
        public int MaxHP;
        public int AddStatus;
    } // end TCharDesc

    public struct THealth
    {
        public int HP;
        public int MP;
        public int MaxHP;
    } // end THealth

    public struct TVisibleMapItem
    {
        public byte btVisibleFlag;
        public Object BaseObject;
        public int nX;
        public int nY;
        public string sName;
        public ushort wLooks;
    } // end TVisibleMapItem

    public struct TVisibleMapEvent
    {
        public byte btVisibleFlag;
        public Object BaseObject;
        public int nX;
        public int nY;
    } // end TVisibleMapEvent

    public struct TVisibleBaseObject
    {
        public byte btVisibleFlag;
        public Object BaseObject;
    } // end TVisibleBaseObject

    public struct TOSessInfo
    {
        // ȫ�ֻỰ
        public string[] sAccount;

        public string[] sIPaddr;
        public int nSessionID;
        public int nPayMent;
        public int nPayMode;
        public int nSessionStatus;
        public uint dwStartTick;
        public uint dwActiveTick;
        public uint dwMakeAccountTick;
        public int nRefCount;
    } // end TOSessInfo

    public struct TSessInfo
    {
        // ȫ�ֻỰ
        // sAccount: string[ACCOUNTLEN];
        public string sAccount;

        public string[] sIPaddr;
        public int nSessionID;
        public int nPayMent;
        public int nPayMode;
        public int nSessionStatus;
        public uint dwStartTick;
        public uint dwActiveTick;
        public uint dwMakeAccountTick;
        public int nRefCount;
    } // end TSessInfo

    public struct TQuestInfo
    {
        public ushort wFlag;
        public byte btValue;
        public int nRandRage;
    } // end TQuestInfo

    public struct TScript
    {
        public bool boQuest;
        public TQuestInfo[] QuestInfo;
        public int nQuest;
        public ArrayList RecordList;
    } // end TScript

    public struct TMonItem
    {
        public int n00;
        public int n04;
        public string sMonName;
        public int n18;
    } // end TMonItem

    public struct TItemName
    {
        public int nItemIndex;
        public int nMakeIndex;
        public string sItemName;
    } // end TItemName

    public struct TDynamicVar
    {
        public string sName;
        public string sFileName;
        public TVarType VarType;
        public int nInternet;
        public string sString;
    } // end TDynamicVar

    public struct TRecallMigic
    {
        public int nHumLevel;
        public string sMonName;
        public int nCount;
        public int nLevel;
    } // end TRecallMigic

    public struct TMonSayMsg
    {
        public int nRate;
        public string sSayMsg;
        public TMonStatus State;
        public TMsgColor Color;
    } // end TMonSayMsg

    public struct TMonDrop
    {
        public string sItemName;
        public int nDropCount;
        public int nNoDropCount;
        public int nCountLimit;
    } // end TMonDrop

    public struct TGameCmd
    {
        public string[] sCmd;
        public int nPermissionMin;
        public int nPermissionMax;
    } // end TGameCmd

    public struct TIPaddr
    {
        public string[] dIPaddr;
        public string[] sIPaddr;
    } // end TIPaddr

    public struct TSrvNetInfo
    {
        public string[] sIPaddr;
        public int nPort;
    } // end TSrvNetInfo

    public struct TCheckCode
    {
    } // end TCheckCode

    public struct TStdItem
    {
        public string[] Name;
        public byte StdMode;
        public byte Shape;
        public byte Weight;
        public byte AniCount;
        public sbyte Source;
        public byte Reserved;
        public byte NeedIdentify;
        public ushort Looks;
        public ushort DuraMax;
        public ushort Reserved1;
        public int AC;
        public int MAC;
        public int DC;
        public int MC;
        public int SC;
        public int Need;
        public int NeedLevel;
        public int Price;
        public byte[] AddValue;
        public byte[] AddPoint;
        public DateTime MaxDate;
    } // end TStdItem

    public struct TOStdItem
    {
        // OK
        public string[] Name;

        public byte StdMode;
        public byte Shape;
        public byte Weight;
        public byte AniCount;
        public sbyte Source;
        public byte Reserved;
        public byte NeedIdentify;
        public ushort Looks;
        public ushort DuraMax;
        public ushort AC;
        public ushort MAC;
        public ushort DC;
        public ushort MC;
        public ushort SC;
        public byte Need;
        public byte NeedLevel;
        public ushort w26;
        public int Price;
    } // end TOStdItem

    public struct TOClientItem
    {
        // OK
        public TOStdItem s;

        public int MakeIndex;
        public ushort Dura;
        public ushort DuraMax;
    } // end TOClientItem

    public struct TClientItem
    {
        // OK
        public TStdItem s;

        public int MakeIndex;
        public ushort Dura;
        public ushort DuraMax;
    } // end TClientItem

    public struct TMonInfo
    {
        public string[] sName;
        public byte btRace;
        public byte btRaceImg;
        public ushort wAppr;
        public ushort wLevel;
        public byte btLifeAttrib;
        public bool boUndead;
        public ushort wCoolEye;
        public uint dwExp;
        public ushort wMP;
        public ushort wHP;
        public ushort wAC;
        public ushort wMAC;
        public ushort wDC;
        public ushort wMaxDC;
        public ushort wMC;
        public ushort wSC;
        public ushort wSpeed;
        public ushort wHitPoint;
        public ushort wWalkSpeed;
        public ushort wWalkStep;
        public ushort wWalkWait;
        public ushort wAttackSpeed;
        public ArrayList ItemList;
    } // end TMonInfo

    public struct TMagic
    {
        public ushort wMagicId;
        public string[] sMagicName;
        public byte btEffectType;
        public byte btEffect;
        public byte bt11;
        public ushort wSpell;
        public ushort wPower;
        public byte[] TrainLevel;
        public ushort w02;
        public int[] MaxTrain;
        public byte btTrainLv;
        public byte btJob;
        public ushort wMagicIdx;
        public uint dwDelayTime;
        public byte btDefSpell;
        public byte btDefPower;
        public ushort wMaxPower;
        public byte btDefMaxPower;
        public string[] sDescr;
    } // end TMagic

    public struct TClientMagic
    {
        // 84
        public char Key;

        public byte Level;
        public int CurTrain;
        public TMagic Def;
    } // end TClientMagic

    public struct TUserMagic
    {
        public TMagic MagicInfo;
        public ushort wMagIdx;
        public byte btLevel;
        public byte btKey;
        public int nTranPoint;
    } // end TUserMagic

    public struct TMinMap
    {
        public string sName;
        public int nID;
    } // end TMinMap

    public struct TMapRoute
    {
        public string sSMapNO;
        public int nDMapX;
        public int nSMapY;
        public string sDMapNO;
        public int nSMapX;
        public int nDMapY;
    } // end TMapRoute

    public struct TMapInfo
    {
        public string sName;
        public string sMapNO;
        public int nL;

        // 0x10
        public int nServerIndex;

        // 0x24
        public int nNEEDONOFFFlag;

        // 0x28
        public bool boNEEDONOFFFlag;

        // 0x2C
        public string sShowName;

        // 0x4C
        public string sReConnectMap;

        // 0x50
        public bool boSAFE;

        // 0x51
        public bool boDARK;

        // 0x52
        public bool boFIGHT;

        // 0x53
        public bool boFIGHT3;

        // 0x54
        public bool boDAY;

        // 0x55
        public bool boQUIZ;

        // 0x56
        public bool boNORECONNECT;

        // 0x57
        public bool boNEEDHOLE;

        // 0x58
        public bool boNORECALL;

        // 0x59
        public bool boNORANDOMMOVE;

        // 0x5A
        public bool boNODRUG;

        // 0x5B
        public bool boMINE;

        // 0x5C
        public bool boNOPOSITIONMOVE;
    } // end TMapInfo

    public struct TUnbindInfo
    {
        public int nUnbindCode;
        public string[] sItemName;
    } // end TUnbindInfo

    public struct TQuestDiaryInfo
    {
        public ArrayList QDDinfoList;
    } // end TQuestDiaryInfo

    public struct TAdminInfo
    {
        public int nLv;
        public string[] sChrName;
        public string[] sIPaddr;
    } // end TAdminInfo

    public struct THumMagic
    {
        public ushort wMagIdx;
        public byte btLevel;
        public byte btKey;
        public int nTranPoint;
    } // end THumMagic

    public struct TNakedAbility
    {
        // Size 20
        public ushort DC;

        public ushort MC;
        public ushort SC;
        public ushort AC;
        public ushort MAC;
        public ushort HP;
        public ushort MP;
        public ushort Hit;
        public ushort Speed;
        public ushort X2;
    } // end TNakedAbility

    // TNakedAbility = packed record //Size 20
    // DC: Integer;
    // MC: Integer;
    // SC: Integer;
    // AC: Integer;
    // MAC: Integer;
    // HP: Integer;
    // MP: Integer;
    // Hit: Integer;
    // Speed: Integer;
    // X2: Integer;
    // end;
    // pTNakedAbility = ^TNakedAbility;
    //
    // TAbility = packed record //OK    //Size 40
    // Level: Word; //0x198  //0x34  0x00
    // AC: Integer; //0x19A  //0x36  0x02
    // MAC: Integer; //0x19C  //0x38  0x04
    // DC: Integer; //0x19E  //0x3A  0x06
    // MC: Integer; //0x1A0  //0x3C  0x08
    // SC: Integer; //0x1A2  //0x3E  0x0A
    // HP: Word; //0x1A4  //0x40  0x0C
    // MP: Word; //0x1A6  //0x42  0x0E
    // MaxHP: Word; //0x1A8  //0x44  0x10
    // MaxMP: Word; //0x1AA  //0x46  0x12
    // Exp: LongWord; //0x1B0  //0x4C 0x18
    // MaxExp: LongWord; //0x1B4  //0x50 0x1C
    // Weight: Word; //0x1B8   //0x54 0x20
    // MaxWeight: Word; //0x1BA   //0x56 0x22  ����
    // WearWeight: Word; //0x1BC   //0x58 0x24
    // MaxWearWeight: Word; //0x1BD   //0x59 0x25  ����
    // HandWeight: Word; //0x1BE   //0x5A 0x26
    // MaxHandWeight: Word; //0x1BF   //0x5B 0x27  ����
    // ATOM_DC: array[1..7] of Word;
    // ATOM_MC: array[1..7] of Word;
    // ATOM_MAC: array[1..7] of Word;
    // end;
    // pTAbility = ^TAbility;
    //
    public struct TAbility
    {
        // 0x198  //0x34  0x00
        public ushort Level;

        // 0x198  //0x34  0x00
        public int AC;

        // 0x19A  //0x36  0x02
        public int MAC;

        // 0x19C  //0x38  0x04
        public int DC;

        // 0x19E  //0x3A  0x06
        public int MC;

        // 0x1A0  //0x3C  0x08
        public int SC;

        // 0x1AA  //0x46  0x12
        public ushort HP;

        // 0x1A4  //0x40  0x0C
        public ushort MP;

        // 0x1A6  //0x42  0x0E
        public ushort MaxHP;

        // 0x1A8  //0x44  0x10
        public ushort MaxMP;

        // 0x1AA  //0x46  0x12
        public uint Exp;

        // 0x1B0  //0x4C 0x18
        public uint MaxExp;

        // 0x1B4  //0x50 0x1C
        public ushort Weight;

        // 0x1B8   //0x54 0x20
        public ushort MaxWeight;

        // 0x1BA   //0x56 0x22  ����
        public ushort WearWeight;

        // 0x1BC   //0x58 0x24
        public ushort MaxWearWeight;

        // 0x1BD   //0x59 0x25  ����
        public ushort HandWeight;

        // 0x1BE   //0x5A 0x26
        public ushort MaxHandWeight;

        // 0x1BF   //0x5B 0x27  ����
        public ushort[] ATOM_DC;

        public ushort[] ATOM_MC;
        public ushort[] ATOM_MAC;
        public byte MoveSpeed;
        public byte AttackSpeed;
        public byte[] AddPoint;
    } // end TAbility

    public struct TOAbility
    {
        // 0x198  //0x34  0x00
        public ushort Level;

        // 0x198  //0x34  0x00
        public ushort AC;

        public ushort MAC;
        public ushort DC;
        public ushort MC;
        public ushort SC;

        // 0x1AA  //0x46  0x12
        public ushort HP;

        // 0x1A4  //0x40  0x0C
        public ushort MP;

        // 0x1A6  //0x42  0x0E
        public ushort MaxHP;

        // 0x1A8  //0x44  0x10
        public ushort MaxMP;

        // 0x1AA  //0x46  0x12
        public byte btReserved1;

        public byte btReserved2;
        public byte btReserved3;
        public byte btReserved4;
        public uint Exp;
        public uint MaxExp;
        public ushort Weight;
        public ushort MaxWeight;

        // ����
        public byte WearWeight;

        public byte MaxWearWeight;

        // ����
        public byte HandWeight;

        public byte MaxHandWeight;
    } // end TOAbility

    public struct THAbility
    {
        public int Level;
        public ushort AC;
        public ushort MAC;
        public ushort DC;
        public ushort MC;
        public ushort SC;
        public int HP;
        public int MP;
        public int MaxHP;
        public int MaxMP;
        public byte btReserved1;
        public byte btReserved2;
        public byte btReserved3;
        public byte btReserved4;
        public uint Exp;
        public uint MaxExp;
        public ushort Weight;
        public ushort MaxWeight;

        // ����
        public byte WearWeight;

        public byte MaxWearWeight;

        // ����
        public byte HandWeight;

        public byte MaxHandWeight;
    } // end THAbility

    public struct TAddAbility
    {
        // 0x1A6  //0x42  0x0E
        public ushort WHP;

        // 0x1A4  //0x40  0x0C
        public ushort WMP;

        // 0x1A6  //0x42  0x0E
        public ushort wHitPoint;

        public ushort wSpeedPoint;
        public int wAC;
        public int wMAC;
        public int wDC;
        public int wMC;
        public int wSC;
        public byte bt1DF;

        // ��ʥ
        public byte bt035;

        public ushort wAntiPoison;
        public ushort wPoisonRecover;
        public ushort wHealthRecover;
        public ushort wSpellRecover;
        public ushort wAntiMagic;
        public byte btLuck;
        public byte btUnLuck;
        public int nHitSpeed;
        public byte btWeaponStrong;
        public ushort[] ATOM_DC;
        public ushort[] ATOM_MC;
        public ushort[] ATOM_MAC;
        public byte MoveSpeed;
        public byte AttackSpeed;
        public byte[] AddPoint;
    } // end TAddAbility

    public struct TWAbility
    {
        public uint dwExp;

        // ���ﾭ��ֵ(Dword)
        public int wHP;

        public int wMP;
        public int wMaxHP;
        public int wMaxMP;
    } // end TWAbility

    public struct TMerchantInfo
    {
        public string[] sScript;
        public string[] sMapName;
        public int nX;
        public int nY;
        public string[] sNPCName;
        public int nFace;
        public int nBody;
        public bool boCastle;
    } // end TMerchantInfo

    public struct TSocketBuff
    {
        public string Buffer;
        public int nLen;
    } // end TSocketBuff

    public struct TSendBuff
    {
        public int nLen;
        public char[] Buffer;
    } // end TSendBuff

    public struct TOUserItem
    {
        public int MakeIndex;
        public ushort wIndex;

        // ��Ʒid
        public ushort Dura;

        // ��ǰ�־�ֵ
        public ushort DuraMax;

        // ���־�ֵ
        public byte[] btValue;

        // array[0..13] of Byte;
        public byte[] AddValue;

        // 12=װ������(1,2,3)
        public byte[] AddPoint;

        // 1=����������(1=�����˺����� 2=ħ���˺����� 3=����Ŀ����� 4=�����˺����� 5=���ӹ����˺�) 2=������ֵ
        public DateTime MaxDate;
    } // end TOUserItem

    // TOHeroUserItem = packed record
    // MakeIndex: Integer;
    // wIndex: Word; //��Ʒid
    // Dura: Word; //��ǰ�־�ֵ
    // DuraMax: Word; //���־�ֵ
    // btValue: TValue; //array[0..13] of Byte;
    // AddValue: TValue;
    // MaxDate: TDateTime;
    // end;
    // pTOHeroUserItem = ^TOHeroUserItem;
    public struct TUserItem
    {
        public int MakeIndex;
        public ushort wIndex;

        // ��Ʒid
        public ushort Dura;

        // ��ǰ�־�ֵ
        public ushort DuraMax;

        // ���־�ֵ
        public byte[] btValue;

        // array[0..13] of Byte;
        public byte[] AddValue;

        // 12=װ������(1,2,3)
        public byte[] AddPoint;

        // 1=����������(1=�����˺����� 2=ħ���˺����� 3=����Ŀ����� 4=�����˺����� 5=���ӹ����˺�) 2=������ֵ
        public byte[] btValue2;

        // 3=���������ǿ 4=ħ��������ǿ 5=��������ǿ 6=ħ��������ǿ 7=����������ǿ 8=���ӽ���ʧ��״̬ 9=���ӽ������״̬ 10=���ٽ���ʧ��״̬ 11=���ٽ������״̬ 12=�ƶ����� 13=��������
        public DateTime MaxDate;
    } // end TUserItem

    public struct TOBigStorage
    {
        // ���޲ֿ����ݽṹ
        public bool boDelete;

        public string[] sCharName;
        public DateTime SaveDateTime;
        public TOUserItem UserItem;
        public int nIndex;
    } // end TOBigStorage

    public struct TOSellOffInfo
    {
        // Size 59    �������ݽṹ
        public string[] sCharName;

        public DateTime dSellDateTime;
        public int nSellGold;
        public int n;
        public TOUserItem UserItem;
        public int nIndex;
    } // end TOSellOffInfo

    //
    // TOHeroBigStorage = packed record //���޲ֿ����ݽṹ
    // boDelete: Boolean;
    // sCharName: string[ACTORNAMELEN];
    // SaveDateTime: TDateTime;
    // UseItems: TOHeroUserItem;
    // nIndex: Integer;
    // end;
    // pTOHeroBigStorage = ^TOHeroBigStorage;
    //
    // TOHeroSellOffInfo = packed record //Size 59    �������ݽṹ
    // sCharName: string[ACTORNAMELEN];
    // dSellDateTime: TDateTime;
    // nSellGold: Integer;
    // n: Integer;
    // UseItems: TOHeroUserItem;
    // nIndex: Integer;
    // end;
    // pTOHeroSellOffInfo = ^TOHeroSellOffInfo;
    public struct TMonItemInfo
    {
        public int SelPoint;
        public int MaxPoint;
        public string ItemName;
        public int Count;
    } // end TMonItemInfo

    public struct TMonsterInfo
    {
        public string Name;
        public ArrayList ItemList;
    } // end TMonsterInfo

    public struct TOHumanRcd
    {
        public string[] sUserID;
        public string[] sCharName;
        public byte btJob;
        public byte btGender;
        public byte btLevel;
        public byte btHair;
        public string[] sMapName;
        public byte btAttackMode;
        public byte btIsAdmin;
        public int nX;
        public int nY;
        public int nGold;
        public uint dwExp;
    } // end TOHumanRcd

    public struct THumanRcd
    {
        public string[] sUserID;
        public string[] sCharName;
        public byte btJob;
        public byte btGender;
        public byte btLevel;
        public byte btHair;
        public string[] sMapName;
        public byte btAttackMode;
        public byte btIsAdmin;
        public int nX;
        public int nY;
        public int nGold;
        public uint dwExp;
    } // end THumanRcd

    public struct TObjectFeature
    {
        public byte btGender;
        public byte btWear;
        public byte btHair;
        public byte btWeapon;
    } // end TObjectFeature

    public struct TStatusInfo
    {
        public int nStatus;
        public uint dwStatusTime;
        public short sm218;
        public uint dwTime220;
    } // end TStatusInfo

    public struct TMsgHeader
    {
        public uint dwCode;
        public int nSocket;
        public ushort wGSocketIdx;
        public ushort wIdent;
        public int wUserListIndex;
        public int nLength;
    } // end TMsgHeader

    //public struct TUserInfo
    //{
    //    public bool bo00;
    //    // 0x00
    //    public bool bo01;
    //    // 0x01 ?
    //    public bool bo02;
    //    // 0x02 ?
    //    public bool bo03;
    //    // 0x03 ?
    //    public int n04;
    //    // 0x0A ?
    //    public int n08;
    //    // 0x0B ?
    //    public bool bo0C;
    //    // 0x0C ?
    //    public bool bo0D;
    //    // 0x0D
    //    public bool bo0E;
    //    // 0x0E ?
    //    public bool bo0F;
    //    // 0x0F ?
    //    public int n10;
    //    // 0x10 ?
    //    public int n14;
    //    // 0x14 ?
    //    public int n18;
    //    // 0x18 ?
    //    public string[] sStr;
    //    // 0x1C
    //    public int nSocket;
    //    // 0x34
    //    public int nGateIndex;
    //    // 0x38
    //    public int n3C;
    //    // 0x3C
    //    public int n40;
    //    // 0x40 ?
    //    public int n44;
    //    // 0x44
    //    public ArrayList List48;
    //    // 0x48
    //    public Object Cert;
    //    // 0x4C
    //    public uint dwTime50;
    //    // 0x50
    //    public bool bo54;
    //} // end TUserInfo

    public struct TGlobaSessionInfo
    {
        public string sAccount;
        public string sIPaddr;
        public int nSessionID;
        public int n24;
        public bool bo28;
        public bool boLoadRcd;
        public bool boHeroLoadRcd;
        public bool boStartPlay;
        public uint dwAddTick;
        public DateTime dAddDate;
        public bool boRandomCode;
    } // end TGlobaSessionInfo

    public struct TUserStateInfo
    {
        public int Feature;
        public string[] UserName;
        public int NAMECOLOR;
        public string[] GuildName;
        public string[] GuildRankName;
        public TClientItem[] UseItems;
    } // end TUserStateInfo

    public struct TSellOffHeader
    {
        public int nItemCount;
    } // end TSellOffHeader

    public struct TSellOffInfo
    {
        // Size 59    �������ݽṹ
        public string[] sCharName;

        public DateTime dSellDateTime;
        public int nSellGold;
        public int n;
        public TUserItem UserItem;
        public int nIndex;
    } // end TSellOffInfo

    public struct TClientSellItem
    {
        // boSelled: Boolean;
        public string[] sCharName;

        public DateTime dSellDateTime;
        public TClientItem SellItem;
    } // end TClientSellItem

    public struct TBigStorage
    {
        // ���޲ֿ����ݽṹ
        public bool boDelete;

        public string[] sCharName;
        public DateTime SaveDateTime;
        public TUserItem UserItem;
        public int nIndex;
    } // end TBigStorage

    public struct TODuelItem
    {
        // ��ս
        public bool boFinish;

        // ��ս���
        public bool boDelete;

        public byte btDuel;
        public string[] sOwnerName;
        public string[] sDuelName;
        public TOUserItem UserItem;
        public int n01;
        public int n02;
        public int nIndex;
    } // end TODuelItem

    public struct TDuelItem
    {
        // ��ս
        public bool boFinish;

        // ��ս���
        public bool boDelete;

        public byte btDuel;
        public string[] sOwnerName;
        public string[] sDuelName;
        public TUserItem UserItem;
        public int n01;
        public int n02;
        public int nIndex;
    } // end TDuelItem

    public struct TDuel
    {
        // ��ս
        public bool boDelete;

        public bool boVictory;

        // ʤ��
        public string[] sCharName;

        public int nDuelGold;
        public int nItemCount;
        public int n01;
        public int n02;
    } // end TDuel

    public struct TDuelInfo
    {
        // ��ս
        public bool boDelete;

        public byte btDuel;
        public DateTime SaveDateTime;
        public TDuel Owner;

        // ������ս��
        public TDuel Duel;

        // ������ս��
        public bool boFinish;

        // ��ս���
        public int n03;

        public int n04;
        public int nIndex;
    } // end TDuelInfo

    // ��̯
    public struct TItemIndex
    {
        public byte btSellType;

        // 0��� 1Ԫ�� 2���� 3����
        public string[] ItemName;

        public int MakeIndex;
        public int Price;
    } // end TItemIndex

    public struct TOStoreServerItem
    {
        public byte btSellType;

        // 0��� 1Ԫ�� 2���� 3����
        public int Price;

        public TOUserItem UserItem;
    } // end TOStoreServerItem

    public struct TOStoreItem
    {
        public byte btSellType;

        // 0��� 1Ԫ�� 2���� 3����
        public TClientItem Item;
    } // end TOStoreItem

    public struct TOUserStoreStateInfo
    {
        public int RecogId;
        public string[] UserName;
        public int NAMECOLOR;
        public string[] SellMsg;
        public TOStoreItem[] UseItems;
    } // end TOUserStoreStateInfo

    public struct TStoreServerItem
    {
        public byte btSellType;

        // 0��� 1Ԫ�� 2���� 3����
        public int Price;

        public TUserItem UserItem;
    } // end TStoreServerItem

    public struct TStoreItem
    {
        public byte btSellType;

        // 0��� 1Ԫ�� 2���� 3����
        public TClientItem Item;
    } // end TStoreItem

    public struct TUserStoreStateInfo
    {
        public int RecogId;
        public string[] UserName;
        public int NAMECOLOR;
        public string[] SellMsg;
        public TStoreItem[] UseItems;
    } // end TUserStoreStateInfo

    public struct TBindItemFile
    {
        public byte btItemType;
        public string sItemName;
        public string sBindItemName;
    } // end TBindItemFile

    public struct TBindItem
    {
        public string[] sUnbindItemName;
        public int nStdMode;
        public int nShape;
        public byte btItemType;
    } // end TBindItem

    public struct TOUserStateInfo
    {
        // OK
        public int feature;

        public string[] UserName;

        // 15
        public string[] GuildName;

        // 14
        public string[] GuildRankName;

        // 15
        public ushort NAMECOLOR;

        public TOClientItem[] UseItems;
    } // end TOUserStateInfo

    public struct TOIDRecordHeader
    {
        public bool boDeleted;
        public byte bt1;
        public byte bt2;
        public byte bt3;
        public DateTime CreateDate;
        public DateTime UpdateDate;
        public string[] sAccount;
    } // end TOIDRecordHeader

    public struct TIDRecordHeader
    {
        public bool boDeleted;
        public byte bt1;
        public byte bt2;
        public byte bt3;
        public DateTime CreateDate;
        public DateTime UpdateDate;
        public string[] sAccount;
    } // end TIDRecordHeader

    public struct TRecordHeader
    {
        // Size 12
        public bool boDeleted;

        public byte nSelectID;
        public bool boIsHero;
        public byte bt2;
        public DateTime dCreateDate;

        // ����ʱ��
        public string[] sName;
    } // end TRecordHeader

    public struct TOHumInfo
    {
        // Size 72
        public TRecordHeader Header;

        public string[] sChrName;

        // 0x14  //��ɫ����   44
        public string[] sAccount;

        // �˺�
        public bool boDeleted;

        // �Ƿ�ɾ��
        public bool boIsHero;

        public DateTime dModDate;
        public byte btCount;

        // �����ƴ�
        public bool boSelected;

        // �Ƿ�ѡ��
        public byte[] n6;
    } // end TOHumInfo

    public struct THumInfo
    {
        // Size 72
        public TRecordHeader Header;

        public string[] sChrName;

        // 0x14  //��ɫ����   44
        public string[] sAccount;

        // �˺�
        public bool boDeleted;

        // �Ƿ�ɾ��
        public bool boIsHero;

        public DateTime dModDate;
        public byte btCount;

        // �����ƴ�
        public bool boSelected;

        // �Ƿ�ѡ��
        public byte[] n6;
    } // end THumInfo

    //public struct TIdxRecord
    //{
    //    public string[] sChrName;
    //    public int nIndex;
    //} // end TIdxRecord

    public struct THumData
    {
    } // end THumData

    public struct TOHumData
    {
        // Size = 3164
        public string[] sChrName;

        public string[] sCurMap;
        public ushort wCurX;
        public ushort wCurY;
        public byte btDir;
        public byte btHair;
        public byte btSex;
        public byte btJob;
        public int nGold;
        public TOAbility Abil;

        // +40
        public ushort[] wStatusTimeArr;

        // +24
        public string[] sHomeMap;

        public ushort wHomeX;
        public ushort wHomeY;
        public string[] sDearName;
        public string[] sMasterName;
        public bool boMaster;
        public int btCreditPoint;
        public byte btDivorce;

        // �Ƿ���
        public byte btMarryCount;

        // ������
        public string[] sStoragePwd;

        public byte btReLevel;
        public bool boOnHorse;
        public TNakedAbility BonusAbil;

        // +20
        public int nBonusPoint;

        public int nGameGold;
        public int nGamePoint;
        public int nPayMentPoint;

        // ��ֵ��
        public int nPKPOINT;

        public byte btAllowGroup;
        public byte btF9;
        public byte btAttatckMode;
        public byte btIncHealth;
        public byte btIncSpell;
        public byte btIncHealing;
        public byte btFightZoneDieCount;
        public string[] sAccount;
        public byte btEE;
        public byte btEF;
        public bool boLockLogon;
        public ushort wContribution;
        public int nHungerStatus;
        public bool boAllowGuildReCall;

        // �Ƿ������л��һ
        public ushort wGroupRcallTime;

        // �Ӵ���ʱ��
        public double dBodyLuck;

        // ���˶�  8
        public bool boAllowGroupReCall;

        // �Ƿ�������غ�һ
        public int nEXPRATE;

        // ���鱶��
        public int nExpTime;

        // ���鱶��ʱ��
        public byte btLastOutStatus;

        // 2006-01-12���� �˳�״̬ 1Ϊ�����˳�
        public ushort wMasterCount;

        // ��ʦͽ����
        public bool boHasHero;

        // �Ƿ���Ӣ��
        public bool boIsHero;

        // �Ƿ���Ӣ��
        public byte btStatus;

        // ״̬
        public string[] sHeroChrName;

        public int nGrudge;
        public byte[] QuestFlag;

        // �ű�����
        public TNewStatus NewStatus;

        // 1ʧ�� 2���� ״̬
        public ushort wStatusDelayTime;

        // ʧ������ʱ��
        public byte[] AddByte;

        public TOUserItem[] HumItems;

        // 9��װ�� �·�  ����  ���� ͷ�� ���� ���� ���� ��ָ ��ָ
        public TOUserItem[] BagItems;

        // ����װ��
        public THumMagic[] HumMagics;

        // ħ��
        public TOUserItem[] StorageItems;

        // �ֿ���Ʒ
        public TOUserItem[] HumAddItems;
    } // end TOHumData

    public struct THumDataInfo
    {
        // Size 3164
        public TRecordHeader Header;

        public THumData Data;
    } // end THumDataInfo

    public struct TOHumDataInfo
    {
        // Size 3164
        public TRecordHeader Header;

        public TOHumData Data;
    } // end TOHumDataInfo

    // TOHeroHumDataInfo = packed record //Size 3164
    // Header: TRecordHeader;
    // Data: TOHeroHumData;
    // end;
    // pTOHeroHumDataInfo = ^TOHeroHumDataInfo;
    public struct TSaveRcd
    {
        public string[] sAccount;
        public string[] sChrName;
        public int nSessionID;
        public int nReTryCount;
        public uint dwSaveTick;

        // 2006-11-12 ���� ��������´α���TICK
        public Object PlayObject;

        public THumDataInfo HumanRcd;
    } // end TSaveRcd

    public struct TLoadDBInfo
    {
        public string[] sAccount;
        public string[] sCharName;
        public string[] sIPaddr;
        public string sMsg;
        public int nSessionID;
        public int nSoftVersionDate;
        public int nPayMent;
        public int nPayMode;
        public int nSocket;
        public int nGSocketIdx;
        public int nGateIdx;
        public bool boClinetFlag;
        public uint dwNewUserTick;
        public Object PlayObject;
        public int nReLoadCount;
        public bool boHeroVersion;
        public THeroDataType HeroData;
        public Object NPC;
    } // end TLoadDBInfo

    //
    // TLoadDBInfo = record
    // sAccount: string[12];
    // sCharName: string[ACTORNAMELEN];
    // sIPaddr: string[15];
    // sMsg: string;
    // nSessionID: Integer;
    // nSoftVersionDate: Integer;
    // nPayMent: Integer;
    // nPayMode: Integer;
    // nSocket: Integer;
    // nGSocketIdx: Integer;
    // nGateIdx: Integer;
    // boClinetFlag: Boolean;
    // dwNewUserTick: LongWord;
    // PlayObject: TObject;
    // nReLoadCount: Integer;
    // boIsHero: Boolean;
    // btLoadDBType: Byte;
    // boHeroVersion: Boolean;
    // end;
    // pTLoadDBInfo = ^TLoadDBInfo;
    //
    // TUserOpenInfo = record
    // sAccount: string[12];
    // sChrName: string[ACTORNAMELEN];
    // LoadUser: TLoadDBInfo;
    // HumanRcd: THumDataInfo;
    // nOpenStatus: Integer;
    // end;
    // pTUserOpenInfo = ^TUserOpenInfo;
    public struct TUserOpenInfo
    {
        public string[] sAccount;
        public string[] sChrName;
        public TLoadDBInfo LoadUser;
        public THumDataInfo HumanRcd;
        public int nResult;
        public Object NPC;
    } // end TUserOpenInfo

    public struct TLoadUser
    {
        public string[] sAccount;
        public string[] sChrName;
        public string[] sIPaddr;
        public int nSessionID;
        public int nSocket;
        public int nGateIdx;
        public int nGSocketIdx;
        public int nPayMent;
        public int nPayMode;
        public uint dwNewUserTick;
        public int nSoftVersionDate;
    } // end TLoadUser

    public struct TDoorStatus
    {
        public bool bo01;
        public bool boOpened;
        public uint dwOpenTick;
        public int nRefCount;
        public int n04;
    } // end TDoorStatus

    //
    // TDoorInfo = record
    // nX: Integer;
    // nY: Integer;
    // n08: Integer;
    // Status: pTDoorStatus;
    // end;
    // pTDoorInfo = ^TDoorInfo;
    //
    public struct TSlaveInfo
    {
        public string sSalveName;
        public byte btSalveLevel;
        public byte btSlaveExpLevel;
        public uint dwRoyaltySec;
        public int nKillCount;
        public int nHP;
        public int nMP;
    } // end TSlaveInfo

    public struct TSwitchDataInfo
    {
        public string[] sChrName;
        public string[] sMAP;
        public ushort wX;
        public ushort wY;
        public TAbility Abil;
        public int nCode;
        public bool boC70;
        public bool boBanShout;
        public bool boHearWhisper;
        public bool boBanGuildChat;
        public bool boAdminMode;
        public bool boObMode;
        public string[] BlockWhisperArr;
        public TSlaveInfo[] SlaveArr;
        public ushort[] StatusValue;
        public uint[] StatusTimeOut;
    } // end TSwitchDataInfo

    public struct TGoldChangeInfo
    {
        public TChangeType ChangeType;
        public string sGameMasterName;
        public string sGetGoldUser;
        public int nGold;
    } // end TGoldChangeInfo

    //public struct TGateInfo
    //{
    //    public TCustomWinSocket Socket;
    //    public bool boUsed;
    //    public string[] sAddr;
    //    public int nPort;
    //    public int n520;
    //    public ArrayList UserList;
    //    public int nUserCount;
    //    public string Buffer;
    //    public int nBuffLen;
    //    public ArrayList BufferList;
    //    public bool boSendKeepAlive;
    //    public uint dwSendKeepAliveTick;
    //    public int nSendChecked;
    //    public int nSendBlockCount;
    //    public uint dwTime544;
    //    public int nSendMsgCount;
    //    public int nSendRemainCount;
    //    public uint dwSendTick;
    //    public int nSendMsgBytes;
    //    public int nSendBytesCount;
    //    public int nSendedMsgCount;
    //    public int nSendCount;
    //    public uint dwSendCheckTick;
    //} // end TGateInfo

    public struct TStartPoint
    {
        // ��ȫ���سǵ� ���ӹ⻷Ч��
        public string[] sMapName;

        public int nCurrX;

        // ������������X(4�ֽ�)
        public int nCurrY;

        public bool boNotAllowSay;
        public int nRange;
        public int nType;
        public int nPkZone;
        public int nPkFire;
        public byte btShape;
    } // end TStartPoint

    // ��ͼ�¼������������
    public struct TQuestUnitStatus
    {
        public int nQuestUnit;
        public bool boOpen;
    } // end TQuestUnitStatus

    public struct TMapCondition
    {
        public int nHumStatus;
        public string[] sItemName;
        public bool boNeedGroup;
    } // end TMapCondition

    public struct TStartScript
    {
        public int nLable;
        public string[] sLable;
    } // end TStartScript

    public struct TMapEvent
    {
        public string[] m_sMapName;
        public int m_nCurrX;
        public int m_nCurrY;
        public int m_nRange;
        public TQuestUnitStatus m_MapFlag;
        public int m_nRandomCount;

        // ; ��Χ:(0 - 999999) 0 �Ļ���Ϊ100% ; ����Խ�󣬻���Խ��
        public TMapCondition m_Condition;

        // ��������
        public TStartScript m_StartScript;
    } // end TMapEvent

    public struct TRememberItem
    {
        public string[] sMapName;
        public int nCurrX;
        public int nCurrY;
    } // end TRememberItem

    public struct TItemEvent
    {
        public string[] sItemName;
        public int nMakeIndex;
        public TRememberItem[] RememberItem;
    } // end TItemEvent

    public struct TSendUserData
    {
        public int nSocketIndx;
        public int nSocketHandle;
        public string sMsg;
    } // end TSendUserData

    public struct TCheckVersion
    {
    } // end TCheckVersion

    public struct TRecordDeletedHeader
    {
        public bool boDeleted;
        public byte bt1;
        public byte bt2;
        public byte bt3;
        public DateTime CreateDate;
        public DateTime LastLoginDate;
        public int n14;
        public int nNextDeletedIdx;
    } // end TRecordDeletedHeader

    public struct TUserEntry
    {
        public string sAccount;
        public string sPassword;
        public string sUserName;
        public string sSSNo;
        public string sPhone;
        public string sQuiz;
        public string sAnswer;
        public string sEMail;
    } // end TOUserEntry

    //    TUserEntry = packed record
    //  sAccount: string[ACCOUNTLEN]; //30
    //  sPassword: string[16];
    //  sUserName: string[20];
    //  sSSNo: string[14];
    //  sPhone: string[14];
    //  sQuiz: string[20];
    //  sAnswer: string[12];
    //  sEMail: string[40];
    //end;

    public struct TUserEntryAdd
    {
        public string sQuiz2;
        public string sAnswer2;
        public string sBirthDay;
        public string sMobilePhone;
        public string sMemo;
        public string sMemo2;
    } // end TUserEntryAdd

    public struct TOAccountDBRecord
    {
        public TOIDRecordHeader Header;
        public TUserEntry UserEntry;
        public TUserEntryAdd UserEntryAdd;
        public int nErrorCount;
        public uint dwActionTick;
        public uint dwCreateTick;
        public byte[] n;
    } // end TOAccountDBRecord

    public struct TAccountDBRecord
    {
        public TIDRecordHeader Header;
        public TUserEntry UserEntry;
        public TUserEntryAdd UserEntryAdd;
        public int nErrorCount;
        public uint dwActionTick;
        public uint dwCreateTick;
        public byte[] n;
    } // end TAccountDBRecord

    public struct TUserLevelRanking
    {
        // ����ȼ�����
        public int nIndex;

        public int nLevel;
        public string[] sChrName;
    } // end TUserLevelRanking

    public struct THeroLevelRanking
    {
        // Ӣ�۵ȼ�����
        public int nIndex;

        public int nLevel;
        public string[] sChrName;
        public string[] sHeroName;
    } // end THeroLevelRanking

    public struct TUserMasterRanking
    {
        // ͽ����������
        public int nIndex;

        public int nMasterCount;
        public string[] sChrName;
    } // end TUserMasterRanking

    public struct TChrMsg
    {
        public int Ident;
        public int x;
        public int y;
        public int dir;
        public int State;
        public int feature;
        public string saying;
        public int sound;
    } // end TChrMsg

    // TRegInfo = record
    // sKey: string;
    // sServerName: string;
    // sRegSrvIP: string[15];
    // nRegPort: Integer;
    // end;
    public struct TDropItem
    {
        public int x;
        public int y;
        public int id;
        public int Looks;
        public string Name;
        public int FlashTime;
        public int FlashStepTime;
        public int FlashStep;
        public bool BoFlash;
    } // end TDropItem

    public struct TUserCharacterInfo
    {
        public string[] Name;
        public byte job;
        public byte HAIR;
        public int Level;
        public byte sex;
    } // end TUserCharacterInfo

    public struct TClientGoods
    {
        public string Name;
        public int SubMenu;
        public int Price;
        public int Stock;
        public int Grade;
    } // end TClientGoods

    public struct TClientBoxItem
    {
        public bool boGive;
        public bool boCenter;
        public TStdItem StdItem;
    } // end TClientBoxItem

    public struct TSuperItemBox
    {
        public TOpenBoxStatus BoxStatus;
        public TUserItem UserItem;
        public byte btBoxType;
        public byte btGiveBoxIndex;
        public string sOpenBoxName;
        public string sItemName;
        public TClientBoxItem[] BoxItemArray;
    } // end TSuperItemBox

    public struct TRegInfo
    {
        public bool boShare;
        public int nSSocket;
        public int nCSocket;
        public uint nParam1;
        public uint nParam2;
        public int[] nProcedure;
    } // end TRegInfo

    public struct TServerConfig
    {
        public byte btShowClientItemStyle;
        public bool boAllowItemAddValue;
        public bool boAllowItemTime;
        public bool boAllowItemAddPoint;
        public bool boCheckSpeedHack;
        public int nGreenNumber;
        public bool boRUNHUMAN;
        public bool boRUNMON;
        public bool boRunNpc;
        public bool boChgSpeed;
        public int nFireDelayTime;
        public int nKTZDelayTime;
        public int nPKJDelayTime;
        public int nSkill50DelayTime;
        public int nZRJFDelayTime;
        public int nMaxLevel;
    } // end TServerConfig

    public struct TTempRecord
    {
        public byte[] btValue;
        public int nX;
        public int nY;
    } // end TTempRecord

    public struct TUpgradeItem
    {
        public string[] sName;
        public int nMakeIndex;
    } // end TUpgradeItem

    public struct TUpgradeClientItem
    {
        public int[] UpgradeItemIndexs;
        public string[] UpgradeItemNames;
    } // end TUpgradeClientItem

    public struct TCopyItem
    {
        public TItemType ItemType;
        public Object OwnerObj;
        public object OwnerAddr;
        public TUserItem UserItem;
    } // end TCopyItem

    // ���뿪�� 0=��ҵ�� 1=Ӣ�۰�
    // ALLFUNCTION = 1;
    // �汾��
    // ==============================================================================
    // ��������С
    // 8192;
    // 8192;
    // ��
    // ��
    // ��
    // ��
    // ��ʥ
    // ����
    // ��Ӱ
    // �·�
    // װ������
    // ����
    // ����
    // ͷ��
    // ��������
    // ��������
    // ���ֽ�ָ
    // ���ֽ�ָ
    // ��
    // ����
    // Ь
    // RUNGATECODE = $AA9AAA9A; BLUE
    // ����
    // ����
    // Ӣ��
    // ������
    // ���ι���
    // ��ѯ��ɫ
    // ������ɫ
    // ɾ����ɫ
    // ѡ���ɫ
    // ѡ�������
    // ��ѯɾ����ɫ
    // �ָ���ɫ
    // ��ѯ�������б�
    // ��ѯ��֤��
    // ��֤��֤��
    // �һ�
    // ת��
    // ��
    // ��
    // ��
    // ʹ��ħ��
    // ��ɱ
    // ��������
    // SM_27 = 27;
    // SM_28 = 28;
    // SM_29 = 29;
    // SM_30 = 30;
    // SM_31 = 31;
    // SM_32 = 32;
    //
    // SM_40 = 40;
    // SM_41 = 41;
    // SM_42 = 42;
    // SM_43 = 43;
    // SM_44 = 44;
    // SM_45 = 45;
    // ���ս���
    // 4���һ�
    // ����ɱ
    // ׷�Ĵ�
    // ����ն
    // ��ɨǧ��
    // ����
    // ����
    // ����
    // ʬ��
    // ��ɱ
    // �ػ�
    // ��ȡ����
    // ����
    // ̫������
    // ��½
    // �µ�ͼ
    // �����ԶԻ���
    // ����������Ѫ
    // ��ͼ����
    // ϵͳ��Ϣ
    // ����
    // ˽��
    // �л���Ϣ
    // ��֤ʧ��
    // �����ʺųɹ�
    // �����ʺ�ʧ��
    // �޸�����ɹ�
    // �޸�����ʧ��
    // �����һسɹ�
    // �����һ�ʧ��
    // ��ѯ��ɫ��Ϣ
    // �½���ɫ�ɹ�
    // �½���ɫʧ��
    // ɾ����ɫ�ɹ�
    // ɾ����ɫʧ��
    // ��ʼ��Ϸ�ɹ�
    // SM_USERFULL  ��ʼ��Ϸʧ��
    // ��ѯ��ɫʧ��
    // ����������� ,ǿ���û�����
    // ѡ�������
    // �������б�
    // ������֤��
    // SM_DOOROPEN           = 612;
    // ͨ����
    // ͨ������ ��ǰʢ������ͨ��ȥ���µ���Ҫ5���ӿ�һ��
    // ����
    // �ı��ͼ
    // ?
    // ?
    // ���س־�
    // ����־øı�
    // ������ɫ�ı�
    // ������Ϸ����
    // ��Χ״̬
    // �ҵ�״̬
    // 714
    // 716
    // �򿪸������ԶԻ���
    // ?
    // ?
    // ?
    // Jacky
    // ���������������
    // ʱ�Ӽ������ͻ�������
    // ?
    // ��������
    // ʵʱ����
    // ��֤�汾ʧ��
    // Jacky
    // jacky
    // �������
    // �л�����
    // Jacky
    // ?
    // δ֪;
    // �����һ�
    // ʩħ��
    // ����Ϫ
    // ����
    // װ����Ʒ
    // ж��װ��
    // ��ҩ
    // ���npc
    // ��Ʒѡ��
    // ���ؼ۸�
    // ������
    // ����
    // �ӵ�Ǯ��
    // ������Ϸ����
    // ������Ʒ
    // ��ȡ�������
    // ��ʼ����
    // ����������Ʒ
    // ���׼�����Ʒ
    // ȡ������
    // ���׽�Ǯ
    // �������
    // �Ĵ���Ʒ
    // ȡ����Ʒ
    // ���춾Ʒ
    // �л�
    // �л���ҳ
    // ��Ա�Ա�
    // ��ӳ�Ա
    // ɾ����Ա
    // �޸Ĺ���
    // ����������Ϣ
    // ??
    // ?
    // ?
    // �׷�
    // ת��
    // ��
    // ��
    // ��
    // ��ͨ���������
    // ��ɱ
    // ��ɱ
    // ����
    // �һ�
    // ���µ�
    // ���ն
    // �ƻ�ն
    // ���ս���
    // ����ɱ
    // ׷�Ĵ�
    // ����ն
    // ��ɨǧ��
    // ��ɫ����
    // Ӣ�۰���
    // ��ѯ�û�״̬
    // ��ѯ��ɫ��Ʒ
    // ����
    // �ͻ��˷��͵����� �˳� ���˻���С��
    // RM_101HITA = 20104;
    // ��Ϸ������
    // 6���̻�
    // 5�ֿռ���
    // �����ʺ�����
    // �½��û�
    // �޸�����
    // �������
    // �������
    // SERIES 7 ÿҳ������    wParam ��ҳ��
    // ==============================================================================
    // �û��ȼ�����
    // ==============================������Ʒ����ϵͳ==============================
    // ��ѯ������Ʒ
    // ָ����Ʒ����ѯ������Ʒ
    // ָ����Ʒ����ѯ������Ʒ
    // ������Ʒ
    // ��ѯ�õ��ļ�����Ʒ
    // ��ѯ�õ��ļ�����Ʒ
    // ���������Ʒ�ɹ�
    // ���������Ʒ�ɹ�
    // ���������Ʒʧ��
    // ���������Ʒʧ��
    // ����ѡ�������Ʒ
    // ����ѡ�������Ʒ
    // ��ѯѡ�������Ʒ
    // ��ѯѡ�������Ʒ
    // ���ܼ�����Ʒ
    // ���ܼ�����Ʒ
    // R = -3  ������Ʒʧ��
    // ������Ʒ�ɹ�
    // R = -3  ������Ʒʧ��
    // ������Ʒ�ɹ�
    // ɳ�л���Ϣ
    // Ӣ�۹һ�
    // ȡ�ر���
    // ȡ�ر���ɹ�
    // ȡ�ر���ʧ��
    // �������
    // �������
    // ��̯״̬
    // ��ʼ��̯
    // ֹͣ��̯
    // ��ѯ��̯
    // ɾ����̯��Ʒ
    // �û��������Ϣ
    // �û���̯��Ʒ
    // �����̯��Ʒ
    // ����ɹ�
    // ����ʧ��
    // ��̯�ɹ�
    // ֹͣ��̯�ɹ�
    // ��̯ʧ��
    // ��̯״̬
    // ���а�
    // //////////////////////////////////////////////////////////////////////////////
    // �ٻ�Ӣ��
    // Ӣ���˳�
    // ���˰�����Ʒ�ŵ�Ӣ�۰���
    // Ӣ�۰�����Ʒ�ŵ����˰���
    // Ӣ�۴�װ��
    // Ӣ����װ��
    // Ӣ�۴�װ��������
    // Ӣ����װ��������
    // ���˴�װ����Ӣ�۰���
    // ������װ����Ӣ�۰���
    // Ӣ�۳�ҩ
    // ����//Ident: 1105 Recog: 260806992 Param: 0 Tag: 32 Series: 0   Recog= ��������   Param=X  Tag=Y
    // Ӣ������Ʒ
    // �ϻ�
    // BLUE_READ_656 = 656;
    // BLUE_READ_657 = 657; //Ident: 657 Recog: 759418336 Param: 0 Tag: 32 Series: 0
    // ���˰�����Ʒ�ŵ�Ӣ�۰����ɹ�
    // ���˰�����Ʒ�ŵ�Ӣ�۰���ʧ��
    // Ӣ�۰�����Ʒ�ŵ����˰����ɹ�
    // Ӣ�۰�����Ʒ�ŵ����˰���ʧ��
    // Ӣ�۴�װ��������  �ɹ�
    // Ӣ�۴�װ�������� ʧ��
    // Ӣ����װ��������   �ɹ�
    // Ӣ����װ��������  ʧ��
    // ���˴�װ����Ӣ�۰���   �ɹ�
    // ���˴�װ����Ӣ�۰��� ʧ��
    // ������װ����Ӣ�۰���    �ɹ�
    // ������װ����Ӣ�۰���  ʧ��
    // Ӣ�۰�������
    // ��ȡӢ�� TMessageBodyWL ����Ӣ���˳�Ч��
    // ��ȡӢ�� TMessageBodyWL ����Ӣ�۵�½Ч��
    // BLUE_READ_898 = 5165; //��ȡӢ���ҳ�  10001(��00.00%)
    // BLUE_READ_899 = 5166; //��ȡӢ����Ϣ
    // ��ȡӢ��Abil
    // Ӣ��SUBABILITY
    // ��ȡӢ�۰���     Tag:������Ʒ���� 2 Series: ����������10
    // ��ȡӢ������װ��
    // ��ȡӢ��ħ��
    // Ӣ�� Ident: 905 Recog: 738569296 Param: 0 Tag: 0 Series: 1   AddItem
    // Ӣ�� Ident: 906 Recog: 738569296 Param: 0 Tag: 0 Series: 1   delItem
    // Ӣ�۴�װ��OK Ident: 907 Recog: 742933632 Param: 0 Tag: 0 Series: 0
    // Ӣ�۴�װ��FAIL
    // Ӣ����װ��OK
    // Ӣ����װ��FAIL
    // Ӣ�۳�ҩOK
    // Ӣ�۳�ҩFAIL
    // Ӣ������ħ��
    // Ӣ��ɾ��ħ��
    // Ӣ��ŭֵ�ı� Ident: 916 Recog: 5 Param: 2 Tag: 102 Series: 0
    // Ӣ�۵�½OK
    // Ӣ���˳�OK
    // Ӣ����Ʒ�־øı�
    // Ӣ������ƷOK
    // Ӣ������ƷFAIL
    // Ӣ������
    // Ӣ�ۻ�ȡ����
    // Ӣ��ħ������
    // �������֮��
    // �������֮�� �ɹ�
    // �������֮��  ʧ��
    // Ӣ���ػ�
    // ע��������Ϣ
    // ��ʼ����
    // ��ʼ����
    // ��ʼ����
    // ��ʼ����
    // ����
    // ��ѯӢ�۰���
    // ��ȡӢ�� TMessageBodyWL ����Ӣ���˳�Ч��
    // ��ȡӢ�� TMessageBodyWL ����Ӣ�۵�½Ч��
    // ����
    // //////////////////////////////////////////////////////////////////////////////
    // MAXBAGITEM = 46; //�û������������
    // ԭ��54;
    // //////////////////////////////////////////////////////////////////////////////
    public enum TNpcType
    {
        n_Norm,
        n_Merchant
    } // end TNpcType

    public enum TObjType
    {
        t_None,
        t_Actor,
        t_Item,
        t_Event,
        t_Gate,
        t_Switch,
        t_MapEvent,
        t_Door,
        t_Roon,
        t_MapMagicEvent
    } // end TObjType

    public enum TClientAction
    {
        cHit,
        cMagHit,
        crun,
        cWalk,
        cDigUp,
        cTurn
    } // end TClientAction

    public enum TGender
    {
        gMan,
        gWoMan
    } // end TGender

    public enum TJob
    {
        jWarr,
        jWizard,
        jTaos
    } // end TJob

    public enum TMonStatus
    {
        s_KillHuman,
        s_UnderFire,
        s_Die,
        s_MonGen
    } // end TMonStatus

    public enum TMsgColor
    {
        c_Red,
        c_Green,
        c_Blue,
        c_White
    } // end TMsgColor

    public enum TMsgType
    {
        t_Notice,
        t_Hint,
        t_System,
        t_Say,
        t_Mon,
        t_GM,
        t_Cust,
        t_Castle
    } // end TMsgType

    public enum TVarType
    {
        vNone,
        vInteger,
        vString
    } // end TVarType

    public enum TVarAttr
    {
        aNone,
        aFixStr,
        aDynamic,
        aConst
    } // end TVarAttr

    public enum TOpenBoxStatus
    {
        b_None,
        b_ShowBox,
        b_OpenBox,
        b_BoxIndex,
        b_ShowItem,
        b_GiveItem
    } // end TOpenBoxStatus

    public enum TObjectType
    {
        ty_None,
        ty_Object,
        ty_VarName,
        ty_Human,
        ty_MonGen,
        ty_Hero,
        ty_Master
    } // end TObjectType

    public enum TNewStatus
    {
        sNone,
        sBlind,
        sConfusion
    } // end TNewStatus

    // ʧ�� ���� ״̬
    public enum TSockData
    {
        d_LoadHumData,
        d_SaveHumData,
        d_LoadHeroData,
        d_SaveHeroData,
        d_LoadRankingData,
        d_SaveData
    } // end TSockData

    public enum THeroDataType
    {
        l_Create,
        l_Delete,
        l_Load,
        l_Save
    } // end THeroDataType

    public enum TChangeType
    {
        t_Gold,
        t_GameGold,
        t_GamePoint,
        t_GameDiamond
    } // end TChangeType

    public delegate void TOpenEx();

    public enum TItemType
    {
        t_UseItem,
        t_BagItem,
        t_StorageItem,
        t_BigStorageItem,
        t_SellOffItem
    } // end TItemType
}