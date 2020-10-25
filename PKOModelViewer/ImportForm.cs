using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Mindpower;

namespace PKOModelViewer
{
    public partial class ImportForm : Form
    {
        MainForm parentForm;
        object threadLock = new object();

        public ImportForm(MainForm parent)
        {
            InitializeComponent();
            parentForm = parent;
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

        private void ImportForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            listBoxFormats.SelectedIndex = 0;

            textBox1.Text = parentForm.textBox1.Text + "importmodel\\";
            textBox2.Text = parentForm.textBox1.Text + "importmodel\\";
            System.IO.Directory.CreateDirectory(textBox1.Text);
            System.IO.Directory.CreateDirectory(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxFormats.SelectedIndex == 0)
            {
                string filename = textBox3.Text;

                if (!System.IO.Directory.Exists(textBox1.Text)) MessageBox.Show("Target model folder not exists");
                if (!System.IO.Directory.Exists(textBox2.Text)) MessageBox.Show("Target texture folder not exists");

                if (radioButton1.Checked)
                {
                    ImportObjToLgo(filename);
                }
                else if (radioButton2.Checked)
                {
                    // not ready
                    // ImportObjToLmo(filename);
                }
            }
        }

        class ObjMaterialData
        {
            public string name;
            public string textureName;
            public lwColorValue4f a;
            public lwColorValue4f d;
            public lwColorValue4f s;
        };

        class ObjSubsetData
        {
            public struct VertexData 
            {
               public int vertex;
               public int normal;
               public int texCoords;
            };
            public string name;
            public string material;
            public bool smooth;
            public List<VertexData> vertexes = new List<VertexData>();

            public void addVertexData(string set)
            {
                var subparts = set.Split('/');
                this.vertexes.Add(new VertexData()
                {
                    vertex = int.Parse(subparts[0]),
                    normal = int.Parse(subparts[1]),
                    texCoords = int.Parse(subparts[2])
                });
            }
        };



