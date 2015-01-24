// .lgo
public: virtual long __thiscall MindPower::lwGeomObjInfo::Load(const char * file) 
{	
	_iobuf *fp = fopen(file, "rb");
	if (!fp)
	  return -1;
	unsigned long version;
	fread(*version, 4, 1, fp);
	long ret = this->Load(fp, version);
	if (fp)
	  fclose(fp);
	return ret;
}
 
public: long __thiscall MindPower::lwGeomObjInfo::Load(struct _iobuf *fp, unsigned long version) 
{
	fread(*(this->id), sizeof(MindPower::lwGeomObjInfo::lwGeomObjInfoHeader), 1, fp); // read a structure of MindPower::lwGeomObjInfo::lwGeomObjInfoHeader
	this->state_ctrl.SetState(5, 0);
	this->state_ctrl.SetState(3, 1);
	if (this->mtl_size > 100000) {
	  MessageBoxA(0,"iii", "error", 0);
	  return -1;
	};
	if (this->mtl_size > 0)
	  MindPower::lwLoadMtlTexInfo(this->mtl_seq, this->mtl_num, fp, version);
	if (this->mesh_size > 0)
	  MindPower::lwMeshInfo_Load(*(this->mesh), fp, version);
	if (this->helper_size > 0)
	  this->helper_data.Load(fp, version);
	if (this->anim_size > 0)
	  this->anim_data.Load(fp, version);
	return 0;
}
 
public: void __thiscall MindPower::lwStateCtrl::SetState(unsigned long state, unsigned char value) 
{
	this->_state_seq = value;
}
 
long __cdecl MindPower::lwLoadMtlTexInfo(struct MindPower::lwMtlTexInfo **out_buf, unsigned long *out_num, struct _iobuf *fp, unsigned long version) 
{
	MindPower::lwMtlTexInfo *buf;
	unsigned long num = 0;
	if (version == 0) {
	  unsigned long old_version;
	  fread(*old_version, sizeof(unsigned long), 1, fp);
	  version = old_version;
	};
	fread(*num, sizeof(unsigned long), 1, fp);
	buf = new (MindPower::lwMtlTexInfo())[num];
	for (unsigned long i = 0; i < num; i++) {
	  MindPower::lwMtlTexInfo_Load(*(buf[i]), fp, version);
	}
	*out_buf = buf;
	out_num = num;
	return 0;
}
 
