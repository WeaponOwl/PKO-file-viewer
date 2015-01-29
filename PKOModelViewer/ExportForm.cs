using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mindpower;

namespace PKOModelViewer
{
    public partial class ExportForm : Form
    {
        class ExportGroup
        {
            public List<lwAnimDataBone> bones;
            public List<lwGeomObjInfo> geoms;
            public List<lwModelObjInfo> models;

            public List<string> bonesoriginpath;
            public List<string> geomsoriginpath;
            public List<string> modelsoriginpath;

            public string targetfilename;

            public ExportGroup()
            {
                bones = new List<lwAnimDataBone>();
                geoms = new List<lwGeomObjInfo>();
                models = new List<lwModelObjInfo>();
                bonesoriginpath = new List<string>();
                geomsoriginpath = new List<string>();
                modelsoriginpath = new List<string>();
            }
            public void Add(lwAnimDataBone bone, string filename)
            {
                bones.Add(bone);
                bonesoriginpath.Add(filename);
            }
            public void Add(lwGeomObjInfo geom, string filename)
            {
                geoms.Add(geom);
                geomsoriginpath.Add(filename);
            }
            public void Add(lwModelObjInfo model, string filename)
            {
                models.Add(model);
                modelsoriginpath.Add(filename);
            }
        }
        class ExportObjInfo
        {
            public System.IO.FileStream stream;
            public System.IO.FileStream mtlstream;
            public System.IO.StreamWriter objwriter;
            public System.IO.StreamWriter mtlwriter;

            public int totalindexes;
            public int totalvertexes;
            public int totalnormals;
            public int totaltexcoord;
            public int totalmaterials;

            public ExportObjInfo()
            {
                stream = null;
                totalindexes = 0;
                totalvertexes = 0;
                totalnormals = 0;
                totaltexcoord = 0;
                totalmaterials = 0;
            }
            public ExportObjInfo(string filename)
            {
                stream = System.IO.File.Open(filename + ".obj", System.IO.FileMode.Create, System.IO.FileAccess.Write);
                mtlstream = System.IO.File.Open(filename + ".mtl", System.IO.FileMode.Create, System.IO.FileAccess.Write);
                objwriter = new System.IO.StreamWriter(stream);
                mtlwriter = new System.IO.StreamWriter(mtlstream);
                totalindexes = 0;
                totalvertexes = 0;
                totalnormals = 0;
                totaltexcoord = 0;
                totalmaterials = 0;
            }

            ~ExportObjInfo()
            {
                stream.Close();
                mtlstream.Close();
            }
        }

        MainForm parentForm;
        object threadLock = new object();

        public ExportForm(MainForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            listBoxFormats.SelectedIndex = 0;

            textBox1.Text = parentForm.textBox1.Text + "exportedmodel\\";
            textBox2.Text = parentForm.textBox1.Text + "exportedtexture\\";
            System.IO.Directory.CreateDirectory(textBox1.Text);
            System.IO.Directory.CreateDirectory(textBox2.Text);

            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSelectForderForModels_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath + "\\";
                textBox1.Text = path;
            }
        }
        private void buttonSelectForderForTextures_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath + "\\";
                textBox2.Text = path;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = listBoxExport.SelectedItems;