        void ImportObjToLgo(string filename)
        {
            var lines = System.IO.File.ReadAllLines(filename);

            string materialLib = "";

            List<Mindpower.D3DXVECTOR3> vertexes = new List<Mindpower.D3DXVECTOR3>();
            List<Mindpower.D3DXVECTOR3> normals = new List<Mindpower.D3DXVECTOR3>();
            List<Mindpower.D3DXVECTOR2> textures = new List<Mindpower.D3DXVECTOR2>();

            List<ObjMaterialData> materials = new List<ObjMaterialData>();
            ObjMaterialData currentMaterial = null;

            List<ObjSubsetData> subsets = new List<ObjSubsetData>();
            ObjSubsetData currentSubset = null;

            foreach (var line in lines)
            {
                var parts = line.Split(' ');

                switch (parts[0].Trim())
                {
                    case "o": // object name. ignore
                    case "": break;

                    case "mtllib":
                        materialLib = parts[1];
                        {
                            var materialLines = System.IO.File.ReadAllLines(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), materialLib));
                            foreach (var materialLine in materialLines)
                            {
                                var materialParts = materialLine.Split(' ');
                                switch (materialParts[0].Trim())
                                {
                                    case "newmtl":
                                        if (currentMaterial != null) materials.Add(currentMaterial);
                                        currentMaterial = new ObjMaterialData() { name = materialParts[1] };
                                        break;
                                    case "Ka":
                                        currentMaterial.a = new lwColorValue4f()
                                        {
                                            a = 1,
                                            r = float.Parse(materialParts[1], CultureInfo.InvariantCulture),
                                            g = float.Parse(materialParts[2], CultureInfo.InvariantCulture),
                                            b = float.Parse(materialParts[3], CultureInfo.InvariantCulture)
                                        }; break;
                                    case "Kd":
                                        currentMaterial.d = new lwColorValue4f()
                                        {
                                            a = 1,
                                            r = float.Parse(materialParts[1], CultureInfo.InvariantCulture),
                                            g = float.Parse(materialParts[2], CultureInfo.InvariantCulture),
                                            b = float.Parse(materialParts[3], CultureInfo.InvariantCulture)
                                        }; break;
                                    case "Ks":
                                        currentMaterial.s = new lwColorValue4f()
                                        {
                                            a = 1,
                                            r = float.Parse(materialParts[1], CultureInfo.InvariantCulture),
                                            g = float.Parse(materialParts[2], CultureInfo.InvariantCulture),
                                            b = float.Parse(materialParts[3], CultureInfo.InvariantCulture)
                                        }; break;
                                    case "map_Kd":
                                        currentMaterial.textureName = materialParts[1]; break;
                                }
                            }
                            if (currentMaterial != null) materials.Add(currentMaterial);
                        }
                        break;
                    case "v":
                        vertexes.Add(new Mindpower.D3DXVECTOR3()
                        {
                            x = float.Parse(parts[1], CultureInfo.InvariantCulture),
                            y = float.Parse(parts[2], CultureInfo.InvariantCulture),
                            z = float.Parse(parts[3], CultureInfo.InvariantCulture)
                        }); break;
                    case "vn":
                        normals.Add(new Mindpower.D3DXVECTOR3()
                        {
                            x = float.Parse(parts[1], CultureInfo.InvariantCulture),
                            y = float.Parse(parts[2], CultureInfo.InvariantCulture),
                            z = float.Parse(parts[3], CultureInfo.InvariantCulture)
                        }); break;
                    case "vt":
                        textures.Add(new Mindpower.D3DXVECTOR2()
                        {
                            x = float.Parse(parts[1], CultureInfo.InvariantCulture),
                            y = float.Parse(parts[2], CultureInfo.InvariantCulture)
                        }); break;
                    case "g":
                        if (currentSubset != null) subsets.Add(currentSubset);
                        currentSubset = new ObjSubsetData() { name = parts[1] };
                        break;
                    case "usemtl":
                        if (currentSubset == null) currentSubset = new ObjSubsetData() { name = "Unnamed" };
                        currentSubset.material = parts[1];
                        break;
                    case "s":
                        if (currentSubset == null) currentSubset = new ObjSubsetData() { name = "Unnamed" };
                        currentSubset.smooth = parts[1] == "on";
                        break;
                    case "f":
                        for (int i = 1; i < parts.Length; i++)
                        {
                            if (parts[i].Length == 0) continue;
                            currentSubset.addVertexData(parts[i]);
                        }
                        break;
                    default:break;
                }
            }

            if (currentSubset != null) subsets.Add(currentSubset);

            Dictionary<ObjSubsetData.VertexData, int> indexes = new Dictionary<ObjSubsetData.VertexData, int>();
            List<uint> indexesSeq = new List<uint>();
            int totalIndexes = 0;
            foreach (var subset in subsets)
            {
                totalIndexes += subset.vertexes.Count;
                foreach (var vertex in subset.vertexes)
                {
                    if (!indexes.ContainsKey(vertex)) indexes.Add(vertex, indexes.Count);
                    indexesSeq.Add((uint)indexes[vertex]);
                }
            }

            lwGeomObjInfo geom = new lwGeomObjInfo();

            geom.mesh = new lwMeshInfo();
            geom.mesh.vertex_seq = new D3DXVECTOR3[indexes.Count];
            geom.mesh.normal_seq = new D3DXVECTOR3[indexes.Count];
            geom.mesh.texcoord0_seq = new D3DXVECTOR2[indexes.Count];
            geom.mesh.subset_seq = new lwSubsetInfo[subsets.Count];
            geom.mesh.index_seq = indexesSeq.ToArray();
            geom.mtl_seq = new lwMtlTexInfo[subsets.Count];

