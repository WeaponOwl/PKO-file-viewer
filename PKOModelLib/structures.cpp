/* ***************************************************************** 
 * STRUCTURES * 
***************************************************************** */ 

struct MindPower::lwGeomObjInfo::lwGeomObjInfoHeader 
{ 
	/* this+0x0 */	unsigned long id; 
	/* this+0x4 */	unsigned long parent_id; 
	/* this+0x8 */	unsigned long type; // MindPower::lwModelObjectLoadType ??? 
	/* this+0xc */	struct D3DXMATRIX mat_local; 
	/* this+0x4c */ struct MindPower::lwRenderCtrlCreateInfo rcci; 
	/* this+0x5c */ class MindPower::lwStateCtrl state_ctrl; 
	/* this+0x64 */ unsigned long mtl_size; 
	/* this+0x68 */ unsigned long mesh_size; 
	/* this+0x6c */ unsigned long helper_size; 
	/* this+0x70 */ unsigned long anim_size; 
} 

struct MindPower::lwGeomObjInfo 
{ 
	/* this+0x4 */	 MindPower::lwGeomObjInfo::lwGeomObjInfoHeader header; 
	/* this+0x78 */	 unsigned long mtl_num; 
	/* this+0x7c */  struct MindPower::lwMtlTexInfo * mtl_seq; 
	/* this+0x80 */  struct MindPower::lwMeshInfo mesh; 
	/* this+0x130 */ struct MindPower::lwHelperInfo helper_data;
	/* this+0x160 */ class MindPower::lwAnimDataInfo anim_data; 
} 

struct MindPower::lwRenderCtrlCreateInfo 
{ 
	/* this+0x0 */ unsigned long ctrl_id; 
	/* this+0x4 */ unsigned long decl_id; 
	/* this+0x8 */ unsigned long vs_id; 
	/* this+0xc */ unsigned long ps_id; 
} 

class MindPower::lwStateCtrl 
{ 
	/* this+0x0 */ unsigned char _state_seq[8]; // MindPower::lwObjectStateEnum ??? 
} 

struct MindPower::lwMtlTexInfo 
{ 
	/* this+0x0 */ float opacity; 
	/* this+0x4 */ unsigned long transp_type; // MindPower::lwMtlTexInfoTransparencyTypeEnum 
	/* this+0x8 */ struct MindPower::lwMaterial mtl; 
	/* this+0x4c */ struct MindPower::lwRenderStateAtom rs_set[8]; 
	/* this+0xac */ struct MindPower::lwTexInfo tex_seq[4]; 
}; 

struct MindPower::lwMtlTexInfo_0000 
{ 
	/* this+0x0 */ struct MindPower::lwMaterial mtl; 
	/* this+0x44 */ struct MindPower::lwRenderStateSetTemplate<2,8> rs_set; 
	/* this+0xc4 */ struct MindPower::lwTexInfo[4] tex_seq; 
}; 

struct MindPower::lwMtlTexInfo_0001 
{ 
	/* this+0x0 */ float opacity; 
	/* this+0x4 */ unsigned long transp_type; // MindPower::lwMtlTexInfoTransparencyTypeEnum 
	/* this+0x8 */ struct MindPower::lwMaterial mtl; 
	/* this+0x4c */ struct MindPower::lwRenderStateSetTemplate<2,8> rs_set; 
	/* this+0xcc */ struct MindPower::lwTexInfo[4] tex_seq; 
}; 

struct MindPower::lwMaterial 
{ 
	/* this+0x0 */ struct MindPower::lwColorValue4f dif; 
	/* this+0x10 */ struct MindPower::lwColorValue4f amb; 
	/* this+0x20 */ struct MindPower::lwColorValue4f spe; 
	/* this+0x30 */ struct MindPower::lwColorValue4f emi; 
	/* this+0x40 */ float power; 
} 

