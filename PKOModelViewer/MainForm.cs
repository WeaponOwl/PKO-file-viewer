using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using Mindpower;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace PKOModelViewer
{
    public partial class MainForm : Form
    {
        enum DrawObjectType { none, lab, lgo, lmo, lxo, character, item, ship };

        object[] drawObject = new object[16];
        DrawObjectType[] drawObjectType = new DrawObjectType[16];
        int drawNum = 0;
        int[] textures = new int[1024];

        public SortedDictionary<int, int> charinfokeys;
        public SortedDictionary<int, int> iteminfokeys;
        public CChaRecord[] chainfo;
        public CItemRecord[] iteminfo;
        public string[] labfiles;
        public string[] lgofiles;
        public string[] lmofiles;
        public string[] lxofiles;

        int totaltextures = 0;
        float rotateX = 0;
        float rotateOffcetX = 0;
        float rotateY = 0;
        float rotateOffcetY = 0;
        float scale = 1;
        uint animationTimer = 0;
        bool enableAnimation = false;
        bool playAnimation = true;
        bool isValueChangedProgramly = false;
        Point oldMouseDown;

        ExportForm exportForm;

        public MainForm()
        {
            for (int i = 0; i < textures.Length; i++)
                textures[i] = -1;

            if (!FreeImageAPI.FreeImage.IsAvailable()) MessageBox.Show("Need FreeImage.dll");

            int sz = Marshal.SizeOf(typeof(CItemRecord));

            InitializeComponent();
        }

        string CutString(char[] cstr)
        {
            int length = 0;
            while (length < cstr.Length && cstr[length] != '\0')
                length++;
            return new string(cstr, 0, length);
        }

        private void buttonSelectFoler_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath + "\\";
                textBox1.Text = path;
                System.IO.File.WriteAllText("config.txt", path);
            }
        }
        private void buttonFindFiles_Click(object sender, EventArgs e)
        {
            labfiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lab", System.IO.SearchOption.AllDirectories);
            lgofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lgo", System.IO.SearchOption.AllDirectories);
            lmofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lmo", System.IO.SearchOption.AllDirectories);
            lxofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lxo", System.IO.SearchOption.AllDirectories);

            TreeNode labNode = new TreeNode("lab - animate bone");
            TreeNode lgoNode = new TreeNode("lgo - geometry object");
            TreeNode lmoNode = new TreeNode("lmo - map object");
            TreeNode lxoNode = new TreeNode("lxo - login scene");
            labNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;
            lgoNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;
            lmoNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;
            //lxoNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;

            foreach (string s in labfiles)
            {
                TreeNode node = new TreeNode(s.Substring(textBox1.Text.Length));
                node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                labNode.Nodes.Add(node);
            }
            foreach (string s in lgofiles)
            {
                TreeNode node = new TreeNode(s.Substring(textBox1.Text.Length));
                node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                lgoNode.Nodes.Add(node);
            }
            foreach (string s in lmofiles)
            {
                TreeNode node = new TreeNode(s.Substring(textBox1.Text.Length));
                node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                lmoNode.Nodes.Add(node);
            }
            foreach (string s in lxofiles)
            {
                TreeNode node = new TreeNode(s.Substring(textBox1.Text.Length));
                //node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                lxoNode.Nodes.Add(node);
            }

            treeOfFiles.Nodes.Clear();
            treeOfFiles.Nodes.Add(labNode);
            treeOfFiles.Nodes.Add(lgoNode);
            treeOfFiles.Nodes.Add(lmoNode);
            treeOfFiles.Nodes.Add(lxoNode);

            try
            {

                charinfokeys = new SortedDictionary<int, int>();
                iteminfokeys = new SortedDictionary<int, int>();
                chainfo = CRawDataSet<CChaRecord>.LoadBin(textBox1.Text + "scripts\\table\\Characterinfo.bin");
                iteminfo = CRawDataSet<CItemRecord>.LoadBin(textBox1.Text + "scripts\\table\\iteminfo.bin");
                TreeNode charNode = new TreeNode("characterinfo.bin - characters");
                TreeNode itemNode = new TreeNode("iteminfo.bin - items");
                itemNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;
                charNode.ContextMenuStrip = treeOfFileslvl0NodeMenu;

                int index = 0;
                foreach (CChaRecord character in chainfo)
                {
                    charinfokeys.Add(character.lID, index);
                    TreeNode node = new TreeNode(CutString(character.szDataName));
                    node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                    charNode.Nodes.Add(node);
                    index++;
                }
                index = 0;
                foreach (CItemRecord item in iteminfo)
                {
                    iteminfokeys.Add(item.lID, index);
                    TreeNode node = new TreeNode(CutString(item.szDataName));
                    node.ContextMenuStrip = treeOfFileslvl1NodeMenu;
                    itemNode.Nodes.Add(node);
                    index++;
                }

                treeOfFiles.Nodes.Add(charNode);
                treeOfFiles.Nodes.Add(itemNode);
            }
            catch (Exception ex) { MessageBox.Show("Unable to parse some database files\n" + ex.ToString()); }
        }

        public string GetRightTextureName(string filename)
        {
            filename = filename.Substring(0, filename.LastIndexOf('.'));
            if (System.IO.File.Exists(filename + ".bmp")) filename = filename + ".bmp";
            else if (System.IO.File.Exists(filename + ".dds")) filename = filename + ".dds";
            else if (System.IO.File.Exists(filename + ".tga")) filename = filename + ".tga";
            else if (System.IO.File.Exists(filename + ".png")) filename = filename + ".png";
            else if (System.IO.File.Exists(filename + ".jpg")) filename = filename + ".jpg";
            else return null;

            return filename;
        }
        public Bitmap LoadBitmaByTextureName(string filename)
        {
            filename = GetRightTextureName(filename);
            if (filename != null)
            {
                byte[] data = System.IO.File.ReadAllBytes(filename);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
                Bitmap bmp = LoadBitmapByStream(ms);
                if (bmp != null) { ms.Close(); return bmp; }

                data = ProcessTextureData(data);
                ms = new System.IO.MemoryStream(data);
                bmp = LoadBitmapByStream(ms);
                if (bmp != null) { ms.Close(); return bmp; }
                ms.Close();
            }
            return null;
        }
        Bitmap LoadBitmapByName(string filename)
        {
            try
            {
                FreeImageAPI.FreeImageBitmap fbmp = FreeImageAPI.FreeImageBitmap.FromFile(filename);
                return fbmp.ToBitmap();
            }
            catch { return null; }
        }
        Bitmap LoadBitmapByStream(System.IO.Stream stream)
        {
            try
            {
                FreeImageAPI.FreeImageBitmap fbmp = FreeImageAPI.FreeImageBitmap.FromStream(stream);
                return fbmp.ToBitmap();
            }
            catch { return null; }
        }
        void LoadTextureFromBitmap(Bitmap bmp, int texture)
        {
            GL.BindTexture(TextureTarget.Texture2D, texture);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);
            bmp.UnlockBits(bmp_data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        }
        bool LoadTextureFromName(string filename, int texture)
        {
            try
            {
                Bitmap bmp = LoadBitmapByName(filename);
                LoadTextureFromBitmap(bmp, texture);
                return true;
            }
            catch { return false; }
        }
        bool LoadTextureFromName(string filename, int texture, lwTexInfo texInfo)
        {
            try
            {
                Bitmap bmp = LoadBitmapByName(filename);
                if (texInfo.colorkey_type == lwColorKeyTypeEnum.COLORKEY_TYPE_COLOR)
                    bmp.MakeTransparent(Color.FromArgb(texInfo.colorkey.a, texInfo.colorkey.r, texInfo.colorkey.g, texInfo.colorkey.b));
                LoadTextureFromBitmap(bmp, texture);
                return true;
            }
            catch { return false; }
        }
        bool LoadTextureFromStream(System.IO.Stream stream, int texture)
        {
            try
            {
                Bitmap bmp = LoadBitmapByStream(stream);
                LoadTextureFromBitmap(bmp, texture);
                return true;
            }
            catch { return false; }
        }
        bool LoadTextureFromStream(System.IO.Stream stream, int texture, lwTexInfo texInfo)
        {
            try
            {
                Bitmap bmp = LoadBitmapByStream(stream);
                if (texInfo.colorkey_type == lwColorKeyTypeEnum.COLORKEY_TYPE_COLOR)
                    bmp.MakeTransparent(Color.FromArgb(texInfo.colorkey.a, texInfo.colorkey.r, texInfo.colorkey.g, texInfo.colorkey.b));
                LoadTextureFromBitmap(bmp, texture);
                return true;
            }
            catch { return false; }
        }
        byte[] ProcessTextureData(byte[] data)
        {
            byte[] encodeddata = new byte[data.Length];

            Array.Copy(data, data.Length - 48, encodeddata, 0, 44);
            Array.Copy(data, 44, encodeddata, 44, data.Length - 44 - 44);
            Array.Copy(data, 0, encodeddata, data.Length - 44, 44);

            return encodeddata;
        }

        bool LoadTexture(string filename, int texture, lwTexInfo texInfo)
        {
            filename = GetRightTextureName(filename);
            if (filename == null) return false;

            byte[] data = System.IO.File.ReadAllBytes(filename);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
            if (LoadTextureFromStream(ms, texture, texInfo)) { ms.Close(); return true; }
            ms.Close();

            data = ProcessTextureData(data);

            ms = new System.IO.MemoryStream(data);
            if (LoadTextureFromStream(ms, texture, texInfo)) { ms.Close(); return true; }
            ms.Close();

            return false;
        }
        public byte[] LoadTextureToArray(string filename, out int width, out int height)
        {
            Bitmap bmp = LoadBitmaByTextureName(filename);
            width = bmp.Width;
            height = bmp.Height;

            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] data = new byte[bmp.Width * bmp.Height * 4];
            Marshal.Copy(bmp_data.Scan0, data, 0, bmp.Width * bmp.Height * 4);
            bmp.UnlockBits(bmp_data);

            return data;
        }
        void LoadTexturesToGeom(ref lwGeomObjInfo geom, string originpath)
        {
            string path = originpath.Replace("\\model\\", "\\texture\\");
            int pathid = path.LastIndexOf("\\");
            path = path.Substring(0, pathid + 1);

            for (int i = 0; i < geom.mtl_num; i++)
            {
                lwMtlTexInfo mtl = geom.mtl_seq[i];
                for (int j = 0; j < mtl.tex_seq.Length; j++)
                {
                    lwTexInfo tex = mtl.tex_seq[j];
                    if (tex != null && tex.file_name != null)
                    {
                        string filename = CutString(tex.file_name);

                        if (filename != null && filename.Length > 0)
                        {
                            int id = GL.GenTexture();
                            string path2 = path + filename;

                            if (LoadTexture(path2, id, tex))
                            {
                                textures[totaltextures] = id;
                                totaltextures++;
                                tex.data_pointer = (uint)id;
                            }
                            else
                            {
                                GL.DeleteTexture(id);
                            }
                        }
                    }
                }
            }
        }
        void DeleteAllTextures()
        {
            foreach (int tex in textures)
            {
                GL.DeleteTexture(tex);
            }
            totaltextures = 0;
        }

        void DisableAnimation()
        {
            trackBar1.Enabled = false;
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            enableAnimation = false;
        }
        void EnableAnimation(int frames)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = frames;
            trackBar1.Value = 0;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = frames;
            numericUpDown1.Value = 0;

            animationTimer = 0;
            trackBar1.Enabled = true;
            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            enableAnimation = true;
            pictureBox1.Visible = false;
        }
        private void treeOfFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                string name = e.Node.Text;
                int index = e.Node.Index;
                int parentindex = e.Node.Parent.Index;
                pictureBox1.Visible = false;

                #region lab loading
                if (parentindex == 0)
                {
                    lwAnimDataBone bone = new lwAnimDataBone();
                    if (bone.Load(labfiles[index]) != 0) { bone = null; return; }

                    drawNum = 1;
                    drawObject[0] = bone;
                    drawObjectType[0] = DrawObjectType.lab;

                    glControl1.Refresh();

                    string info = labfiles[index] + "\n";
                    info += "\nbones: " + bone._header.bone_num;
                    info += "\nframes: " + bone._header.frame_num;
                    info += "\ndummys: " + bone._header.dummy_num;
                    info += "\nkey type: " + bone._header.key_type;

                    for (int i = 0; i < bone._header.bone_num; i++)
                    {
                        string bonename = new string(bone._base_seq[i].name);
                        if (bonename.IndexOf('\0') > 0)
                        {
                            bonename = bonename.Substring(0, bonename.IndexOf('\0'));
                            info += "\n bone " + bonename + " [" + bone._base_seq[i].id + " - " + bone._base_seq[i].parent_id + "]";
                        }
                    }
                    for (int i = 0; i < bone._header.dummy_num; i++)
                        info += "\n dummy " + bone._dummy_seq[i].id + " [" + bone._dummy_seq[i].parent_bone_id + "]";

                    richTextBox1.Text = info;
                    EnableAnimation((int)bone._header.frame_num);
                }
                #endregion

                #region lgo loading
                else if (parentindex == 1)
                {
                    totaltextures = 0;
                    lwGeomObjInfo geom = new lwGeomObjInfo();
                    if (geom.Load(lgofiles[index]) != 0) { geom = null; return; }

                    drawNum = 1;
                    drawObject[0] = geom;
                    drawObjectType[0] = DrawObjectType.lgo;

                    DisableAnimation();
                    DeleteAllTextures();
                    LoadTexturesToGeom(ref geom, lgofiles[index]);

                    if (geom.anim_data != null)
                    {
                        if (geom.anim_data.anim_bone != null)
                            EnableAnimation((int)geom.anim_data.anim_bone._header.frame_num);
                        if(geom.anim_data.anim_mat!=null)
                            EnableAnimation((int)geom.anim_data.anim_mat._frame_num);
                    }

                    string info = lgofiles[index] + "\n";
                    info += "\nmaterials:" + geom.mtl_num;
                    for (int i = 0; i < geom.mtl_num; i++)
                    {
                        info += "\n    mtl" + i + " textures:" + geom.mtl_seq[i].tex_seq.Length;
                        for (int j = 0; j < geom.mtl_seq[i].tex_seq.Length; j++)
                        {
                            if (geom.mtl_seq[i].tex_seq[j] != null && geom.mtl_seq[i].tex_seq[j].file_name != null)
                            {
                                int length = 0;
                                while (geom.mtl_seq[i].tex_seq[j].file_name[length] != '\0' && length < geom.mtl_seq[i].tex_seq[j].file_name.Length) length++;
                                string filename = new string(geom.mtl_seq[i].tex_seq[j].file_name, 0, length);
                                info += "\n        " + j + ":" + filename;
                            }
                        }
                    }
                    info += "\nmesh vertex num:" + geom.mesh.header.vertex_num;
                    info += "\nmesh index num:" + geom.mesh.header.index_num;

                    richTextBox1.Text = info;

                    glControl1.Refresh();
                }
                #endregion

                #region lmo loading
                else if (parentindex == 2)
                {
                    totaltextures = 0;
                    lwModelObjInfo model = new lwModelObjInfo();
                    if (model.Load(lmofiles[index]) != 0) { model = null; return; }

                    drawNum = 1;
                    drawObject[0] = model;
                    drawObjectType[0] = DrawObjectType.lmo;

                    string info = lmofiles[index] + "\n";
                    info += "\nmodels: " + model.geom_obj_num;

                    DisableAnimation();
                    DeleteAllTextures();

                    for (int q = 0; q < model.geom_obj_num; q++)
                    {
                        lwGeomObjInfo geom = model.geom_obj_seq[q];
                        LoadTexturesToGeom(ref model.geom_obj_seq[q], lmofiles[index]);
                        if (geom.anim_data != null)
                        {
                            if (geom.anim_data.anim_bone != null)
                                EnableAnimation((int)geom.anim_data.anim_bone._header.frame_num);
                            if (geom.anim_data.anim_mat != null)
                                EnableAnimation((int)geom.anim_data.anim_mat._frame_num);
                        }

                        info += "\n\n---model #" + q;
                        info += "\nmaterials:" + geom.mtl_num;
                        for (int i = 0; i < geom.mtl_num; i++)
                        {
                            info += "\n    mtl" + i + " textures:" + geom.mtl_seq[i].tex_seq.Length;
                            for (int j = 0; j < geom.mtl_seq[i].tex_seq.Length; j++)
                            {
                                if (geom.mtl_seq[i].tex_seq[j] != null && geom.mtl_seq[i].tex_seq[j].file_name != null)
                                {
                                    string filename = CutString(geom.mtl_seq[i].tex_seq[j].file_name);
                                    info += "\n        " + j + ":" + filename;
                                }
                            }
                        }
                        info += "\nmesh vertex num:" + geom.mesh.header.vertex_num;
                        info += "\nmesh index num:" + geom.mesh.header.index_num;
                    }

                    richTextBox1.Text = info;

                    glControl1.Refresh();
                }
                #endregion

                #region lxo loading
                else if (parentindex == 3)
                {
                    lwModelInfo modelinfo = new lwModelInfo();
                    modelinfo.Load(lxofiles[index]);
                    if (modelinfo.Load(name) != 0) { modelinfo = null; return; }

                    drawNum = 1;
                    drawObject[0] = modelinfo;
                    drawObjectType[0] = DrawObjectType.lxo;

                    DisableAnimation();
                    glControl1.Refresh();

                    richTextBox1.Text = "Not active in this version";
                }
                #endregion

                #region character loading
                else if (parentindex == 4)
                {
                    CChaRecord character = chainfo[index];
                    drawNum = 0;

                    DisableAnimation();

                    string info = CutString(character.szDataName) + "\n";
                    info += "\nheight " + character.fHeight + "\n";
                    info += "width " + character.fWidth + "\n";
                    info += "length " + character.fLengh + "\n\n";
                    info += "items (";
                    for (int i = 0; i < character.lItem.Length; i++)
                    {
                        if (i != 0) info += ",";
                        info += character.lItem[i];
                    }
                    info += ")\n\n";
                    info += "script " + character.lScript + "\n";
                    info += "ID " + character.nID + "\n";
                    info += "index " + character.nIndex + "\n";
                    info += "actionId " + character.sActionID + "\n";
                    info += "bornEffect " + character.sBornEff + "\n";
                    info += "dieEffect " + character.sDieEff + "\n";
                    info += "effectId " + character.sEeffID + "\n";
                    info += "effectActionId (";
                    for (int i = 0; i < character.sEffectActionID.Length; i++)
                    {
                        if (i != 0) info += ",";
                        info += character.sEffectActionID[i];
                    }
                    info += ")\nmodel " + character.sModel + "\n";
                    info += "scinInfo (";
                    for (int i = 0; i < character.sSkinInfo.Length; i++)
                    {
                        if (i != 0) info += ",";
                        info += character.sSkinInfo[i];
                    }
                    info += ")\nsuitId " + character.sSuitID + "\n";
                    info += "modalType " + (byte)character.chModalType + "\n";
                    info += "suitNum " + character.sSuitNum + "\n\n";
                    info += "guild: " + CutString(character.szGuild) + "\n";
                    info += "iconName: " + CutString(character.szIconName) + "\n";
                    info += "job: " + CutString(character.szJob) + "\n";
                    info += "name: " + CutString(character.szName) + "\n";
                    info += "title: " + CutString(character.szTitle) + "\n";

                    trackBar1.Enabled = false;
                    numericUpDown1.Enabled = false;
                    button1.Enabled = false;
                    enableAnimation = false;
                    pictureBox1.Visible = false;

                    if (character.chModalType == 1)
                    {
                        lwAnimDataBone bone = new lwAnimDataBone();
                        if (bone.Load(textBox1.Text + "animation\\" + character.sModel.ToString("0000") + ".lab") == 0)
                        {
                            drawObject[drawNum] = bone;
                            drawObjectType[drawNum] = DrawObjectType.lab;
                            drawNum++;

                            EnableAnimation((int)bone._header.frame_num);
                        }

                        info += "\nanimation: " + character.sModel.ToString("0000") + ".lab\n";

                        foreach (uint tex in textures)
                            GL.DeleteTexture(tex);
                        totaltextures = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            if (character.sSkinInfo[i] != 0)
                            {
                                CItemRecord rec = iteminfo[iteminfokeys[character.sSkinInfo[i]]];

                                char[] mdl = new char[19];
                                Array.Copy(rec.chModule, (character.sModel + 1) * 19, mdl, 0, 19);

                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                {
                                    LoadTexturesToGeom(ref geom, filenameModel);
                                    drawObject[drawNum] = geom;
                                    drawObjectType[drawNum] = DrawObjectType.lgo;
                                    drawNum++;
                                }

                                info += "model: " + CutString(mdl) + ".lgo\n";
                            }
                        }
                    }
                    if (character.chModalType == 2)
                    {
                        info += "\nanimation: ?? \n";

                        for (int i = 0; i < 5; i++)
                        {
                            if (character.sSkinInfo[i] != 0)
                            {
                                CItemRecord rec = iteminfo[iteminfokeys[character.sSkinInfo[i]]];

                                char[] mdl = new char[19];
                                Array.Copy(rec.chModule, 0, mdl, 0, 19);

                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                {
                                    if (geom.anim_data != null && geom.anim_data.anim_mat != null)
                                    {
                                        EnableAnimation((int)geom.anim_data.anim_mat._frame_num);
                                    }
                                    LoadTexturesToGeom(ref geom, filenameModel);
                                    drawObject[drawNum] = geom;
                                    drawObjectType[drawNum] = DrawObjectType.ship;
                                    drawNum++;
                                }

                                info += "model: " + CutString(mdl) + ".lgo\n";
                            }
                        }
                    }
                    if (character.chModalType == 4)
                    {
                        lwAnimDataBone bone = new lwAnimDataBone();
                        if (bone.Load(textBox1.Text + "animation\\" + character.sModel.ToString("0000") + ".lab") == 0)
                        {
                            drawObject[drawNum] = bone;
                            drawObjectType[drawNum] = DrawObjectType.lab;
                            drawNum++;

                            EnableAnimation((int)bone._header.frame_num);
                        }

                        info += "\nanimation: " + character.sModel.ToString("0000") + ".lab\n";

                        foreach (uint tex in textures)
                            GL.DeleteTexture(tex);
                        totaltextures = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            if (character.sSkinInfo[i] != 0)
                            {
                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = textBox1.Text + "model\\character\\" + (i + 10000 * (character.sSuitID + 100 * character.sModel)).ToString("0000000000") + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                {
                                    LoadTexturesToGeom(ref geom, filenameModel);
                                    drawObject[drawNum] = geom;
                                    drawObjectType[drawNum] = DrawObjectType.lgo;
                                    drawNum++;
                                }

                                info += "model: " + (i + 10000 * (character.sSuitID + 100 * character.sModel)).ToString("0000000000") + ".lgo\n";
                            }
                        }
                    }

                    richTextBox1.Text = info;

                    glControl1.Refresh();
                }
                #endregion

                #region items loading
                if (parentindex == 5)
                {
                    CItemRecord item = iteminfo[index];
                    drawNum = 0;
                    DeleteAllTextures();
                    //drawObject[0] = item;
                    //drawObjectType[0] = DrawObjectType.item;

                    string info = CutString(item.szDataName) + "\n\n";
                    //info += "able link: " + CutString(item.szAbleLink) + "\n";
                    info += "attr effect: " + CutString(item.szAttrEffect) + "\n";
                    info += "descriptor: " + CutString(item.szDescriptor) + "\n";
                    info += "icon: " + CutString(item.szICON) + "\n";
                    info += "name: " + CutString(item.szName) + "\n\n";
                    info += "id: " + item.lID + "\n";
                    info += "modules: \n";
                    for (int i = 0; i < 5; i++)
                    {
                        char[] mdl = new char[19];
                        Array.Copy(item.chModule, i * 19, mdl, 0, 19);
                        if (i == 0) info += "on drop:    " + CutString(mdl) + "\n";
                        else if (i == 1) info += "on Lance:   " + CutString(mdl) + "\n";
                        else if (i == 2) info += "on Carsise: " + CutString(mdl) + "\n";
                        else if (i == 3) info += "on Phyllis: " + CutString(mdl) + "\n";
                        else if (i == 4) info += "on Ami:     " + CutString(mdl) + "\n";

                        lwGeomObjInfo geom = new lwGeomObjInfo();
                        string filenameModel = textBox1.Text + "model\\item\\" + CutString(mdl) + ".lgo";
                        if (item.sType >= 19 && item.sType <= 25) filenameModel = textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";

                        if (geom.Load(filenameModel) == 0)
                        {
                            LoadTexturesToGeom(ref geom, filenameModel);
                            drawObject[drawNum] = geom;
                            drawObjectType[drawNum] = DrawObjectType.item;
                            drawNum++;
                        }
                    }

                    info += "\nforge lvl: " + (byte)item.chForgeLv + "\n";
                    info += "forge ready: " + (byte)item.chForgeSteady + "\n";
                    info += "instance: " + (byte)item.chInstance + "\n";
                    info += "pick to: " + (byte)item.chPickTo + "\n";
                    info += "price: " + item.lPrice + "\n";
                    info += "index: " + item.nIndex + "\n";
                    info += "l hand value: " + item.sLHandValu + "\n";
                    info += "need lvl: " + item.sNeedLv + "\n";
                    info += "type: " + (EItemType)item.sType + "\n";

                    Bitmap bmp = LoadBitmaByTextureName(textBox1.Text + "texture\\icon\\" + CutString(item.szICON) + ".bmp");
                    pictureBox1.Image = bmp;
                    pictureBox1.Visible = true;

                    DisableAnimation();
                    glControl1.Refresh();

                    richTextBox1.Text = info;
                }
                #endregion
            }
        }

        void DrawGrid()
        {
            GL.PushMatrix();
            GL.Color3(0.5f, 0.5f, 0.5f);
            GL.Begin(BeginMode.Lines);

            for (int i = -10; i <= 10; i++)
            {
                GL.Vertex3(i, -10, 0); GL.Vertex3(i, 10, 0);
                GL.Vertex3(-10, i, 0); GL.Vertex3(10, i, 0);
            }

            GL.End();
            GL.PopMatrix();
        }
        Matrix4[] GetTransformByFrame(lwAnimDataBone bone, uint frame)
        {
            Matrix4[] finishmatrixes = new Matrix4[bone._header.bone_num];
            for (int i = 0; i < bone._header.bone_num; i++)
            {
                lwBoneKeyInfo key = bone._key_seq[i];
                Matrix4 currentMat = Matrix4.Identity;

                if (bone._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_QUAT)
                {
                    Quaternion quat = new Quaternion(key.quat_seq[frame].x, key.quat_seq[frame].y, key.quat_seq[frame].z, key.quat_seq[frame].w);
                    Vector3 offcet = new Vector3(key.pos_seq[frame].x, key.pos_seq[frame].y, key.pos_seq[frame].z);

                    currentMat = Matrix4.CreateFromQuaternion(quat) * Matrix4.CreateTranslation(offcet);
                }
                else if (bone._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_MAT43)
                {
                    currentMat = new Matrix4(key.mat43_seq[frame].m[0], key.mat43_seq[frame].m[1], key.mat43_seq[frame].m[2], 0,
                                              key.mat43_seq[frame].m[3], key.mat43_seq[frame].m[4], key.mat43_seq[frame].m[5], 0,
                                              key.mat43_seq[frame].m[6], key.mat43_seq[frame].m[7], key.mat43_seq[frame].m[8], 0,
                                              key.mat43_seq[frame].m[9], key.mat43_seq[frame].m[10], key.mat43_seq[frame].m[11], 1);
                }
                else if (bone._header.key_type == lwBoneKeyInfoType.BONE_KEY_TYPE_MAT44)
                {
                    currentMat = new Matrix4(key.mat44_seq[frame].m[0], key.mat44_seq[frame].m[1], key.mat44_seq[frame].m[2], key.mat44_seq[frame].m[3],
                                              key.mat44_seq[frame].m[4], key.mat44_seq[frame].m[5], key.mat44_seq[frame].m[6], key.mat44_seq[frame].m[7],
                                              key.mat44_seq[frame].m[8], key.mat44_seq[frame].m[9], key.mat44_seq[frame].m[10], key.mat44_seq[frame].m[11],
                                              key.mat44_seq[frame].m[12], key.mat44_seq[frame].m[13], key.mat44_seq[frame].m[14], key.mat44_seq[frame].m[15]);
                }

                if (bone._base_seq[i].parent_id != 0xffffffff && bone._base_seq[i].parent_id < bone._header.bone_num)
                {
                    currentMat = currentMat * finishmatrixes[bone._base_seq[i].parent_id];
                }

                finishmatrixes[i] = currentMat;
            }

            return finishmatrixes;
        }
        void DrawGeom(lwGeomObjInfo geom)
        {
            if (geom.anim_data != null)
            {
                lwAnimDataInfo data = geom.anim_data;
                if (data.anim_bone != null)
                {
                    DrawGeom(geom, data.anim_bone);
                    return;
                }
                if (data.anim_mat!=null)
                {
                    DrawGeom(geom, data.anim_mat);
                    return;
                }
            }
            GL.PushMatrix();
            GL.MultMatrix(geom.header.mat_local.m);
            for (int j = 0; j < geom.mesh.header.subset_num; j++)
            {
                if (CutString(geom.mtl_seq[j].tex_seq[0].file_name) == "1.BMP") // 1.bmp - is for weapon effects
                    continue;
                GL.BindTexture(TextureTarget.Texture2D, geom.mtl_seq[j].tex_seq[0].data_pointer);
                GL.Color3(1f, 1f, 1f);
                GL.Begin(BeginMode.Triangles);
                for (uint i = geom.mesh.subset_seq[j].start_index; i < geom.mesh.subset_seq[j].start_index + geom.mesh.subset_seq[j].primitive_num * 3; i++)
                {
                    D3DXVECTOR3 p1 = geom.mesh.vertex_seq[geom.mesh.index_seq[i]];
                    D3DXVECTOR2 t1 = geom.mesh.texcoord0_seq[geom.mesh.index_seq[i]];

                    GL.TexCoord2(t1.x, t1.y);
                    GL.Vertex3(p1.x, p1.y, p1.z);
                }
                GL.End();
            }
            GL.PopMatrix();
        }
        void DrawGeom(lwGeomObjInfo geom, lwAnimDataBone bone)
        {
            if (geom.mesh.header.bone_index_num > 0 && bone._header.frame_num == 0) { DrawGeom(geom); return; }
            uint frame = animationTimer % bone._header.frame_num;
            Matrix4[] finishmatrixes = GetTransformByFrame(bone, frame);
            Vector3[] transformed = new Vector3[geom.mesh.header.bone_infl_factor];

            GL.PushMatrix();
            GL.MultMatrix(geom.header.mat_local.m);
            for (int j = 0; j < geom.mesh.header.subset_num; j++)
            {
                GL.BindTexture(TextureTarget.Texture2D, geom.mtl_seq[j].tex_seq[0].data_pointer);
                GL.Color3(1f, 1f, 1f);
                GL.Begin(BeginMode.Triangles);
                for (uint i = geom.mesh.subset_seq[j].start_index; i < geom.mesh.subset_seq[j].start_index + geom.mesh.subset_seq[j].primitive_num * 3; i++)
                {
                    uint vertexIndex = geom.mesh.index_seq[i];
                    D3DXVECTOR3 dp1 = geom.mesh.vertex_seq[vertexIndex];
                    D3DXVECTOR2 dt1 = geom.mesh.texcoord0_seq[vertexIndex];

                    Vector3 p1 = new Vector3(dp1.x, dp1.y, dp1.z);
                    Vector2 t1 = new Vector2(dt1.x, dt1.y);

                    lwBlendInfo blend = geom.mesh.blend_seq[vertexIndex];
                    for (int q = 0; q < geom.mesh.header.bone_infl_factor; q++)
                    {
                        uint boneIndex = geom.mesh.bone_index_seq[blend.index[q]];
                        Matrix4 invMat = invMat = new Matrix4(bone._invmat_seq[boneIndex].m[0], bone._invmat_seq[boneIndex].m[1], bone._invmat_seq[boneIndex].m[2], bone._invmat_seq[boneIndex].m[3],
                                         bone._invmat_seq[boneIndex].m[4], bone._invmat_seq[boneIndex].m[5], bone._invmat_seq[boneIndex].m[6], bone._invmat_seq[boneIndex].m[7],
                                         bone._invmat_seq[boneIndex].m[8], bone._invmat_seq[boneIndex].m[9], bone._invmat_seq[boneIndex].m[10], bone._invmat_seq[boneIndex].m[11],
                                         bone._invmat_seq[boneIndex].m[12], bone._invmat_seq[boneIndex].m[13], bone._invmat_seq[boneIndex].m[14], bone._invmat_seq[boneIndex].m[15]); ;

                        transformed[q] = Vector3.Transform(p1, invMat * finishmatrixes[boneIndex]);
                    }

                    Vector3 finishpoint = transformed[0] * blend.weight[0];
                    for (int q = 1; q < geom.mesh.header.bone_infl_factor; q++)
                        finishpoint += transformed[q] * blend.weight[q];

                    GL.TexCoord2(t1);
                    GL.Vertex3(finishpoint);
                }
                GL.End();
            }
            GL.PopMatrix();
        }
        void DrawGeom(lwGeomObjInfo geom ,lwAnimDataMatrix mat,bool usematlocal=false)
        {
            uint frame = animationTimer % mat._frame_num;
            lwMatrix43 finishmatrix43 = mat._mat_seq[frame];
            Matrix4 finishmatrix = new Matrix4(finishmatrix43.m[0], finishmatrix43.m[1], finishmatrix43.m[2], 0,
                                               finishmatrix43.m[3], finishmatrix43.m[4], finishmatrix43.m[5], 0,
                                               finishmatrix43.m[6], finishmatrix43.m[7], finishmatrix43.m[8], 0,
                                               finishmatrix43.m[9], finishmatrix43.m[10], finishmatrix43.m[11], 1);

            GL.PushMatrix();
            GL.MultMatrix(ref finishmatrix);
            if (usematlocal)
                GL.MultMatrix(geom.header.mat_local.m);
            for (int j = 0; j < geom.mesh.header.subset_num; j++)
            {
                GL.BindTexture(TextureTarget.Texture2D, geom.mtl_seq[j].tex_seq[0].data_pointer);
                GL.Color3(1f, 1f, 1f);
                GL.Begin(BeginMode.Triangles);
                for (uint i = geom.mesh.subset_seq[j].start_index; i < geom.mesh.subset_seq[j].start_index + geom.mesh.subset_seq[j].primitive_num * 3; i++)
                {
                    D3DXVECTOR3 p1 = geom.mesh.vertex_seq[geom.mesh.index_seq[i]];
                    D3DXVECTOR2 t1 = geom.mesh.texcoord0_seq[geom.mesh.index_seq[i]];

                    //Vector3 p = Vector3.Transform(new Vector3(p1.x, p1.y, p1.z) , finishmatrix);
                    Vector3 p = new Vector3(p1.x, p1.y, p1.z);

                    GL.TexCoord2(t1.x, t1.y);
                    GL.Vertex3(p);
                }
                GL.End();
            }
            GL.PopMatrix();
        }
        void DrawBone(lwAnimDataBone bone)
        {
            if (bone._header.frame_num == 0) return;
            uint frame = animationTimer % bone._header.frame_num;
            Vector3[] positions = new Vector3[bone._header.bone_num];
            Matrix4[] finishmatrixes = GetTransformByFrame(bone, frame);

            for (int i = 0; i < bone._header.bone_num; i++)
            {
                Matrix4 invMat = invMat = new Matrix4(bone._invmat_seq[i].m[0], bone._invmat_seq[i].m[1], bone._invmat_seq[i].m[2], bone._invmat_seq[i].m[3],
                                         bone._invmat_seq[i].m[4], bone._invmat_seq[i].m[5], bone._invmat_seq[i].m[6], bone._invmat_seq[i].m[7],
                                         bone._invmat_seq[i].m[8], bone._invmat_seq[i].m[9], bone._invmat_seq[i].m[10], bone._invmat_seq[i].m[11],
                                         bone._invmat_seq[i].m[12], bone._invmat_seq[i].m[13], bone._invmat_seq[i].m[14], bone._invmat_seq[i].m[15]); ;
                Matrix4 startMat = Matrix4.Invert(invMat);
                Vector3 startPos = new Vector3(startMat.M41, startMat.M42, startMat.M43);

                positions[i] = Vector3.Transform(startPos, invMat * finishmatrixes[i]);
            }

            GL.Color3(1.0, 1.0, 1.0);
            GL.Begin(BeginMode.Lines);
            for (int i = 0; i < bone._header.bone_num; i++)
            {
                Vector3 parentBonePos = positions[i];
                if (bone._base_seq[i].parent_id == 0xffffffff) continue;
                parentBonePos = new Vector3(positions[bone._base_seq[i].parent_id]);
                Vector3 bonePos = positions[i];

                GL.Vertex3(bonePos);
                GL.Vertex3(parentBonePos);
            }
            GL.End();
        }
        void DrawObject(object drawObject, DrawObjectType drawObjectType,int id)
        {
            if (drawObjectType == DrawObjectType.ship)
            {
                GL.Enable(EnableCap.Texture2D);
                 for (int i = 0; i < drawNum; i++)
                     if (((lwGeomObjInfo)this.drawObject[i]).anim_data != null && ((lwGeomObjInfo)this.drawObject[i]).anim_data.anim_mat != null)
                     {
                         DrawGeom((lwGeomObjInfo)drawObject, ((lwGeomObjInfo)this.drawObject[i]).anim_data.anim_mat, true);
                         break;
                     }
                 GL.Disable(EnableCap.Texture2D);
            }
            if (drawObjectType == DrawObjectType.item)
            {
                lwGeomObjInfo geom = (lwGeomObjInfo)drawObject;
                GL.Enable(EnableCap.Texture2D);
                Random rand = new Random((int)(id * geom.mesh.header.index_num));
                rand.Next(); rand.Next(); rand.Next(); rand.Next();
                GL.PushMatrix();
                if (id == 1) GL.Translate(-1, -1, 0);
                if (id == 2) GL.Translate(1, -1, 0);
                if (id == 3) GL.Translate(1, 1, 0);
                if (id == 4) GL.Translate(-1, 1, 0);
                GL.Rotate(rand.Next(100), 0, 0, 1);
                DrawGeom(geom);
                GL.PopMatrix();
                GL.Disable(EnableCap.Texture2D);
            }
            if (drawObjectType == DrawObjectType.lgo)
            {
                if (drawNum > 1)
                {
                    lwAnimDataBone bone = null;
                    for (int i = 0; i < drawNum; i++)
                        if (this.drawObjectType[i] == DrawObjectType.lab)
                        {
                            bone = (lwAnimDataBone)this.drawObject[i];
                            break;
                        }
                    if (bone != null)
                    {
                        lwGeomObjInfo geom = (lwGeomObjInfo)drawObject;

                        GL.Enable(EnableCap.Texture2D);
                        DrawGeom(geom, bone);
                        GL.Disable(EnableCap.Texture2D);
                        return;
                    }
                }
                lwGeomObjInfo geom2 = (lwGeomObjInfo)drawObject;

                GL.Enable(EnableCap.Texture2D);
                DrawGeom(geom2);
                GL.Disable(EnableCap.Texture2D);
            }
            if (drawObjectType == DrawObjectType.lmo)
            {
                lwModelObjInfo model = (lwModelObjInfo)drawObject;

                GL.Enable(EnableCap.Texture2D);
                for (int i = 0; i < model.geom_obj_num; i++)
                {
                    lwGeomObjInfo geom = model.geom_obj_seq[i];
                    DrawGeom(geom);
                }
                GL.Disable(EnableCap.Texture2D);
            }
            else if (drawObjectType == DrawObjectType.lab)
            {
                if (drawNum > 1)
                    return;

                lwAnimDataBone bone = (lwAnimDataBone)drawObject;
                DrawBone(bone);
            }
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 camera = Matrix4.LookAt(new Vector3(5, 0, 5), new Vector3(0, 0, 1), new Vector3(0, 0, 1));
            GL.MultMatrix(ref camera);
            GL.Rotate(rotateY + rotateOffcetY, 0, 1, 0);
            GL.Rotate(rotateX + rotateOffcetX, 0, 0, 1);
            GL.Scale(scale, scale, scale);

            DrawGrid();
            for (int i = 0; i < drawNum; i++)
                DrawObject(drawObject[i], drawObjectType[i], i);

            glControl1.SwapBuffers();
        }

        void SetProection()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, (float)w / (float)h, 1, 1000);
            GL.MultMatrix(ref proj);
            GL.Viewport(0, 0, w, h);
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.3f, 0.3f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            SetProection();
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            SetProection();
            glControl1.Refresh();
        }
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            oldMouseDown.X = e.X;
            oldMouseDown.Y = e.Y;
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            oldMouseDown.X = 0;
            oldMouseDown.Y = 0;
            rotateX += rotateOffcetX;
            rotateOffcetX = 0;
            rotateY += rotateOffcetY;
            rotateOffcetY = 0;
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (oldMouseDown.X != 0 || oldMouseDown.Y != 0)
            {
                rotateOffcetX = (e.X - oldMouseDown.X);
                rotateOffcetY = (e.Y - oldMouseDown.Y);
                glControl1.Refresh();
            }
        }
        private void glControl_MouseWheel(object sender, MouseEventArgs e)
        {
            float scaleOffcet = (float)Math.Pow(1.2, e.Delta / 100.0f);
            scale *= scaleOffcet;
            glControl1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enableAnimation && playAnimation)
            {
                animationTimer++;
                glControl1.Refresh();
                isValueChangedProgramly = true;
                trackBar1.Value = (int)animationTimer % trackBar1.Maximum;
                numericUpDown1.Value = (int)animationTimer % numericUpDown1.Maximum;
                isValueChangedProgramly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playAnimation = !playAnimation;

            if (playAnimation) button1.Text = "||";
            else button1.Text = ">";
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            animationTimer = (uint)trackBar1.Value;
            if (!isValueChangedProgramly)
            {
                playAnimation = false;
                button1.Text = ">";
                glControl1.Refresh();
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
            animationTimer = (uint)trackBar1.Value;
            if (!isValueChangedProgramly)
            {
                playAnimation = false;
                button1.Text = ">";
                glControl1.Refresh();
            }
        }

        private void MainForm_Close(object sender, EventArgs e) { exportForm.Close(); }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = System.IO.File.ReadAllText("config.txt");
            }
            catch 
            {
                try
                {
                    textBox1.Text = Environment.CurrentDirectory + "\\";
                    System.IO.File.WriteAllText("config.txt", Environment.CurrentDirectory + "\\");
                }
                catch { ;}
            }

            exportForm = new ExportForm(this);
            exportForm.Hide();
            glControl1.MouseWheel += glControl_MouseWheel;
            this.FormClosing += MainForm_Close;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void exportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportForm.Hide();
            exportForm.Show();
        }

        void AddNodeToExportList(TreeNode node)
        {
            int index = node.Index;
            int parentindex = node.Parent.Index;

            if (parentindex == 0)
            {
                exportForm.listBoxExport.Items.Add("[lab] [" + index + "] " + node.Text);
            }
            else if (parentindex == 1)
            {
                exportForm.listBoxExport.Items.Add("[lgo] [" + index + "] " + node.Text);
            }
            else if (parentindex == 2)
            {
                exportForm.listBoxExport.Items.Add("[lmo] [" + index + "] " + node.Text);
            }
            else if (parentindex == 3)
            {
                exportForm.listBoxExport.Items.Add("[lxo] [" + index + "] " + node.Text);
            }
            else if (parentindex == 4)
            {
                exportForm.listBoxExport.Items.Add("[char] [" + index + "] " + node.Text);
            }
            else if (parentindex == 5)
            {
                exportForm.listBoxExport.Items.Add("[item] [" + index + "] " + node.Text);
            }
        }
        private void pushThisToExportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeOfFiles.SelectedNode;

            AddNodeToExportList(node);
        }
        private void pushAllThisLvlToExportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeOfFiles.SelectedNode;
            TreeNodeCollection nodes = node.Parent.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                AddNodeToExportList(nodes[i]);
            }
        }
        private void pushAllChildrentToExportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeOfFiles.SelectedNode;
            TreeNodeCollection nodes = node.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                AddNodeToExportList(nodes[i]);
            }
        }
        private void treeOfFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeOfFiles.SelectedNode = treeOfFiles.GetNodeAt(e.X, e.Y);
            }
        }
    }
}
