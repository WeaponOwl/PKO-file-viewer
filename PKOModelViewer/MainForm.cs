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
        enum DrawObjectType { none, lab, lgo, lmo, lxo };

        object drawObject = null;
        DrawObjectType drawObjectType = DrawObjectType.none;
        int[] textures = new int[128];
        int totaltextures = 0;
        float rotate = 0;
        float rotateOffcet = 0;
        float scale = 1;
        float scaleOffcet = 1;
        Point oldMouseDown;

        public MainForm()
        {
            for (int i = 0; i < textures.Length; i++)
                textures[i] = -1;

            if (!FreeImageAPI.FreeImage.IsAvailable()) MessageBox.Show("Need FreeImage.dll");

            InitializeComponent();
        }

        private void buttonSelectFoler_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath + "\\";
                textBox1.Text = path;
            }
        }

        private void buttonFindFiles_Click(object sender, EventArgs e)
        {
            string[] labfiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lab", System.IO.SearchOption.AllDirectories);
            string[] lgofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lgo", System.IO.SearchOption.AllDirectories);
            string[] lmofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lmo", System.IO.SearchOption.AllDirectories);
            string[] lxofiles = System.IO.Directory.GetFiles(textBox1.Text, "*.lxo", System.IO.SearchOption.AllDirectories);
            TreeNode labNode = new TreeNode("lab - animate bone");
            TreeNode lgoNode = new TreeNode("lgo - geometry object");
            TreeNode lmoNode = new TreeNode("lmo - map object");
            TreeNode lxoNode = new TreeNode("lxo - login scene");
            foreach (string s in labfiles)
            {
                string name = s.Substring(s.LastIndexOf("\\") + 1) + "\t[" + s + "]";
                labNode.Nodes.Add(name);
            }
            foreach (string s in lgofiles)
            {
                string name = s.Substring(s.LastIndexOf("\\") + 1) + "\t[" + s + "]";
                lgoNode.Nodes.Add(name);
            }
            foreach (string s in lmofiles)
            {
                string name = s.Substring(s.LastIndexOf("\\") + 1) + "\t[" + s + "]";
                lmoNode.Nodes.Add(name);
            }
            foreach (string s in lxofiles)
            {
                string name = s.Substring(s.LastIndexOf("\\") + 1) + "\t[" + s + "]";
                lxoNode.Nodes.Add(name);
            }
            treeOfFiles.Nodes.Add(labNode);
            treeOfFiles.Nodes.Add(lgoNode);
            treeOfFiles.Nodes.Add(lmoNode);
            treeOfFiles.Nodes.Add(lxoNode);
        }

        bool LoadAsBmp(System.IO.Stream stream)
        {
            try
            {
                FreeImageAPI.FreeImageBitmap fbmp = FreeImageAPI.FreeImageBitmap.FromStream(stream);
                Bitmap bmp = fbmp.ToBitmap();
                BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

                bmp.UnlockBits(bmp_data);
            }
            catch (Exception e) {return false; }
            return true;
        }
        bool LoadTexture(string filename)
        {
            filename = filename.Substring(0, filename.LastIndexOf('.'));
            if (System.IO.File.Exists(filename + ".bmp")) filename = filename + ".bmp";
            else if (System.IO.File.Exists(filename + ".dds")) filename = filename + ".dds";
            else if (System.IO.File.Exists(filename + ".tga")) filename = filename + ".tga";
            else if (System.IO.File.Exists(filename + ".png")) filename = filename + ".png";
            else if (System.IO.File.Exists(filename + ".jpg")) filename = filename + ".jpg";
            else return false;

            byte[] data = System.IO.File.ReadAllBytes(filename);
            
            System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
            if (LoadAsBmp(ms)) { ms.Close(); return true; }
            ms.Close();

            byte[] encodeddata = new byte[data.Length];

            Array.Copy(data, data.Length - 48, encodeddata, 0, 44);
            Array.Copy(data, 44, encodeddata, 44, data.Length - 44 - 44);
            Array.Copy(data, 0, encodeddata, data.Length - 44, 44);
            ms = new System.IO.MemoryStream(encodeddata);
            if (LoadAsBmp(ms)) { ms.Close(); return true; }
            ms.Close();

            return false;
        }
        void LoadTextures(ref lwGeomObjInfo geom, string originpath)
        {
            for (int i = 0; i < geom.mtl_num; i++)
            {
                for (int j = 0; j < geom.mtl_seq[i].tex_seq.Length; j++)
                {
                    if (geom.mtl_seq[i].tex_seq[j]!=null&&geom.mtl_seq[i].tex_seq[j].file_name != null)
                    {
                        int length = 0;
                        while (geom.mtl_seq[i].tex_seq[j].file_name[length] != '\0' && length < geom.mtl_seq[i].tex_seq[j].file_name.Length) length++;
                        string filename = new string(geom.mtl_seq[i].tex_seq[j].file_name, 0, length);

                        if (filename.Length > 0)
                        {
                            int id = GL.GenTexture();
                            string path = originpath.Replace("\\model\\", "\\texture\\");
                            int pathid = path.LastIndexOf("\\");
                            string path2 = path.Substring(0, pathid + 1) + filename;

                            GL.BindTexture(TextureTarget.Texture2D, id);
                            if (LoadTexture(path2))
                            {
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

                                textures[totaltextures] = id;
                                totaltextures++;
                                geom.mtl_seq[i].tex_seq[j].data_pointer = (uint)id;
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
        private void treeOfFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = e.Node.Text.IndexOf('[');
            if (index > 0)
            {
                string name = e.Node.Text.Substring(index + 1, e.Node.Text.Length - index - 2);

                if (name.Contains(".lab"))
                {
                    lwAnimDataBone bone = new lwAnimDataBone();
                    if (bone.Load(name) != 0) { bone = null; return; }

                    drawObject = bone;
                    drawObjectType = DrawObjectType.lab;

                    glControl1.Refresh();

                    string info = name + "\n";
                    info += "\nbones: " + bone._header.bone_num;
                    info += "\nframes: " + bone._header.frame_num;
                    info += "\ndummys: " + bone._header.dummy_num;

                    richTextBox1.Text = info;
                }

                else if (name.Contains(".lgo"))
                {
                    totaltextures = 0;
                    lwGeomObjInfo geom = new lwGeomObjInfo();
                    if (geom.Load(name) != 0) { geom = null; return; }

                    drawObject = geom;
                    drawObjectType = DrawObjectType.lgo;

                    foreach (uint tex in textures)
                        GL.DeleteTexture(tex);
                    LoadTextures(ref geom, name);

                    string info = name + "\n";
                    info += "\nmaterials:" + geom.mtl_num;
                    for (int i = 0; i < geom.mtl_num; i++)
                    {
                        info += "\n    mtl"+i+" textures:" + geom.mtl_seq[i].tex_seq.Length;
                        for (int j = 0; j < geom.mtl_seq[i].tex_seq.Length;j++ )
                        {
                            if (geom.mtl_seq[i].tex_seq[j]!=null&&geom.mtl_seq[i].tex_seq[j].file_name != null)
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

                else if (name.Contains(".lmo"))
                {
                    totaltextures = 0;
                    lwModelObjInfo model = new lwModelObjInfo();
                    if (model.Load(name) != 0) { model = null; return; }

                    drawObject = model;
                    drawObjectType = DrawObjectType.lmo;

                    string info = name + "\n";
                    info += "\nmodels: " + model.geom_obj_num;

                    foreach (uint tex in textures)
                        GL.DeleteTexture(tex);

                    for (int q = 0; q < model.geom_obj_num; q++)
                    {
                        LoadTextures(ref model.geom_obj_seq[q], name);

                        info += "\n\n---model #"+q;
                        lwGeomObjInfo geom = model.geom_obj_seq[q];
                        info += "\nmaterials:" + geom.mtl_num;
                        for (int i = 0; i < geom.mtl_num; i++)
                        {
                            info += "\n    mtl" + i + " textures:" + geom.mtl_seq[i].tex_seq.Length;
                            for (int j = 0; j < geom.mtl_seq[i].tex_seq.Length; j++)
                            {
                                if (geom.mtl_seq[i].tex_seq[j]!=null&&geom.mtl_seq[i].tex_seq[j].file_name != null)
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
                    }

                    richTextBox1.Text = info;

                    glControl1.Refresh();
                }

                else if (name.Contains(".lxo"))
                {
                    lwModelInfo modelinfo = new lwModelInfo();
                    modelinfo.Load(name);
                    if (modelinfo.Load(name) != 0) { modelinfo = null; return; }

                    drawObject = modelinfo;
                    drawObjectType = DrawObjectType.lxo;

                    glControl1.Refresh();
                }
            }
        }

        void DrawTextures(lwGeomObjInfo geom, float x)
        {
            for (int i = 0; i < geom.mtl_num; i++)
            {
                GL.BindTexture(TextureTarget.Texture2D, geom.mtl_seq[i].tex_seq[0].data_pointer);
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(0, 0); GL.Vertex3(x, i * 1.5f + 0, 1);
                GL.TexCoord2(1, 0); GL.Vertex3(x, i * 1.5f + 1, 1);
                GL.TexCoord2(1, 1); GL.Vertex3(x, i * 1.5f + 1, 0);
                GL.TexCoord2(0, 1); GL.Vertex3(x, i * 1.5f + 0, 0);
                GL.End();
            }
        }
        void DrawGeom(lwGeomObjInfo geom)
        {
            GL.PushMatrix();
            GL.MultMatrix(geom.header.mat_local.m);
            for (int j = 0; j < geom.mesh.header.subset_num; j++)
            {
                GL.BindTexture(TextureTarget.Texture2D, geom.mtl_seq[j].tex_seq[0].data_pointer);
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
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 camera = Matrix4.LookAt(new Vector3(5, 0, 5), new Vector3(0, 0, 1), new Vector3(0, 0, 1));
            GL.MultMatrix(ref camera);
            GL.Rotate(rotate + rotateOffcet, 0, 0, 1);
            GL.Scale(scale*scaleOffcet,scale*scaleOffcet,scale*scaleOffcet);
            GL.Color3(1f, 1f, 1f);

            if (drawObjectType == DrawObjectType.lgo)
            {
                lwGeomObjInfo geom = (lwGeomObjInfo)drawObject;

                GL.Enable(EnableCap.Texture2D);
                DrawGeom(geom);

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
                lwAnimDataBone bone = (lwAnimDataBone)drawObject;
            }

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
            GL.ClearColor(0.3f,0.3f,0.3f,1f);
            GL.Enable(EnableCap.DepthTest);
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
            rotate += rotateOffcet;
            rotateOffcet = 0;
            scale *= scaleOffcet;
            scaleOffcet = 1;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (oldMouseDown.X != 0)
            {
                rotateOffcet = (e.X - oldMouseDown.X);
                scaleOffcet = (float)Math.Pow(1.2,(-e.Y + oldMouseDown.Y) / 10);
                glControl1.Refresh();
            }
        }
    }
}