struct MindPower::lwColorValue4b 
{ 
	/* this+0x0 */ unsigned char b; 
	/* this+0x1 */ unsigned char g; 
	/* this+0x2 */ unsigned char r; 
	/* this+0x3 */ unsigned char a; 
} 

struct MindPower::lwColorValue4f 
{ 
	/* this+0x0 */ float r; 
	/* this+0x4 */ float g; 
	/* this+0x8 */ float b; 
	/* this+0xc */ float a; 
} 

struct MindPower::lwRenderStateAtom 
{ 
	/* this+0x0 */ unsigned long state; // MindPower::lwRenderStateAtomType 
	/* this+0x4 */ unsigned long value0; 
	/* this+0x8 */ unsigned long value1; 
} 

struct MindPower::lwRenderStateSetTemplate<2,8> 
{ 
	/* this+0x0 */ struct MindPower::lwRenderStateValue rsv_seq[2][8]; 
} 

struct MindPower::lwRenderStateValue 
{ 
	/* this+0x0 */ unsigned long state; 
	/* this+0x4 */ unsigned long value; 
} 

struct MindPower::lwTexInfo 
{ 
	/* this+0x0 */ unsigned long stage; 
	/* this+0x4 */ unsigned long level; 
	/* this+0x8 */ unsigned long usage; 
	/* this+0xc */ enum _D3DFORMAT format; 
	/* this+0x10 */ enum _D3DPOOL pool; 
	/* this+0x14 */ unsigned long byte_alignment_flag; 
	/* this+0x18 */ unsigned long type; // MindPower::lwTexInfoTypeEnum 
	/* this+0x1c */ unsigned long width; 
	/* this+0x20 */ unsigned long height; 
	/* this+0x24 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
	/* this+0x28 */ struct MindPower::lwColorValue4b colorkey; 
	/* this+0x2c */ char file_name[64]; 
	/* this+0x6c */ void * data; 
	/* this+0x70 */ struct MindPower::lwRenderStateAtom[8] tss_set; 
} 

struct MindPower::lwTexInfo_0000 
{ 
	/* this+0x0 */ unsigned long stage; 
	/* this+0x4 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
	/* this+0x8 */ struct MindPower::lwColorValue4b colorkey; 
	/* this+0xc */ enum _D3DFORMAT format; 
	/* this+0x10 */ char file_name[64]; 
	/* this+0x50 */ struct MindPower::lwRenderStateSetTemplate<2,8> tss_set; 
} 

struct MindPower::lwTexInfo_0001 
{ 
	/* this+0x0 */ unsigned long stage; 
	/* this+0x4 */ unsigned long level; 
	/* this+0x8 */ unsigned long usage; 
	/* this+0xc */ enum _D3DFORMAT format; 
	/* this+0x10 */ enum _D3DPOOL pool; 
	/* this+0x14 */ unsigned long byte_alignment_flag; 
	/* this+0x18 */ unsigned long type; // MindPower::lwTexInfoTypeEnum 
	/* this+0x1c */ unsigned long width; 
	/* this+0x20 */ unsigned long height; 
	/* this+0x24 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
	/* this+0x28 */ struct MindPower::lwColorValue4b colorkey; 
	/* this+0x2c */ char file_name[64]; 
	/* this+0x6c */ void * data; 
	/* this+0x70 */ struct MindPower::lwRenderStateSetTemplate<2,8> tss_set; 
} 