            for (int i = selected.Count; i > 0; i--)
            {
                listBoxExport.Items.Remove(selected[0]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBoxExport.ClearSelected();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxExport.Items.Count; i++)
            {
                listBoxExport.SetSelected(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxExport.SelectedItems)
            {
                ExportGroup group = new ExportGroup();
                string listItem = (string)obj;

                int indexstart = listItem.LastIndexOf('[');
                int indexend = listItem.LastIndexOf(']');

                string indexstring = listItem.Substring(indexstart + 1, indexend - indexstart - 1);
                int index = int.Parse(indexstring);

                if (listItem.StartsWith("[lgo]"))
                {
                    string filename = parentForm.lgofiles[index];

                    lwGeomObjInfo geom = new lwGeomObjInfo();
                    if (geom.Load(filename) == 0)
                        group.Add(geom, filename);
                }
                if (listItem.StartsWith("[lmo]"))
                {
                    string filename = parentForm.lmofiles[index];

                    lwModelObjInfo model = new lwModelObjInfo();
                    if (model.Load(filename) == 0)
                        group.Add(model, filename);
                }
                if (listItem.StartsWith("[char]"))
                {
                    CChaRecord character = parentForm.chainfo[index];

                    for (int i = 0; i < 5; i++)
                    {
                        if (character.sSkinInfo[i] != 0)
                        {
                            if (character.chModalType == 1)
                            {
                                CItemRecord rec = parentForm.iteminfo[parentForm.iteminfokeys[character.sSkinInfo[i]]];

                                char[] mdl = new char[19];
                                Array.Copy(rec.chModule, (character.sModel + 1) * 19, mdl, 0, 19);

                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = parentForm.textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                    group.Add(geom, filenameModel);
                            }
                            if (character.chModalType == 2)
                            {
                                CItemRecord rec = parentForm.iteminfo[parentForm.iteminfokeys[character.sSkinInfo[i]]];

                                char[] mdl = new char[19];
                                Array.Copy(rec.chModule, 0, mdl, 0, 19);

                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = parentForm.textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                    group.Add(geom, filenameModel);
                            }
                            if (character.chModalType == 4)
                            {
                                lwGeomObjInfo geom = new lwGeomObjInfo();
                                string filenameModel = parentForm.textBox1.Text + "model\\character\\" + (i + 10000 * (character.sSuitID + 100 * character.sModel)).ToString("0000000000") + ".lgo";
                                if (geom.Load(filenameModel) == 0)
                                    group.Add(geom, filenameModel);
                            }
                        }
                    }
                }
                if (listItem.StartsWith("[item]"))
                {
                    CItemRecord item = parentForm.iteminfo[index];

                    for (int i = 0; i < 5; i++)
                    {
                        char[] mdl = new char[19];
                        Array.Copy(item.chModule, i * 19, mdl, 0, 19);
                        lwGeomObjInfo geom = new lwGeomObjInfo();
                        string filenameModel = parentForm.textBox1.Text + "model\\item\\" + CutString(mdl) + ".lgo";
                        if (item.sType >= 19 && item.sType <= 25) filenameModel = parentForm.textBox1.Text + "model\\character\\" + CutString(mdl) + ".lgo";

                        if (geom.Load(filenameModel) == 0)
                            group.Add(geom, filenameModel);
                    }
                }

                Export(group);
            }

            button4_Click(sender, e);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxExport.SelectedItems)
            {
                ;
            }

            button4_Click(sender, e);
        }

        string GetTargetTexturePath(Mindpower.lwGeomObjInfo geom, int mtl_id, string origin_filename)
        {
            string texname = new string(geom.mtl_seq[mtl_id].tex_seq[0].file_name);
            string path = origin_filename.Replace(parentForm.textBox1.Text + "model\\", "");
            return textBox2.Text + path;
        }
        string GetOriginTexturePath(Mindpower.lwGeomObjInfo geom, int mtl_id, string origin_filename)
        {
            string path = origin_filename.Replace("\\model\\", "\\texture\\");
            int pathid = path.LastIndexOf("\\");
            path = path.Substring(0, pathid + 1) + new string(geom.mtl_seq[mtl_id].tex_seq[0].file_name);
            return path;
        }
        string GetTargetModelPath(string origin_filename)
        {
            string path = origin_filename.Replace(parentForm.textBox1.Text + "model\\", textBox1.Text);
            return path;
        }
        string CutString(char[] cstr)
        {
            int length = 0;
            while (length < cstr.Length && cstr[length] != '\0')
                length++;
            return new string(cstr, 0, length);
        }
        string RelativePath(string absPath, string relTo)
        {
            string[] absDirs = absPath.Split('\\');
            string[] relDirs = relTo.Split('\\');

            // Get the shortest of the two paths
            int len = absDirs.Length < relDirs.Length ? absDirs.Length :
            relDirs.Length;

            // Use to determine where in the loop we exited
            int lastCommonRoot = -1;
            int index;

            // Find common root
            for (index = 0; index < len; index++)
            {
                if (absDirs[index] == relDirs[index]) lastCommonRoot = index;
                else break;
            }

            // If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base");
            }

            // Build up the relative path
            StringBuilder relativePath = new StringBuilder();

