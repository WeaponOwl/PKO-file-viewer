#include <stdio.h>
#include <Windows.h>

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
D3DXVECTOR3 operator+(const D3DXVECTOR3& a,const D3DXVECTOR3& b)
{
	D3DXVECTOR3 r = {a.x+b.x,a.y+b.y,a.z+b.z};
	return r;
}
D3DXVECTOR3 operator/(const D3DXVECTOR3& a,float b)
{
	D3DXVECTOR3 r = {a.x/b,a.y/b,a.z/b};
	return r;
}

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
	/* this+0x0 */ float x;
	/* this+0x4 */ float y;
	/* this+0x8 */ float z;
	/* this+0xc */ float w;
};

namespace Mindpower
{
	struct lwColorValue4b 
	{ 
		/* this+0x0 */ unsigned char b; 
		/* this+0x1 */ unsigned char g; 
		/* this+0x2 */ unsigned char r; 
		/* this+0x3 */ unsigned char a; 
	};

	struct lwColorValue4f 
	{ 
		/* this+0x0 */ float r; 
		/* this+0x4 */ float g; 
		/* this+0x8 */ float b; 
		/* this+0xc */ float a; 
	};

	struct lwRenderCtrlCreateInfo 
	{ 
		/* this+0x0 */ unsigned long ctrl_id; 
		/* this+0x4 */ unsigned long decl_id; 
		/* this+0x8 */ unsigned long vs_id; 
		/* this+0xc */ unsigned long ps_id; 
	};

	class lwStateCtrl 
	{ 
	public :
		/* this+0x0 */ unsigned char _state_seq[8]; // MindPower::lwObjectStateEnum ??? 

		void __thiscall SetState(unsigned long state, unsigned char value) 
		{
			this->_state_seq[state] = value;
		}
	};

	struct lwMaterial 
	{ 
		/* this+0x0 */ struct lwColorValue4f dif; 
		/* this+0x10 */ struct lwColorValue4f amb; 
		/* this+0x20 */ struct lwColorValue4f spe; 
		/* this+0x30 */ struct lwColorValue4f emi; 
		/* this+0x40 */ float power; 
	}; 

	struct lwRenderStateAtom 
	{ 
		/* this+0x0 */ unsigned long state; // MindPower::lwRenderStateAtomType 
		/* this+0x4 */ unsigned long value0; 
		/* this+0x8 */ unsigned long value1; 
	};

	struct lwRenderStateValue 
	{ 
		/* this+0x0 */ unsigned long state; 
		/* this+0x4 */ unsigned long value; 
	}; 

	template <int T1, int T2> struct lwRenderStateSetTemplate 
	{ 
		/* this+0x0 */ struct lwRenderStateValue rsv_seq[T1][T2]; 
	}; 