            int materiasCounter = 0;
            totalIndexes = 0;
            foreach (var subset in subsets)
            {
                geom.mesh.subset_seq[materiasCounter] = new lwSubsetInfo();
                geom.mesh.subset_seq[materiasCounter].primitive_num = (uint)(subset.vertexes.Count / 3);
                geom.mesh.subset_seq[materiasCounter].start_index = (uint)totalIndexes;
                geom.mesh.subset_seq[materiasCounter].min_index = 0;
                geom.mesh.subset_seq[materiasCounter].vertex_num = 0x00000000;

                int subset_ind_num = totalIndexes + subset.vertexes.Count;
                for (int j = 0; j < subset.vertexes.Count; j++)
                {
                    var vertex = subset.vertexes[j];
                    var index = indexes[vertex];

                    if (geom.mesh.subset_seq[materiasCounter].min_index > index)
                    {
                        geom.mesh.subset_seq[materiasCounter].min_index = (uint)index;
                    }
                    if (geom.mesh.subset_seq[materiasCounter].vertex_num < index)
                    {
                        geom.mesh.subset_seq[materiasCounter].vertex_num = (uint)index;
                    }
                }

                geom.mesh.subset_seq[materiasCounter].vertex_num -= geom.mesh.subset_seq[materiasCounter].min_index;
                geom.mesh.subset_seq[materiasCounter].vertex_num += 1;

                geom.mtl_seq[materiasCounter] = new lwMtlTexInfo();

                geom.mtl_seq[materiasCounter].rs_set = new lwRenderStateAtom[8];
                geom.mtl_seq[materiasCounter].tex_seq = new lwTexInfo[4];
                for (int i = 0; i < 4; i++)
                {
                    geom.mtl_seq[materiasCounter].tex_seq[i] = new lwTexInfo()
                    {
                        file_name = new char[64],
                        tss_set = new lwRenderStateAtom[8]
                    };
                }

                ObjMaterialData thisMaterial = null;
                foreach (var mtl in materials)
                {
                    if (subset.material == mtl.name) thisMaterial = mtl;
                }

                if (thisMaterial != null)
                {
                    if (thisMaterial.textureName == null)
                    {
                        thisMaterial.textureName = "1.BMP";
                        ShowInputDialog(ref thisMaterial.textureName, "No texture for material " + thisMaterial.name + ". Enter new one texture name");
                    }

                    geom.mtl_seq[materiasCounter].mtl.amb.r = thisMaterial.a.r;
                    geom.mtl_seq[materiasCounter].mtl.amb.g = thisMaterial.a.g;
                    geom.mtl_seq[materiasCounter].mtl.amb.b = thisMaterial.a.b;
                    geom.mtl_seq[materiasCounter].mtl.dif.r = thisMaterial.d.r;
                    geom.mtl_seq[materiasCounter].mtl.dif.g = thisMaterial.d.g;
                    geom.mtl_seq[materiasCounter].mtl.dif.b = thisMaterial.d.b;
                    geom.mtl_seq[materiasCounter].mtl.spe.r = thisMaterial.s.r;
                    geom.mtl_seq[materiasCounter].mtl.spe.g = thisMaterial.s.g;
                    geom.mtl_seq[materiasCounter].mtl.spe.b = thisMaterial.s.b;
                    geom.mtl_seq[materiasCounter].mtl.amb.a = geom.mtl_seq[materiasCounter].mtl.dif.a = geom.mtl_seq[materiasCounter].mtl.spe.a = 1.0f;

                    geom.mtl_seq[materiasCounter].opacity = 1;

                    for (int i = 0; i < geom.mtl_seq[materiasCounter].rs_set.Length; i++)
                        geom.mtl_seq[materiasCounter].rs_set[i].state = unchecked((uint)-1);
                    for (int i = 0; i < geom.mtl_seq[materiasCounter].tex_seq.Length; i++)
                        for (int j = 0; j < geom.mtl_seq[materiasCounter].tex_seq[i].tss_set.Length; j++)
                            geom.mtl_seq[materiasCounter].tex_seq[i].tss_set[j].state = unchecked((uint)-1);
                    geom.mtl_seq[materiasCounter].transp_type = Mindpower.lwMtlTexInfoTransparencyTypeEnum.MTLTEX_TRANSP_FILTER;

                    geom.mtl_seq[materiasCounter].tex_seq[0].type = (int)Mindpower.lwTexInfoTypeEnum.TEX_TYPE_FILE;
                    geom.mtl_seq[materiasCounter].tex_seq[0].stage = 0;
                    geom.mtl_seq[materiasCounter].tex_seq[0].level = 1;
                    geom.mtl_seq[materiasCounter].tex_seq[0].usage = 0;
                    geom.mtl_seq[materiasCounter].tex_seq[0].format = _D3DFORMAT.D3DFMT_UNKNOWN;
                    geom.mtl_seq[materiasCounter].tex_seq[0].pool = _D3DPOOL.D3DPOOL_DEFAULT;
                    geom.mtl_seq[materiasCounter].tex_seq[0].file_name = new char[64];
                    thisMaterial.textureName.CopyTo(0, geom.mtl_seq[materiasCounter].tex_seq[0].file_name, 0, Math.Min(geom.mtl_seq[materiasCounter].tex_seq[0].file_name.Length, thisMaterial.textureName.Length));

                    string sourceTexture = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), thisMaterial.textureName);
                    if (System.IO.File.Exists(sourceTexture) && System.IO.Directory.Exists(textBox2.Text))
                    {
                        try
                        {
                            System.IO.File.Copy(sourceTexture, System.IO.Path.Combine(textBox2.Text, thisMaterial.textureName));
                        }
                        catch {; }
                    }
                }
                else
                {
                    geom.mtl_seq[materiasCounter].mtl.amb.r = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.amb.g = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.amb.b = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.r = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.g = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.b = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.r = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.g = 0.75f;
                    geom.mtl_seq[materiasCounter].mtl.dif.b = 0.75f;

                    geom.mtl_seq[materiasCounter].mtl.amb.a = geom.mtl_seq[materiasCounter].mtl.dif.a = geom.mtl_seq[materiasCounter].mtl.spe.a = 1.0f;

                    string texture = "1.BMP";
                    texture.CopyTo(0, geom.mtl_seq[materiasCounter].tex_seq[0].file_name, 0, Math.Min(geom.mtl_seq[materiasCounter].tex_seq[0].file_name.Length, texture.Length));
                }

                materiasCounter++;
                totalIndexes += subset.vertexes.Count;
            }

            foreach (var keyValue in indexes)
            {
                int index = keyValue.Value;
                var vertexData = keyValue.Key;

                geom.mesh.vertex_seq[index] = vertexes[vertexData.vertex - 1];
                geom.mesh.normal_seq[index] = normals[vertexData.vertex - 1];
                geom.mesh.texcoord0_seq[index] = textures[vertexData.vertex - 1];
            }

            geom.mesh.header.vertex_num = (uint)indexes.Count;
            geom.mesh.header.index_num = (uint)totalIndexes;
            geom.mesh.header.subset_num = (uint)subsets.Count;

            geom.header.id = 1; // i not sure this is correct
            geom.header.parent_id = unchecked((uint)-1);
            geom.header.mat_local = new D3DXMATRIX() { m = new float[16] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 } };
            geom.header.rcci.ctrl_id = 1;
            geom.header.rcci.decl_id = 5;
            geom.mtl_num = (uint)subsets.Count;

            {
                _D3DVERTEXELEMENT9[] vert_decl = new _D3DVERTEXELEMENT9[32];
                uint ve_num = 0;
                ushort this_offset = 0;

                if (geom.mesh.vertex_seq != null)
                {
                    vert_decl[ve_num].Stream = 0;
                    vert_decl[ve_num].Offset = this_offset;
                    vert_decl[ve_num].Type = 2;
                    vert_decl[ve_num].Method = 0;
                    vert_decl[ve_num].Usage = 0;
                    vert_decl[ve_num].UsageIndex = 0;

                    ve_num += 1;
                    this_offset += (ushort)System.Runtime.InteropServices.Marshal.SizeOf(typeof(D3DXVECTOR3));
                }

                if (geom.mesh.normal_seq != null)
                {
                    vert_decl[ve_num].Stream = 0;
                    vert_decl[ve_num].Offset = this_offset;
                    vert_decl[ve_num].Type = 2;
                    vert_decl[ve_num].Method = 0;
                    vert_decl[ve_num].Usage = 3;
                    vert_decl[ve_num].UsageIndex = 0;

                    ve_num += 1;
                    this_offset += (ushort)System.Runtime.InteropServices.Marshal.SizeOf(typeof(D3DXVECTOR3));
                }
                if (geom.mesh.texcoord0_seq != null)
                {
                    vert_decl[ve_num].Stream = 0;
                    vert_decl[ve_num].Offset = this_offset;
                    vert_decl[ve_num].Type = 1;
                    vert_decl[ve_num].Method = 0;
                    vert_decl[ve_num].Usage = 5;
                    vert_decl[ve_num].UsageIndex = 0;

                    ve_num += 1;
                    this_offset += (ushort)System.Runtime.InteropServices.Marshal.SizeOf(typeof(D3DXVECTOR2));
                }

                // VE_END
                vert_decl[ve_num].Stream = 0xff;
                vert_decl[ve_num].Offset = 0;
                vert_decl[ve_num].Type = 0;
                vert_decl[ve_num].Method = 0;
                vert_decl[ve_num].Usage = 0;
                vert_decl[ve_num].UsageIndex = 0;

                ve_num += 1;

                // fill it
                geom.mesh.header.vertex_element_num = ve_num;
                geom.mesh.vertex_element_seq = new _D3DVERTEXELEMENT9[geom.mesh.header.vertex_element_num];
                for (int i = 0; i < geom.mesh.header.vertex_element_num; i++)
                    geom.mesh.vertex_element_seq[i] = vert_decl[i];
            }

            geom.mesh.header.fvf = 0x110;
            geom.mesh.header.pt_type = _D3DPRIMITIVETYPE.D3DPT_TRIANGLELIST;

            geom.header.mtl_size = 0;
            for (int i = 0; i < geom.mtl_num; i++)
            {
                geom.header.mtl_size +=
                    (uint)(Marshal.SizeOf(typeof(float)) +
                Marshal.SizeOf(typeof(uint)) +
                Marshal.SizeOf(typeof(lwMaterial)) +
                Marshal.SizeOf(typeof(lwRenderStateAtom)) * 8 +
                Marshal.SizeOf(typeof(lwTexInfo)) * 4);
            }

            geom.header.state_ctrl = new lwStateCtrl() { _state_seq = new byte[8] };
            geom.header.state_ctrl.SetState(0, 1);
            geom.header.state_ctrl.SetState(1, 1);

            if (geom.header.mtl_size > 0)
            {
                geom.header.mtl_size += (uint)Marshal.SizeOf(typeof(uint)); // number
            }

            geom.header.mesh_size =
                (uint)Marshal.SizeOf(typeof(lwMeshInfo.lwMeshInfoHeader))
                + (uint)Marshal.SizeOf(typeof(_D3DVERTEXELEMENT9)) * geom.mesh.header.vertex_element_num
                + (uint)Marshal.SizeOf(typeof(lwSubsetInfo)) * geom.mesh.header.subset_num
                + (uint)Marshal.SizeOf(typeof(D3DXVECTOR3)) * geom.mesh.header.vertex_num
                + (uint)Marshal.SizeOf(typeof(D3DXVECTOR3)) * geom.mesh.header.vertex_num
                + (uint)Marshal.SizeOf(typeof(D3DXVECTOR2)) * geom.mesh.header.vertex_num
                + (uint)Marshal.SizeOf(typeof(uint)) * geom.mesh.header.index_num;

            geom.header.anim_size = 0;
            geom.header.helper_size = 0;

            geom.Save(System.IO.Path.Combine(textBox1.Text, System.IO.Path.GetFileNameWithoutExtension(filename) + ".lgo"));
        }

        private static DialogResult ShowInputDialog(ref string input, string message)
        {
            System.Drawing.Size size = new System.Drawing.Size(500, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = message;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