struct MindPower::lwMeshInfo 
{ 
	/* this+0x0 */ struct MindPower::lwMeshInfo::lwMeshInfoHeader header; 
	/* this+0x80 */ struct D3DXVECTOR3 * vertex_seq; 
	/* this+0x84 */ struct D3DXVECTOR3 * normal_seq; 
	/* this+0x88 */ struct D3DXVECTOR2 * texcoord_seq[4]; 
	/* this+0x88 */ struct D3DXVECTOR2 * texcoord0_seq; 
	/* this+0x8c */ struct D3DXVECTOR2 * texcoord1_seq; 
	/* this+0x90 */ struct D3DXVECTOR2 * texcoord2_seq; 
	/* this+0x94 */ struct D3DXVECTOR2 * texcoord3_seq; 
	/* this+0x98 */ unsigned long * vercol_seq; 
	/* this+0x9c */ unsigned long * index_seq; 
	/* this+0xa0 */ unsigned long * bone_index_seq; 
	/* this+0xa4 */ struct MindPower::lwBlendInfo * blend_seq; 
	/* this+0xa8 */ struct MindPower::lwSubsetInfo * subset_seq; 
	/* this+0xac */ struct _D3DVERTEXELEMENT9 * vertex_element_seq; 
};

struct MindPower::lwMeshInfo_0000 
{ 
	/* this+0x0 */ struct MindPower::lwMeshInfo_0000::lwMeshInfoHeader header; 
	/* this+0x98 */ struct D3DXVECTOR3 * vertex_seq; 
	/* this+0x9c */ struct D3DXVECTOR3 * normal_seq; 
	/* this+0xa0 */ struct D3DXVECTOR2 * texcoord_seq[4]; 
	/* this+0xa0 */ struct D3DXVECTOR2 * texcoord0_seq; 
	/* this+0xa4 */ struct D3DXVECTOR2 * texcoord1_seq; 
	/* this+0xa8 */ struct D3DXVECTOR2 * texcoord2_seq; 
	/* this+0xac */ struct D3DXVECTOR2 * texcoord3_seq; 
	/* this+0xb0 */ unsigned long * vercol_seq; 
	/* this+0xb4 */ unsigned long * index_seq; 
	/* this+0xb8 */ struct MindPower::lwBlendInfo * blend_seq; 
	/* this+0xbc */ struct MindPower::lwSubsetInfo subset_seq[16]; 
	/* this+0x1bc */ unsigned char bone_index_seq[25]; 
};

struct MindPower::lwMeshInfo_0003 
{ 
	/* this+0x0 */ struct MindPower::lwMeshInfo_0003::lwMeshInfoHeader header; 
	/* this+0x78 */ struct D3DXVECTOR3 * vertex_seq; 
	/* this+0x7c */ struct D3DXVECTOR3 * normal_seq; 
	/* this+0x80 */ struct D3DXVECTOR2 * texcoord_seq[4]; 
	/* this+0x80 */ struct D3DXVECTOR2 * texcoord0_seq; 
	/* this+0x84 */ struct D3DXVECTOR2 * texcoord1_seq; 
	/* this+0x88 */ struct D3DXVECTOR2 * texcoord2_seq; 
	/* this+0x8c */ struct D3DXVECTOR2 * texcoord3_seq; 
	/* this+0x90 */ unsigned long * vercol_seq; 
	/* this+0x94 */ unsigned long * index_seq; 
	/* this+0x98 */ struct MindPower::lwBlendInfo * blend_seq; 
	/* this+0x9c */ struct MindPower::lwSubsetInfo subset_seq[16]; 
	/* this+0x19c */ unsigned char bone_index_seq[25]; 
};

struct MindPower::lwMeshInfo::lwMeshInfoHeader 
{ 
	/* this+0x0 */ unsigned long fvf; 
	/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
	/* this+0x8 */ unsigned long vertex_num; 
	/* this+0xc */ unsigned long index_num; 
	/* this+0x10 */ unsigned long subset_num; 
	/* this+0x14 */ unsigned long bone_index_num; 
	/* this+0x18 */ unsigned long bone_infl_factor; 
	/* this+0x1c */ unsigned long vertex_element_num; 
	/* this+0x20 */ struct MindPower::lwRenderStateAtom rs_set[8]; 
};

