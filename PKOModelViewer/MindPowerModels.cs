using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Mindpower
{
    public class StructReader
    {
        public static T ReadStruct<T>(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }
        public static T ReadStructFromArray<T>(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }

        public static T[] ReadStructArray<T>(BinaryReader reader, int size)
        {
            T[] theStructures = new T[size];

            for (int i = 0; i < size; i++)
            {
                theStructures[i] = ReadStruct<T>(reader);
            }

            return theStructures;
        }
        public static T[] ReadStructArray<T>(BinaryReader reader, uint size)
        {
            T[] theStructures = new T[size];

            for (uint i = 0; i < size; i++)
            {
                theStructures[i] = ReadStruct<T>(reader);
            }

            return theStructures;
        }
        public static T[] ReadStructArrayFromBytes<T>(byte[] bytes, uint size)
        {
            T[] theStructures = new T[size];

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            

            for (uint i = 0; i < size; i++)
            {
                theStructures[i] = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject() + Marshal.SizeOf(typeof(T)), typeof(T));
            }

            handle.Free();
            return theStructures;
        }
    }

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct D3DXMATRIX 
    { 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        /* this+0x0 */
        public float[] m; 
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct _D3DVECTOR 
    {
        /* this+0x0 */
        public float x;
        /* this+0x4 */
        public float y;
        /* this+0x8 */
        public float z; 
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct D3DXVECTOR2 
    { 
	    /* this+0x0 */ 
        public float x;
        /* this+0x4 */
        public float y; 
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct D3DXVECTOR3 
    {
        /* this+0x0 */
        public float x;
        /* this+0x4 */
        public float y;
        /* this+0x8 */
        public float z; 

        D3DXVECTOR3(float x,float y,float z){this.x=x;this.y=y;this.z=z;}
        static public D3DXVECTOR3 operator+(D3DXVECTOR3 a,D3DXVECTOR3 b){return new D3DXVECTOR3(a.x+b.x,a.y+b.y,a.z+b.z);}
        static public D3DXVECTOR3 operator/(D3DXVECTOR3 a,float b){return new D3DXVECTOR3(a.x/b,a.y/b,a.z/b);}
        static public D3DXVECTOR3 operator*(D3DXVECTOR3 a, D3DXMATRIX b) 
        {
            float x = a.x * b.m[0] + a.y * b.m[4] + a.z * b.m[8] + b.m[12];
            float y = a.x * b.m[1] + a.y * b.m[5] + a.z * b.m[9] + b.m[13];
            float z = a.x * b.m[2] + a.y * b.m[6] + a.z * b.m[10] + b.m[14];

            return new D3DXVECTOR3(x, y, z);
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct D3DXVECTOR4 
    {
        /* this+0x0 */
        public float x;
        /* this+0x4 */
        public float y;
        /* this+0x8 */
        public float z;
        /* this+0xc */
        public float w; 
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct _D3DVERTEXELEMENT9 
    {
        /* this+0x0 */
        public ushort Stream;
        /* this+0x2 */
        public ushort Offset;
        /* this+0x4 */
        public byte Type;
        /* this+0x5 */
        public byte Method;
        /* this+0x6 */
        public byte Usage;
        /* this+0x7 */
        public byte UsageIndex; 
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct D3DXQUATERNION 
    {
        /* this+0x0 */
        public float x;
        /* this+0x4 */
        public float y;
        /* this+0x8 */
        public float z;
        /* this+0xc */
        public float w;
    };

    public enum _D3DPRIMITIVETYPE
    {
        D3DPT_POINTLIST = 0x1,
        D3DPT_LINELIST = 0x2,
        D3DPT_LINESTRIP = 0x3,
        D3DPT_TRIANGLELIST = 0x4,
        D3DPT_TRIANGLESTRIP = 0x5,
        D3DPT_TRIANGLEFAN = 0x6,
        D3DPT_FORCE_DWORD = 0x7fffffff,
    };

    public enum _D3DFORMAT
    {
        D3DFMT_UNKNOWN = 0x0,
        D3DFMT_R8G8B8 = 0x14,
        D3DFMT_A8R8G8B8 = 0x15,
        D3DFMT_X8R8G8B8 = 0x16,
        D3DFMT_R5G6B5 = 0x17,
        D3DFMT_X1R5G5B5 = 0x18,
        D3DFMT_A1R5G5B5 = 0x19,
        D3DFMT_A4R4G4B4 = 0x1a,
        D3DFMT_R3G3B2 = 0x1b,
        D3DFMT_A8 = 0x1c,
        D3DFMT_A8R3G3B2 = 0x1d,
        D3DFMT_X4R4G4B4 = 0x1e,
        D3DFMT_A2B10G10R10 = 0x1f,
        D3DFMT_G16R16 = 0x22,
        D3DFMT_A8P8 = 0x28,
        D3DFMT_P8 = 0x29,
        D3DFMT_L8 = 0x32,
        D3DFMT_A8L8 = 0x33,
        D3DFMT_A4L4 = 0x34,
        D3DFMT_V8U8 = 0x3c,
        D3DFMT_L6V5U5 = 0x3d,
        D3DFMT_X8L8V8U8 = 0x3e,
        D3DFMT_Q8W8V8U8 = 0x3f,
        D3DFMT_V16U16 = 0x40,
        D3DFMT_W11V11U10 = 0x41,
        D3DFMT_A2W10V10U10 = 0x43,
        D3DFMT_UYVY = 0x59565955,
        D3DFMT_YUY2 = 0x32595559,
        D3DFMT_DXT1 = 0x31545844,
        D3DFMT_DXT2 = 0x32545844,
        D3DFMT_DXT3 = 0x33545844,
        D3DFMT_DXT4 = 0x34545844,
        D3DFMT_DXT5 = 0x35545844,
        D3DFMT_D16_LOCKABLE = 0x46,
        D3DFMT_D32 = 0x47,
        D3DFMT_D15S1 = 0x49,
        D3DFMT_D24S8 = 0x4b,
        D3DFMT_D16 = 0x50,
        D3DFMT_D24X8 = 0x4d,
        D3DFMT_D24X4S4 = 0x4f,
        D3DFMT_VERTEXDATA = 0x64,
        D3DFMT_INDEX16 = 0x65,
        D3DFMT_INDEX32 = 0x66,
        D3DFMT_FORCE_DWORD = 0x7fffffff,
    };

    public enum _D3DPOOL
    {
        D3DPOOL_DEFAULT = 0x0,
        D3DPOOL_MANAGED = 0x1,
        D3DPOOL_SYSTEMMEM = 0x2,
        D3DPOOL_SCRATCH = 0x3,
        D3DPOOL_FORCE_DWORD = 0x7fffffff,
    }; 

    public enum lwModelObjectLoadType
    {
    	MODELOBJECT_LOAD_RESET = 0,
    	MODELOBJECT_LOAD_MERGE = 1,
    	MODELOBJECT_LOAD_MERGE2 = 2
    };

    public enum lwTexInfoTypeEnum
    {
    	TEX_TYPE_FILE = 0,
    	TEX_TYPE_SIZE = 1,
    	TEX_TYPE_DATA = 2,
    	TEX_TYPE_INVALID = -1
    };

    public enum lwColorKeyTypeEnum
    {
    	COLORKEY_TYPE_NONE = 0,
    	COLORKEY_TYPE_COLOR = 1,
    	COLORKEY_TYPE_PIXEL = 2
    };

    public enum lwMtlTexInfoTransparencyTypeEnum
    {
    	MTLTEX_TRANSP_FILTER = 0,
    	MTLTEX_TRANSP_ADDITIVE = 1,
    	MTLTEX_TRANSP_ADDITIVE1 = 2,
    	MTLTEX_TRANSP_ADDITIVE2 = 3,
    	MTLTEX_TRANSP_ADDITIVE3 = 4,
    	MTLTEX_TRANSP_SUBTRACTIVE = 5,
    	MTLTEX_TRANSP_SUBTRACTIVE1 = 6,
    	MTLTEX_TRANSP_SUBTRACTIVE2 = 7,
    	MTLTEX_TRANSP_SUBTRACTIVE3 = 8
    };

    public enum lwBoneKeyInfoType
    {
    	BONE_KEY_TYPE_MAT43 = 1,
    	BONE_KEY_TYPE_MAT44 = 2,
    	BONE_KEY_TYPE_QUAT = 3,
    	BONE_KEY_TYPE_INVALID = -1
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwColorValue4b 
	{
        /* this+0x0 */
        public byte b;
        /* this+0x1 */
        public byte g;
        /* this+0x2 */
        public byte r;
        /* this+0x3 */
        public byte a; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwColorValue4f 
	{
        /* this+0x0 */
        public float r;
        /* this+0x4 */
        public float g;
        /* this+0x8 */
        public float b;
        /* this+0xc */
        public float a; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwRenderCtrlCreateInfo 
	{
        /* this+0x0 */
        public uint ctrl_id;
        /* this+0x4 */
        public uint decl_id;
        /* this+0x8 */
        public uint vs_id;
        /* this+0xc */
        public uint ps_id; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwStateCtrl 
	{
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        /* this+0x0 */
        public byte[] _state_seq; // MindPower::lwObjectStateEnum ??? 

		public void SetState(uint state, byte value)
        {
            this._state_seq[state] = value;
        }
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwMaterial 
	{
        /* this+0x0 */
        public lwColorValue4f dif;
        /* this+0x10 */
        public lwColorValue4f amb;
        /* this+0x20 */
        public lwColorValue4f spe;
        /* this+0x30 */
        public lwColorValue4f emi;
        /* this+0x40 */
        public float power; 
	}; 

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwRenderStateAtom 
	{
        /* this+0x0 */
        public uint state; // MindPower::lwRenderStateAtomType 
        /* this+0x4 */
        public uint value0;
        /* this+0x8 */
        public uint value1; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwRenderStateValue 
	{
        /* this+0x0 */
        public uint state;
        /* this+0x4 */
        public uint value; 
	}; 

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwRenderStateSetTemplate28
	{ 
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        /* this+0x0 */
        public lwRenderStateValue[] rsv_seq; 
	}; 

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwTexInfo 
	{
        /* this+0x0 */
        public uint stage;
        /* this+0x4 */
        public uint level;
        /* this+0x8 */
        public uint usage;
        /* this+0xc */
        [MarshalAs(UnmanagedType.U4)]
        public _D3DFORMAT format;
        /* this+0x10 */
        [MarshalAs(UnmanagedType.U4)]
        public _D3DPOOL pool;
        /* this+0x14 */
        public uint byte_alignment_flag;
        /* this+0x18 */
        [MarshalAs(UnmanagedType.U4)]
        public lwTexInfoTypeEnum type;
        /* this+0x1c */
        public uint width;
        /* this+0x20 */
        public uint height;
        /* this+0x24 */
        [MarshalAs(UnmanagedType.U4)]
        public lwColorKeyTypeEnum colorkey_type;
        /* this+0x28 */
        public lwColorValue4b colorkey; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /* this+0x2c */
        public char[] file_name; 
        /* this+0x6c */
        public uint data_pointer; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
        /* this+0x70 */
        public lwRenderStateAtom[] tss_set; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwTexInfo_0000 
	{
        /* this+0x0 */
        public uint stage;
        /* this+0x4 */
        [MarshalAs(UnmanagedType.U4)]
        public lwColorKeyTypeEnum colorkey_type;
        /* this+0x8 */
        public lwColorValue4b colorkey;
        /* this+0xc */
        [MarshalAs(UnmanagedType.U4)]
        public _D3DFORMAT format; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /* this+0x10 */
        public char[] file_name;
        /* this+0x50 */
        public lwRenderStateSetTemplate28 tss_set; 
	}; 

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwTexInfo_0001 
	{
        /* this+0x0 */
        public uint stage;
        /* this+0x4 */
        public uint level;
        /* this+0x8 */
        public uint usage;
        /* this+0xc */
        [MarshalAs(UnmanagedType.U4)]
        public _D3DFORMAT format;
        /* this+0x10 */
        [MarshalAs(UnmanagedType.U4)]
        public _D3DPOOL pool;
        /* this+0x14 */
        public uint byte_alignment_flag;
        /* this+0x18 */
        [MarshalAs(UnmanagedType.U4)]
        public lwTexInfoTypeEnum type;
        /* this+0x1c */
        public uint width;
        /* this+0x20 */
        public uint height;
        /* this+0x24 */
        [MarshalAs(UnmanagedType.U4)]
        public lwColorKeyTypeEnum colorkey_type;
        /* this+0x28 */
        public lwColorValue4b colorkey; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /* this+0x2c */
        public char[] file_name; 
        /* this+0x6c */
        public uint data_pointer;
        /* this+0x70 */
        public lwRenderStateSetTemplate28 tss_set; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwMtlTexInfo 
	{
        /* this+0x0 */
        public float opacity;
        /* this+0x4 */
        [MarshalAs(UnmanagedType.U4)]
        public lwMtlTexInfoTransparencyTypeEnum transp_type; // MindPower::lwMtlTexInfoTransparencyTypeEnum 
        /* this+0x8 */
        public lwMaterial mtl; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
        /* this+0x4c */
        public lwRenderStateAtom[] rs_set; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=4)]
        /* this+0xac */
        public lwTexInfo[] tex_seq; 
	}; 

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwBlendInfo 
	{ 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=4)]
        /* this+0x0 */
        public byte[] index;  
		/* this+0x0 */ 
        //uint indexd; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=4)]
        /* this+0x4 */
        public float[] weight; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwSubsetInfo 
	{
        /* this+0x0 */
        public uint primitive_num;
        /* this+0x4 */
        public uint start_index;
        /* this+0x8 */
        public uint vertex_num;
        /* this+0xc */
        public uint min_index; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwMeshInfo 
	{ 
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct lwMeshInfoHeader 
		{
            /* this+0x0 */
            public uint fvf;
            /* this+0x4 */
            [MarshalAs(UnmanagedType.U4)]
            public _D3DPRIMITIVETYPE pt_type;
            /* this+0x8 */
            public uint vertex_num;
            /* this+0xc */
            public uint index_num;
            /* this+0x10 */
            public uint subset_num;
            /* this+0x14 */
            public uint bone_index_num;
            /* this+0x18 */
            public uint bone_infl_factor;
            /* this+0x1c */
            public uint vertex_element_num; 
            [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
            /* this+0x20 */
            public lwRenderStateAtom[] rs_set; 
		} ;
        /* this+0x0 */
        public lwMeshInfoHeader header; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x80 */
        public D3DXVECTOR3[] vertex_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x84 */
        public D3DXVECTOR3[] normal_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x88 */
        public D3DXVECTOR2[] texcoord0_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x8c */
        public D3DXVECTOR2[] texcoord1_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x90 */
        public D3DXVECTOR2[] texcoord2_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x94 */
        public D3DXVECTOR2[] texcoord3_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x98 */
        public uint[] vercol_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x9c */
        public uint[] index_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa0 */
        public uint[] bone_index_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa4 */
        public lwBlendInfo[] blend_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa8 */
        public lwSubsetInfo[] subset_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xac */
        public _D3DVERTEXELEMENT9[] vertex_element_seq; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwMeshInfo_0000 
	{ 
	    [StructLayout(LayoutKind.Sequential,Pack=1)]
        /* this+0x0 */
        public struct lwMeshInfoHeader 
		{
            /* this+0x0 */
            public uint fvf;
            /* this+0x4 */
            [MarshalAs(UnmanagedType.U4)]
            public _D3DPRIMITIVETYPE pt_type;
            /* this+0x8 */
            public uint vertex_num;
            /* this+0xc */
            public uint index_num;
            /* this+0x10 */
            public uint subset_num;
            /* this+0x14 */
            public uint bone_index_num;
            /* this+0x18 */
            public lwRenderStateSetTemplate28 rs_set; 
		};
        /* this+0x0 */
        public lwMeshInfoHeader header; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x98 */
        public D3DXVECTOR3[] vertex_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x9c */
        public D3DXVECTOR3[] normal_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa0 */
        public D3DXVECTOR2[] texcoord0_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa4 */
        public D3DXVECTOR2[] texcoord1_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xa8 */
        public D3DXVECTOR2[] texcoord2_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xac */
        public D3DXVECTOR2[] texcoord3_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xb0 */
        public uint[] vercol_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xb4 */
        public uint[] index_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xb8 */
        public lwBlendInfo[] blend_seq; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=16)]
        /* this+0xbc */
        public lwSubsetInfo[] subset_seq; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=25)]
        /* this+0x1bc */
        public byte[] bone_index_seq; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwMeshInfo_0003 
	{ 
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct lwMeshInfoHeader 
		{
            /* this+0x0 */
            public uint fvf;
            /* this+0x4 */
            [MarshalAs(UnmanagedType.U4)]
            public _D3DPRIMITIVETYPE pt_type;
            /* this+0x8 */
            public uint vertex_num;
            /* this+0xc */
            public uint index_num;
            /* this+0x10 */
            public uint subset_num;
            /* this+0x14 */
            public uint bone_index_num; 
            [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
            /* this+0x18 */
            public lwRenderStateAtom[] rs_set; 
		};
        /* this+0x0 */
        public lwMeshInfoHeader header; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x78 */
        public D3DXVECTOR3[] vertex_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x7c */
        public D3DXVECTOR3[] normal_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x80 */
        public D3DXVECTOR2[] texcoord0_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x84 */
        public D3DXVECTOR2[] texcoord1_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x88 */
        public D3DXVECTOR2[] texcoord2_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x8c */
        public D3DXVECTOR2[] texcoord3_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x90 */
        public uint[] vercol_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x94 */
        public uint[] index_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x98 */
        public lwBlendInfo[] blend_seq; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=16)]
        /* this+0x9c */
        public lwSubsetInfo[] subset_seq; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=25)]
        /* this+0x19c */
        public byte[] bone_index_seq; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwHelperDummyInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public D3DXMATRIX mat;
        /* this+0x44 */
        public D3DXMATRIX mat_local;
        /* this+0x84 */
        public uint parent_type;
        /* this+0x88 */
        public uint parent_id; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwHelperDummyInfo_1000 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public D3DXMATRIX mat; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwBox 
	{
        /* this+0x0 */
        public D3DXVECTOR3 c;
        /* this+0xc */
        public D3DXVECTOR3 r; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwBox_1001 
	{
        /* this+0x0 */
        public D3DXVECTOR3 p;
        /* this+0xc */
        public D3DXVECTOR3 s; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwHelperBoxInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public uint type;
        /* this+0x8 */
        public uint state;
        /* this+0xc */
        public lwBox box;
        /* this+0x24 */
        public D3DXMATRIX mat; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=32)]
        /* this+0x64 */
        public char[] name; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class _lwPlane 
	{
        /* this+0x0 */
        public float a;
        /* this+0x4 */
        public float b;
        /* this+0x8 */
        public float c;
        /* this+0xc */
        public float d; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwHelperMeshFaceInfo 
	{ 
	    [MarshalAs(UnmanagedType.ByValArray,SizeConst=3)]
        /* this+0x0 */
        public uint[] vertex; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=3)]
        /* this+0xc */
        public uint[] adj_face;
        /* this+0x18 */
        public _lwPlane plane;
        /* this+0x28 */
        public D3DXVECTOR3 center; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwHelperMeshInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public uint type; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=32)]
        /* this+0x8 */
        public char[] name;
        /* this+0x28 */
        public uint state;
        /* this+0x2c */
        public uint sub_type;
        /* this+0x30 */
        public D3DXMATRIX mat;
        /* this+0x70 */
        public lwBox box; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x88 */
        public D3DXVECTOR3[] vertex_seq; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x8c */
        public lwHelperMeshFaceInfo[] face_seq;
        /* this+0x90 */
        public uint vertex_num;
        /* this+0x94 */
        public uint face_num; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwBoundingBoxInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public lwBox box;
        /* this+0x1c */
        public D3DXMATRIX mat; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwSphere 
	{
        /* this+0x0 */
        public D3DXVECTOR3 c;
        /* this+0xc */
        public float r; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwBoundingSphereInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public lwSphere sphere;
        /* this+0x14 */
        public D3DXMATRIX mat; 
	};

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lwHelperInfo
    {
        /* this+0x4 */
        public uint type; // MindPower::lwHelperInfoType 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x8 */
        public lwHelperDummyInfo[] dummy_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xc */
        public lwHelperBoxInfo[] box_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x10 */
        public lwHelperMeshInfo[] mesh_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x14 */
        public lwBoundingBoxInfo[] bbox_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x18 */
        public lwBoundingSphereInfo[] bsphere_seq;
        /* this+0x1c */
        public uint dummy_num;
        /* this+0x20 */
        public uint box_num;
        /* this+0x24 */
        public uint mesh_num;
        /* this+0x28 */
        public uint bbox_num;
        /* this+0x2c */
        public uint bsphere_num;

        int _LoadHelperDummyInfo(BinaryReader fp, uint version)
        {
            if (version >= 0x1001)
            {
                this.dummy_num = fp.ReadUInt32();
                this.dummy_seq = StructReader.ReadStructArray<lwHelperDummyInfo>(fp, this.dummy_num);
            }
            else if (version <= 0x1000)
            {
                this.dummy_num = fp.ReadUInt32();
                lwHelperDummyInfo_1000[] old_s = StructReader.ReadStructArray<lwHelperDummyInfo_1000>(fp, this.dummy_num);
                //fread(old_s, sizeof(lwHelperDummyInfo_1000), this.dummy_num, fp);
                this.dummy_seq = new lwHelperDummyInfo[this.dummy_num];
                for (uint i = 0; i < this.dummy_num; i++)
                {
                    this.dummy_seq[i].id = old_s[i].id;
                    this.dummy_seq[i].mat = old_s[i].mat;
                    this.dummy_seq[i].parent_type = 0;
                    this.dummy_seq[i].parent_id = 0;
                };
            };
            return 0;
        }
        int _LoadHelperBoxInfo(BinaryReader fp, uint version)
        {
            this.box_num = fp.ReadUInt32();
            this.box_seq = StructReader.ReadStructArray<lwHelperBoxInfo>(fp, this.box_num);
            if (version <= 0x1001)
            {
                lwBox_1001 old_b = new lwBox_1001();
                for (uint i = 0; i < this.box_num; i++)
                {
                    lwBox b = this.box_seq[i].box;
                    old_b.p = b.c;
                    old_b.s = b.r;
                    b.r = old_b.s / 2;
                    b.c = old_b.p + b.r;
                };
            };
            return 0;
        }
        int _LoadHelperMeshInfo(BinaryReader fp, uint version)
        {
            this.mesh_num = fp.ReadUInt32();
            this.mesh_seq = new lwHelperMeshInfo[this.mesh_num];
            //fread(&(this.mesh_num), sizeof(uint), 1, fp);
            //this.mesh_seq = new lwHelperMeshInfo[this.mesh_num];
            for (uint i = 0; i < this.mesh_num; i++)
            {
                this.mesh_seq[i] = new lwHelperMeshInfo();
                lwHelperMeshInfo info = this.mesh_seq[i];
                info.id = fp.ReadUInt32();
                info.type = fp.ReadUInt32();
                info.sub_type = fp.ReadUInt32();
                info.name = StructReader.ReadStructArray<char>(fp, 20);
                info.state = fp.ReadUInt32();

                uint a = fp.ReadUInt32(),b= fp.ReadUInt32(),c= fp.ReadUInt32();

                info.mat = StructReader.ReadStruct<D3DXMATRIX>(fp);
                info.box = StructReader.ReadStruct<lwBox>(fp);
                info.vertex_num = fp.ReadUInt32();
                info.face_num = fp.ReadUInt32();
                info.vertex_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, info.vertex_num);
                info.face_seq = StructReader.ReadStructArray<lwHelperMeshFaceInfo>(fp, info.face_num);
            };
            if (version <= 0x1001)
            {
                lwBox_1001 old_b = new lwBox_1001();
                for (uint i = 0; i < this.mesh_num; i++)
                {
                    lwBox b = this.mesh_seq[i].box;
                    old_b.p = b.c;
                    old_b.s = b.r;
                    b.r = old_b.s / 2;
                    b.c = old_b.p + b.r;
                };
            };
            return 0;
        }
        int _LoadBoundingBoxInfo(BinaryReader fp, uint version)
        {
            this.bbox_num = fp.ReadUInt32();
            this.bbox_seq = StructReader.ReadStructArray<lwBoundingBoxInfo>(fp, this.bbox_num);
            if (version <= 0x1001)
            {
                lwBox_1001 old_b = new lwBox_1001();
                for (uint i = 0; i < this.bbox_num; i++)
                {
                    lwBox b = this.bbox_seq[i].box;
                    old_b.p = b.c;
                    old_b.s = b.r;
                    b.r = old_b.s / 2;
                    b.c = old_b.p + b.r;
                };
            };
            return 0;
        }
        int _LoadBoundingSphereInfo(BinaryReader fp, uint version)
        {
            this.bsphere_num = fp.ReadUInt32();
            this.bsphere_seq = StructReader.ReadStructArray<lwBoundingSphereInfo>(fp, this.bsphere_num);
            return 0;
        }
        public int Load(BinaryReader fp, uint version)
        {
            if (version == 0)
            {
                uint old_version;
                old_version = fp.ReadUInt32();// No messing around with 'version' O_o
            };
            this.type = fp.ReadUInt32();
            if ((this.type & 0x1) != 0)
                this._LoadHelperDummyInfo(fp, version);
            if ((this.type & 0x2) != 0)
                this._LoadHelperBoxInfo(fp, version);
            if ((this.type & 0x4) != 0)
                this._LoadHelperMeshInfo(fp, version);
            if ((this.type & 0x10) != 0)
                this._LoadBoundingBoxInfo(fp, version);
            if ((this.type & 0x20) != 0)
                this._LoadBoundingSphereInfo(fp, version);
            return 0;
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwBoneBaseInfo 
	{ 
	    [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /* this+0x0 */
        public char[] name;
        /* this+0x40 */
        public uint id;
        /* this+0x44 */
        public uint parent_id; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwBoneDummyInfo 
	{
        /* this+0x0 */
        public uint id;
        /* this+0x4 */
        public uint parent_bone_id;
        /* this+0x8 */
        public D3DXMATRIX mat; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwMatrix33 
	{ 
	    [MarshalAs(UnmanagedType.ByValArray,SizeConst=9)]
        /* this+0x0 */
        public float[] m; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwMatrix43 
	{ 
	    [MarshalAs(UnmanagedType.ByValArray,SizeConst=12)]
        /* this+0x0 */
        public float[] m; 
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwBoneKeyInfo 
	{ 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x0 */
        public lwMatrix43[] mat43_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public D3DXMATRIX[] mat44_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x8 */
        public D3DXVECTOR3[] pos_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0xc */
        public D3DXQUATERNION[] quat_seq; 
	};

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class lwAnimDataBone
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        /* this+0x4 */
        public struct lwBoneInfoHeader
        {
            /* this+0x0 */
            public uint bone_num;
            /* this+0x4 */
            public uint frame_num;
            /* this+0x8 */
            public uint dummy_num;
            /* this+0xc */
            public lwBoneKeyInfoType key_type; // MindPower::lwBoneKeyInfoType 
        };
        /* this+0x4 */
        public lwBoneInfoHeader _header;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x14 */
        public lwBoneBaseInfo[] _base_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x18 */
        public lwBoneDummyInfo[] _dummy_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x1c */
        public lwBoneKeyInfo[] _key_seq;
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x20 */
        public D3DXMATRIX[] _invmat_seq;

        public int Load(BinaryReader fp, uint version)
        {
            if (version == 0)
            {
                uint old_version = fp.ReadUInt32();
                int x = 0;
            };
            if (this._base_seq != null)
            {
                return -1;
            };
            this._header = StructReader.ReadStruct<lwAnimDataBone.lwBoneInfoHeader>(fp);
            this._base_seq = StructReader.ReadStructArray<lwBoneBaseInfo>(fp, this._header.bone_num);
            this._key_seq = new lwBoneKeyInfo[this._header.bone_num];
            this._invmat_seq = StructReader.ReadStructArray<D3DXMATRIX>(fp, this._header.bone_num);
            this._dummy_seq = StructReader.ReadStructArray<lwBoneDummyInfo>(fp, this._header.dummy_num);

            if (this._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_MAT43)
            {
                for (uint i = 0; i < this._header.bone_num; i++)
                {
                    this._key_seq[i] = new lwBoneKeyInfo();
                    lwBoneKeyInfo key = this._key_seq[i];
                    key.mat43_seq = StructReader.ReadStructArray<lwMatrix43>(fp, this._header.frame_num);
                };
            }
            else if (this._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_MAT44)
            {
                for (uint i = 0; i < this._header.bone_num; i++)
                {
                    this._key_seq[i] = new lwBoneKeyInfo();
                    lwBoneKeyInfo key = this._key_seq[i];
                    key.mat44_seq = StructReader.ReadStructArray<D3DXMATRIX>(fp, this._header.frame_num);
                };
            }
            else if (this._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_QUAT)
            {
                if (version >= 0x1003)
                {
                    for (uint i = 0; i < this._header.bone_num; i++)
                    {
                        this._key_seq[i] = new lwBoneKeyInfo();
                        lwBoneKeyInfo key = this._key_seq[i];
                        key.pos_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, this._header.frame_num);
                        key.quat_seq = StructReader.ReadStructArray<D3DXQUATERNION>(fp, this._header.frame_num);
                    };
                }
                else
                {
                    for (uint i = 0; i < this._header.bone_num; i++)
                    {
                        this._key_seq[i] = new lwBoneKeyInfo();
                        lwBoneKeyInfo key = this._key_seq[i];
                        uint pos_num = this._base_seq[i].parent_id == 0xffffffff ? this._header.frame_num : 1;
                        key.pos_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, pos_num);
                        if (pos_num == 1)
                        {
                            for (uint j = 1; j < this._header.frame_num; j++)
                            {
                                key.pos_seq[i] = key.pos_seq[0];
                            };
                        };
                        key.quat_seq = StructReader.ReadStructArray<D3DXQUATERNION>(fp, this._header.frame_num);
                    };
                };
            };
            return 0;
        }

        public int Load(string file)
        {
            int ret = -1;
            if (!File.Exists(file))
                return -1;
            FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read);
            BinaryReader fp = new BinaryReader(fs);

            uint version = fp.ReadUInt32();
            if (version < 0x1000)
            {
                version = 0;
                System.Windows.Forms.MessageBox.Show("old animation file: " + file + ", need re-export it", "warning");

                fp.Close();
                fs.Close();
                return ret;
            };
            if (this.Load(fp, version) >= 0)
            { // Overloaded version
                ret = 0;
            }

            fp.Close();
            fs.Close();
            return ret;
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwAnimDataMatrix 
	{ 
	    [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public lwMatrix43[] _mat_seq;
        /* this+0x8 */
        public uint _frame_num;

        public int Load(BinaryReader fp, uint version)
        {
            this._frame_num = fp.ReadUInt32();
            this._mat_seq = StructReader.ReadStructArray<lwMatrix43>(fp, this._frame_num);
            return 0;
        }

        public int Load(BinaryReader fp, uint version, uint frames)
        {
            this._frame_num = fp.ReadUInt32();
            if (frames < _frame_num)
                _frame_num = frames;
            this._mat_seq = StructReader.ReadStructArray<lwMatrix43>(fp, this._frame_num);
            return 0;
        }
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwKeyFloat 
	{
        /* this+0x0 */
        public uint key;
        /* this+0x4 */
        public uint slerp_type;
        /* this+0x8 */
        public float data; 
	};

    public interface lwIAnimKeySetFloat
	{
		uint SetKeySequence(lwKeyFloat[] seq,uint num);
	};
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwAnimKeySetFloat : lwIAnimKeySetFloat
	{ 
	    [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public lwKeyFloat[] _data_seq;
        /* this+0x8 */
        public uint _data_num;
        /* this+0xc */
        public uint _data_capacity;

        public uint SetKeySequence(lwKeyFloat[] seq, uint num)
        {
            _data_seq = seq;
            _data_num = num;
            _data_capacity = num;
            return 0;
        }
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwAnimDataMtlOpacity 
	{ 
	    [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x4 */
        public lwIAnimKeySetFloat _aks_ctrl;

        public int Load(BinaryReader fp, uint version)
        {
            int ret = -1;
            uint num = fp.ReadUInt32();
            lwKeyFloat[] seq = StructReader.ReadStructArray<lwKeyFloat>(fp, num);
            this._aks_ctrl = new lwAnimKeySetFloat();
            if (this._aks_ctrl.SetKeySequence(seq, num) >= 0)
            {
                ret = 0;
            };
            return ret;
        }
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwAnimDataTexUV 
	{ 
	    [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public D3DXMATRIX[] _mat_seq;
        /* this+0x8 */
        public uint _frame_num;

        public int Load(BinaryReader fp, uint version)
        {
            this._frame_num = fp.ReadUInt32();
            this._mat_seq = StructReader.ReadStructArray<D3DXMATRIX>(fp, this._frame_num);
            return 0;
        }
	};

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class lwAnimDataTexImg
    {
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public lwTexInfo[] _data_seq;
        /* this+0x8 */
        public uint _data_num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        /* this+0xc */
        public char[] _tex_path;

        public int Load(BinaryReader fp, uint version)
        {
            int ret = 0;
            if (version == 0)
            {
                System.Windows.Forms.MessageBox.Show("old version file, need re-export it", "warning");
                ret = -1;
            }
            else
            {
                this._data_num = fp.ReadUInt32();
                this._data_seq = StructReader.ReadStructArray<lwTexInfo>(fp, this._data_num);
            };
            return ret;
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwAnimDataMtlOpacitySet
    {
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=16)]
        public lwAnimDataMtlOpacity[] mtl;
    }

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwAnimDataTexUVSet
    {
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        public lwAnimDataTexUV[] mtl;
    }

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwAnimDataTexImgSet
    {
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        public lwAnimDataTexImg[] mtl;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class lwAnimDataInfo
    {
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x4 */
        public lwAnimDataBone anim_bone;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x8 */
        public lwAnimDataMatrix anim_mat;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0xc */
        public lwAnimDataMtlOpacitySet anim_mtlopac;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x4c */
        public lwAnimDataTexUVSet anim_tex;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x14c */
        public lwAnimDataTexImgSet anim_img;

        public int Load(BinaryReader fp, uint version)
        {
            if (version == 0)
            {
                uint old_version = fp.ReadUInt32();
            };
            uint data_bone_size;
            uint data_mat_size;
            uint[] data_mtlopac_size=null;
            uint[] data_texuv_size;
            uint[] data_teximg_size;
            data_bone_size = fp.ReadUInt32();
            data_mat_size = fp.ReadUInt32();
            if (version >= 4101)
            {
                data_mtlopac_size = StructReader.ReadStructArray<uint>(fp, 16);
            };
            data_texuv_size = StructReader.ReadStructArray<uint>(fp, 16 * 4);
            data_teximg_size = StructReader.ReadStructArray<uint>(fp, 16 * 4);
            if (data_bone_size > 0)
            {
                this.anim_bone = new lwAnimDataBone();
                this.anim_bone.Load(fp, version);
            };
            if (data_mat_size > 0)
            {
                this.anim_mat = new lwAnimDataMatrix();
                //uint frames = (data_mat_size - 4) / (uint)Marshal.SizeOf(typeof(lwMatrix43));
                this.anim_mat.Load(fp, version);
            };
            if (version >= 0x1005)
            {
                for (uint i = 0; i < 16; i++)
                {
                    if (data_mtlopac_size[i] == 0)
                        continue;
                    if (this.anim_mtlopac.mtl == null)
                        this.anim_mtlopac.mtl = new lwAnimDataMtlOpacity[16];
                    this.anim_mtlopac.mtl[i] = new lwAnimDataMtlOpacity();
                    this.anim_mtlopac.mtl[i].Load(fp, version);
                };
            };
            for (uint i = 0; i < 16; i++)
            {
                for (uint j = 0; j < 4; j++)
                {
                    if (data_texuv_size[i * 4 + j] == 0)
                        continue;
                    if (this.anim_tex.mtl == null)
                        this.anim_tex.mtl = new lwAnimDataTexUV[64];
                    this.anim_tex.mtl[i * 4 + j] = new lwAnimDataTexUV();
                    this.anim_tex.mtl[i * 4 + j].Load(fp, version);
                };
            };
            for (uint i = 0; i < 16; i++)
            {
                for (uint j = 0; j < 4; j++)
                {
                    if (data_teximg_size[i * 4 + j] == 0)
                        continue;
                    if (this.anim_img.mtl == null)
                        this.anim_img.mtl = new lwAnimDataTexImg[64];
                    this.anim_img.mtl[i * 4 + j] = new lwAnimDataTexImg();
                    this.anim_img.mtl[i * 4 + j].Load(fp, version);
                };
            };
            return 0;
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwGeomObjInfo 
	{ 
	    [StructLayout(LayoutKind.Sequential,Pack=1)]
        /* this+0x4 */
        public struct lwGeomObjInfoHeader 
		{
            /* this+0x0 */
            public uint id;
            /* this+0x4 */
            public uint parent_id;
            /* this+0x8 */
            public lwModelObjectLoadType type;
            /* this+0xc */
            public D3DXMATRIX mat_local;
            /* this+0x4c */
            public lwRenderCtrlCreateInfo rcci;
            /* this+0x5c */
            public lwStateCtrl state_ctrl;
            /* this+0x64 */
            public uint mtl_size;
            /* this+0x68 */
            public uint mesh_size;
            /* this+0x6c */
            public uint helper_size;
            /* this+0x70 */
            public uint anim_size; 
		};
        /* this+0x4 */
        public lwGeomObjInfoHeader header;
        /* this+0x78 */
        public uint mtl_num; 
        [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x7c */
        public lwMtlTexInfo[] mtl_seq;
        /* this+0x80 */
        public lwMeshInfo mesh;
        /* this+0x130 */
        public lwHelperInfo helper_data;
        /* this+0x160 */
        public lwAnimDataInfo anim_data;

        public lwGeomObjInfo() { ;}

        public int Load(BinaryReader fp, uint version)
        {
            this.header = StructReader.ReadStruct<lwGeomObjInfo.lwGeomObjInfoHeader>(fp);
            this.header.state_ctrl.SetState(5, 0);
            this.header.state_ctrl.SetState(3, 1);
            if (this.header.mtl_size > 100000)
            {
                System.Windows.Forms.MessageBox.Show("iii", "error");
                return -1;
            };
            if (this.header.mtl_size > 0)
                lwLoadMtlTexInfo(ref this.mtl_seq, ref this.mtl_num, fp, version);
            if (this.header.mesh_size > 0)
                lwMeshInfo_Load(ref this.mesh, fp, version);
            if (this.header.helper_size > 0)
                this.helper_data.Load(fp, version);
            if (this.header.anim_size > 0)
            {
                this.anim_data = new lwAnimDataInfo();
                this.anim_data.Load(fp, version);
            }
            return 0;
        }
        public int Load(string file)
        {
            if (!File.Exists(file))
                return -1;
            FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read);
            BinaryReader fp = new BinaryReader(fs);

            uint version = fp.ReadUInt32();
            int ret = this.Load(fp, version);
            fp.Close();
            fs.Close();
            return ret;
        }

        int lwMtlTexInfo_Load(ref lwMtlTexInfo info, BinaryReader fp, uint version)
        {
            if (version >= 0x1000)
            {
                info.opacity = fp.ReadSingle();
                info.transp_type = (lwMtlTexInfoTransparencyTypeEnum)fp.ReadUInt32();
                info.mtl = StructReader.ReadStruct<lwMaterial>(fp);
                info.rs_set = StructReader.ReadStructArray<lwRenderStateAtom>(fp, 8);
                info.tex_seq = StructReader.ReadStructArray<lwTexInfo>(fp, 4);
            }
            else if (version == 2)
            {
                info.opacity = fp.ReadSingle();
                info.transp_type = (lwMtlTexInfoTransparencyTypeEnum)fp.ReadUInt32();
                info.mtl = StructReader.ReadStruct<lwMaterial>(fp);
                info.rs_set = StructReader.ReadStructArray<lwRenderStateAtom>(fp, 8);
                info.tex_seq = StructReader.ReadStructArray<lwTexInfo>(fp, 4);
            }
            else if (version == 1)
            {
                info.opacity = fp.ReadSingle();
                info.transp_type = (lwMtlTexInfoTransparencyTypeEnum)fp.ReadUInt32();
                info.mtl = StructReader.ReadStruct<lwMaterial>(fp);
                lwRenderStateSetTemplate28 rsm = StructReader.ReadStruct<lwRenderStateSetTemplate28>(fp);
                //fread(&rsm, sizeof(lwRenderStateSetTemplate<2,8>), 1, fp);
                lwTexInfo_0001[] tex_info = StructReader.ReadStructArray<lwTexInfo_0001>(fp, 4);
                info.tex_seq = new lwTexInfo[4];
                info.rs_set = new lwRenderStateAtom[8];
                //fread(&tex_info, sizeof(lwTexInfo_0001)*4, 1, fp);
                for (uint i = 0; i < 8; i++)
                {
                    lwRenderStateValue rsv = rsm.rsv_seq[i];
                    if (rsv.state == 0xffffffff)
                        break;
                    uint v;
                    if (rsv.state == 25)
                    {
                        v = 5;
                    }
                    else if (rsv.state == 24)
                    {
                        v = 129;
                    }
                    else
                    {
                        v = rsv.value;
                    };
                    info.rs_set[i].state = rsv.state;
                    info.rs_set[i].value0 = v;
                    info.rs_set[i].value1 = v;
                };
                for (uint i = 0; i < 4; i++)
                {
                    lwTexInfo_0001 p = tex_info[i];
                    if (p.stage == 0xffffffff)
                        break;
                    info.tex_seq[i] = new lwTexInfo();
                    lwTexInfo t = info.tex_seq[i];
                    t.level = p.level;
                    t.usage = p.usage;
                    t.pool = p.pool;
                    t.type = p.type;
                    t.width = p.width;
                    t.height = p.height;
                    t.stage = p.stage;
                    t.format = p.format;
                    t.colorkey = p.colorkey;
                    t.colorkey_type = p.colorkey_type;
                    t.byte_alignment_flag = p.byte_alignment_flag;
                    t.file_name = p.file_name;
                    for (uint j = 0; j < 8; j++)
                    {
                        lwRenderStateValue rsv = p.tss_set.rsv_seq[j];
                        if (rsv.state == 0xffffffff)
                            break;
                        t.tss_set[j].state = rsv.state;
                        t.tss_set[j].value0 = rsv.value;
                        t.tss_set[j].value1 = rsv.value;
                    };
                };
            }
            else if (version == 0)
            {
                info.mtl = StructReader.ReadStruct<lwMaterial>(fp);
                lwRenderStateSetTemplate28 rsm = StructReader.ReadStruct<lwRenderStateSetTemplate28>(fp);
                lwTexInfo_0000[] tex_info = StructReader.ReadStructArray<lwTexInfo_0000>(fp, 4);
                info.rs_set = new lwRenderStateAtom[8];
                info.tex_seq = new lwTexInfo[4];
                for (uint i = 0; i < 8; i++)
                {
                    lwRenderStateValue rsv = rsm.rsv_seq[i];
                    if (rsv.state == 0xffffffff)
                        break;
                    uint v;
                    if (rsv.state == 25)
                    {
                        v = 5;
                    }
                    else if (rsv.state == 24)
                    {
                        v = 129;
                    }
                    else
                    {
                        v = rsv.value;
                    };
                    info.rs_set[i].state = rsv.state;
                    info.rs_set[i].value0 = v;
                    info.rs_set[i].value1 = v;
                };
                for (uint i = 0; i < 4; i++)
                {
                    lwTexInfo_0000 p = tex_info[i];
                    if (p.stage == 0xffffffff)
                        break;
                    info.tex_seq[i] = new lwTexInfo();
                    lwTexInfo t = info.tex_seq[i];
                    t.level = 1;
                    t.usage = 0;
                    t.pool = (_D3DPOOL)0;
                    t.type = 0;
                    t.stage = p.stage;
                    t.format = p.format;
                    t.colorkey = p.colorkey;
                    t.colorkey_type = p.colorkey_type;
                    t.byte_alignment_flag = 0;
                    t.file_name = p.file_name;
                    for (uint j = 0; j < 8; j++)
                    {
                        lwRenderStateValue rsv = p.tss_set.rsv_seq[j];
                        if (rsv.state == 0xffffffff)
                            break;
                        t.tss_set[j].state = rsv.state;
                        t.tss_set[j].value0 = rsv.value;
                        t.tss_set[j].value1 = rsv.value;
                    };
                };
                if (info.tex_seq[0].format == (_D3DFORMAT)26)
                    info.tex_seq[0].format = (_D3DFORMAT)25;
            }
            else
            {
                //MessageBoxA(0, "invalid file version", "error", 0);
                System.Windows.Forms.MessageBox.Show("invalid file version", "error");
                return -1;
            };
            info.tex_seq[0].pool = (_D3DPOOL)1;
            info.tex_seq[0].level = 3;
            int transp_flag = 0;
            uint i2;
            for (i2 = 0; i2 < 8; i2++)
            {
                lwRenderStateAtom rsa = info.rs_set[i2];
                if (rsa.state == 0xffffffff)
                    break;
                if ((rsa.state == 20) && ((rsa.value0 == 2) || (rsa.value0 == 4)))
                    transp_flag = 1;
                if ((rsa.state == 137) && (rsa.value0 == 0))
                    transp_flag++;
            };
            if ((transp_flag == 1) && (i2 < 7))
            {
                info.rs_set[i2].value0 = 137;
                info.rs_set[i2].value1 = 0;
            }
            return 0;
        }
        int lwLoadMtlTexInfo(ref lwMtlTexInfo[] out_buf, ref uint out_num, BinaryReader fp, uint version)
        {
            if (version == 0)
            {
                version = fp.ReadUInt32();
            };
            uint num = fp.ReadUInt32();
            lwMtlTexInfo[] buf = new lwMtlTexInfo[num];
            for (uint i = 0; i < num; i++)
            {
                buf[i] = new lwMtlTexInfo();
                lwMtlTexInfo_Load(ref buf[i], fp, version);
            }
            out_buf = buf;
            out_num = num;
            return 0;
        }
        int lwMeshInfo_Load(ref lwMeshInfo info, BinaryReader fp, uint version)
        {
            if (version == 0)
            {
                version = fp.ReadUInt32();
            };
            if (version >= 0x1004)
            {
                info.header = StructReader.ReadStruct<lwMeshInfo.lwMeshInfoHeader>(fp);
            }
            else if (version >= 0x1003)
            {
                lwMeshInfo_0003.lwMeshInfoHeader header = StructReader.ReadStruct<lwMeshInfo_0003.lwMeshInfoHeader>(fp);
                info.header.fvf = header.fvf;
                info.header.pt_type = header.pt_type;
                info.header.vertex_num = header.vertex_num;
                info.header.index_num = header.index_num;
                info.header.subset_num = header.subset_num;
                info.header.bone_index_num = header.bone_index_num;
                info.header.bone_infl_factor = (uint)(info.header.bone_index_num > 0 ? 2 : 0);
                info.header.vertex_element_num = 0;
            }
            else if ((version >= 0x1000) || (version == 1))
            {
                lwMeshInfo_0003.lwMeshInfoHeader header = StructReader.ReadStruct<lwMeshInfo_0003.lwMeshInfoHeader>(fp);
                //fread(&header, sizeof(lwMeshInfo_0003::lwMeshInfoHeader), 1, fp);
                info.header.fvf = header.fvf;
                info.header.pt_type = header.pt_type;
                info.header.vertex_num = header.vertex_num;
                info.header.index_num = header.index_num;
                info.header.subset_num = header.subset_num;
                info.header.bone_index_num = header.bone_index_num;
                info.header.bone_infl_factor = (uint)(info.header.bone_index_num > 0 ? 2 : 0);
                info.header.vertex_element_num = 0;
            }
            else if (version == 0)
            {
                lwMeshInfo_0000.lwMeshInfoHeader header = StructReader.ReadStruct<lwMeshInfo_0000.lwMeshInfoHeader>(fp);
                //fread(&header, sizeof(lwMeshInfo_0000::lwMeshInfoHeader), 1, fp);
                info.header.fvf = header.fvf;
                info.header.pt_type = header.pt_type;
                info.header.vertex_num = header.vertex_num;
                info.header.index_num = header.index_num;
                info.header.subset_num = header.subset_num;
                info.header.bone_index_num = header.bone_index_num;
                info.header.rs_set = new lwRenderStateAtom[8];
                for (uint j = 0; j < 8; j++)
                {
                    lwRenderStateValue rsv = header.rs_set.rsv_seq[j];
                    if (rsv.state == 0xffffffff)
                        break;
                    uint v;
                    if (rsv.state == 147)
                    {
                        v = 2;
                    }
                    else
                    {
                        v = rsv.value;
                    };
                    info.header.rs_set[j].state = rsv.state;
                    info.header.rs_set[j].value0 = v;
                    info.header.rs_set[j].value1 = v;
                };
            }
            else
            {
                //MessageBoxA(0, "invalid version", "error", 0);
                System.Windows.Forms.MessageBox.Show("invalid version", "error");
            };
            if (version >= 0x1004)
            {
                if (info.header.vertex_element_num > 0)
                {
                    info.vertex_element_seq = StructReader.ReadStructArray<_D3DVERTEXELEMENT9>(fp, info.header.vertex_element_num);
                };
                if (info.header.vertex_num > 0)
                {
                    info.vertex_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x10) != 0)
                {
                    info.normal_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x100) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x200) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x300) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord2_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x400) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord2_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord3_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x40) != 0)
                {
                    info.vercol_seq = StructReader.ReadStructArray<uint>(fp, info.header.vertex_num);
                };
                if (info.header.bone_index_num > 0)
                {
                    info.blend_seq = StructReader.ReadStructArray<lwBlendInfo>(fp, info.header.vertex_num);
                    info.bone_index_seq = StructReader.ReadStructArray<uint>(fp, info.header.bone_index_num);
                };
                if (info.header.index_num > 0)
                {
                    info.index_seq = StructReader.ReadStructArray<uint>(fp, info.header.index_num);
                };
                if (info.header.subset_num > 0)
                {
                    info.subset_seq = StructReader.ReadStructArray<lwSubsetInfo>(fp, info.header.subset_num);
                };
            }
            else
            {
                info.subset_seq = StructReader.ReadStructArray<lwSubsetInfo>(fp, info.header.subset_num);
                info.vertex_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, info.header.vertex_num);
                if ((info.header.fvf & 0x10) != 0)
                {
                    info.normal_seq = StructReader.ReadStructArray<D3DXVECTOR3>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x100) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x200) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x300) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord2_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                }
                else if ((info.header.fvf & 0x400) != 0)
                {
                    info.texcoord0_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord1_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord2_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                    info.texcoord3_seq = StructReader.ReadStructArray<D3DXVECTOR2>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x40) != 0)
                {
                    info.vercol_seq = StructReader.ReadStructArray<uint>(fp, info.header.vertex_num);
                };
                if ((info.header.fvf & 0x1000) != 0)
                {
                    info.blend_seq = StructReader.ReadStructArray<lwBlendInfo>(fp, info.header.vertex_num);
                    byte[] byte_index_seq = StructReader.ReadStructArray<byte>(fp, info.header.bone_index_num);
                    info.bone_index_seq = new uint[info.header.bone_index_num];
                    for (uint i = 0; i < info.header.bone_index_num; i++)
                    {
                        info.bone_index_seq[i] = (uint)byte_index_seq[i];
                    };
                };
                if (info.header.index_num > 0)
                {
                    info.index_seq = StructReader.ReadStructArray<uint>(fp, info.header.index_num);
                };
            };
            return 0;
        }
	};

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class lwModelObjInfo
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct lwModelObjInfoHeader
        {
            /* this+0x0 */
            public uint type;
            /* this+0x4 */
            public uint addr;
            /* this+0x8 */
            public uint size;
        };

        /* this+0x4 */
        public uint geom_obj_num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        /* this+0x8 */
        public lwGeomObjInfo[] geom_obj_seq;
        /* this+0x88 */
        public lwHelperInfo helper_data;

        public int Load(string file)
        {
            if (!File.Exists(file))
                return -1;
            FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read);
            BinaryReader fp = new BinaryReader(fs);

            uint version = fp.ReadUInt32();
            uint obj_num = fp.ReadUInt32();
            lwModelObjInfoHeader[] header = StructReader.ReadStructArray<lwModelObjInfoHeader>(fp, obj_num);
            this.geom_obj_seq = new lwGeomObjInfo[32];
            this.geom_obj_num = 0;
            for (uint i = 0; i < obj_num; i++)
            {
                fs.Seek(header[i].addr, SeekOrigin.Begin);
                //fseek(fp, header[i].addr, 0);
                if (header[i].type == 1)
                {
                    this.geom_obj_seq[this.geom_obj_num] = new lwGeomObjInfo();
                    if (version == 0)
                    {
                        uint old_version = fp.ReadUInt32();
                    }
                    this.geom_obj_seq[this.geom_obj_num].Load(fp, version);
                    this.geom_obj_num++;
                }
                else if (header[i].type == 2)
                {
                    this.helper_data.Load(fp, version);
                };
            };
            fs.Close();
            fp.Close();
            return 0;
        }
    };

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct lwModelHeadInfo 
	{
        /* this+0x0 */
        public uint mask;
        /* this+0x4 */
        public uint version; 
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /* this+0x8 */
        public char[] decriptor; 
	};

    public interface lwITreeNode
	{	
		//int __thiscall EnumTree(uint __cdecl ,lwITreeNode*,void*);
		int EnumTree(TreeProcFreeNode a1,__find_info a2,uint a3);
		int InsertChild(lwITreeNode n1,lwITreeNode n2);
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct __find_info
	{
        [MarshalAs(UnmanagedType.LPStruct)]
        /*off:0000;siz:0004*/
        public lwITreeNode node;
        /*off:0004;siz:0004*/
        public uint handle;
	};

    public delegate uint TreeProcFreeNode(lwITreeNode node,byte[] data);

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public class lwTreeNode : lwITreeNode
	{ 
	    [MarshalAs(UnmanagedType.LPArray)]
        /* this+0x4 */
        public byte[] _data;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x8 */
        public lwITreeNode _parent; 
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0xc */
        public lwITreeNode _child; 
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x10 */
        public lwITreeNode _sibling;

        public void _SetRegisterID(lwModelNodeInfo id) { ;}
        public int EnumTree(TreeProcFreeNode arg1, __find_info arg2, uint arg3) { return 0; }
        public int InsertChild(lwITreeNode n1, lwITreeNode n2) { return 0;}
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct /*siz:88*/lwModelNodeHeadInfo
	{
        /*off:0000;siz:0004*/
        public uint handle;
        /*off:0004;siz:0004*/
        public uint type;
        /*off:0008;siz:0004*/
        public uint id;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=64)]
        /*off:0012;siz:0064*/
        public char[] descriptor;
        /*off:0076;siz:0004*/
        public uint parent_handle;
        /*off:0080;siz:0004*/
        public uint link_parent_id;
        /*off:0084;siz:0004*/
        public uint link_id;
	};

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct /*siz:100*/lwModelNodeInfo
	{

        /*off:0004;siz:0088*/
        public lwModelNodeHeadInfo _head;
        [MarshalAs(UnmanagedType.LPArray)]
        /*off:0092;siz:0004*/
        public byte[] _data;
        [MarshalAs(UnmanagedType.LPArray)]
        /*off:0096;siz:0004*/
        public byte[] _param;

        public int Load(BinaryReader f, uint ver)
        {
            return 0;
        }
	};

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class lwModelInfo
    {
        /* this+0x0 */
        public lwModelHeadInfo _head;
        [MarshalAs(UnmanagedType.LPStruct)]
        /* this+0x48 */
        public lwITreeNode _obj_tree;

        public uint __tree_proc_find_node(lwITreeNode node, byte[] data) { return 0; }
        public int Load(string file)
        {
            int ret = -1;
            if (!File.Exists(file))
                return 1;
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader fp = new BinaryReader(fs);
            this._head = StructReader.ReadStruct<lwModelHeadInfo>(fp);
            uint obj_num = fp.ReadUInt32();
            if (obj_num == 0)
            {
                fs.Close();
                return 0;
            };
            lwITreeNode tree_node = null;
            lwModelNodeInfo node_info;
            for (uint i = 0; i < obj_num; i++)
            {
                node_info = new lwModelNodeInfo();
                if (node_info.Load(fp, this._head.version) < 0)
                {
                    fs.Close();
                    return ret;
                }
                tree_node = new lwTreeNode();
                ((lwTreeNode)tree_node)._SetRegisterID(node_info); // MindPower::lwTreeNode::_SetRegisterID(uint)
                if (this._obj_tree == null)
                {
                    this._obj_tree = tree_node;
                }
                else
                {
                    __find_info param;
                    param.handle = node_info._head.parent_handle;
                    param.node = null;
                    this._obj_tree.EnumTree(__tree_proc_find_node, param, 0);
                    if (param.node == null)
                    {
                        fs.Close();
                        return ret;
                    };
                    if (param.node.InsertChild(null, tree_node) < 0)
                    {
                        fs.Close();
                        return ret;
                    };
                };
            };
            ret = 0;
            fp.Close();
            fs.Close();
            return ret;
        }
    };
}