	struct lwTexInfo 
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
		/* this+0x28 */ struct lwColorValue4b colorkey; 
		/* this+0x2c */ char file_name[64]; 
		/* this+0x6c */ void * data; 
		/* this+0x70 */ struct lwRenderStateAtom tss_set[8]; 
	};

	struct lwTexInfo_0000 
	{ 
		/* this+0x0 */ unsigned long stage; 
		/* this+0x4 */ unsigned long colorkey_type; // MindPower::lwColorKeyTypeEnum 
		/* this+0x8 */ struct lwColorValue4b colorkey; 
		/* this+0xc */ enum _D3DFORMAT format; 
		/* this+0x10 */ char file_name[64]; 
		/* this+0x50 */ struct lwRenderStateSetTemplate<2,8> tss_set; 
	}; 

	struct lwTexInfo_0001 
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
		/* this+0x28 */ struct lwColorValue4b colorkey; 
		/* this+0x2c */ char file_name[64]; 
		/* this+0x6c */ void * data; 
		/* this+0x70 */ struct lwRenderStateSetTemplate<2,8> tss_set; 
	};

	struct lwMtlTexInfo 
	{ 
		/* this+0x0 */ float opacity; 
		/* this+0x4 */ unsigned long transp_type; // MindPower::lwMtlTexInfoTransparencyTypeEnum 
		/* this+0x8 */ struct lwMaterial mtl; 
		/* this+0x4c */ struct lwRenderStateAtom rs_set[8]; 
		/* this+0xac */ struct lwTexInfo tex_seq[4]; 
	}; 

	struct lwBlendInfo 
	{ 
		union
		{
			/* this+0x0 */ unsigned char index[4];  
			/* this+0x0 */ unsigned long indexd; 
		};
		/* this+0x4 */ float weight[4]; 
	};

	struct lwSubsetInfo 
	{ 
		/* this+0x0 */ unsigned long primitive_num; 
		/* this+0x4 */ unsigned long start_index; 
		/* this+0x8 */ unsigned long vertex_num; 
		/* this+0xc */ unsigned long min_index; 
	};

	struct lwMeshInfo 
	{ 
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ unsigned long bone_infl_factor; 
			/* this+0x1c */ unsigned long vertex_element_num; 
			/* this+0x20 */ struct lwRenderStateAtom rs_set[8]; 
		} header; 
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
		/* this+0xa4 */ struct lwBlendInfo * blend_seq; 
		/* this+0xa8 */ struct lwSubsetInfo * subset_seq; 
		/* this+0xac */ struct _D3DVERTEXELEMENT9 * vertex_element_seq; 
	};

	struct lwMeshInfo_0000 
	{ 
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ struct lwRenderStateSetTemplate<2,8> rs_set; 
		} header; 
		/* this+0x98 */ struct D3DXVECTOR3 * vertex_seq; 
		/* this+0x9c */ struct D3DXVECTOR3 * normal_seq; 
		/* this+0xa0 */ struct D3DXVECTOR2 * texcoord_seq[4]; 
		/* this+0xa0 */ struct D3DXVECTOR2 * texcoord0_seq; 
		/* this+0xa4 */ struct D3DXVECTOR2 * texcoord1_seq; 
		/* this+0xa8 */ struct D3DXVECTOR2 * texcoord2_seq; 
		/* this+0xac */ struct D3DXVECTOR2 * texcoord3_seq; 
		/* this+0xb0 */ unsigned long * vercol_seq; 
		/* this+0xb4 */ unsigned long * index_seq; 
		/* this+0xb8 */ struct lwBlendInfo * blend_seq; 
		/* this+0xbc */ struct lwSubsetInfo subset_seq[16]; 
		/* this+0x1bc */ unsigned char bone_index_seq[25]; 
	};

	struct lwMeshInfo_0003 
	{ 
		/* this+0x0 */ struct lwMeshInfoHeader 
		{ 
			/* this+0x0 */ unsigned long fvf; 
			/* this+0x4 */ enum _D3DPRIMITIVETYPE pt_type; 
			/* this+0x8 */ unsigned long vertex_num; 
			/* this+0xc */ unsigned long index_num; 
			/* this+0x10 */ unsigned long subset_num; 
			/* this+0x14 */ unsigned long bone_index_num; 
			/* this+0x18 */ struct lwRenderStateAtom rs_set[8]; 
		} header; 
		/* this+0x78 */ struct D3DXVECTOR3 * vertex_seq; 
		/* this+0x7c */ struct D3DXVECTOR3 * normal_seq; 
		/* this+0x80 */ struct D3DXVECTOR2 * texcoord_seq[4]; 
		/* this+0x80 */ struct D3DXVECTOR2 * texcoord0_seq; 
		/* this+0x84 */ struct D3DXVECTOR2 * texcoord1_seq; 
		/* this+0x88 */ struct D3DXVECTOR2 * texcoord2_seq; 
		/* this+0x8c */ struct D3DXVECTOR2 * texcoord3_seq; 
		/* this+0x90 */ unsigned long * vercol_seq; 
		/* this+0x94 */ unsigned long * index_seq; 
		/* this+0x98 */ struct lwBlendInfo * blend_seq; 
		/* this+0x9c */ struct lwSubsetInfo subset_seq[16]; 
		/* this+0x19c */ unsigned char bone_index_seq[25]; 
	};

	struct lwHelperDummyInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ struct D3DXMATRIX mat; 
		/* this+0x44 */ struct D3DXMATRIX mat_local; 
		/* this+0x84 */ unsigned long parent_type; 
		/* this+0x88 */ unsigned long parent_id; 
	};

	struct lwHelperDummyInfo_1000 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ struct D3DXMATRIX mat; 
	};

	class lwBox 
	{ 
	public:
		/* this+0x0 */ struct D3DXVECTOR3 c; 
		/* this+0xc */ struct D3DXVECTOR3 r; 
	};

	class lwBox_1001 
	{ 
	public:
		/* this+0x0 */ struct D3DXVECTOR3 p; 
		/* this+0xc */ struct D3DXVECTOR3 s; 
	};

	struct lwHelperBoxInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long type; 
		/* this+0x8 */ unsigned long state; 
		/* this+0xc */ class lwBox box; 
		/* this+0x24 */ struct D3DXMATRIX mat; 
		/* this+0x64 */ char name[32]; 
	};

	class _lwPlane 
	{ 
		/* this+0x0 */ float a; 
		/* this+0x4 */ float b; 
		/* this+0x8 */ float c; 
		/* this+0xc */ float d; 
	};

	struct lwHelperMeshFaceInfo 
	{ 
		/* this+0x0 */ unsigned long vertex[3]; 
		/* this+0xc */ unsigned long adj_face[3]; 
		/* this+0x18 */ class _lwPlane plane; 
		/* this+0x28 */ struct D3DXVECTOR3 center; 
	};

	struct lwHelperMeshInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long type; 
		/* this+0x8 */ char name[32]; 
		/* this+0x28 */ unsigned long state; 
		/* this+0x2c */ unsigned long sub_type; 
		/* this+0x30 */ struct D3DXMATRIX mat; 
		/* this+0x70 */ class lwBox box; 
		/* this+0x88 */ struct D3DXVECTOR3 * vertex_seq; 
		/* this+0x8c */ struct lwHelperMeshFaceInfo * face_seq; 
		/* this+0x90 */ unsigned long vertex_num; 
		/* this+0x94 */ unsigned long face_num; 
	};

	struct lwBoundingBoxInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ class lwBox box; 
		/* this+0x1c */ struct D3DXMATRIX mat; 
	};

	class lwSphere 
	{ 
		/* this+0x0 */ struct D3DXVECTOR3 c; 
		/* this+0xc */ float r; 
	};

	struct lwBoundingSphereInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ class lwSphere sphere; 
		/* this+0x14 */ struct D3DXMATRIX mat; 
	};

	struct lwHelperInfo 
	{ 
		/* this+0x4 */ unsigned long type; // MindPower::lwHelperInfoType 
		/* this+0x8 */ struct lwHelperDummyInfo * dummy_seq; 
		/* this+0xc */ struct lwHelperBoxInfo * box_seq; 
		/* this+0x10 */ struct lwHelperMeshInfo * mesh_seq; 
		/* this+0x14 */ struct lwBoundingBoxInfo * bbox_seq; 
		/* this+0x18 */ struct lwBoundingSphereInfo * bsphere_seq; 
		/* this+0x1c */ unsigned long dummy_num; 
		/* this+0x20 */ unsigned long box_num; 
		/* this+0x24 */ unsigned long mesh_num; 
		/* this+0x28 */ unsigned long bbox_num; 
		/* this+0x2c */ unsigned long bsphere_num; 

		long _LoadHelperDummyInfo(struct _iobuf *fp, unsigned long version) 
		{
			if (version >= 0x1001) {
			  fread(&(this->dummy_num), sizeof(unsigned long), 1, fp);
			  this->dummy_seq = new lwHelperDummyInfo[this->dummy_num];
			  fread(this->dummy_seq, sizeof(lwHelperDummyInfo), this->dummy_num, fp);
			} else if (version <= 0x1000) {
			  fread(&(this->dummy_num), sizeof(unsigned long), 1, fp);
			  lwHelperDummyInfo_1000 *old_s = new lwHelperDummyInfo_1000[this->dummy_num];
			  fread(old_s, sizeof(lwHelperDummyInfo_1000), this->dummy_num, fp);
			  this->dummy_seq = new lwHelperDummyInfo[this->dummy_num];
			  for (unsigned long i = 0; i < this->dummy_num; i++) {
				 this->dummy_seq[i].id = old_s[i].id;
				 this->dummy_seq[i].mat = old_s[i].mat;
				 this->dummy_seq[i].parent_type = 0;
				 this->dummy_seq[i].parent_id = 0;
			  };
			  delete [] old_s;
			};
			return 0;
		}
 
		long _LoadHelperBoxInfo(struct _iobuf *fp, unsigned long version) 
		{
			fread(&(this->box_num), sizeof(unsigned long), 1, fp);
			this->box_seq = new lwHelperBoxInfo[this->box_num];
			fread(this->box_seq, sizeof(lwHelperBoxInfo), this->box_num, fp);
			if (version <= 0x1001) {
			  lwBox_1001 old_b = lwBox_1001();
			  for (unsigned long i = 0; i < this->box_num; i++) {
				 lwBox *b = &this->box_seq[i].box;
				 old_b.p = b->c;
				 old_b.s = b->r;
				 b->r = old_b.s / 2;
				 b->c = old_b.p + b->r;
			  };
			};
			return 0;
		}
 
		long _LoadHelperMeshInfo(struct _iobuf *fp, unsigned long version) 
		{
			fread(&(this->mesh_num), sizeof(unsigned long), 1, fp);
			this->mesh_seq = new lwHelperMeshInfo[this->mesh_num];
			for (unsigned long i = 0; i < this->mesh_num; i++) {
			  lwHelperMeshInfo *info = &this->mesh_seq[i];
			  fread(&(info->id), sizeof(unsigned long), 1, fp);
			  fread(&(info->type), sizeof(unsigned long), 1, fp);
			  fread(&(info->sub_type), sizeof(unsigned long), 1, fp);
			  fread(&(info->name), 20, 1, fp); // sizeof(info->name) = 20;
			  fread(&(info->state), sizeof(unsigned long), 1, fp);
			  fread(&(info->mat), sizeof(D3DXMATRIX), 1, fp);
			  fread(&(info->box), sizeof(lwBox), 1, fp);
			  fread(&(info->vertex_num), sizeof(unsigned long), 1, fp);
			  fread(&(info->face_num), sizeof(unsigned long), 1, fp);
			  info->vertex_seq = new D3DXVECTOR3[info->vertex_num];
			  info->face_seq = new lwHelperMeshFaceInfo[info->face_num];
			  fread(info->vertex_seq, sizeof(D3DXVECTOR3), info->vertex_num, fp);
			  fread(info->face_seq, sizeof(lwHelperMeshFaceInfo), info->face_num, fp);
			};
			if (version <= 0x1001) {
			  lwBox_1001 old_b = lwBox_1001();
			  for(unsigned long i = 0; i < this->mesh_num; i++) {
				 lwBox *b = &this->mesh_seq[i].box;
				 old_b.p = b->c;
				 old_b.s = b->r;
				 b->r = old_b.s / 2;
				 b->c = old_b.p + b->r;
			  };
			};
			return 0;
		}
 
		long _LoadBoundingBoxInfo(struct _iobuf *fp, unsigned long version) 
		{
			fread(&(this->bbox_num), sizeof(unsigned long), 1, fp);
			this->bbox_seq = new lwBoundingBoxInfo[this->bbox_num];
			fread(this->bbox_seq, sizeof(lwBoundingBoxInfo), this->bbox_num, fp);
			if (version <= 0x1001) {
			  lwBox_1001 old_b = lwBox_1001();
			  for (unsigned long i = 0; i < this->bbox_num; i++) {
				 lwBox *b = &this->bbox_seq[i].box;
				 old_b.p = b->c;
				 old_b.s = b->r;
				 b->r = old_b.s / 2;
				 b->c = old_b.p + b->r;
			  };
			};
			return 0;
		}
 
		long _LoadBoundingSphereInfo(struct _iobuf *fp, unsigned long version) 
		{
			fread(&(this->bsphere_num), sizeof(unsigned long), 1, fp);
			this->bsphere_seq = new lwBoundingSphereInfo[this->bsphere_num];
			fread(this->bsphere_seq, sizeof(lwBoundingSphereInfo), this->bsphere_num, fp);
			return 0;
		}

		long Load(struct _iobuf *fp, unsigned long version) 
		{  
			if (version == 0) {
			  unsigned long old_version;
			  fread(&(old_version), sizeof(unsigned long), 1, fp); // No messing around with 'version' O_o
			};
			fread(&(this->type), sizeof(unsigned long), 1, fp);
			if (this->type & 0x1)
			  this->_LoadHelperDummyInfo(fp, version);
			if (this->type & 0x2)
			  this->_LoadHelperBoxInfo(fp, version);
			if (this->type & 0x4)
			  this->_LoadHelperMeshInfo(fp, version);
			if (this->type & 0x10)
			  this->_LoadBoundingBoxInfo(fp, version);
			if (this->type & 0x20)
			  this->_LoadBoundingSphereInfo(fp, version);
			return 0; 
		}
	};

	struct lwBoneBaseInfo 
	{ 
		/* this+0x0 */ char name[64]; 
		/* this+0x40 */ unsigned long id; 
		/* this+0x44 */ unsigned long parent_id; 
	};

	struct lwBoneDummyInfo 
	{ 
		/* this+0x0 */ unsigned long id; 
		/* this+0x4 */ unsigned long parent_bone_id; 
		/* this+0x8 */ struct D3DXMATRIX mat; 
	};

	class lwMatrix33 
	{ 
		/* this+0x0 */ float m[3][3]; 
	};

	class lwMatrix43 
	{ 
		/* this+0x0 */ float m[4][3]; 
	};

	struct lwBoneKeyInfo 
	{ 
		/* this+0x0 */ class lwMatrix43 * mat43_seq; 
		/* this+0x4 */ struct D3DXMATRIX * mat44_seq; 
		/* this+0x8 */ struct D3DXVECTOR3 * pos_seq; 
		/* this+0xc */ struct D3DXQUATERNION * quat_seq; 
	};

	class lwAnimDataBone 
	{ 
	public:
		/* this+0x4 */ struct lwBoneInfoHeader 
		{ 
			/* this+0x0 */ unsigned long bone_num; 
			/* this+0x4 */ unsigned long frame_num; 
			/* this+0x8 */ unsigned long dummy_num; 
			/* this+0xc */ unsigned long key_type; // MindPower::lwBoneKeyInfoType 
		} _header; 
		/* this+0x14 */ struct lwBoneBaseInfo * _base_seq; 
		/* this+0x18 */ struct lwBoneDummyInfo * _dummy_seq; 
		/* this+0x1c */ struct lwBoneKeyInfo * _key_seq; 
		/* this+0x20 */ struct D3DXMATRIX * _invmat_seq; 

		long Load(struct _iobuf *fp, unsigned long version) 
		{
		  if (version == 0) {
			 unsigned long old_version;
			 fread(&old_version, sizeof(unsigned long), 1, fp);
			 int x = 0;
		  };
		  if (this->_base_seq) {
			 return -1;
		  };
		  fread(&(this->_header), sizeof(lwAnimDataBone::lwBoneInfoHeader), 1, fp);
		  this->_base_seq = new lwBoneBaseInfo[this->_header.bone_num];
		  this->_key_seq = new lwBoneKeyInfo[this->_header.bone_num];
		  this->_invmat_seq = new D3DXMATRIX[this->_header.bone_num];
		  this->_dummy_seq = new lwBoneDummyInfo[this->_header.dummy_num];
		  fread(this->_base_seq, sizeof(lwBoneBaseInfo), this->_header.bone_num, fp);
		  fread(this->_invmat_seq, sizeof(D3DXMATRIX), this->_header.bone_num, fp);
		  fread(this->_dummy_seq, sizeof(lwBoneDummyInfo), this->_header.dummy_num, fp);
		  if (this->_header.key_type == 1) {
			 for (unsigned long i = 0; i < this->_header.bone_num; i++) {
				lwBoneKeyInfo *key = &this->_key_seq[i];
				key->mat43_seq = new lwMatrix43[this->_header.frame_num];
				fread(key->mat43_seq, sizeof(lwMatrix43), this->_header.frame_num, fp);
			 };
		  } else if (this->_header.key_type == 2) {
			 for (unsigned long i = 0; i < this->_header.bone_num; i++) {
				lwBoneKeyInfo *key = &this->_key_seq[i];
				key->mat44_seq = new D3DXMATRIX[this->_header.frame_num];
				fread(key->mat44_seq, sizeof(D3DXMATRIX), this->_header.frame_num, fp);
			 };
		  } else if (this->_header.key_type == 3) {
			 if (version >= 0x1003) {
				for (unsigned long i = 0; i < this->_header.bone_num; i++) {
					lwBoneKeyInfo *key = &this->_key_seq[i];
					key->pos_seq = new D3DXVECTOR3[this->_header.frame_num];
					fread(key->pos_seq, sizeof(D3DXVECTOR3), this->_header.frame_num, fp);
					key->quat_seq = new D3DXQUATERNION[this->_header.frame_num];
					fread(key->quat_seq, sizeof(D3DXQUATERNION), this->_header.frame_num, fp);
				};
			 } else {
				for (unsigned long i = 0; i < this->_header.bone_num; i++) {
				  lwBoneKeyInfo *key = &this->_key_seq[i];
				  unsigned long pos_num = this->_base_seq[i].parent_id == -1 ? this->_header.frame_num : 1;
				  key->pos_seq = new D3DXVECTOR3[this->_header.frame_num];
				  fread(key->pos_seq, sizeof(D3DXVECTOR3), pos_num, fp);
				  if (pos_num == 1) {
					 for (unsigned long j = 1; j < this->_header.frame_num; j++) {
						key->pos_seq[i] = key->pos_seq[0];
					 };
				  };
				  key->quat_seq = new D3DXQUATERNION[this->_header.frame_num];
				  fread(key->quat_seq, sizeof(D3DXQUATERNION), this->_header.frame_num, fp);
				};
			 };
		  };
		  return 0;
		  }

		virtual long Load(const char * file) 
		{
		  long ret = -1;
		  _iobuf *fp = fopen(file, "rb");
		  if (fp) {
			 unsigned long version;
			 fread(&version, sizeof(unsigned long), 1, fp);
			 if ( version < 0x1000 ) {
				version = 0;
				char buf[256];
				sprintf(buf, "old animation file: %s, need re-export it", file);
				MessageBoxA(0, buf, "warning", 0);
			 };
			 if (this->Load(fp, version) >= 0) { // Overloaded version
				 ret = 0;
			 }
		  };
		  if (fp)
			 fclose(fp);
		  return ret;
		}
	};

	class lwAnimDataMatrix 
	{ 
	public:
		/* this+0x4 */ class lwMatrix43 * _mat_seq; 
		/* this+0x8 */ unsigned long _frame_num; 

		long __thiscall Load(struct _iobuf *fp, unsigned long version) 
		{  
			fread(&(this->_frame_num), sizeof(unsigned long), 1, fp);
			this->_mat_seq = new lwMatrix43[this->_frame_num];
			fread(this->_mat_seq, sizeof(lwMatrix43), this->_frame_num, fp);
			return 0;
		}
	};

	struct lwKeyFloat 
	{ 
		/* this+0x0 */ unsigned long key; 
		/* this+0x4 */ unsigned long slerp_type; 
		/* this+0x8 */ float data; 
	};

	class lwIAnimKeySetFloat
	{
	public:
		virtual unsigned long SetKeySequence(lwKeyFloat *seq,unsigned long num) = 0;
	};
	class lwAnimKeySetFloat : public lwIAnimKeySetFloat
	{ 
	public:
		/* this+0x4 */ struct lwKeyFloat * _data_seq; 
		/* this+0x8 */ unsigned long _data_num; 
		/* this+0xc */ unsigned long _data_capacity; 

		unsigned long SetKeySequence(lwKeyFloat *seq,unsigned long num){_data_seq=seq;_data_num=num;_data_capacity=num;return 0;}
	};

	struct lwAnimDataMtlOpacity 
	{ 
	public:
		/* this+0x4 */ class lwIAnimKeySetFloat * _aks_ctrl; 

		long Load(struct _iobuf *fp, unsigned long version) 
		{
		  long ret = -1;
		  unsigned long num;
		  fread(&(num), sizeof(unsigned long), 1, fp);
		  lwKeyFloat *seq = new lwKeyFloat[num];
		  fread(seq, sizeof(lwKeyFloat), num, fp);
		  this->_aks_ctrl = new lwAnimKeySetFloat();
		  if (this->_aks_ctrl->SetKeySequence(seq, num) >= 0) {
			  ret = 0;
		  };
		  return ret;
		  }
	};

	struct lwAnimDataTexUV 
	{ 
	public:
		/* this+0x4 */ struct D3DXMATRIX * _mat_seq; 
		/* this+0x8 */ unsigned long _frame_num; 

		long Load(struct _iobuf *fp, unsigned long version) 
		{
			fread(&(this->_frame_num), sizeof(unsigned long), 1, fp);
			this->_mat_seq = new D3DXMATRIX[this->_frame_num];
			fread(this->_mat_seq, sizeof(D3DXMATRIX), this->_frame_num, fp);
			return 0;
		}
	};

	class lwAnimDataTexImg 
	{ 
	public:
		/* this+0x4 */ struct lwTexInfo * _data_seq; 
		/* this+0x8 */ unsigned long _data_num; 
		/* this+0xc */ char _tex_path[260]; 

		long Load(struct _iobuf *fp, unsigned long version) 
		{
		  long ret = 0;
		  if (version == 0) {
			 char buf[256];
			 sprintf(buf, "old version file, need	  re-export it");
			 MessageBoxA(0, buf, "warning", 0);
			 ret = -1;
		  } else {
			 fread(&(this->_data_num), sizeof(unsigned long), 1, fp);
			 this->_data_seq = new lwTexInfo[this->_data_num];
			 fread(this->_data_seq, sizeof(lwTexInfo), this->_data_num, fp);
		  };
		  return ret;
		}
	};

	class lwAnimDataInfo 
	{ 
	public: 
		/* this+0x4 */ class lwAnimDataBone * anim_bone; 
		/* this+0x8 */ class lwAnimDataMatrix * anim_mat; 
		/* this+0xc */ struct lwAnimDataMtlOpacity * anim_mtlopac[16]; 
		/* this+0x4c */ struct lwAnimDataTexUV * anim_tex[16][4]; 
		/* this+0x14c */ class lwAnimDataTexImg * anim_img[16][4]; 

		long  Load(struct _iobuf *fp, unsigned long version) 
		{
			if (version == 0) {
			  unsigned long old_version;
			  fread(&(old_version), sizeof(unsigned long), 1, fp);
			};
			unsigned long data_bone_size;
			unsigned long data_mat_size;
			unsigned long data_mtlopac_size[16];
			unsigned long data_texuv_size[16][4];
			unsigned long data_teximg_size[16][4];
			fread(&(data_bone_size), sizeof(unsigned long), 1, fp);
			fread(&(data_mat_size), sizeof(unsigned long), 1, fp);
			if (version >= 4001) {
			  fread(&(data_mtlopac_size[0]), sizeof(data_mtlopac_size), 1, fp);
			};
			fread(&(data_texuv_size[0][0]), sizeof(data_texuv_size), 1, fp);
			fread(&(data_teximg_size[0][0]), sizeof(data_teximg_size), 1, fp);
			if (version > 0) {
			  this->anim_bone = new lwAnimDataBone();
			  this->anim_bone->Load(fp, version);
			};
			if (data_mat_size > 0) {
			  this->anim_mat = new lwAnimDataMatrix();
			  this->anim_mat->Load(fp, version);
			};
			if (version >= 0x1005) {
			  for (unsigned long i = 0; i < 16; i++) {
				 if (data_mtlopac_size[i] == 0 )
					continue;
				 this->anim_mtlopac[i] = new lwAnimDataMtlOpacity();
				 this->anim_mtlopac[i]->Load(fp, version);
			  };
			};
			for(unsigned long i = 0; i < 16; i++) {
			  for(unsigned long j = 0; j < 4; j++) {
				 if (data_texuv_size[i][j] == 0 )
					continue;
				 this->anim_tex[i][j] = new lwAnimDataTexUV();
				 this->anim_tex[i][j]->Load(fp, version);
			  };
			};
			for (unsigned long i = 0; i < 16; i++) {
			  for(unsigned long j = 0; j < 4; j++) {
				 if (data_teximg_size[i][j] == 0 )
					continue;
				 this->anim_img[i][j] = new lwAnimDataTexImg();
				 this->anim_img[i][j]->Load(fp, version);
			  };
			};
			return 0;
		}
	};

	long __cdecl lwMtlTexInfo_Load(struct lwMtlTexInfo *info, struct _iobuf *fp, unsigned long version) 
	{
		if (version >= 0x1000) {
			fread(&(info->opacity), sizeof(float), 1, fp);
			fread(&(info->transp_type), sizeof(unsigned long), 1, fp);
			fread(&(info->mtl), sizeof(lwMaterial), 1, fp);
			fread(&(info->rs_set), sizeof(lwRenderStateAtom)*8, 1, fp);
			fread(&(info->tex_seq), sizeof(lwTexInfo)*4, 1, fp);
		} else if (version == 2) {
			fread(&(info->opacity), sizeof(float), 1, fp);
			fread(&(info->transp_type), sizeof(unsigned long), 1, fp);
			fread(&(info->mtl), sizeof(lwMaterial), 1, fp);
			fread(&(info->rs_set), sizeof(lwRenderStateAtom)*8, 1, fp);
			fread(&(info->tex_seq), sizeof(lwTexInfo)*4, 1, fp);
		} else if (version == 1) {
		 fread(&(info->opacity), sizeof(float), 1, fp);
		 fread(&(info->transp_type), sizeof(unsigned long), 1, fp);
		 fread(&(info->mtl), sizeof(lwMaterial), 1, fp);
		 lwRenderStateSetTemplate<2,8> rsm;
		 fread(&rsm, sizeof(lwRenderStateSetTemplate<2,8>), 1, fp);
		 lwTexInfo_0001 tex_info[4];
		 fread(&tex_info, sizeof(lwTexInfo_0001)*4, 1, fp);
		 for (unsigned long i = 0; i < 8; i++) {
			 lwRenderStateValue *rsv = &(rsm.rsv_seq[0][i]);
			if (rsv->state == -1)
			  break;
			unsigned long v;
			if (rsv->state == 25) {
			  v = 5;
			} else if (rsv->state == 24) {
			  v = 129;
			} else {
			  v = rsv->value;
			};
			info->rs_set[i].state = rsv->state;
			info->rs_set[i].value0 = v;
			info->rs_set[i].value1 = v;
		 };
		 for (unsigned long i = 0; i < 4; i++) {
			lwTexInfo_0001 *p = &(tex_info[i]);
			if (p->stage == -1)
			  break;
			lwTexInfo *t = &(info->tex_seq[i]);
			t->level = p->level;
			t->usage = p->usage;
			t->pool = p->pool;
			t->type = p->type;
			t->width = p->width;
			t->height = p->height;
			t->stage = p->stage;
			t->format = p->format;
			t->colorkey = p->colorkey;
			t->colorkey_type = p->colorkey_type;
			t->byte_alignment_flag = p->byte_alignment_flag;
			strcpy(t->file_name, p->file_name);
			for (unsigned long j = 0; j < 8; j++) {
			  lwRenderStateValue *rsv = &(p->tss_set.rsv_seq[j][0]);
			  if (rsv->state == -1)
				 break;
			  t->tss_set[j].state = rsv->state;
			  t->tss_set[j].value0 = rsv->value;
			  t->tss_set[j].value1 = rsv->value;
			};
		 };
	  } else if (version == 0) {
		 fread(&(info->mtl),sizeof(lwMaterial), 1, fp);
		 lwRenderStateSetTemplate<2,8> rsm;
		 fread(&(rsm), sizeof(lwRenderStateSetTemplate<2,8>), 1, fp);
		 lwTexInfo_0000 tex_info[4];
		 fread(&(tex_info), sizeof(lwTexInfo_0000)*4, 1, fp);
		 for (unsigned long i = 0; i < 8; i++) {
			lwRenderStateValue *rsv = &(rsm.rsv_seq[0][i]);
			if (rsv->state == -1)
			  break;
			unsigned long v;
			if (rsv->state == 25) {
			  v = 5;
			} else if (rsv->state == 24) {
			  v = 129;
			} else {
			  v = rsv->value;
			};
			info->rs_set[i].state = rsv->state;
			info->rs_set[i].value0 = v;
			info->rs_set[i].value1 = v;
		 };
		 for (unsigned long i = 0; i < 4; i++) {
			lwTexInfo_0000 *p = &(tex_info[i]);
			if (p->stage == -1)
			  break;
			lwTexInfo *t = &(info->tex_seq[i]);
			t->level = 1;
			t->usage = 0;
			t->pool = (_D3DPOOL)0;
			t->type = 0;
			t->stage = p->stage;
			t->format = p->format;
			t->colorkey = p->colorkey;
			t->colorkey_type = p->colorkey_type;
			t->byte_alignment_flag = 0;
			strcpy(t->file_name, p->file_name);
			for (unsigned long j = 0; j < 8; j++) {
			  lwRenderStateValue *rsv = &(p->tss_set.rsv_seq[0][j]);
			  if (rsv->state == -1)
				 break;
			  t->tss_set[j].state = rsv->state;
			  t->tss_set[j].value0 = rsv->value;
			  t->tss_set[j].value1 = rsv->value;
			};
		 };
		 if ( info->tex_seq[0].format == 26 )
			info->tex_seq[0].format = (_D3DFORMAT)25;
	  } else {
		 MessageBoxA(0, "invalid file version", "error", 0);
		 return -1;
	  };
	  info->tex_seq[0].pool = (_D3DPOOL)1;
	  info->tex_seq[0].level = 3;
	  int transp_flag = 0;
	  unsigned long i;
	  for (i = 0; i < 8; i++) {
		 lwRenderStateAtom *rsa = &info->rs_set[i];
		 if (rsa->state == -1 )
			break;
		 if ((rsa->state == 20)&&((rsa->value0 == 2)||(rsa->value0 == 4)))
			transp_flag = 1;
		 if ((rsa->state == 137)&&(rsa->value0 == 0))
			transp_flag++;
	  };
	  if ((transp_flag == 1)&&(i < 7));
		//RSA_VALUE(&(info->rs_set[i]), 137, 0);  //endcrypt
	  return 0;
  }

	long __cdecl lwLoadMtlTexInfo(struct lwMtlTexInfo **out_buf, unsigned long *out_num, struct _iobuf *fp, unsigned long version) 
	{
		lwMtlTexInfo *buf;
		unsigned long num = 0;
		if (version == 0) {
		  unsigned long old_version;
		  fread(&old_version, sizeof(unsigned long), 1, fp);
		  version = old_version;
		};
		fread(&num, sizeof(unsigned long), 1, fp);
		buf = new lwMtlTexInfo[num];
		for (unsigned long i = 0; i < num; i++) {
		  lwMtlTexInfo_Load(&(buf[i]), fp, version);
		}
		*out_buf = buf;
		*out_num = num;
		return 0;
	}
 
	long __cdecl lwMeshInfo_Load(struct lwMeshInfo *info, struct _iobuf *fp, unsigned long version) 
	{
	if (version == 0) {
	  unsigned long old_version;
	  fread(&(old_version), sizeof(unsigned long), 1, fp);
	  version = old_version;
	};
	if (version >= 0x1004) {
	  fread(&(info->header), sizeof(lwMeshInfo::lwMeshInfoHeader), 1, fp);
	} else if (version >= 0x1003) {
	  lwMeshInfo_0003::lwMeshInfoHeader header;
	  fread(&(header), sizeof(lwMeshInfo_0003::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header.fvf;
	  info->header.pt_type = header.pt_type;
	  info->header.vertex_num = header.vertex_num;
	  info->header.index_num = header.index_num;
	  info->header.subset_num = header.subset_num;
	  info->header.bone_index_num = header.bone_index_num;
	  info->header.bone_infl_factor = info->header.bone_index_num > 0 ? 2 : 0;
	  info->header.vertex_element_num = 0;
	} else if ((version >= 0x1000)||(version == 1)) {
	  lwMeshInfo_0003::lwMeshInfoHeader header;
	  fread(&header, sizeof(lwMeshInfo_0003::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header.fvf;
	  info->header.pt_type = header.pt_type;
	  info->header.vertex_num = header.vertex_num;
	  info->header.index_num = header.index_num;
	  info->header.subset_num = header.subset_num;
	  info->header.bone_index_num = header.bone_index_num;
	  info->header.bone_infl_factor = info->header.bone_index_num > 0 ? 2 : 0;
	  info->header.vertex_element_num = 0;
	} else if (version == 0) {
	  lwMeshInfo_0000::lwMeshInfoHeader header;
	  fread(&header, sizeof(lwMeshInfo_0000::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header.fvf;
	  info->header.pt_type = header.pt_type;
	  info->header.vertex_num = header.vertex_num;
	  info->header.index_num = header.index_num;
	  info->header.subset_num = header.subset_num;
	  info->header.bone_index_num = header.bone_index_num;
	  for (unsigned long j = 0; j < 8; j++) {
		  lwRenderStateValue *rsv = &header.rs_set.rsv_seq[j][0];
		 if (rsv->state == -1)
			break;
		 unsigned long v;
		 if (rsv->state == 147) {
			v = 2;
		 } else {
			v = rsv->value;
		 };
		 info->header.rs_set[j].state = rsv->state;
		 info->header.rs_set[j].value0 = v;
		 info->header.rs_set[j].value1 = v;
	  };
	} else {
	  MessageBoxA(0, "invalid version", "error", 0);
	};
	if (version >= 0x1004) {
	  if (info->header.vertex_element_num > 0) {
		 info->vertex_element_seq = new _D3DVERTEXELEMENT9[info->header.vertex_element_num];
		 fread(info->vertex_element_seq, sizeof(_D3DVERTEXELEMENT9), info->header.vertex_element_num, fp);
	  };
	  if (info->header.vertex_num > 0) {
		 info->vertex_seq = new D3DXVECTOR3[info->header.vertex_num];
		 fread(info->vertex_seq, sizeof(D3DXVECTOR3), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x10) {
		 info->normal_seq = new D3DXVECTOR3[info->header.vertex_num];
		 fread(info->normal_seq, sizeof(D3DXVECTOR3), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x100) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x200) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x300) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x400) {
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord3_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord3_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x40) {
		 info->vercol_seq = new unsigned long[info->header.vertex_num];
		 fread(info->vercol_seq, sizeof(unsigned long), info->header.vertex_num, fp);
	  };
	  if (info->header.bone_index_num > 0) {
		 info->blend_seq = new lwBlendInfo[info->header.vertex_num];
		 info->bone_index_seq = new unsigned long[info->header.bone_index_num];
		 fread(info->blend_seq, sizeof(lwBlendInfo), info->header.vertex_num, fp);
		 fread(info->bone_index_seq, sizeof(unsigned long), info->header.bone_index_num, fp);
	  };
	  if (info->header.index_num > 0) {
		 info->index_seq = new unsigned long[info->header.index_num];
		 fread(info->index_seq, sizeof(unsigned long), info->header.index_num, fp);
	  };
	  if (info->header.subset_num > 0) {
		 info->subset_seq = new lwSubsetInfo[info->header.subset_num];
		 fread(info->subset_seq, sizeof(lwSubsetInfo), info->header.subset_num, fp);
	  };
	} else {
	  info->subset_seq = new lwSubsetInfo[info->header.subset_num];
	  fread(info->subset_seq, sizeof(lwSubsetInfo), info->header.subset_num, fp);
	  info->vertex_seq = new D3DXVECTOR3[info->header.vertex_num];
	  fread(info->vertex_seq, sizeof(D3DXVECTOR3), info->header.vertex_num, fp);
	  if (info->header.fvf & 0x10) {
		 info->normal_seq = new D3DXVECTOR3[info->header.vertex_num];
		 fread(info->normal_seq, sizeof(D3DXVECTOR3), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x100) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x200) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x300) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  } else if (info->header.fvf & 0x400) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->header.vertex_num];
		 info->texcoord3_seq = new D3DXVECTOR2[info->header.vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
		 fread(info->texcoord3_seq, sizeof(D3DXVECTOR2), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x40) {
		 info->vercol_seq = new unsigned long[info->header.vertex_num];
		 fread(info->vercol_seq, sizeof(unsigned long), info->header.vertex_num, fp);
	  };
	  if (info->header.fvf & 0x1000) {
		 info->blend_seq = new lwBlendInfo[info->header.vertex_num];
		 unsigned char *byte_index_seq = new unsigned char[info->header.bone_index_num];
		 fread(info->blend_seq, sizeof(lwBlendInfo), info->header.vertex_num, fp);
		 fread(byte_index_seq, sizeof(char), info->header.bone_index_num, fp);
		 info->bone_index_seq = new unsigned long[info->header.bone_index_num];
		 for (unsigned long i = 0; ; i++) {
			info->bone_index_seq[i] = (char)byte_index_seq[i];
		 };
		 delete [] byte_index_seq;
	  };
	  if (info->header.index_num > 0) {
		 info->index_seq = new unsigned long[info->header.index_num];
		 fread(info->index_seq, sizeof(unsigned long), info->header.index_num, fp);
	  };
	};
	return 0; 
}

	struct lwGeomObjInfo 
	{ 
	public:
		/* this+0x4 */   struct lwGeomObjInfoHeader 
		{ 
			/* this+0x0 */	unsigned long id; 
			/* this+0x4 */	unsigned long parent_id; 
			/* this+0x8 */	unsigned long type; // MindPower::lwModelObjectLoadType ??? 
			/* this+0xc */	struct D3DXMATRIX mat_local; 
			/* this+0x4c */ struct lwRenderCtrlCreateInfo rcci; 
			/* this+0x5c */ class lwStateCtrl state_ctrl; 
			/* this+0x64 */ unsigned long mtl_size; 
			/* this+0x68 */ unsigned long mesh_size; 
			/* this+0x6c */ unsigned long helper_size; 
			/* this+0x70 */ unsigned long anim_size; 
		} header; 
		/* this+0x78 */	 unsigned long mtl_num; 
		/* this+0x7c */  struct lwMtlTexInfo * mtl_seq; 
		/* this+0x80 */  struct lwMeshInfo mesh; 
		/* this+0x130 */ struct lwHelperInfo helper_data;
		/* this+0x160 */ class lwAnimDataInfo anim_data; 

		long Load(FILE *fp, unsigned long version) 
		{
			fread(&(this->header), sizeof(lwGeomObjInfo::lwGeomObjInfoHeader), 1, fp); // read a structure of MindPower::lwGeomObjInfo::lwGeomObjInfoHeader
			this->header.state_ctrl.SetState(5, 0);
			this->header.state_ctrl.SetState(3, 1);
			if (this->header.mtl_size > 100000) {
				MessageBoxA(0,"iii", "error", 0);
				return -1;
			};
			if (this->header.mtl_size > 0)
				lwLoadMtlTexInfo(&this->mtl_seq, &this->mtl_num, fp, version);
			if (this->header.mesh_size > 0)
				lwMeshInfo_Load(&(this->mesh), fp, version);
			if (this->header.helper_size > 0)
				this->helper_data.Load(fp, version);
			if (this->header.anim_size > 0)
				this->anim_data.Load(fp, version);
			return 0;
		}
		virtual long Load(const char * file) 
		{	
			FILE *fp = fopen(file, "rb");
			if (!fp)
				return -1;
			unsigned long version;
			fread(&version, 4, 1, fp);
			long ret = this->Load(fp, version);
			if (fp)
				fclose(fp);
			return ret;
		}
	};
}

int main()
{
	//D:\Games\TalesOfPirate\Пиратия Online\model\item

	Mindpower::lwGeomObjInfo obj;
	obj.Load("D:/Games/TalesOfPirate/Пиратия Online/model/character/0170000000.lgo");

	return 0;
}