struct MindPower::lwMeshInfo_0000::lwMeshInfoHeader 
{ 
	/* this+0x0 */ unsigned long fvf; 
	/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
	/* this+0x8 */ unsigned long vertex_num; 
	/* this+0xc */ unsigned long index_num; 
	/* this+0x10 */ unsigned long subset_num; 
	/* this+0x14 */ unsigned long bone_index_num; 
	/* this+0x18 */ struct MindPower::lwRenderStateSetTemplate<2,8> rs_set; 
};

struct MindPower::lwMeshInfo_0003::lwMeshInfoHeader 
{ 
	/* this+0x0 */ unsigned long fvf; 
	/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
	/* this+0x8 */ unsigned long vertex_num; 
	/* this+0xc */ unsigned long index_num; 
	/* this+0x10 */ unsigned long subset_num; 
	/* this+0x14 */ unsigned long bone_index_num; 
	/* this+0x18 */ struct MindPower::lwRenderStateAtom rs_set[8]; 
};

struct MindPower::lwRenderStateAtom 
{ 
	/* this+0x0 */ unsigned long state; // MindPower::lwRenderStateAtomType 
	/* this+0x4 */ unsigned long value0; 
	/* this+0x8 */ unsigned long value1; 
};

struct MindPower::lwRenderStateSetTemplate<2,8> 
{ 
	/* this+0x0 */ struct MindPower::lwRenderStateValue rsv_seq[2][8]; 
};

struct MindPower::lwBlendInfo 
{ 
	/* this+0x0 */ unsigned char index[4]; 
	/* this+0x0 */ unsigned long indexd; 
	/* this+0x4 */ float weight[4]; 
};

struct MindPower::lwSubsetInfo 
{ 
	/* this+0x0 */ unsigned long primitive_num; 
	/* this+0x4 */ unsigned long start_index; 
	/* this+0x8 */ unsigned long vertex_num; 
	/* this+0xc */ unsigned long min_index; 
};

struct MindPower::lwHelperInfo 
{ 
	/* this+0x4 */ unsigned long type; // MindPower::lwHelperInfoType 
	/* this+0x8 */ struct MindPower::lwHelperDummyInfo * dummy_seq; 
	/* this+0xc */ struct MindPower::lwHelperBoxInfo * box_seq; 
	/* this+0x10 */ struct MindPower::lwHelperMeshInfo * mesh_seq; 
	/* this+0x14 */ struct MindPower::lwBoundingBoxInfo * bbox_seq; 
	/* this+0x18 */ struct MindPower::lwBoundingSphereInfo * bsphere_seq; 
	/* this+0x1c */ unsigned long dummy_num; 
	/* this+0x20 */ unsigned long box_num; 
	/* this+0x24 */ unsigned long mesh_num; 
	/* this+0x28 */ unsigned long bbox_num; 
	/* this+0x2c */ unsigned long bsphere_num; 
};

struct MindPower::lwHelperDummyInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ struct D3DXMATRIX mat; 
	/* this+0x44 */ struct D3DXMATRIX mat_local; 
	/* this+0x84 */ unsigned long parent_type; 
	/* this+0x88 */ unsigned long parent_id; 
};

struct MindPower::lwHelperDummyInfo_1000 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ struct D3DXMATRIX mat; 
};

struct MindPower::lwHelperBoxInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ unsigned long type; 
	/* this+0x8 */ unsigned long state; 
	/* this+0xc */ class MindPower::lwBox box; 
	/* this+0x24 */ struct D3DXMATRIX mat; 
	/* this+0x64 */ char name[32]; 
};

class MindPower::lwBox 
{ 
	/* this+0x0 */ struct D3DXVECTOR3 c; 
	/* this+0xc */ struct D3DXVECTOR3 r; 
};

class MindPower::lwBox_1001 
{ 
	/* this+0x0 */ struct D3DXVECTOR3 p; 
	/* this+0xc */ struct D3DXVECTOR3 s; 
};

