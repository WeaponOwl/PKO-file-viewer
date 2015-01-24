#include "MindpowerModelsNet.h"
#include <cstring>
#include <Windows.h>

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

void __thiscall MindpowerModelsNet::lwStateCtrl::SetState(unsigned long state, unsigned char value)
{
	this->_state_seq[state] = value;
}

long __thiscall MindpowerModelsNet::lwHelperInfo::_LoadHelperDummyInfo(FILE *fp, unsigned long version) 
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
long __thiscall MindpowerModelsNet::lwHelperInfo::_LoadHelperBoxInfo(FILE *fp, unsigned long version) 
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
long __thiscall MindpowerModelsNet::lwHelperInfo::_LoadHelperMeshInfo(FILE *fp, unsigned long version) 
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
long __thiscall MindpowerModelsNet::lwHelperInfo::_LoadBoundingBoxInfo(FILE *fp, unsigned long version) 
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
long __thiscall MindpowerModelsNet::lwHelperInfo::_LoadBoundingSphereInfo(FILE *fp, unsigned long version) 
{
	fread(&(this->bsphere_num), sizeof(unsigned long), 1, fp);
	this->bsphere_seq = new lwBoundingSphereInfo[this->bsphere_num];
	fread(this->bsphere_seq, sizeof(lwBoundingSphereInfo), this->bsphere_num, fp);
	return 0;
}

long __thiscall MindpowerModelsNet::lwHelperInfo::Load(FILE *fp, unsigned long version) 
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

long __thiscall MindpowerModelsNet::lwAnimDataBone::Load(struct _iobuf *fp, unsigned long version) 
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

