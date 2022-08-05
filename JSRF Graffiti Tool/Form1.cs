using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

using JSRF_Graffiti_Tool.Libs;
using System.Net.NetworkInformation;

namespace JSRF_Graffiti_Tool
{
    public partial class Form1 : Form
    {
        #region declarations

        public static string startup_dir = Application.StartupPath;
        private string tmp_dir = Application.StartupPath + "\\resources\\tmp\\";
        string settings_dir = Application.StartupPath + "\\resources\\";
        string tex_dir;

        private Process proc_ImgEditor;

        private String[] texture_sizes = { "128 128", "128 128", "384 256", "512 256", "1024 256" };


        private List<string> settings = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // list_graffitis(0);

            settings_load();
        }

        #region graffiti display

        // called when when one of the graffiti size button is clicked (SS S M L XL)
        // list graffitis of specific size 
        // the size of the graffiti (0-4) is defined in the sender Button's Tag
        private void btn_graffiti_size_Click(object sender, EventArgs e)
        {
            list_graffitis(Convert.ToInt16(((Button)sender).Tag));
        }

        // loads graffitis of specific size and displays the images with Graffiti_PicBox in flowLayoutPanel1
        private void list_graffitis(int size)
        {
            flowLayoutPanel1.Controls.Clear();

            tex_dir = txtb_jsrf_mod_dir.Text;
            if (tex_dir == "") { MessageBox.Show("Error: \"JSRF TEX folder in Settings is not defined, please select the folder."); tabControl1.SelectedIndex = 1; return; }
            if (!Directory.Exists(tex_dir)) { MessageBox.Show("Media\\Mark\\TEX\\  Directory not found.\nPlease make sure you have set the proper JSRF path\nand that JSRF files are in place."); return; }
            

            // search .grf grafitti files of a certain size
            string[] files_grf = Directory.GetFiles(txtb_jsrf_mod_dir.Text.TrimEnd(Path.DirectorySeparatorChar), "grf_" + size.ToString() + "_*.grf");
            string[] files_sai = Directory.GetFiles(txtb_jsrf_mod_dir.Text.TrimEnd(Path.DirectorySeparatorChar), "sai_" + "0" + size.ToString() + "_*.grf");
            string[] files_rpolice = Directory.GetFiles(txtb_jsrf_mod_dir.Text.TrimEnd(Path.DirectorySeparatorChar), "rpolice_" + "0" + size.ToString() + "_*.grf");
            List<string> grf = new List<string>(files_grf);
            List<string> sai = new List<string>(files_sai);
            List<string> rpolice = new List<string>(files_rpolice);

            List<string> graffiti = new List<string>();
            graffiti.AddRange(grf);
            graffiti.AddRange(sai);
            graffiti.AddRange(rpolice);

            if (graffiti.Count == 0) { MessageBox.Show("No graffiti files found."); return; }

            foreach (var file in graffiti)
            {
                Graffiti_PicBox picbox = load_image_to_graffitiPicBox(file);
                if(picbox != null)
                // add graffiti picturebox to flowlayout panel
                flowLayoutPanel1.Controls.Add(picbox);
            }
        }

