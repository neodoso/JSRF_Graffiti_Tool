using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace JSRF_Graffiti_Tool.Libs
{
    class IO
    {
        // TODO this doesn't seem to work, says file is locked, when in fact, it's not
        public static bool IsFileLocked(string filepath)
        {
            try
            {
                FileInfo file = new FileInfo(filepath);
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                // ex because file might be: still being written, used by another process, or doesn't exist
                return true;
            }

            // file is not locked
            return false;
        }


        /// <summary>
        /// create directory if it doesn't exist
        /// </summary>
        /// <param name="_dir"></param>
        public static void create_dir(string _dir)
        {
            try
            {
                if (!Directory.Exists(_dir))
                {
                    Directory.CreateDirectory(_dir);
                }
            }
            catch { }
        }

        /// <summary>
        /// deletes directory's content (files and folders recursively)
        /// </summary>
        /// <param name="_dir"></param>
        public static void delete_dir_contents(string _dir)
        {
            if (!Directory.Exists(_dir)) { return; }
            System.IO.DirectoryInfo di = new DirectoryInfo(_dir);

            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch { }

            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch { }

            }
        }

        //converts long paths to short paths, for "dos" console commands
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
        [MarshalAs(UnmanagedType.LPTStr)] string path,
        [MarshalAs(UnmanagedType.LPTStr)]  StringBuilder shortPath, int shortPathLength);

        // copies file from one source to a destinaiton, checks if file exists etc
        public static void copy_safe(string source, string destination)
        {
            if (File.Exists(source))
            {
                if (!Directory.Exists(Path.GetDirectoryName(destination)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destination));
                }
                File.Copy(source, destination, true);
            }
        }

        public static void delete_safe(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Unable to delete file: " + file + "\nFile might be locked by another process.");
                }
            }
        }

        public static void move_dir_safe(string source, string target)
        {
            if (!Directory.Exists(source))
            {
                return;
            }

            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    string targetFile = Path.Combine(folders.Target, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
            Directory.Delete(source, true);
        }

        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
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

        public static Boolean IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists)
                dir.Create();
            return true;
        }


    }
}