long __cdecl MindPower::lwMtlTexInfo_Load(struct MindPower::lwMtlTexInfo *info, struct _iobuf *fp, unsigned long version) 
{
	if (version >= 0x1000) {
		fread(*(info->opacity), sizeof(float), 1, fp);
		fread(*(info->transp_type), sizeof(unsigned long), 1, fp);
		fread(*(info->mtl), sizeof(MindPower::lwMaterial), 1, fp);
		fread(*(info->rs_set), sizeof(MindPower::lwRenderStateAtom)*8, 1, fp);
		fread(*(info->tex_seq), sizeof(MindPower::lwTexInfo)*4, 1, fp);
	} else if (version = 2) {
		fread(*(info->opacity), sizeof(float), 1, fp);
		fread(*(info->transp_type), sizeof(unsigned long), 1, fp);
		fread(*(info->mtl), sizeof(MindPower::lwMaterial), 1, fp);
		fread(*(info->rs_set), sizeof(MindPower::lwRenderStateAtom)*8, 1, fp);
		fread(*(info->tex_seq), sizeof(MindPower::lwTexInfo)*4, 1, fp);
	} else if (version = 1) {
	 fread(*(info->opacity), sizeof(float), 1, fp);
	 fread(*(info->transp_type), sizeof(unsigned long), 1, fp);
	 fread(*(info->mtl), sizeof(MindPower::lwMaterial), 1, fp);
	 MindPower::lwRenderStateSetTemplate<2,8> rsm;
	 fread(*rsm, sizeof(MindPower::lwRenderStateSetTemplate<2,8>), 1, fp);
	 MindPower::lwTexInfo_0001 tex_info[4];
	 fread(*tex_info, sizeof(MindPower::lwTexInfo_0001)*4, 1, fp);
	 for (unsigned long i = 0; i < 8; i++) {
		MindPower::lwRenderStateValue *rsv = *(rsm[0][i]);
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
		MindPower::lwTexInfo_0001 *p = *(tex_info[i]);
		if (p->state == -1)
		  break;
		MindPower::lwTexInfo *t = *(info->tex_seq[i])
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
		for (unsigned long j = 0; j < 8, j++) {
		  MindPower::lwRenderStateValue *rsv = *(p->tss_set[j][0]);
		  if (rsv->state == -1)
			 break;
		  t->tss_set[j].state = rsv->state;
		  t->tss_set[j].value0 = rsv->value;
		  t->tss_set[j].value1 = rsv->value;
		};
	 };
  } else if (version == 0) {
	 fread(*(info->mtl),sizeof(MindPower::lwMaterial), 1, fp);
	 MindPower::lwRenderStateSetTemplate<2,8> rsm;
	 fread(*(rsm), sizeof(MindPower::lwRenderStateSetTemplate<2,8>), 1, fp);
	 MindPower::lwTexInfo_0000 tex_info[4];
	 fread(*(tex_info), sizeof(MindPower::lwTexInfo_0000)*4, 1, fp);
	 for (unsigned long i = 0; i < 8; i++) {
		MindPower::lwRenderStateValue *rsv = *(rsm[0][i]);
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
		MindPower::lwTexInfo_0000 *p = *(tex_info[i]);
		if (p->state == -1)
		  break;
		MindPower::lwTexInfo *t = *(info->tex_seq[i]);
		t->level = 1;
		t->usage = 0;
		t->pool = 0;
		t->type = 0;
		t->stage = p->stage;
		t->format = p->format;
		t->colorkey = p->colorkey;
		t->colorkey_type = p->colorkey_type
		t->byte_alignment_flag = 0;
		strcpy(t->file_name, p->file_name);
		for (unsigned long j = 0; j < 8; j++) {
		  MindPower::lwRenderStateValue *rsv = *(p->tss_set[0][j]);
		  if (rsv->state == -1)
			 break;
		  t->tss_set[j].state = rsv->state;
		  t->tss_set[j].value0 = rsv->value;
		  t->tss_set[j].value1 = rsv->value;
		};
	 };
	 if ( info->tex_seq[0].format == 26 )
		info->tex_seq[0].format = 25;
  } else {
	 MessageBoxA(0, "invalid file version", "error", 0);
	 return -1;
  };
  info->tex_seq[0].pool = 1;
  info->tex_seq[0].level = 3;
  int transp_flag = 0;
  unsigned long i;
  for (i = 0; i < 8; i++) {
	 MindPower::lwRenderStateAtom *rsa = &info->rs_set[i];
	 if (rsa->state == -1 )
		break;
	 if ((rsa->state == 20)&&((rsa->value0 == 2)||(rsa->value0 == 4)))
		transp_flag = 1;
	 if ((rsa->state == 137)&&(rsa->value0 == 0))
		transp_flag++;
  };
  if ((transp_flag = 1)&&(i < 7)
	 MindPower::RSA_VALUE(*(info->rs_set[i]), 137, 0);
  return 0;
  }
 
long __cdecl MindPower::lwMeshInfo_Load(struct MindPower::lwMeshInfo *info, struct _iobuf *fp, unsigned long version) {
  
	if (version == 0) {
	  unsigned long old_version;
	  fread(*(old_version), sizeof(unsigned long), 1, fp);
	  version = old_version;
	};
	if (version >= 0x1004) {
	  fread(*(info->header), sizeof(MindPower::lwMeshInfo::lwMeshInfoHeader), 1, fp);
	} else if (version >= 0x1003) {
	  MindPower::lwMeshInfo_0003::lwMeshInfoHeader header;
	  fread(*(header), sizeof(MindPower::lwMeshInfo_0003::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header->fvf;
	  info->header.pt_type = header->pt_type;
	  info->header.vertex_num = header->vertex_num;
	  info->header.index_num = header->index_num;
	  info->header.subset_num = header->subset_num;
	  info->header.bone_index_num = header->bone_index_num;
	  info->header.bone_infl_factor = info->header.bone_index_num > 0 ? 2 : 0;
	  info->header.vertex_element_num = 0;
	} else if ((version >= 0x1000)||(version == 1)) {
	  MindPower::lwMeshInfo_0003::lwMeshInfoHeader header;
	  fread(header, sizeof(MindPower::lwMeshInfo_0003::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header->fvf;
	  info->header.pt_type = header->pt_type;
	  info->header.vertex_num = header->vertex_num;
	  info->header.index_num = header->index_num;
	  info->header.subset_num = header->subset_num;
	  info->header.bone_index_num = header->bone_index_num;
	  info->header.bone_infl_factor = info->header.bone_index_num > 0 ? 2 : 0;
	  info->header.vertex_element_num = 0;
	} else if (version == 0) {
	  MindPower::lwMeshInfo_0000::lwMeshInfoHeader header;
	  fread(*(header), sizeof(MindPower::lwMeshInfo_0000::lwMeshInfoHeader), 1, fp);
	  info->header.fvf = header->fvf;
	  info->header.pt_type = header->pt_type;
	  info->header.vertex_num = header->vertex_num;
	  info->header.index_num = header->index_num;
	  info->header.subset_num = header->subset_num;
	  info->header.bone_index_num = header->bone_index_num;
	  for (unsigned long j = 0; j < 8; j++) {
		 MindPower::lwRenderStateValue *rsv = &header->rs_set[i][0];
		 if (rsa->state == -1)
			break;
		 unsigned long v;
		 if (rsv->state == 147) {
			v = 2;
		 } else {
			v = rsv->value;
		 };
		 info->header.rs_set[i].state = rsv->state;
		 info->header.rs_set[i].value0 = v;
		 info->header.rs_set[i].value1 = v;
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
		 info->normal_seq = new D3DXVECTOR3[info->header.vertex_num];
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
	  } else if (info->fvf & 0x300) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
	  } else if (info->fvf & 0x400) {
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
		 info->blend_seq = new MindPower::lwBlendInfo[info->header.vertex_num];
		 info->bone_index_seq = new unsigned long[info->header.bone_index_num];
		 fread(info->blend_seq, sizeof(MindPower::lwBlendInfo), info->header.vertex_num, fp);
		 fread(info->bone_index_seq, sizeof(unsigned long), info->header.bone_index_num, fp);
	  };
	  if (info->header.index_num > 0) {
		 info->index_seq = new unsigned long[info->header.index_num];
		 fread(info->index_seq, sizeof(unsigned long), info->header.index_num, fp);
	  };
	  if (info->header.subset_num > 0) {
		 info->subset_seq = new MindPower::lwSubsetInfo[info->header.subset_num];
		 fread(info->subset_seq, sizeof(MindPower::lwSubsetInfo), info->header.subset_num, fp);
	  };
	} else {
	  info->header.subset_seq = new MindPower::lwSubsetInfo[info->header.subset_num];
	  fread(info->subset_seq, sizeof(MindPower::lwSubsetInfo), info->header.subset_num, fp);
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
	  } else if (info->fvf & 0x300) {
		 info->texcoord0_seq = new D3DXVECTOR2[info->vertex_num];
		 info->texcoord1_seq = new D3DXVECTOR2[info->vertex_num];
		 info->texcoord2_seq = new D3DXVECTOR2[info->vertex_num];
		 fread(info->texcoord0_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
		 fread(info->texcoord1_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
		 fread(info->texcoord2_seq, sizeof(D3DXVECTOR2), info->vertex_num, fp);
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
		 info->blend_seq = new MindPower::lwBlendInfo[info->header.vertex_num];
		 unsigned char *byte_index_seq = new char[info->header.bone_index_num];
		 fread(info->blend_seq, sizeof(MindPower::lwBlendInfo), info->header.vertex_num, fp);
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
 
public: long __thiscall MindPower::lwHelperInfo::Load(struct _iobuf *fp, unsigned long version) {
  
	if (version == 0) {
	  unsigned long old_version;
	  fread(*(old_version), sizeof(unsigned long), 1, fp); // No messing around with 'version' O_o
	};
	fread(*(this->type), sizeof(unsigned long), 1, fp);
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
 
public: long __thiscall MindPower::lwHelperInfo::_LoadHelperDummyInfo(struct _iobuf *fp, unsigned long version) {
  
	if (version >= 0x1001) {
	  fread(*(this->dummy_num), sizeof(unsigned long), 1, fp);
	  this->dummy_seq = new MindPower::lwHelperDummyInfo[this->dummy_num];
	  fread(this->dummy_seq, sizeof(MindPower::lwHelperDummyInfo), this->dummy_num, fp);
	} else if (version <= 0x1000) {
	  fread(*(this->dummy_num), sizeof(unsigned long), 1, fp);
	  struct MindPower::lwHelperDummyInfo_1000 *old_s = new MindPower::lwIndexMatrix44[this->dummy_num];
	  fread(old_s, sizeof(MindPower::lwHelperDummyInfo_1000), this->dummy_num, fp);
	  this->dummy_seq = new MindPower::lwHelperDummyInfo[this->dummy_num];
	  for (unsigned long i = 0; i < this->dummy_num; i++) {
		 this->dummy_seq[i]->id = old_s[i]->id
		 this->dummy_seq[i]->mat = old_s[i]->mat;
		 this->dummy_seq[i]->parent_type = 0;
		 this->dummy_seq[i]->parent_id = 0;
	  };
	  delete [] old_s;
	};
	return 0;
  
}
 
public: long __thiscall MindPower::lwHelperInfo::_LoadHelperBoxInfo(struct _iobuf *fp, unsigned long version) {
  
	fread(*(this->box_num), sizeof(unsigned long), 1, fp);
	this->box_seq = new MindPower::lwHelperBoxInfo[this->box_num];
	fread(this->box_seq, sizeof(MindPower::lwHelperBoxInfo), this->box_num, fp);
	if (version <= 0x1001) {
	  MindPower::lwBox_1001 old_b = MindPower::lwBox_1001();
	  for (unsigned long i = 0; i < this->box_num, i++) {
		 MindPower::lwBox *b = this->box_seq[i];
		 old_b.p = b->c;
		 old_b.s = b->r;
		 b->r = old_b.s / 2;
		 b->c = old_b.p + b->r;
	  };
	};
	return 0;
  
}
 
public: long __thiscall MindPower::lwHelperInfo::_LoadHelperMeshInfo(struct _iobuf *fp, unsigned long version) {
  
	fread(*(this->mesh_num), sizeof(unsigned long), 1, fp);
	this->mesh_seq = new MindPower::lwHelperMeshInfo[this->mesh_num];
	for (unsigned long i = 0; i < this->mesh_num; i++) {
	  MindPower::lwHelperMeshInfo *info = this->mesh_seq[i];
	  fread(*(info->id), sizeof(unsigned long), 1, fp);
	  fread(*(info->type), sizeof(unsigned long), 1, fp);
	  fread(*(info->sub_type), sizeof(unsigned long), 1, fp);
	  fread(*(info->name), 20, 1, fp); // sizeof(info->name) = 20;
	  fread(*(info->state) sizeof(unsigned long), 1, fp);
	  fread(*(info->mat), sizeof(D3DXMATRIX), 1, fp);
	  fread(*(info->box), sizeof(MindPower::lwBox), 1, fp);
	  fread(*(info->vertex_num), sizeof(unsigned long), 1, fp);
	  fread(*(info->face_num), sizeof(unsigned long), 1, fp);
	  info->vertex_seq = new D3DXVECTOR4[info->vertex_num];
	  info->face_seq = new MindPower::lwHelperMeshFaceInfo[info->face_num];
	  fread(info->vertex_seq, sizeof(D3DXVECTOR3), info->vertex_num, fp);
	  fread(info->face_seq, sizeof(MindPower::lwHelperMeshFaceInfo), info->face_num, fp);
	};
	if (version <= 0x1001) {
	  MindPower::lwBox_1001 old_b = MindPower::lwBox_1001();
	  for(unsigned long i = 0; i < this->mesh_num; i++) {
		 MindPower::lwBox *b = this->mesh_seq[i]->box;
		 old_b.p = b->c;
		 old_b.s = b->r;
		 b->r = old_b.s / 2;
		 b->c = old_b.p + b->r;
	  };
	};
	return 0;
  
}
 
public: long __thiscall MindPower::lwHelperInfo::_LoadBoundingBoxInfo(struct _iobuf *fp, unsigned long version) {
  
	fread(*(this->bbox_num), sizeof(unsigned long), 1, fp);
	info->bbox_seq = new MindPower::lwBoundingBoxInfo[this->bbox_num];
	fread(info->bbox_seq, sizeof(MindPower::lwBoundingBoxInfo), this->bbox_num, fp);
	if (version <= 0x1001) {
	  MindPower::lwBox_1001 old_b = MindPower::lwBox_1001();
	  for (unsigned long i = 0; i < this->bbox_num; i++) {
		 MindPower::lwBox *b = info->bbox_seq[i]->box;
		 old_b.p = b->c;
		 old_b.s = b->r;
		 b->r = old_b.s / 2;
		 b->c = old_b.p + b->r;
	  };
	};
	return 0;
  
}
 
public: long __thiscall MindPower::lwHelperInfo::_LoadBoundingSphereInfo(struct _iobuf *fp, unsigned long version) {
  
	fread(*(this->bsphere_num), sizeof(unsigned long), 1, fp);
	info->bsphere_seq = new MindPower::lwBoundingSphereInfo[this->bsphere_num];
	fread(this->bsphere_seq, sizeof(MindPower::lwBoundingSphereInfo), this->bsphere_num, fp);
	return 0;
  
}
 
public: long __thiscall MindPower::lwAnimDataInfo::Load(struct _iobuf *fp, unsigned long version) {
  
	if (version = 0) {
	  unsigned long old_version;
	  fread(*(old_version), sizeof(unsigned long), 1, fp);
	};
	unsigned long data_bone_size;
	unsigned long data_mat_size;
	unsigned long data_mtlopac_size[16];
	unsigned long data_texuv_size[4][16];
	unsigned long data_teximg_size[4][16];
	fread(*(data_bone_size), sizeof(unsigned long), 1, fp);
	fread(*(data_mat_size), sizeof(unsigned long), 1, fp);
	if (version >= 0x1005) {
	  fread(*(data_mtlopac_size), sizeof(data_mtlopac_size), 1, fp);
	};
	fread(*(data_texuv_size), sizeof(data_texuv_size), 1, fp);
	fread(*(data_teximg_size), sizeof(data_teximg_size), 1, fp);
	if (version > 0) {
	  this->anim_bone = new MindPower::lwAnimDataBone();
	  this->anim_bone->Load(fp, version);
	};
	if (data_mat_size > 0) {
	  this->anim_mat = new MindPower::lwAnimDataMatrix();
	  this->anim_mat->Load(fp, version);
	};
	if (version >= 0x1005) {
	  for (unsigned long i = 0; i < 16; i++) {
		 if (data_mtlopac_size[i] == 0 )
			continue;
		 this->anim_mtlopac[i] = new MindPower::lwAnimDataMtlOpacity();
		 this->anim_mtlopac[i]->Load(fp, version);
	  };
	};
	for(unsigned long i = 0; i < 16; i++) {
	  for(unsigned long j = 0; j < 4; j++) {
		 if (data_texuv_size[i][j] == 0 )
			continue;
		 this->anim_tex[i][j] = new MindPower::lwAnimDataTexUV();
		 this->anim_tex[i][j]->Load(fp, version);
	  };
	};
	for (unsigned long i = 0; i < 16; i++) {
	  for(unsigned long j = 0; j < 4; j++) {
		 if (data_teximg_size[i][j] == 0 )
			continue;
		 this->anim_img[i][j] = new MindPower::lwAnimDataTexImg();
		 this->anim_img[i][j]->Load();
	  };
	};
	return 0;
  
}
 
// .lab
public: virtual long __thiscall MindPower::lwAnimDataBone::Load(const char * file) {
  long ret = -1;
  _iobuf *fp = fopen(file, "rb");
  if (fp) {
	 unsigned long version;
	 fread(&version, sizeof(unsigned long), 1, fp);
	 if ( version < 0x1000 ) {
		version = 0;
		char buf[256];
		sprintf(&buf, "old animation file: %s, need re-export it", file);
		MessageBoxA(0, &buf, "warning", 0);
	 };
	 if (this->MindPower::lwAnimDataBone::Load(fp, version) >= 0) { // Overloaded version
		 ret = 0;
	 }
  };
  if (fp)
	 fclose(fp);
  return ret;
  }
 
public: long __thiscall MindPower::lwAnimDataBone::Load(struct _iobuf *fp, unsigned long version) {
  if (version == 0) {
	 unsigned long old_version;
	 fread(old_version, sizeof(unsigned long), 1, fp);
	 int x = 0;
  };
  if (this->_base_seq) {
	 return -1;
  };
  fread(*(this->_header), sizeof(MindPower::lwAnimDataBone::lwBoneInfoHeader), 1, fp);
  this->_base_seq = new MindPower::lwBoneBaseInfo[this->_header.bone_num];
  this->_key_seq = new MindPower::lwBoneKeyInfo[this->_header._bone_num];
  this->_invmat_seq = new D3DXMATRIX[this->_header._bone_num];
  this->_dummy_seq = new MindPower::lwBoneDummyInfo[this->_header.dummy_num];
  fread(this->_base_seq, sizeof(MindPower::lwBoneBaseInfo), this->_header.bone_num, fp);
  fread(this->_invmat_seq, sizeof(D3DXMATRIX), this->_header.bone_num, fp);
  fread(this->_dummy_seq, sizeof(MindPower::lwBoneDummyInfo), this->_header.dummy_num, fp);
  if (this->_header.key_type == 1) {
	 for (unsigned long i = 0; i < this->_header.bone_num; i++) {
		MindPower::lwBoneKeyInfo *key = this->_key_seq[i];
		key->mat43_seq = new MindPower::lwMatrix43[this->frame_num];
		fread(key->mat43_seq, sizeof(MindPower::lwMatrix43), this->_header.frame_num, fp);
	 };
  } else if (this->_header.key_type == 2) {
	 for (unsigned long i = 0; i < this->_header.bone_num; i++) {
		MindPower::lwBoneKeyInfo *key = this->_key_seq[i];
		key->mat44_seq = new D3DXMATRIX[this->_header.frame_num];
		fread(key->mat44_seq, sizeof(D3DXMATRIX), this->_header.frame_num, fp);
	 };
  } else if (this->_header.key_type == 3) {
	 if (version >= 0x1003) {
		for (unsigned long i = 0; i < this->_header.bone_num; i++) {
			MindPower::lwBoneKeyInfo *key = this->_key_seq[i];
			key->pos_seq = new D3DXVECTOR3[this->_header.frame_num];
			fread(key->pos_seq, sizeof(D3DXVECTOR3), this->_header.frame_num, fp);
			key->quat_seq = new D3DXQUATERNION[this->_header.frame_num];
			fread(key->quat_seq, sizeof(D3DXQUATERNION), this->_header.frame_num, fp);
		};
	 } else {
		for (unsigned long i = 0; i < this->_header.bone_num; i++) {
		  MindPower::lwBoneKeyInfo *key = this->_key_seq[i];
		  unsigned long pos_num = this->_base_seq[i]->parent_id == -1 ? this->_header.frame_num : 1;
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
 
public: long __thiscall MindPower::lwAnimDataMatrix::Load(struct _iobuf *fp, unsigned long version) {
  
	fread(*(this->_frame_num), sizeof(unsigned long), 1, fp);
	this->_mat_seq = new MindPower::lwMatrix43[this->_frame_num];
	fread(this->_mat_seq, sizeof(MindPower::lwMatrix43), this->_frame_num, fp);
	return 0;
  
}
 
public: long __thiscall MindPower::lwAnimDataMtlOpacity::Load(struct _iobuf *fp, unsigned long version) {
  long ret = -1;
  unsigned long num;
  fread(*(num), sizeof(unsigned long), 1, fp);
  MindPower::lwKeyFloat *seq = new MindPower::lwKeyFloat[num];
  fread(seq, sizeof(MindPower::lwKeyFloat), num, fp);
  this->_aks_ctrl = new MindPower::lwAnimKeySetFloat();
  if (this->_aks_ctrl->SetKeySequence(seq, num) >= 0) {
	  ret = 0;
  };
  return ret;
  }
 
public: long __thiscall MindPower::lwAnimDataTexUV::Load(struct _iobuf *fp, unsigned long version) {
  fread(*(this->_frame_num), sizeof(unsigned long), 1, fp);
  this->_mat_seq = new D3DXMATRIX[this->_frame_num];
  fread(this->_mat_seq, sizeof(D3DXMATRIX), this->_frame_num, fp);
  return 0;
  }
 
public: long __thiscall MindPower::lwAnimDataTexImg::Load(struct _iobuf *fp, unsigned long version) {
  long ret = 0;
  if (version == 0) {
	 char buf[256];
	 sprintf(*buf, "old version file, need	  re-export it");
	 MessageBoxA(0, &buf, "warning", 0);
	 ret = -1;
  } else {
	 fread(*(this->_data_num), sizeof(unsigned long), 1, fp);
	 this->_data_seq = new MindPower::lwTexInfo[this->_data_num];
	 fread(this->_data_seq, sizeof(MindPower::lwTexInfo), this->_data_num, fp);
  };
  return ret;
  }
 
// .lmo
public: virtual long __thiscall MindPower::lwModelObjInfo::Load(const char *file) {
  
	_iobuf *fp = fopen(file, "rb");
	if ( !fp )
	  return -1;
	unsigned long version;
	fread(&version, sizeof(unsigned long), 1, fp);
	unsigned long obj_num;
	fread(&obj_num, sizeof(unsigned long), 1, fp);
	MindPower::lwModelObjInfo::lwModelObjInfoHeader header[33];
	fread(&header, sizeof(MindPower::lwModelObjInfo::lwModelObjInfoHeader), obj_num, fp);
	this->geom_obj_num = 0;
	for (unsigned long i = 0; i < obj_num; i++) {
	  fseek(fp, header[i].addr, 0);
	  if (header[i].type == 1) {
		 this->geom_obj_seq[this->geom_obj_num] = new MindPower::lwGeomObjInfo();
		 if ( version == 0) {
			unsigned long old_version;
			fread(&old_version, 4, 1, fp);
		 }
		 this->geom_obj_seq[this->geom_obj_num]->MindPower::lwGeomObjInfo::Load(fp, version);
		 this->geom_obj_num++;
	  } else if (header[i].type == 2) {
		 this->helper_data->MindPower::lwHelperInfo::Load(fp, version);
	  };
	};
	if (fp)
	  fclose(fp);
	return 0;
  
}
 
public: long __thiscall MindPower::lwHelperDummyObjInfo::Load(struct _iobuf *fp, unsigned long version) {
  
	long ret = -1;
	fread(&this->_id, sizeof(unsigned long), 1, fp);
	fread(&this->_mat, sizeof(D3DXMATRIX), 1, fp);
	if (this->_anim_data ) delete this->_anim_data;
	unsigned long anim_data_flag = 0;
	fread(&anim_data_flag, sizeof(unsigned long), 1, fp);
	if (anim_data_flag == 1) {
	  MindPower::lwAnimDataMatrix *anim_data = new MindPower::lwAnimDataMatrix();
	  if (anim_data->MindPower::lwAnimDataMatrix::Load(fp, 0) < 0) {
		 delete anim_data;
		 return -1;
	  } else {
		 this->_anim_data = anim_data;
	  };
	};
	ret = 0;
	return ret;
  
}
 
public: long __thiscall MindPower::lwModelNodeInfo::Load(struct _iobuf *fp, unsigned long version) {
  
	long ret = -1;
	fread(&this->_head, sizeof(MindPower::lwModelNodeHeadInfo), 1, fp);
	switch (this->_head.type) {
		 this->_data = new MindPower::lwGeomObjInfo();
		 if ((MindPower::lwGeomObjInfo *)(this->_data)->MindPower::lwGeomObjInfo::Load(fp, version) >= 0) ret = 0;
		 break;
	  case 2:
		 this->_data = new MindPower::lwAnimDataBone();
		 if ((MindPower::lwAnimDataBone *)(this->_data)->MindPower::lwAnimDataBone::Load(fp, version) >= 0) ret = 0;
		 break;
	  case 3:
		 this->_data = new MindPower::lwHelperDummyObjInfo();
		 if ((MindPower::lwHelperDummyObjInfo *)(this->_data)->MindPower::lwHelperDummyObjInfo::Load(fp, version) >= 0) ret = 0;
		 break;
	  case 4:
		 this->_data = new MindPower::lwHelperInfo();
		 if ((MindPower::lwHelperInfo *)(this->_data)->MindPower::lwHelperInfo::Load(fp, version) >= 0) ret = 0;
		 break;
	  default:
	};
  
	return ret;
  
}
	
// .lxo
public: long __thiscall MindPower::lwModelInfo::Load(const char *file) {
  
	long ret = -1;
	_iobuf *fp = fopen(file, "rb");
	if (!fp) {
	  goto __ret;
	};
	fread(&this->_head, sizeof(MindPower::lwModelHeadInfo), 1, fp);
	unsigned long obj_num
	fread(&obj_num, sizeof(unsigned long), 1, fp);
	if (obj_num == 0) {
	  goto __addr_ret_ok;
	};
	MindPower::lwITreeNode *tree_node = 0;
	MindPower::lwModelNodeInfo *node_info = 0;
	for (unsigned long i = 0; i < obj_num; i++) {
	  node_info = new MindPower::lwModelNodeInfo();
	  if (node_info->MindPower::lwModelNodeInfo::Load(fp, this->_head.version) < 0) {
		 delete node_info;
		 goto __ret;
	  }
	  tree_node = new MindPower::lwTreeNode();
	  tree_node->_SetRegisterID((void *)node_info); // MindPower::lwTreeNode::_SetRegisterID(unsigned long)
	  if (this->_obj_tree == 0) {
		 this->_obj_tree = tree_node;
	  } else {
		 MindPower::__find_info param;
		 param.handle = node_info->_parent_handle;
		 param.node = 0;
		 this->_obj_tree->EnumTree(MindPower::__tree_proc_find_node, &param, 0);
		 if (param.node = 0) {
			goto __ret;
		 };
		 if (param.node->InsertChild(0, tree_node) < 0) {
			goto __ret;
		 };
	  };
	};
	__addr_ret_ok:
	  ret = 0;
	__ret:
	  if (fp)
		 fclose(fp);
	  return ret;
  
}