struct MindPower::lwHelperMeshInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ unsigned long type; 
	/* this+0x8 */ char name[32]; 
	/* this+0x28 */ unsigned long state; 
	/* this+0x2c */ unsigned long sub_type; 
	/* this+0x30 */ struct D3DXMATRIX mat; 
	/* this+0x70 */ class MindPower::lwBox box; 
	/* this+0x88 */ struct D3DXVECTOR3 * vertex_seq; 
	/* this+0x8c */ struct MindPower::lwHelperMeshFaceInfo * face_seq; 
	/* this+0x90 */ unsigned long vertex_num; 
	/* this+0x94 */ unsigned long face_num; 
};

struct MindPower::lwHelperMeshFaceInfo 
{ 
	/* this+0x0 */ unsigned long vertex[3]; 
	/* this+0xc */ unsigned long adj_face[3]; 
	/* this+0x18 */ class MindPower::_lwPlane plane; 
	/* this+0x28 */ struct D3DXVECTOR3 center; 
};

struct MindPower::lwBoundingBoxInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ class MindPower::lwBox box; 
	/* this+0x1c */ struct D3DXMATRIX mat; 
};

struct MindPower::lwBoundingSphereInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ class MindPower::lwSphere sphere; 
	/* this+0x14 */ struct D3DXMATRIX mat; 
};

class MindPower::lwSphere 
{ 
	/* this+0x0 */ struct D3DXVECTOR3 c; 
	/* this+0xc */ float r; 
};

class MindPower::_lwPlane 
{ 
	/* this+0x0 */ float a; 
	/* this+0x4 */ float b; 
	/* this+0x8 */ float c; 
	/* this+0xc */ float d; 
};

class MindPower::lwAnimDataInfo 
{ 
	/* this+0x4 */ class MindPower::lwAnimDataBone * anim_bone; 
	/* this+0x8 */ class MindPower::lwAnimDataMatrix * anim_mat; 
	/* this+0xc */ struct MindPower::lwAnimDataMtlOpacity * anim_mtlopac[16]; 
	/* this+0x4c */ struct MindPower::lwAnimDataTexUV * anim_tex[16][4]; 
	/* this+0x14c */ class MindPower::lwAnimDataTexImg * anim_img[16][4]; 
};

class MindPower::lwAnimDataBone 
{ 
	/* this+0x4 */ struct MindPower::lwAnimDataBone::lwBoneInfoHeader _header; 
	/* this+0x14 */ struct MindPower::lwBoneBaseInfo * _base_seq; 
	/* this+0x18 */ struct MindPower::lwBoneDummyInfo * _dummy_seq; 
	/* this+0x1c */ struct MindPower::lwBoneKeyInfo * _key_seq; 
	/* this+0x20 */ struct D3DXMATRIX * _invmat_seq; 
};

struct MindPower::lwAnimDataBone::lwBoneInfoHeader 
{ 
	/* this+0x0 */ unsigned long bone_num; 
	/* this+0x4 */ unsigned long frame_num; 
	/* this+0x8 */ unsigned long dummy_num; 
	/* this+0xc */ unsigned long key_type; // MindPower::lwBoneKeyInfoType 
};

struct MindPower::lwBoneBaseInfo 
{ 
	/* this+0x0 */ char name[64]; 
	/* this+0x40 */ unsigned long id; 
	/* this+0x44 */ unsigned long parent_id; 
};

struct MindPower::lwBoneDummyInfo 
{ 
	/* this+0x0 */ unsigned long id; 
	/* this+0x4 */ unsigned long parent_bone_id; 
	/* this+0x8 */ struct D3DXMATRIX mat; 
};

struct MindPower::lwBoneKeyInfo 
{ 
	/* this+0x0 */ class MindPower::lwMatrix43 * mat43_seq; 
	/* this+0x4 */ struct D3DXMATRIX * mat44_seq; 
	/* this+0x8 */ struct D3DXVECTOR3 * pos_seq; 
	/* this+0xc */ struct D3DXQUATERNION * quat_seq; 
};