            // Add on the ..
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) relativePath.Append("..\\");
            }

            // Add on the folders
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + "\\");
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);

            return relativePath.ToString();
        }

        void Export(ExportGroup group)
        {
            if (listBoxFormats.SelectedIndex == 0)
            {
                string filename=textBox3.Text;
                if (!checkBox3.Checked)
                {
                    if (group.geomsoriginpath.Count > 0) filename = group.geomsoriginpath[0];
                    else if (group.modelsoriginpath.Count > 0) filename = group.modelsoriginpath[0];
                    else if (group.bonesoriginpath.Count > 0) filename = group.bonesoriginpath[0];
                    else return;
                }

                ExportObjInfo info = new ExportObjInfo(System.IO.Path.GetDirectoryName(textBox1.Text) + "\\" + System.IO.Path.GetFileName(filename));
                group.targetfilename = System.IO.Path.GetFileName(filename);

                ExportToObj(group, info);

                info.stream.Close();
                info.mtlstream.Close();
            }
        }
        void ExportToObj(lwGeomObjInfo geom, string obj_name, string pathtomodel, ExportGroup group, ExportObjInfo info)
        {
            System.IO.StreamWriter objwriter = info.objwriter;
            System.IO.StreamWriter mtlwriter = info.mtlwriter;

            int startvertex = info.totalvertexes;
            int startnormal = info.totalnormals;
            int starttexcoord = info.totaltexcoord;
            int startindex = info.totalindexes;

            bool texcoordexist = false;
            bool normalexist = false;

            lock (threadLock)
            {
                for (int i = 0; i < geom.mesh.header.vertex_num; i++)
                {
                    D3DXVECTOR3 pos = geom.mesh.vertex_seq[i];
                    pos = pos * geom.header.mat_local;

                    if (checkBox5.Checked)
                    {
                        float z = -pos.y;
                        pos.y = pos.z;
                        pos.z = z;
                    }

                    objwriter.WriteLine("v {0:0.0000} {1:0.0000} {2:0.0000}", pos.x, pos.y, pos.z);
                    info.totalvertexes++;
                }

                if ((geom.mesh.header.fvf & 0x10) != 0)
                {
                    normalexist = true;
                    for (int i = 0; i < geom.mesh.header.vertex_num; i++)
                    {
                        objwriter.WriteLine("vn {0:0.0000} {1:0.0000} {2:0.0000}", geom.mesh.normal_seq[i].x, geom.mesh.normal_seq[i].y, geom.mesh.normal_seq[i].z);
                        info.totalnormals++;
                    }
                }
                if ((geom.mesh.header.fvf & 0x100) != 0 || (geom.mesh.header.fvf & 0x200) != 0 || (geom.mesh.header.fvf & 0x300) != 0 || (geom.mesh.header.fvf & 0x400) != 0)
                {
                    texcoordexist = true;
                    for (int i = 0; i < geom.mesh.header.vertex_num; i++)
                    {
                        if (checkBox4.Checked)
                            objwriter.WriteLine("vt {0:0.0000} {1:0.0000}", geom.mesh.texcoord0_seq[i].x, 1 - geom.mesh.texcoord0_seq[i].y);
                        else
                            objwriter.WriteLine("vt {0:0.0000} {1:0.0000}", geom.mesh.texcoord0_seq[i].x, geom.mesh.texcoord0_seq[i].y);
                        info.totaltexcoord++;
                    }
                }
            }

            for (int i = 0; i < geom.mesh.header.subset_num; i++)
            {
                string mtlname = obj_name;
                lock (threadLock)
                {
                    objwriter.WriteLine("\ng {0}_{1}", mtlname, i);
                    objwriter.WriteLine("usemtl {0}-{1}\n", mtlname,i);
                    objwriter.WriteLine("s off");

                    for (int j = 0; j < geom.mesh.subset_seq[i].primitive_num * 3; j += 3)
                    {
                        objwriter.Write("f ");
                        for (int k = 0; k < 3; k++)
                        {
                            uint facevertex = (uint)(geom.mesh.index_seq[j + k + geom.mesh.subset_seq[i].start_index] + startvertex) + 1;
                            uint facenormal = (uint)(geom.mesh.index_seq[j + k + geom.mesh.subset_seq[i].start_index] + startnormal) + 1;
                            uint facetexcoord = (uint)(geom.mesh.index_seq[j + k + geom.mesh.subset_seq[i].start_index] + starttexcoord) + 1;
                            if (normalexist && texcoordexist)
                                objwriter.Write("{0}/{1}/{2} ", facevertex, facetexcoord, facenormal);
                            else if (normalexist && !texcoordexist)
                                objwriter.Write("{0}//{2} ", facevertex, facenormal);
                            else if (!normalexist && texcoordexist)
                                objwriter.Write("{0}/{1} ", facevertex, facetexcoord);
                            else
                                objwriter.Write("{0} ", facevertex);
                        }
                        objwriter.Write("\n");
                    }

                    mtlwriter.WriteLine("newmtl {0}-{1}", mtlname,i);
                    mtlwriter.WriteLine("Ka {0} {1} {2}", geom.mtl_seq[i].mtl.amb.r, geom.mtl_seq[i].mtl.amb.g, geom.mtl_seq[i].mtl.amb.b);
                    mtlwriter.WriteLine("Kd {0} {1} {2}", geom.mtl_seq[i].mtl.dif.r, geom.mtl_seq[i].mtl.dif.g, geom.mtl_seq[i].mtl.dif.b);
                    mtlwriter.WriteLine("Ks {0} {1} {2}", geom.mtl_seq[i].mtl.spe.r, geom.mtl_seq[i].mtl.spe.g, geom.mtl_seq[i].mtl.spe.b);

                    string newtexturepath = RelativePath(System.IO.Path.GetDirectoryName(textBox1.Text) + "\\", System.IO.Path.GetDirectoryName(textBox2.Text) + "\\");
                    mtlwriter.WriteLine("map_Kd {0}", newtexturepath + CutString(geom.mtl_seq[i].tex_seq[0].file_name));
                }

                if (checkBox2.Checked)
                {
                    string path = System.IO.Path.GetDirectoryName(pathtomodel).Replace("\\model\\", "\\texture\\");
                    System.Drawing.Bitmap bmp = parentForm.LoadBitmaByTextureName(path + "\\" + CutString(geom.mtl_seq[i].tex_seq[0].file_name));
                    bmp.Save(System.IO.Path.GetDirectoryName(textBox2.Text) + "\\" + CutString(geom.mtl_seq[i].tex_seq[0].file_name));
                }
                else
                {
                    string path = System.IO.Path.GetDirectoryName(pathtomodel).Replace("\\model\\", "\\texture\\");
                    string filename = parentForm.GetRightTextureName(path + "\\" + CutString(geom.mtl_seq[i].tex_seq[0].file_name));

                    if (filename != null)
                        System.IO.File.Copy(filename, System.IO.Path.GetDirectoryName(textBox2.Text) + "\\" + CutString(geom.mtl_seq[i].tex_seq[0].file_name), true);
                }
            }
        }
        void ExportToObj(ExportGroup group,ExportObjInfo info)
        {
            System.IO.StreamWriter objwriter = info.objwriter;
            System.IO.StreamWriter mtlwriter = info.mtlwriter;

            lock (threadLock)
            {
                objwriter.WriteLine("mtllib {0}.mtl\n", group.targetfilename);
                objwriter.WriteLine("o {0}\n", System.IO.Path.GetFileNameWithoutExtension(group.targetfilename));
            }

            int objId=0;
            foreach (lwGeomObjInfo geom in group.geoms)
            {
                ExportToObj(geom, 
                    System.IO.Path.GetFileNameWithoutExtension(group.geomsoriginpath[objId]) + "_" + objId, 
                    group.geomsoriginpath[objId], 
                    group, 
                    info);
                objId++;
            }

            int mdlId=0;
            foreach (lwModelObjInfo model in group.models)
            {
                for (int i = 0; i < model.geom_obj_num; i++)
                {
                    ExportToObj(model.geom_obj_seq[i], 
                        System.IO.Path.GetFileNameWithoutExtension(group.modelsoriginpath[mdlId]) + "-" + i + "_" + objId, 
                        group.modelsoriginpath[mdlId], 
                        group, 
                        info);
                    objId++;
                }
                mdlId++;
            }

            mtlwriter.Close();
            objwriter.Close();
        }
    }
}
