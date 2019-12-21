using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ErrorsProcessingLib;
using System.Drawing;
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
                FileStream fs = new FileStream(Path,FileMode.Create,FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs,Params);

                fs.Close();
            }
            catch(Exception e)
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
                FileStream fs = null;
                while (fs == null)
                {
                    try
                    {
                        fs = new FileStream(Path, FileMode.Open, FileAccess.Read);
                    }
                    catch (FileNotFoundException e)
                    {
                        ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", false);

                        Parametres prm = new Parametres(ParamsDefault);
                        
                        prm.Save();
                        
                    }
                }
                BinaryFormatter bf = new BinaryFormatter();

                ParamsStruct value = (ParamsStruct)bf.Deserialize(fs);

                fs.Close();

                return value;
            }
            catch (Exception)
            {
                //ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", _debug);
                return ParamsDefault;
            }
        }
    }
}