long __thiscall MindpowerModelsNet::lwAnimDataBone::Load(const char * file) 
{
  long ret = -1;
  FILE *fp = fopen(file, "rb");
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

long __thiscall __thiscall MindpowerModelsNet::lwAnimDataMatrix::Load(struct _iobuf *fp, unsigned long version) 
{  
	fread(&(this->_frame_num), sizeof(unsigned long), 1, fp);
	this->_mat_seq = new lwMatrix43[this->_frame_num];
	fread(this->_mat_seq, sizeof(lwMatrix43), this->_frame_num, fp);
	return 0;
}

unsigned long __thiscall MindpowerModelsNet::lwAnimKeySetFloat::SetKeySequence(lwKeyFloat *seq,unsigned long num)
{
	_data_seq=seq;
	_data_num=num;
	_data_capacity=num;
	return 0;
}

long __thiscall MindpowerModelsNet::lwAnimDataMtlOpacity::Load(struct _iobuf *fp, unsigned long version) 
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

long __thiscall MindpowerModelsNet::lwAnimDataTexUV::Load(struct _iobuf *fp, unsigned long version) 
{
	fread(&(this->_frame_num), sizeof(unsigned long), 1, fp);
	this->_mat_seq = new D3DXMATRIX[this->_frame_num];
	fread(this->_mat_seq, sizeof(D3DXMATRIX), this->_frame_num, fp);
	return 0;
}

long __thiscall MindpowerModelsNet::lwAnimDataTexImg::Load(struct _iobuf *fp, unsigned long version) 
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

long __thiscall MindpowerModelsNet::lwAnimDataInfo::Load(struct _iobuf *fp, unsigned long version) 
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

long __cdecl MindpowerModelsNet::lwMtlTexInfo_Load(struct lwMtlTexInfo *info, struct _iobuf *fp, unsigned long version) 
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

long __cdecl MindpowerModelsNet::lwLoadMtlTexInfo(struct lwMtlTexInfo **out_buf, unsigned long *out_num, struct _iobuf *fp, unsigned long version) 
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
 
long __cdecl MindpowerModelsNet::lwMeshInfo_Load(struct lwMeshInfo *info, struct _iobuf *fp, unsigned long version) 
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

long __thiscall MindpowerModelsNet::lwGeomObjInfo::Load(FILE *fp, unsigned long version) 
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
long __thiscall MindpowerModelsNet::lwGeomObjInfo::Load(const char * file) 
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

long __thiscall MindpowerModelsNet::lwModelObjInfo::Load(const char *file) 
{  
	FILE *fp = fopen(file, "rb");
	if ( !fp )
	  return -1;
	unsigned long version;
	fread(&version, sizeof(unsigned long), 1, fp);
	unsigned long obj_num;
	fread(&obj_num, sizeof(unsigned long), 1, fp);
	lwModelObjInfo::lwModelObjInfoHeader header[33];
	fread(&header, sizeof(lwModelObjInfo::lwModelObjInfoHeader), obj_num, fp);
	this->geom_obj_num = 0;
	for (unsigned long i = 0; i < obj_num; i++) {
	  fseek(fp, header[i].addr, 0);
	  if (header[i].type == 1) {
		 this->geom_obj_seq[this->geom_obj_num] = new lwGeomObjInfo();
		 if ( version == 0) {
			unsigned long old_version;
			fread(&old_version, 4, 1, fp);
		 }
		 this->geom_obj_seq[this->geom_obj_num]->Load(fp, version);
		 this->geom_obj_num++;
	  } else if (header[i].type == 2) {
		 this->helper_data.Load(fp, version);
	  };
	};
	if (fp)
	  fclose(fp);
	return 0; 
}

unsigned long __cdecl MindpowerModelsNet::__tree_proc_find_node(class lwITreeNode *,void *)
{
	return 0;
}
void __thiscall MindpowerModelsNet::lwTreeNode::_SetRegisterID(void *)
{
	;
}
long __thiscall MindpowerModelsNet::lwTreeNode::EnumTree(unsigned long (__cdecl*)(class lwITreeNode *,void *),void *,unsigned long)
{
	return 0;
}
long __thiscall MindpowerModelsNet::lwTreeNode::InsertChild(lwITreeNode *,lwITreeNode *)
{
	return 0;
}
long __thiscall MindpowerModelsNet::lwModelNodeInfo::Load(FILE *,unsigned long)
{
	return 0;
}
long __thiscall MindpowerModelsNet::lwModelInfo::Load(const char *file) 
{  
	long ret = -1;
	FILE *fp = fopen(file, "rb");
	if (!fp) 
	{
		fclose(fp);
		return ret; 
	};
	fread(&this->_head, sizeof(lwModelHeadInfo), 1, fp);
	unsigned long obj_num;
	fread(&obj_num, sizeof(unsigned long), 1, fp);
	if (obj_num == 0) 
	{
		ret = 0;
		if (fp)
			fclose(fp);
		return ret; 
	};
	lwITreeNode *tree_node = 0;
	lwModelNodeInfo *node_info = 0;
	for (unsigned long i = 0; i < obj_num; i++) 
	{
		node_info = new lwModelNodeInfo();
		if (node_info->Load(fp, this->_head.version) < 0) 
		{
			delete node_info;
			if (fp)
				fclose(fp);
			return ret; 
		}
		tree_node = new lwTreeNode();
		((lwTreeNode*)tree_node)->_SetRegisterID((void *)node_info); // MindPower::lwTreeNode::_SetRegisterID(unsigned long)
	  if (this->_obj_tree == 0) 
	  {
		 this->_obj_tree = tree_node;
	  } 
	  else 
	  {
		 __find_info param;
		 param.handle = node_info->_head.parent_handle;
		 param.node = 0;
		 this->_obj_tree->EnumTree(__tree_proc_find_node, &param, 0);
		 if (param.node == 0) 
		 {
			if (fp)
				fclose(fp);
			return ret; 
		 };
		 if (param.node->InsertChild(0, tree_node) < 0) {
			if (fp)
				fclose(fp);
			return ret; 
		 };
	  };
	};
	ret = 0;
	if (fp)
	 fclose(fp);
	return ret; 
}