class MindPower::lwMatrix33 
{ 
	/* this+0x0 */ float m[3][3]; 
};

class MindPower::lwMatrix43 
{ 
	/* this+0x0 */ float m[4][3]; 
};

class MindPower::lwAnimDataMatrix 
{ 
	/* this+0x4 */ class MindPower::lwMatrix43 * _mat_seq; 
	/* this+0x8 */ unsigned long _frame_num; 
};

struct MindPower::lwAnimDataMtlOpacity 
{ 
	/* this+0x4 */ class MindPower::lwIAnimKeySetFloat * _aks_ctrl; 
};

class MindPower::lwAnimKeySetFloat 
{ 
	/* this+0x4 */ struct MindPower::lwKeyFloat * _data_seq; 
	/* this+0x8 */ unsigned long _data_num; 
	/* this+0xc */ unsigned long _data_capacity; 
};

struct MindPower::lwKeyFloat 
{ 
	/* this+0x0 */ unsigned long key; 
	/* this+0x4 */ unsigned long slerp_type; 
	/* this+0x8 */ float data; 
};

struct MindPower::lwAnimDataTexUV 
{ 
	/* this+0x4 */ struct D3DXMATRIX * _mat_seq; 
	/* this+0x8 */ unsigned long _frame_num; 
};

class MindPower::lwAnimDataTexImg 
{ 
	/* this+0x4 */ struct MindPower::lwTexInfo * _data_seq; 
	/* this+0x8 */ unsigned long _data_num; 
	/* this+0xc */ char _tex_path[260]; 
};

class MindPower::lwModelInfo 
{ 
	/* this+0x0 */ struct MindPower::lwModelHeadInfo _head; 
	/* this+0x48 */ class MindPower::lwITreeNode * _obj_tree; 
};

struct MindPower::lwModelHeadInfo 
{ 
	/* this+0x0 */ unsigned long mask; 
	/* this+0x4 */ unsigned long version; 
	/* this+0x8 */ char decriptor[64]; 
};

class MindPower::lwTreeNode 
{ 
	/* this+0x4 */ void * _data; 
	/* this+0x8 */ class MindPower::lwITreeNode * _parent; 
	/* this+0xc */ class MindPower::lwITreeNode * _child; 
	/* this+0x10 */ class MindPower::lwITreeNode * _sibling; 
};

struct MindPower::lwModelObjInfo 
{ 
	/* this+0x4 */ unsigned long geom_obj_num; 
	/* this+0x8 */ struct MindPower::lwGeomObjInfo * geom_obj_seq[32]; 
	/* this+0x88 */ struct MindPower::lwHelperInfo helper_data; 
};

struct MindPower::lwModelObjInfo::lwModelObjInfoHeader 
{ 
	/* this+0x0 */ unsigned long type; 
	/* this+0x4 */ unsigned long addr; 
	/* this+0x8 */ unsigned long size; 
};

struct D3DXMATRIX 
{ 
	/* this+0x0 */ float m[4][4]; 
};

struct _D3DVECTOR 
{ 
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
};

struct D3DXVECTOR2 
{ 
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
};

struct D3DXVECTOR3 
{ 
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
};

struct D3DXVECTOR4 
{ 
	/* this+0x0 */ float x; 
	/* this+0x4 */ float y; 
	/* this+0x8 */ float z; 
	/* this+0xc */ float w; 
};

struct _D3DVERTEXELEMENT9 
{ 
	/* this+0x0 */ unsigned short Stream; 
	/* this+0x2 */ unsigned short Offset; 
	/* this+0x4 */ unsigned char Type; 
	/* this+0x5 */ unsigned char Method; 
	/* this+0x6 */ unsigned char Usage; 
	/* this+0x7 */ unsigned char UsageIndex; 
};

struct D3DXQUATERNION 
{ 
	/* this+0x0 */ float x 
	/* this+0x4 */ float y 
	/* this+0x8 */ float z 
	/* this+0xc */ float w 
};


