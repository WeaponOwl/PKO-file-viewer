#pragma once

#include <cstdio>

//using namespace System;

struct D3DXMATRIX 
{ 
public :
	/* this+0x0 */ float m[4][4]; 
};
struct _D3DVECTOR 
{ 
public :
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
};
struct D3DXVECTOR2 
{ 
public :
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
};
struct D3DXVECTOR3 
{ 
public :
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
};
D3DXVECTOR3 operator+(const D3DXVECTOR3& a,const D3DXVECTOR3& b);
D3DXVECTOR3 operator/(const D3DXVECTOR3& a,float b);
struct D3DXVECTOR4 
{ 
public :
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
	/* this+0xc */ float w; 
};
struct _D3DVERTEXELEMENT9 
{ 
public :
	/* this+0x0 */ unsigned short Stream; 
	/* this+0x2 */ unsigned short Offset; 
	/* this+0x4 */ unsigned char Type; 
	/* this+0x5 */ unsigned char Method; 
	/* this+0x6 */ unsigned char Usage; 
	/* this+0x7 */ unsigned char UsageIndex; 
};
struct D3DXQUATERNION 
{ 
public :
	/* this+0x0 */ float x;
	/* this+0x4 */ float y;
	/* this+0x8 */ float z;
	/* this+0xc */ float w;
};
typedef enum _D3DPRIMITIVETYPE 
{ 
	D3DPT_POINTLIST = 0x1, 
	D3DPT_LINELIST = 0x2, 
	D3DPT_LINESTRIP = 0x3, 
	D3DPT_TRIANGLELIST = 0x4, 
	D3DPT_TRIANGLESTRIP = 0x5, 
	D3DPT_TRIANGLEFAN = 0x6, 
	D3DPT_FORCE_DWORD = 0x7fffffff, 
} _D3DPRIMITIVETYPE; 
typedef enum _D3DFORMAT 
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
} _D3DFORMAT; 
typedef enum _D3DPOOL 
{ 
	D3DPOOL_DEFAULT = 0x0, 
	D3DPOOL_MANAGED = 0x1, 
	D3DPOOL_SYSTEMMEM = 0x2, 
	D3DPOOL_SCRATCH = 0x3, 
	D3DPOOL_FORCE_DWORD = 0x7fffffff, 
}_D3DPOOL; 

namespace MindpowerModelsNet 
{
	struct lwColorValue4b 
	{ 
	public :
		/* this+0x0 */ unsigned char b; 
		/* this+0x1 */ unsigned char g; 
		/* this+0x2 */ unsigned char r; 
		/* this+0x3 */ unsigned char a; 
	};

	struct lwColorValue4f 
	{ 
	public :
		/* this+0x0 */ float r; 
		/* this+0x4 */ float g; 
		/* this+0x8 */ float b; 
		/* this+0xc */ float a; 
	};

	struct lwRenderCtrlCreateInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long ctrl_id; 
		/* this+0x4 */ unsigned long decl_id; 
		/* this+0x8 */ unsigned long vs_id; 
		/* this+0xc */ unsigned long ps_id; 
	};

	class lwStateCtrl 
	{ 
	public :
		/* this+0x0 */ unsigned char _state_seq[8]; // MindPower::lwObjectStateEnum ??? 

		void __thiscall SetState(unsigned long state, unsigned char value);
	};

	struct lwMaterial 
	{ 
	public :
		/* this+0x0 */ lwColorValue4f dif; 
		/* this+0x10 */ lwColorValue4f amb; 
		/* this+0x20 */ lwColorValue4f spe; 
		/* this+0x30 */ lwColorValue4f emi; 
		/* this+0x40 */ float power; 
	}; 

	struct lwRenderStateAtom 
	{ 
	public :
		/* this+0x0 */ unsigned long state; // MindPower::lwRenderStateAtomType 
		/* this+0x4 */ unsigned long value0; 
		/* this+0x8 */ unsigned long value1; 
	};

	struct lwRenderStateValue 
	{ 
	public :
		/* this+0x0 */ unsigned long state; 
		/* this+0x4 */ unsigned long value; 
	}; 

	template <int T1, int T2> struct lwRenderStateSetTemplate 
	{ 
	public :
		/* this+0x0 */ lwRenderStateValue rsv_seq[T1][T2]; 
	}; 

	struct lwTexInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long stage; 
		/* this+0x4 */ unsigned long level; 
		/* this+0x8 */ unsigned long usage; 
		/* this+0xc */ _D3DFORMAT format; 
		/* this+0x10 */ _D3DPOOL pool; 
		/* this+0x14 */ unsigned long byte_alignment_flag; 
		/* this+0x18 */ unsigned long type; // MindPower::lwTexInfoTypeEnum 
		/* this+0x1c */ unsigned long width; 
		/* this+0x20 */ unsigned long height; 
		/* this+0x24 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
		/* this+0x28 */ lwColorValue4b colorkey; 
		/* this+0x2c */ char file_name[64]; 
		/* this+0x6c */ void * data; 
		/* this+0x70 */ lwRenderStateAtom tss_set[8]; 
	};

	struct lwTexInfo_0000 
	{ 
	public :
		/* this+0x0 */ unsigned long stage; 
		/* this+0x4 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
		/* this+0x8 */ lwColorValue4b colorkey; 
		/* this+0xc */ _D3DFORMAT format; 
		/* this+0x10 */ char file_name[64]; 
		/* this+0x50 */ lwRenderStateSetTemplate<2,8> tss_set; 
	}; 

	struct lwTexInfo_0001 
	{ 
	public :
		/* this+0x0 */ unsigned long stage; 
		/* this+0x4 */ unsigned long level; 
		/* this+0x8 */ unsigned long usage; 
		/* this+0xc */ _D3DFORMAT format; 
		/* this+0x10 */ _D3DPOOL pool; 
		/* this+0x14 */ unsigned long byte_alignment_flag; 
		/* this+0x18 */ unsigned long type; // MindPower::lwTexInfoTypeEnum 
		/* this+0x1c */ unsigned long width; 
		/* this+0x20 */ unsigned long height; 
		/* this+0x24 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
		/* this+0x28 */ lwColorValue4b colorkey; 
		/* this+0x2c */ char file_name[64]; 
		/* this+0x6c */ void * data; 
		/* this+0x70 */ lwRenderStateSetTemplate<2,8> tss_set; 
	};

	struct lwMtlTexInfo 
	{ 
	public :
		/* this+0x0 */ float opacity; 
		/* this+0x4 */ unsigned long transp_type; // MindPower::lwMtlTexInfoTransparencyTypeEnum 
		/* this+0x8 */ lwMaterial mtl; 
		/* this+0x4c */ lwRenderStateAtom rs_set[8]; 
		/* this+0xac */ lwTexInfo tex_seq[4]; 
	}; 

	struct lwBlendInfo 
	{ 
	public :
		union
		{
		public :
			/* this+0x0 */ unsigned char index[4];  
			/* this+0x0 */ unsigned long indexd; 
		};
		/* this+0x4 */ float weight[4]; 
	};

	struct lwSubsetInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long primitive_num; 
		/* this+0x4 */ unsigned long start_index; 
		/* this+0x8 */ unsigned long vertex_num; 
		/* this+0xc */ unsigned long min_index; 
	};

	struct lwMeshInfo 
	{ 
	public :
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
		public :
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ unsigned long bone_infl_factor; 
			/* this+0x1c */ unsigned long vertex_element_num; 
			/* this+0x20 */ lwRenderStateAtom rs_set[8]; 
		} header; 
		/* this+0x80 */ D3DXVECTOR3 * vertex_seq; 
		/* this+0x84 */ D3DXVECTOR3 * normal_seq; 
		/* this+0x88 */ D3DXVECTOR2 * texcoord_seq[4]; 
		/* this+0x88 */ D3DXVECTOR2 * texcoord0_seq; 
		/* this+0x8c */ D3DXVECTOR2 * texcoord1_seq; 
		/* this+0x90 */ D3DXVECTOR2 * texcoord2_seq; 
		/* this+0x94 */ D3DXVECTOR2 * texcoord3_seq; 
		/* this+0x98 */ unsigned long * vercol_seq; 
		/* this+0x9c */ unsigned long * index_seq; 
		/* this+0xa0 */ unsigned long * bone_index_seq; 
		/* this+0xa4 */ lwBlendInfo * blend_seq; 
		/* this+0xa8 */ lwSubsetInfo * subset_seq; 
		/* this+0xac */ _D3DVERTEXELEMENT9 * vertex_element_seq; 
	};

	struct lwMeshInfo_0000 
	{ 
	public :
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
		public :
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ lwRenderStateSetTemplate<2,8> rs_set; 
		} header; 
		/* this+0x98 */ D3DXVECTOR3 * vertex_seq; 
		/* this+0x9c */ D3DXVECTOR3 * normal_seq; 
		/* this+0xa0 */ D3DXVECTOR2 * texcoord_seq[4]; 
		/* this+0xa0 */ D3DXVECTOR2 * texcoord0_seq; 
		/* this+0xa4 */ D3DXVECTOR2 * texcoord1_seq; 
		/* this+0xa8 */ D3DXVECTOR2 * texcoord2_seq; 
		/* this+0xac */ D3DXVECTOR2 * texcoord3_seq; 
		/* this+0xb0 */ unsigned long * vercol_seq; 
		/* this+0xb4 */ unsigned long * index_seq; 
		/* this+0xb8 */ lwBlendInfo * blend_seq; 
		/* this+0xbc */ lwSubsetInfo subset_seq[16]; 
		/* this+0x1bc */ unsigned char bone_index_seq[25]; 
	};

	struct lwMeshInfo_0003 
	{ 
	public :
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
		public :
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ lwRenderStateAtom rs_set[8]; 
		} header; 
		/* this+0x78 */ D3DXVECTOR3 * vertex_seq; 
		/* this+0x7c */ D3DXVECTOR3 * normal_seq; 
		/* this+0x80 */ D3DXVECTOR2 * texcoord_seq[4]; 
		/* this+0x80 */ D3DXVECTOR2 * texcoord0_seq; 
		/* this+0x84 */ D3DXVECTOR2 * texcoord1_seq; 
		/* this+0x88 */ D3DXVECTOR2 * texcoord2_seq; 
		/* this+0x8c */ D3DXVECTOR2 * texcoord3_seq; 
		/* this+0x90 */ unsigned long * vercol_seq; 
		/* this+0x94 */ unsigned long * index_seq; 
		/* this+0x98 */ lwBlendInfo * blend_seq; 
		/* this+0x9c */ lwSubsetInfo subset_seq[16]; 
		/* this+0x19c */ unsigned char bone_index_seq[25]; 
	};

	struct lwHelperDummyInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ D3DXMATRIX mat; 
		/* this+0x44 */ D3DXMATRIX mat_local; 
		/* this+0x84 */ unsigned long parent_type; 
		/* this+0x88 */ unsigned long parent_id; 
	};

	struct lwHelperDummyInfo_1000 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ D3DXMATRIX mat; 
	};

	class lwBox 
	{ 
	public:
		/* this+0x0 */ D3DXVECTOR3 c; 
		/* this+0xc */ D3DXVECTOR3 r; 
	};

	class lwBox_1001 
	{ 
	public:
		/* this+0x0 */ D3DXVECTOR3 p; 
		/* this+0xc */ D3DXVECTOR3 s; 
	};

	struct lwHelperBoxInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long type; 
		/* this+0x8 */ unsigned long state; 
		/* this+0xc */ lwBox box; 
		/* this+0x24 */ D3DXMATRIX mat; 
		/* this+0x64 */ char name[32]; 
	};

	class _lwPlane 
	{ 
	public :
		/* this+0x0 */ float a; 
		/* this+0x4 */ float b; 
		/* this+0x8 */ float c; 
		/* this+0xc */ float d; 
	};

	struct lwHelperMeshFaceInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long vertex[3]; 
		/* this+0xc */ unsigned long adj_face[3]; 
		/* this+0x18 */ _lwPlane plane; 
		/* this+0x28 */ D3DXVECTOR3 center; 
	};

	struct lwHelperMeshInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long type; 
		/* this+0x8 */ char name[32]; 
		/* this+0x28 */ unsigned long state; 
		/* this+0x2c */ unsigned long sub_type; 
		/* this+0x30 */ D3DXMATRIX mat; 
		/* this+0x70 */ lwBox box; 
		/* this+0x88 */ D3DXVECTOR3 * vertex_seq; 
		/* this+0x8c */ lwHelperMeshFaceInfo * face_seq; 
		/* this+0x90 */ unsigned long vertex_num; 
		/* this+0x94 */ unsigned long face_num; 
	};

	struct lwBoundingBoxInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ lwBox box; 
		/* this+0x1c */ D3DXMATRIX mat; 
	};

	class lwSphere 
	{ 
	public :
		/* this+0x0 */ D3DXVECTOR3 c; 
		/* this+0xc */ float r; 
	};

	struct lwBoundingSphereInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ lwSphere sphere; 
		/* this+0x14 */ D3DXMATRIX mat; 
	};

	struct lwHelperInfo 
	{ 
	public :
		/* this+0x4 */ unsigned long type; // MindPower::lwHelperInfoType 
		/* this+0x8 */ lwHelperDummyInfo * dummy_seq; 
		/* this+0xc */ lwHelperBoxInfo * box_seq; 
		/* this+0x10 */ lwHelperMeshInfo * mesh_seq; 
		/* this+0x14 */ lwBoundingBoxInfo * bbox_seq; 
		/* this+0x18 */ lwBoundingSphereInfo * bsphere_seq; 
		/* this+0x1c */ unsigned long dummy_num; 
		/* this+0x20 */ unsigned long box_num; 
		/* this+0x24 */ unsigned long mesh_num; 
		/* this+0x28 */ unsigned long bbox_num; 
		/* this+0x2c */ unsigned long bsphere_num; 

		long __thiscall _LoadHelperDummyInfo(FILE *fp, unsigned long version);
		long __thiscall _LoadHelperBoxInfo(FILE *fp, unsigned long version);
		long __thiscall _LoadHelperMeshInfo(FILE *fp, unsigned long version);
		long __thiscall _LoadBoundingBoxInfo(FILE *fp, unsigned long version);
		long __thiscall _LoadBoundingSphereInfo(FILE *fp, unsigned long version);
		long __thiscall Load(FILE *fp, unsigned long version);
	};

	struct lwBoneBaseInfo 
	{ 
	public :
		/* this+0x0 */ char name[64]; 
		/* this+0x40 */ unsigned long id; 
		/* this+0x44 */ unsigned long parent_id; 
	};

	struct lwBoneDummyInfo 
	{ 
	public :
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long parent_bone_id; 
		/* this+0x8 */ D3DXMATRIX mat; 
	};

	class lwMatrix33 
	{ 
	public :
		/* this+0x0 */ float m[3][3]; 
	};

	class lwMatrix43 
	{ 
	public :
		/* this+0x0 */ float m[4][3]; 
	};

	struct lwBoneKeyInfo 
	{ 
	public :
		/* this+0x0 */ lwMatrix43 * mat43_seq; 
		/* this+0x4 */ D3DXMATRIX * mat44_seq; 
		/* this+0x8 */ D3DXVECTOR3 * pos_seq; 
		/* this+0xc */ D3DXQUATERNION * quat_seq; 
	};

	class lwAnimDataBone 
	{ 
	public:
		/* this+0x4 */ struct lwBoneInfoHeader 
		{ 
		public :
			/* this+0x0 */ unsigned long bone_num; 
			/* this+0x4 */ unsigned long frame_num; 
			/* this+0x8 */ unsigned long dummy_num; 
			/* this+0xc */ unsigned long key_type; // MindPower::lwBoneKeyInfoType 
		} _header; 
		/* this+0x14 */ lwBoneBaseInfo * _base_seq; 
		/* this+0x18 */ lwBoneDummyInfo * _dummy_seq; 
		/* this+0x1c */ lwBoneKeyInfo * _key_seq; 
		/* this+0x20 */ D3DXMATRIX * _invmat_seq; 

		long __thiscall Load(FILE *fp, unsigned long version);

		virtual long __thiscall Load(const char * file);
	};

	class lwAnimDataMatrix 
	{ 
	public:
		/* this+0x4 */ lwMatrix43 * _mat_seq; 
		/* this+0x8 */ unsigned long _frame_num; 

		long __thiscall Load(FILE *fp, unsigned long version);
	};

	struct lwKeyFloat 
	{ 
	public :
		/* this+0x0 */ unsigned long key; 
		/* this+0x4 */ unsigned long slerp_type; 
		/* this+0x8 */ float data; 
	};

	class lwIAnimKeySetFloat
	{
	public:
		virtual unsigned long __thiscall SetKeySequence(lwKeyFloat *seq,unsigned long num)=0;
	};
	class lwAnimKeySetFloat : public lwIAnimKeySetFloat
	{ 
	public:
		/* this+0x4 */ lwKeyFloat * _data_seq; 
		/* this+0x8 */ unsigned long _data_num; 
		/* this+0xc */ unsigned long _data_capacity; 

		unsigned long __thiscall SetKeySequence(lwKeyFloat *seq,unsigned long num) ;
	};

	struct lwAnimDataMtlOpacity 
	{ 
	public:
		/* this+0x4 */ lwIAnimKeySetFloat * _aks_ctrl; 

		long __thiscall Load(FILE *fp, unsigned long version);
	};

	struct lwAnimDataTexUV 
	{ 
	public:
		/* this+0x4 */ D3DXMATRIX * _mat_seq; 
		/* this+0x8 */ unsigned long _frame_num; 

		long __thiscall Load(FILE *fp, unsigned long version);
	};

	class lwAnimDataTexImg 
	{ 
	public:
		/* this+0x4 */ lwTexInfo * _data_seq; 
		/* this+0x8 */ unsigned long _data_num; 
		/* this+0xc */ char _tex_path[260]; 

		long __thiscall Load(FILE *fp, unsigned long version);
	};

	class lwAnimDataInfo 
	{ 
	public: 
		/* this+0x4 */ lwAnimDataBone * anim_bone; 
		/* this+0x8 */ lwAnimDataMatrix * anim_mat; 
		/* this+0xc */ lwAnimDataMtlOpacity * anim_mtlopac[16]; 
		/* this+0x4c */ lwAnimDataTexUV * anim_tex[16][4]; 
		/* this+0x14c */ lwAnimDataTexImg * anim_img[16][4]; 

		long __thiscall Load(FILE *fp, unsigned long version);
	};

	long __cdecl lwMtlTexInfo_Load(lwMtlTexInfo *info, FILE *fp, unsigned long version);
	long __cdecl lwLoadMtlTexInfo(lwMtlTexInfo **out_buf, unsigned long *out_num, FILE *fp, unsigned long version);
	long __cdecl lwMeshInfo_Load(lwMeshInfo *info, FILE *fp, unsigned long version);

	struct lwGeomObjInfo 
	{ 
	public:
		/* this+0x4 */   struct lwGeomObjInfoHeader 
		{ 
		public :
			/* this+0x0 */	unsigned long id; 
			/* this+0x4 */	unsigned long parent_id; 
			/* this+0x8 */	unsigned long type; // MindPower::lwModelObjectLoadType ??? 
			/* this+0xc */	D3DXMATRIX mat_local; 
			/* this+0x4c */ lwRenderCtrlCreateInfo rcci; 
			/* this+0x5c */ lwStateCtrl state_ctrl; 
			/* this+0x64 */ unsigned long mtl_size; 
			/* this+0x68 */ unsigned long mesh_size; 
			/* this+0x6c */ unsigned long helper_size; 
			/* this+0x70 */ unsigned long anim_size; 
		} header; 
		/* this+0x78 */	 unsigned long mtl_num; 
		/* this+0x7c */  lwMtlTexInfo * mtl_seq; 
		/* this+0x80 */  lwMeshInfo mesh; 
		/* this+0x130 */ lwHelperInfo helper_data;
		/* this+0x160 */ lwAnimDataInfo anim_data; 

		long __thiscall Load(FILE *fp, unsigned long version);
		virtual long __thiscall Load(const char * file);
	};

	struct lwModelObjInfo 
	{ 
	public :
		struct lwModelObjInfoHeader 
		{ 
		public:
			/* this+0x0 */ unsigned long type; 
			/* this+0x4 */ unsigned long addr; 
			/* this+0x8 */ unsigned long size; 
		};

		/* this+0x4 */ unsigned long geom_obj_num; 
		/* this+0x8 */ lwGeomObjInfo * geom_obj_seq[32]; 
		/* this+0x88 */ lwHelperInfo helper_data; 

		virtual long __thiscall Load(const char *file);
	};

	struct lwModelHeadInfo 
	{ 
	public:
		/* this+0x0 */ unsigned long mask; 
		/* this+0x4 */ unsigned long version; 
		/* this+0x8 */ char decriptor[64]; 
	};

	class lwITreeNode
	{
	public:
		//long __thiscall EnumTree(unsigned long __cdecl ,lwITreeNode*,void*);
		virtual long __thiscall EnumTree(unsigned long (__cdecl*)(class lwITreeNode *,void *),void *,unsigned long)=0;
		virtual long __thiscall InsertChild(lwITreeNode*,lwITreeNode*)=0;
	};

	struct __find_info
	{
		/*off:0000;siz:0004*/public: lwITreeNode* node;
		/*off:0004;siz:0004*/public: unsigned long handle;
	};

	unsigned long __cdecl __tree_proc_find_node(lwITreeNode *,void *);

	class lwTreeNode : public lwITreeNode
	{ 
	public:
		/* this+0x4 */ void * _data; 
		/* this+0x8 */ lwITreeNode * _parent; 
		/* this+0xc */ lwITreeNode * _child; 
		/* this+0x10 */ lwITreeNode * _sibling; 

		void __thiscall _SetRegisterID(void*);
		long __thiscall EnumTree(unsigned long (__cdecl*)(class lwITreeNode *,void *),void *,unsigned long);
		long __thiscall InsertChild(lwITreeNode *,lwITreeNode *);
	};

	struct /*siz:88*/lwModelNodeHeadInfo
	{
	public:
		/*off:0000;siz:0004*/public: unsigned long handle;
		/*off:0004;siz:0004*/public: unsigned long type;
		/*off:0008;siz:0004*/public: unsigned long id;
		/*off:0012;siz:0064*/public: char descriptor[64];
		/*off:0076;siz:0004*/public: unsigned long parent_handle;
		/*off:0080;siz:0004*/public: unsigned long link_parent_id;
		/*off:0084;siz:0004*/public: unsigned long link_id;
	};

	struct /*siz:100*/lwModelNodeInfo
	{
	public:
		/*off:0004;siz:0088*/public: lwModelNodeHeadInfo _head;
		/*off:0092;siz:0004*/public: void* _data;
		/*off:0096;siz:0004*/public: void* _param;

		long __thiscall Load(FILE *,unsigned long);
	};

	class lwModelInfo 
	{ 
	public:
		/* this+0x0 */ lwModelHeadInfo _head; 
		/* this+0x48 */ lwITreeNode* _obj_tree; 

		long __thiscall Load(const char *file);
	};
}
