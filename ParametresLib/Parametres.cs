using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ErrorsProcessingLib;
using System.Drawing;
using System.Text.Json;
namespace ParametresLib
{
    public class Parametres
    {
        public ParamsStruct  Params;
        static readonly ParamsStruct  ParamsDefault;
        public static string Path  = Application.StartupPath + "\\config.bin";
        private static bool  _debug;
        static Parametres()
        {
            ParamsDefault = GetDefault();
        }
        public static ParamsStruct GetDefault()
        {
            ParamsStruct ps = new ParamsStruct();

            ps.Port                     = 1100;
            ps.Login                    = "";
            ps.Password                 = "";
            ps.ServerIp                 = "127.0.0.1";
            ps.Bayda                    = false;
            ps.SavePassword             = false;
            ps.SendDelay                = 10;
            ps.WatchForce               = false;
            ps.AutoStart                = true;

            ps.MChatOwnForeColor        = Color.White;
            ps.MChatOwnBackColor        = Color.Blue;

            ps.MChatUserForeColor       = Color.White;
            ps.MChatUserBackColor       = Color.FromArgb(0, 0, 64);

            ps.MChatUListForeColor      = Color.White;
            ps.MChatUListBackColor      = Color.FromArgb(0, 0, 64);

            ps.MessageTextForeColor     = Color.White;
            ps.MessageTextBackColor     = Color.FromArgb(0, 0, 64);

            ps.TimeForeColor            = Color.Yellow;
            ps.TimeBackColor            = Color.FromArgb(0, 0, 64);


            ps.MChatBackColor           = Color.FromArgb(0, 0, 64);

            ps.PChatViewForeColor       = Color.White;
            ps.PChatViewBackColor       = Color.FromArgb(0, 0, 64);

            ps.PChatMTextForeColor      = Color.Red;
            ps.PChatMTextBackColor      = Color.FromArgb(0, 0, 64);

            ps.PChatTimeForeColor       = Color.Yellow;
            ps.PChatTimeBackColor       = Color.FromArgb(0, 0, 64);

            ps.PChatBtnSendForeColor    = Color.Cornsilk;
            ps.PChatBtnSendBackColor    = Color.MidnightBlue;

            ps.PChatOwnForeColor        = Color.Red;
            ps.PChatOwnBackColor        = Color.FromArgb(0, 0, 64);

            ps.PChatOwnerFont           = new Font("Lucida Console",8);

            return ps;
        }
        public  Parametres()
        {
#if DEBUG 
            _debug = true;
#endif
        }
        public Parametres(ParamsStruct ps)
        {
            Params = ps;
#if DEBUG
            _debug = true;
#endif
        }
        public  void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(Params); // Serialize Params to JSON
                File.WriteAllText(Path, json); // Save JSON to file
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "Save in Parametres.cs", _debug);
            }
        }
        /// <summary>
        /// Если файла настроек нет, то будет создан по умолчанию
        /// </summary>
        /// <returns></returns>
        public static ParamsStruct Load()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    ErrorsProc.WriteErrorAndMessage(new FileNotFoundException(), "Load in Parametres.cs", false);

                    Parametres prm = new Parametres(ParamsDefault);
                    prm.Save();
                }

                string json = File.ReadAllText(Path);
                ParamsStruct value = JsonSerializer.Deserialize<ParamsStruct>(json);

                return value;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", _debug);
                return ParamsDefault;
            }
        }
    }
}