/* ***************************************************************** 
 * ENUMS * 
***************************************************************** */ 

typedef enum MindPower::lwRenderCtrlVSTypesEnum 
{ 
	RENDERCTRL_VS_FIXEDFUNCTION = 0x1, 
	RENDERCTRL_VS_VERTEXBLEND = 0x2, 
	RENDERCTRL_VS_VERTEXBLEND_DX9 = 0x3, 
	RENDERCTRL_VS_USER = 0x100, 
	RENDERCTRL_VS_INVALID = 0xff, 
} MindPower::lwRenderCtrlVSTypesEnum; 

typedef enum MindPower::lwModelObjectLoadType 
{ 
	MODELOBJECT_LOAD_RESET = 0x0, 
	MODELOBJECT_LOAD_MERGE = 0x1, 
	MODELOBJECT_LOAD_MERGE2 = 0x2, 
} MindPower::lwModelObjectLoadType; 

typedef enum MindPower::__unnamed 
{ 
	GEOMOBJ_TYPE_GENERIC = 0x0, 
	GEOMOBJ_TYPE_CHECK_BB = 0x1, 
	GEOMOBJ_TYPE_CHECK_BB2 = 0x2, 
} MindPower::__unnamed; 

typedef enum MindPower::lwObjectStateEnum 
{ 
	STATE_VISIBLE = 0x0, 
	STATE_ENABLE = 0x1, 
	STATE_UPDATETRANSPSTATE = 0x3, 
	STATE_TRANSPARENT = 0x4, 
	STATE_FRAMECULLING = 0x5, 
	STATE_INVALID = 0xff, 
	OBJECT_STATE_NUM = 0x8, 
} MindPower::lwObjectStateEnum; 

typedef enum MindPower::lwMtlTexInfoTransparencyTypeEnum 
{ 
	MTLTEX_TRANSP_FILTER = 0x0, 
	MTLTEX_TRANSP_ADDITIVE = 0x1, 
	MTLTEX_TRANSP_SUBTRACTIVE = 0x2, 
} MindPower::lwMtlTexInfoTransparencyTypeEnum; 

typedef enum MindPower::lwTexInfoTypeEnum 
{ 
	TEX_TYPE_FILE = 0x0, 
	TEX_TYPE_SIZE = 0x1, 
	TEX_TYPE_DATA = 0x2, 
	TEX_TYPE_INVALID = 0xff, 
} MindPower::lwTexInfoTypeEnum; 

typedef enum MindPower::lwColorKeyTypeEnum 
{ 
	COLORKEY_TYPE_NONE = 0x0, 
	COLORKEY_TYPE_COLOR = 0x1, 
	COLORKEY_TYPE_PIXEL = 0x2, 
} MindPower::lwColorKeyTypeEnum; 

typedef enum MindPower::lwRenderStateAtomType 
{ 
	RENDERSTATE_TYPE_RS = 0x0, 
	RENDERSTATE_TYPE_TSS = 0x1, 
	RENDERSTATE_TYPE_SS = 0x2, 
	RENDERSTATE_TYPE_INVALID = 0xff, 
} MindPower::lwRenderStateAtomType; 

typedef enum MindPower::lwMtlTexAgent::__unnamed 
{ 
	RSA_SET_SIZE = 0x8, 
} MindPower::lwMtlTexAgent::__unnamed; 

typedef enum MindPower::lwRenderStateAtomType 
{ 
	RENDERSTATE_TYPE_RS = 0x0, 
	RENDERSTATE_TYPE_TSS = 0x1, 
	RENDERSTATE_TYPE_SS = 0x2, 
	RENDERSTATE_TYPE_INVALID = 0xff, 
} MindPower::lwRenderStateAtomType; 