        // loads image as extended picture box
        private Graffiti_PicBox load_image_to_graffitiPicBox(string filepath)
        {
            Graffiti_PicBox PicBox = new Graffiti_PicBox();
            string filename = Path.GetFileNameWithoutExtension(filepath);
            // make sure its a graffiti file
           // if (!filename.Contains("grf_") || !filename.Contains("sai_") || !filename.Contains("rpolice_")) { return null; }

            int size = Convert.ToInt16(filename.Split('_')[1]);

            // filepath without extension
            filepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath), System.IO.Path.GetFileNameWithoutExtension(filepath));


            // make a copy of the .grf file as .tga if it doesn't already exist
            if (!File.Exists(filepath +".tga"))
            {
                File.Copy(filepath + ".grf", filepath + ".tga");
            }
            // if image hasn't been converted to bmp yet
            if (!File.Exists(filepath + ".png"))
            {
                // convert to bmp so we can load it in the picturebox
                img_convert(filename, tex_dir, "tga", "png", "");
            }

            PicBox.filepath = filepath + ".tga";
            Bitmap bitmap = LoadBitmap(filepath + ".png");
            Bitmap bitmap_thumb = bitmap;

            // scale picturebox depending on the graffiti size
            switch (size)
            {
                case 0:
                case 1:
                    PicBox.Size = new Size(125, 125);
                    bitmap_thumb = new Bitmap(bitmap);
                    break;
                case 2:
                    PicBox.Size = new Size(150, 100);
                    bitmap_thumb = new Bitmap(bitmap);
                    break;
                case 3:
                    PicBox.Size = new Size(175, 87);
                    // resize image to save memory space
                    bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 3, bitmap.Height / 3));
                    break;
                case 4:
                    PicBox.Size = new Size(256, 64);
                    // resize image to save memory space
                    bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 4, bitmap.Height / 4));
                    break;
            }

            PicBox.set_image(bitmap_thumb);
            bitmap.Dispose();

            return PicBox;
        }


        /// <summary>
        ///  this bitmap loading method, allows the bitmap data to be disposed when .Dipose() is used 
        /// this will ensure the bitmap data is cleared from the memory when disposing the picturebox
        /// </summary>
        /// <param name="path">bitmap file path</param>
        /// <returns></returns>
        public static Bitmap LoadBitmap(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                return new Bitmap(memoryStream);
            }
        }

        /// <summary>
        /// convert image to another format
        /// </summary>
        /// <param name="file_name">file name</param>
        /// <param name="working_dir">working directory for VampTool</param>
        /// <param name="in_format">input file format</param>
        /// <param name="out_format">output file format</param>
        /// <param name="args">conversion arguments for VampTool</param>
        private void img_convert(string file_name, string working_dir, string in_format, string out_format, string args)
        {
            string proc_args = "-i=" + file_name + "." + in_format + " -o=" + file_name + "." + out_format + " " + args;

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    // WorkingDirectory = Application.StartupPath + "\\resources\\tmp\\",
                    WorkingDirectory = working_dir,
                    FileName = Application.StartupPath + "\\resources\\tools\\VampConvert.exe",
                    Arguments = proc_args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            proc.WaitForExit();
        }

        // returns graffiti filepath
        private string get_selected_graffiti_filepath()
        {
            string filepath = "";
            foreach (Graffiti_PicBox item in flowLayoutPanel1.Controls)
            {
                if (item.selected)
                {
                    filepath = item.filepath;
                    break;
                }
            }

            if (filepath == "") { MessageBox.Show("Please select a graffiti in the list"); return ""; }
            return filepath;
        }

        #endregion

        #region Selected graffiti buttons/operations

        // Edit selected graffiti
        // opens graffiti image on image editor (i.e. photoshop, paint.net etc)
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtb_img_editor_path.Text))
            {
                MessageBox.Show("Please select an image editor in the Settings tab.");
                tabControl1.SelectedIndex = 1;
                return;
            }

            string graffiti_filepath = get_selected_graffiti_filepath();

            // check if graffiti file path is valid and if file exists
            if (graffiti_filepath == "") { return; }
            if (!File.Exists(graffiti_filepath)) { MessageBox.Show("Could not find file: \n" + graffiti_filepath); return; }


            launch_image_editor(GetShortPath(graffiti_filepath));
        }

        // opens graffiti in image editor
        private void launch_image_editor(string args)
        {
            proc_ImgEditor = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = GetShortPath(tmp_dir),
                    FileName = txtb_img_editor_path.Text,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory());
            proc_ImgEditor.Start();
        }

        // imports .tga image as .bmp and update to corresponding graffiti picturebox (determined by file name)
        // and convert .tga to .grf
        private void btn_import_Click(object sender, EventArgs e)
        {
            string filepath = get_selected_graffiti_filepath();
            if (filepath == "") { return; }
            if (!File.Exists(filepath)) { MessageBox.Show("Could not find file: \n" + filepath); return; }

            clear_cxbx_cache();

            int size = Convert.ToInt16(Path.GetFileNameWithoutExtension(filepath).Split('_')[1]);


            #region check tga dimensions are correct

            //read TGA file to get X Y dimensions
            string tga_size;
            using (BinaryReader b = new BinaryReader(File.Open(filepath, FileMode.Open)))
            {
                // jump headers and stuff directly to what we want
                b.BaseStream.Position = 12;
                tga_size = b.ReadInt16().ToString() + " " + b.ReadInt16().ToString();
                b.Close();
                b.Dispose();
            }

            // if texture size from .tga doesn't match the selected graffiti size warn user and return
            if (tga_size != texture_sizes[size])
            {
                MessageBox.Show("Texture resolution for this graffiti size should be " + texture_sizes[size].Replace(" ", " by ") + " pixels.", "Error: invalid texture resolution.");
                return;
            }

            #endregion


            // re-import graffiti picturebox item
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {

                Graffiti_PicBox item = (Graffiti_PicBox)flowLayoutPanel1.Controls[i];

                if (item.filepath == filepath)
                {
                    // convert to bmp so we can load it in the picturebox
                    img_convert(Path.GetFileNameWithoutExtension(filepath), tex_dir, "tga", "png", "");

                    // Graffiti_PicBox import = load_image_to_graffitiPicBox(filepath);

                    #region generate bitmap thumbnail

                    Bitmap bitmap = LoadBitmap(filepath.Replace(".tga", ".png"));
                    Bitmap bitmap_thumb = bitmap;

                    // scale picturebox depending on the graffiti size
                    switch (size)
                    {
                        case 0:
                        case 1:
                            bitmap_thumb = new Bitmap(bitmap);
                            break;
                        case 2:
                            bitmap_thumb = new Bitmap(bitmap);
                            break;
                        case 3:
                            // resize image to save memory space
                            bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 3, bitmap.Height / 3));
                            break;
                        case 4:
                            // resize image to save memory space
                            bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 4, bitmap.Height / 4));
                            break;
                    }
                    bitmap.Dispose();

                    #endregion

                    // set image
                    item.set_image(bitmap_thumb);
                    item.Update();
                    break;
                }
            }

            string filepath_noExt = filepath.Replace(".tga", "");

            IO.delete_safe(filepath_noExt + ".dds");

            // convert to DDS DXT3 (no mipmaps)
            img_convert(Path.GetFileNameWithoutExtension(filepath), tex_dir, "tga", "dds", "-format=DXT3");

            if (!File.Exists(filepath_noExt + ".dds"))
            {
                MessageBox.Show("Could not convert .tga to .dds", "Error");
                return;
            }

            IO.delete_safe(filepath_noExt + ".prs");
            // rename dds to prs
            File.Move(filepath_noExt + ".dds", filepath_noExt + ".prs");

            // save .tga as .grf
            IO.delete_safe(filepath_noExt + ".grf");
            // rename dds to prs
            File.Copy(filepath_noExt + ".tga", filepath_noExt + ".grf");

            // remove DDS header (128 bytes)
            try
            {

                byte[] bytes = System.IO.File.ReadAllBytes(filepath_noExt + ".prs");
                byte[] headless = new byte[bytes.Length - 128];

                Array.Copy(bytes, 128, headless, 0, bytes.Length - 128);

                System.IO.File.WriteAllBytes(filepath_noExt + ".prs", headless);

            }
            catch (System.Exception excep)
            {
                MessageBox.Show("Failed converting dds to prs: " + excep.Message);
                return;

            }


            System.Media.SystemSounds.Beep.Play();
        }

        // revert graffiti image to original
        private void btn_restore_Click(object sender, EventArgs e)
        {
            if (txtb_jsrf_original_dir.Text == "") { MessageBox.Show("JSRF TEX folder (original files) in Settings is not defined, please select the folder."); tabControl1.SelectedIndex = 1; return; }
            if (!Directory.Exists(txtb_jsrf_original_dir.Text)) { MessageBox.Show("Error: \"JSRF folder: original files\" in Settings does not exist."); return; }

            string subolfder = "";
            int split_dir_at = 0;

            string filepath = get_selected_graffiti_filepath();
            if (filepath == "") { return; }


            string[] folders = filepath.Split(Path.DirectorySeparatorChar);

            // find the "Media" folder in path and substract the parent folders from it
            for (int i = 0; i < folders.Length; i++) { if (folders[i] == "TEX") { split_dir_at = i; } }
            for (int i = split_dir_at + 1; i < folders.Length; i++) { subolfder = subolfder + "\\" + folders[i]; }


            string ori_filepath = txtb_jsrf_original_dir.Text.TrimEnd(Path.DirectorySeparatorChar) + subolfder;
            string ori_filepath_noExt = ori_filepath.Replace(".tga", "");

            if (!File.Exists(ori_filepath_noExt + ".grf")) { MessageBox.Show("Error: original file (" + ori_filepath_noExt + ".grf" + ") does not exist."); return; }
            if (!File.Exists(ori_filepath_noExt + ".prs")) { MessageBox.Show("Error: original file (" + ori_filepath_noExt + ".prs" + ") does not exist."); return; }


            // replace the modded file by a copy of the original
            File.Copy(ori_filepath_noExt + ".grf", filepath, true);
            File.Copy(ori_filepath_noExt + ".grf", filepath.Replace(".tga", ".grf"), true);
            File.Copy(ori_filepath_noExt + ".prs", filepath.Replace(".tga", ".prs"), true);

            int size = Convert.ToInt16(Path.GetFileNameWithoutExtension(filepath).Split('_')[1]);

            // re-import graffiti picturebox item
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {

                Graffiti_PicBox item = (Graffiti_PicBox)flowLayoutPanel1.Controls[i];

                if (item.filepath == filepath)
                {
                    // convert to bmp so we can load it in the picturebox
                    img_convert(Path.GetFileNameWithoutExtension(filepath), tex_dir, "tga", "png", "");

                    // Graffiti_PicBox import = load_image_to_graffitiPicBox(filepath);

                    #region generate bitmap thumbnail

                    Bitmap bitmap = LoadBitmap(filepath.Replace(".tga", ".png"));
                    Bitmap bitmap_thumb = bitmap;

                    // scale picturebox depending on the graffiti size
                    switch (size)
                    {
                        case 0:
                        case 1:
                            bitmap_thumb = new Bitmap(bitmap);
                            break;
                        case 2:
                            bitmap_thumb = new Bitmap(bitmap);
                            break;
                        case 3:
                            // resize image to save memory space
                            bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 3, bitmap.Height / 3));
                            break;
                        case 4:
                            // resize image to save memory space
                            bitmap_thumb = new Bitmap(bitmap, new Size(bitmap.Width / 4, bitmap.Height / 4));
                            break;
                    }
                    bitmap.Dispose();

                    #endregion

                    // set image
                    item.set_image(bitmap_thumb);
                    item.Update();
                    break;
                }
            }



            System.Media.SystemSounds.Beep.Play();
        }

        // send graffiti file to xbox
        private void btn_send_to_xbox_Click(object sender, EventArgs e)
        {
            // return if one or mutiple FTP settings are undefined
            if ((txtb_xbox_debug_ip.Text == "") || (txtb_xbox_login.Text == "") || (txtb_xbox_pass.Text == ""))
            {
                MessageBox.Show("Please make sure the Xbox FTP IP, login and password are defined in the settings tab.", "Error"); tabControl1.SelectedIndex = 1; return;
            }

            if (txtb_xbox_jsrf_dir.Text == "") { MessageBox.Show("Please set the xbox JSRF folder in the xbox FTP Settings.", "Error"); tabControl1.SelectedIndex = 1; return; }

            string filepath = get_selected_graffiti_filepath();
            string filepath_noExt = filepath.Replace(".tga", "");

            // check if graffiti file path is valid and if file exists
            if (filepath == "") { return; }
            if (!File.Exists(filepath_noExt + ".grf")) { MessageBox.Show("Could not find file: \n" + filepath_noExt + ".grf", "Error: missing file"); return; }
            if (!File.Exists(filepath_noExt + ".prs")) { MessageBox.Show("Could not find file: \n" + filepath_noExt + ".prs", "Error: missing file"); return; }

            // test ping xbox
            if (!PingHost(txtb_xbox_debug_ip.Text))
            {
                MessageBox.Show("Could not ping the Xbox, make sure the xbox is running on the dashboard \nwith FTP and that the FTP settings are correct.", "Error"); tabControl1.SelectedIndex = 1; return;
            }


            // check if ftp connects
            // create ftp client with xbox login/password defined in Settings tab
            ftp ftpClient = new ftp(@"ftp://" + txtb_xbox_debug_ip.Text + "/", txtb_xbox_login.Text, txtb_xbox_pass.Text);



            string subFolfder = "";
            int split_dir_at = 0;
            string[] folders = filepath.Split(Path.DirectorySeparatorChar);

            // find the "Media" folder in path and substract the parent folders from it
            for (int i = 0; i < folders.Length; i++) { if (folders[i] == "TEX") { split_dir_at = i; } }
            for (int i = split_dir_at + 1; i < folders.Length; i++) { subFolfder = subFolfder + "\\" + folders[i]; }



            ftpClient.upload((txtb_xbox_jsrf_dir.Text + "Mark/TEX/" + Path.GetFileNameWithoutExtension(filepath) + ".grf").Replace("\\", "/"), @filepath_noExt + ".grf");
            ftpClient.upload((txtb_xbox_jsrf_dir.Text + "Mark/TEX/" + Path.GetFileNameWithoutExtension(filepath) + ".prs").Replace("\\", "/"), @filepath_noExt + ".prs");


            // delete file from cache (so the game will reload the new modded file we just uploaded)
            ftpClient.delete("X:/Media/Mark/TEX/");
            ftpClient.delete("Y:/Media/Mark/TEX/");
            ftpClient.delete("Z:/Media/Mark/TEX/");

            System.Media.SystemSounds.Beep.Play();
        }

        #endregion

        #region cxbx

        private void btn_sel_cxbx_dir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                txtb_cxbx_dir.Text = path + "\\";
            }
        }

        private void clear_cxbx_cache()
        {
            // clear cache (for PC platform cxbx)
            if (Directory.Exists(txtb_cxbx_dir.Text))
            {
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition2\\");
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition3\\");
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition4\\");
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition5\\");
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition6\\");
                Libs.IO.delete_dir_contents(txtb_cxbx_dir.Text + "EmuDisk\\Partition7\\");

                string cxbx_roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cxbx-Reloaded\\";

                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition2\\");
                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition3\\");
                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition4\\");
                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition5\\");
                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition6\\");
                Libs.IO.delete_dir_contents(cxbx_roaming + "EmuDisk\\Partition7\\");
            }
        }

        #endregion

        #region network / FTP

        /// <summary>
        /// upload file to xbox by FTP
        /// </summary>
        /// <param name="filepath"></param>
        private void ftp_file_2_xbox(string filepath)
        {
            // return if no JSRF file is currently loaded in the JSRF tool
            if (filepath == "") { return; }
            // return if one or mutiple FTP settings are undefined
            if ((txtb_xbox_debug_ip.Text == "") || (txtb_xbox_login.Text == "") || (txtb_xbox_pass.Text == "")) { MessageBox.Show("Please make sure the Xbox FTP IP, login and password are defined in the settings tab."); return; }

            // create ftp client with xbox login/password defined in Settings tab
            ftp ftpClient = new ftp(@"ftp:// " + txtb_xbox_debug_ip.Text + "/", txtb_xbox_login.Text, txtb_xbox_pass.Text);

            string subFolfder = "";
            int split_dir_at = 0;
            string[] folders = filepath.Split(Path.DirectorySeparatorChar);

            // find the "Media" folder in path and substract the parent folders from it
            for (int i = 0; i < folders.Length; i++) { if (folders[i] == "Media") { split_dir_at = i; } }
            for (int i = split_dir_at + 1; i < folders.Length; i++) { subFolfder = subFolfder + "\\" + folders[i]; }

            ftpClient.upload((txtb_xbox_jsrf_dir.Text.TrimEnd(Path.DirectorySeparatorChar) + subFolfder).Replace("\\", "/"), filepath);

            // delete file from cache (so the game will reload the new modded file we just uploaded)
            ftpClient.delete("X:/Media/Mark/TEX/");
            ftpClient.delete("Y:/Media/Mark/TEX/");
            ftpClient.delete("Z:/Media/Mark/TEX/");
        }

        // Ping test
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
        #endregion


        #region misc functions

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);

        private static string GetShortPath(string longPath)
        {
            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(longPath, shortPath, 255);
            return shortPath.ToString();
        }

        public static void DeleteDirectoryContent(string target_dir)
        {
            if (Directory.Exists(target_dir))
            {

                System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(target_dir);

                foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        #endregion

        #region settings

        // yeah back when I started learning C# I had no idea VS had built-in Settings to store settings
        // so I made this, feel free to change it if you feel Properties>Settings works better for you
        // this automatically loads all settings by calling settings_load()  (dynamically loads setting values into form controls)

        private void settings_save(object sender, EventArgs e)
        {
            try
            {
                // Properties ob =  (Object)sender;
                string obj_name = "";
                string arg = "";


                if (sender.GetType() == typeof(CheckBox))
                {
                    CheckBox obj = (CheckBox)sender;
                    obj_name = obj.Name.ToString();
                    arg = obj.Checked.ToString();
                }

                if (sender.GetType() == typeof(TextBox))
                {
                    TextBox obj = (TextBox)sender;
                    obj_name = obj.Name.ToString();
                    arg = obj.Text.ToString();
                }

                if (sender.GetType() == typeof(ComboBox))
                {
                    ComboBox obj = (ComboBox)sender;
                    obj_name = obj.Name.ToString();
                    arg = obj.SelectedIndex.ToString();

                }


                if (sender.GetType() == typeof(Panel))
                {
                    Panel obj = (Panel)sender;
                    obj_name = obj.Name.ToString();
                    arg = obj.BackColor.R + ":" + obj.BackColor.G + ":" + obj.BackColor.B;
                }

                TextWriter tw = new StreamWriter(settings_dir + "settings.ini");

                Boolean set_found = false;
                for (int i = 0; i < settings.Count; i++)
                {
                    if (settings[i].Split('<')[1] == obj_name)
                    {
                        settings[i] = arg + "<" + obj_name;
                        set_found = true;
                    }
                    tw.WriteLine(settings[i]);
                }

                if ((settings.Count == 0) || (!set_found) && (arg != "") && (obj_name != ""))
                {
                    settings.Add(arg + "<" + obj_name);
                    tw.WriteLine(arg + "<" + obj_name);
                }


                tw.Close();

            }

            catch (System.Exception excep)
            {
                MessageBox.Show("Error saving settings " + excep.Message);
            }

        }

        private void settings_load()
        {

            settings.Clear();

            try
            {

                if (File.Exists(settings_dir + "settings.ini"))
                {

                    string f = settings_dir + "settings.ini";
                    List<string> lines = new List<string>();

                    using (StreamReader r = new StreamReader(f))
                    {

                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }


                    foreach (string s in lines)
                    {

                        string[] arg = s.Split('<');

                        Object prop = this.Controls.Find(arg[1], true)[0];

                        settings.Add(s);

                        if (prop != null)
                        {
                            if (prop.GetType() == typeof(CheckBox))
                            {
                                CheckBox obj = (CheckBox)prop;
                                if (arg[0].ToLower() == "true") { obj.Checked = true; }
                                if (arg[0].ToLower() == "false") { obj.Checked = false; }
                            }

                            if (prop.GetType() == typeof(TextBox))
                            {
                                TextBox obj = (TextBox)prop;
                                obj.Text = arg[0];
                            }

                            if (prop.GetType() == typeof(ComboBox))
                            {
                                ComboBox obj = (ComboBox)prop;
                                obj.SelectedIndex = Convert.ToInt32(arg[0]);
                            }

                        }
                    }
                }
            }

            catch (System.Exception excep)
            {
                MessageBox.Show("Error saving settings " + excep.Message);
            }
        }


        // select JSRF folder
        private void btn_favfolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                if (!path.Contains("TEX"))
                {
                    MessageBox.Show("Please select the \"TEX\"  from the JSRF files (Media\\Mark\\TEX\\).");
                    return;
                }

                
                txtb_jsrf_mod_dir.Text = path + "\\";
            }

            // clear temporary directory
            DeleteDirectoryContent(tmp_dir);

            if (!Directory.Exists(tmp_dir))
                Directory.CreateDirectory(tmp_dir);
        }

        // select original jsrf files directory
        private void btn_jsrf_original_dir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                if (!path.Contains("TEX"))
                {
                    MessageBox.Show("Please select the \"TEX\"  from the JSRF files (Media\\Mark\\TEX\\).");
                    return;
                }
                txtb_jsrf_original_dir.Text = path + "\\";
            }
        }

        // select image editor file path (i.e. photoshop.exe)
        private void btn_img_editor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "exe files (*.exe)|*.exe";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string path = openFileDialog1.FileName;
                txtb_img_editor_path.Text = path;

            }
        }

        #endregion

    }
}
