using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;
namespace ShortcutLib
{
    public partial class ShortcutEx
    {
        public ShortcutEx(){
        }
        public static void CreateLink(string name, string path, string description, string baseFolder)
        {
            try
            {
                WshShellClass wsh = new WshShellClass();
                WshShortcut link = (WshShortcut)wsh.CreateShortcut(baseFolder + "\\" + name + ".lnk");
                link.TargetPath = path;
                link.Description = description;
                int pos = path.LastIndexOf('\\');
                link.WorkingDirectory = path.Substring(0, pos);
                link.Save();
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка создания ярлыка:\n" + _E.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CreateDesktopLink(string name, string path, string description)
        {
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            CreateLink(name, path, description, desktopFolder);
        }
        public static void CreateQuickLaunchLink(string name, string path, string description)
        {
            string QLFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            QLFolder += @"\Microsoft\Internet Explorer\Quick Launch";
            CreateLink(name, path, description, QLFolder);
        }
        /// <summary>
        /// Вернёт полный путь к группе
        /// </summary>
        public static string CreateStartMenuGroup(string name)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                path += @"\" + name;
                Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка создания группы в меню Пуск:\n" + _E.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        public static void DeleteStartMenuGroup(string name)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                path += @"\" + name;
                Directory.Delete(path, true);
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка удаления группы в меню Пуск:\n" + _E.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DeleteDesktopLink(string name)
        {
            try
            {
                string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = desktopFolder + @"\" + name + ".lnk";
                System.IO.File.Delete(path);
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка удаления ярлыка с рабочего стола:\n" + _E.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DeleteQuickLaunchLink(string name)
        {
            try
            {
                string QLFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                QLFolder += @"\Microsoft\Internet Explorer\Quick Launch";
                string path = QLFolder + @"\" + name + ".lnk";
                System.IO.File.Delete(path);
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка удаления ярлыка с панели быстрого запуска:\n" + _E.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}