typedef enum MindPower::lwHelperInfoType 
{ 
	HELPER_TYPE_DUMMY = 0x1, 
	HELPER_TYPE_BOX = 0x2, 
	HELPER_TYPE_MESH = 0x4, 
	HELPER_TYPE_BOUNDINGBOX = 0x10, 
	HELPER_TYPE_BOUNDINGSPHERE = 0x20, 
	HELPER_TYPE_INVALID = 0x0, 
} MindPower::lwHelperInfoType; 

typedef enum MindPower::lwPlaneClassifyType 
{ 
	PLANE_ON_SIDE = 0x0, 
	PLANE_FRONT_SIDE = 0x1, 
	PLANE_BACK_SIDE = 0x2, 
} MindPower::lwPlaneClassifyType; 

typedef enum MindPower::lwAnimDataInfo::__unnamed 
{ 
	ANIM_DATA_NUM = 0x92, 
} MindPower::lwAnimDataInfo::__unnamed; 

typedef enum MindPower::lwBoneKeyInfoType 
{ 
	BONE_KEY_TYPE_MAT43 = 0x1, 
	BONE_KEY_TYPE_MAT44 = 0x2, 
	BONE_KEY_TYPE_QUAT = 0x3, 
	BONE_KEY_TYPE_INVALID = 0xff, 
} MindPower::lwBoneKeyInfoType; 

typedef enum MindPower::__unnamed 
{ 
	ANIM_CTRL_TYPE_MAT = 0x0, 
	ANIM_CTRL_TYPE_BONE = 0x1,
	ANIM_CTRL_TYPE_TEXUV = 0x2, 
	ANIM_CTRL_TYPE_TEXIMG = 0x3, 
	ANIM_CTRL_TYPE_MTLOPACITY = 0x4, 
	ANIM_CTRL_TYPE_NUM = 0x5, 
	ANIM_CTRL_TYPE_INVALID = 0xff, 
} MindPower::__unnamed; 

typedef enum MindPower::lwAnimKeySetMask 
{ 
	AKSM_KEY = 0x1, 
	AKSM_DATA = 0x2, 
	AKSM_SLERPTYPE = 0x4, 
} MindPower::lwAnimKeySetMask; 

typedef enum MindPower::lwAnimKeySetSlerpType 
{ 
	AKST_INVALID = 0x0, 
	__akst_begin = 0x0, 
	AKST_LINEAR = 0x1, 
	AKST_SIN1 = 0x2, 
	AKST_SIN2 = 0x3, 
	AKST_SIN3 = 0x4, 
	AKST_SIN4 = 0x5, 
	AKST_COS1 = 0x6, 
	AKST_COS2 = 0x7, 
	AKST_COS3 = 0x8, 
	AKST_COS4 = 0x9, 
	AKST_TAN1 = 0xa, 
	AKST_CTAN1 = 0xb, 
	__akst_end = 0xc, 
} MindPower::lwAnimKeySetSlerpType; 

typedef enum MindPower::lwModelEntityTypeEnum 
{ 
	NODE_PRIMITIVE = 0x1, 
	NODE_BONECTRL = 0x2, 
	NODE_DUMMY = 0x3, 
	NODE_HELPER = 0x4, 
	NODE_LIGHT = 0x5, 
	NODE_CAMERA = 0x6, 
	MODELNODE_INVALID = 0xff, 
} MindPower::lwModelEntityTypeEnum; 

typedef enum MindPower::lwModelNodeQueryMask 
{ 
	MNQI_ID = 0x1, 
	MNQI_TYPE = 0x2, 
	MNQI_DATA = 0x4, 
	MNQI_DESCRIPTOR = 0x8, 
	MNQI_USERPROC = 0x10, 
} MindPower::lwModelNodeQueryMask; 

typedef enum MindPower::lwModelObjectLoadType 
{ 
	MODELOBJECT_LOAD_RESET = 0x0, 
	MODELOBJECT_LOAD_MERGE = 0x1, 
	MODELOBJECT_LOAD_MERGE2 = 0x2, 
} MindPower::lwModelObjectLoadType; 

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