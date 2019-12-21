using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SetupParamsLib
{
    public class SetupParams
    {
        [Serializable]
        public enum LinkLocation
        {
            Desktop,
            QuickLaunch
        }

        public static string logname = "install.log";
        public static string _path = "";

        public static bool Load(out Params param)
        {
            param = new Params();
            try
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(logname, FileMode.Open, FileAccess.Read);
                }
                catch (FileNotFoundException _E)
                {
                    MessageBox.Show(@"Не найдена необходимая для удаления информация",
                        @"",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                var bf = new BinaryFormatter();

                param = (Params) bf.Deserialize(fs);

                fs.Close();

                return true;
            }
            catch (Exception _E)
            {
                MessageBox.Show("Ошибка при получении информации для деинсталляции\n" +
                                _E.Message,
                    @"",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public static void Save(Params @params)
        {
            try
            {
                var fs = new FileStream(_path + "\\" + logname, FileMode.Create, FileAccess.Write);

                var bf = new BinaryFormatter();

                bf.Serialize(fs, @params);

                fs.Close();
            }
            catch
            {
            }
        }

        [Serializable]
        public struct Params
        {
            public ArrayList files;
            public ArrayList folders;
            public ArrayList links;
            public ArrayList startGroups;

            public string productName;
            public string productVertion;
            public string baseAppName;
            public string description;
        }
    }
}