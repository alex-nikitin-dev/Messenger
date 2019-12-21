using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using ErrorsProcessingLib;

namespace MessengerServer
{
    [Serializable]
    public struct ParamsStruct
    {
        public int MessageDelay;
        public int BwDelay;
        public int BlackMulti;
        public int GeneralMulti;
        public bool AutoStart;
        public bool ForceDebug;
    }
    public class Parametres
    {
        public ParamsStruct Params;
        static readonly ParamsStruct ParamsDefault;
        public static string _path = Assembly.GetExecutingAssembly().Location + "\\config.bin";
        private static bool _debug;
        static Parametres()
        {
            ParamsDefault.MessageDelay = 10;
            ParamsDefault.BwDelay = 1000;
            ParamsDefault.BlackMulti = 2;
            ParamsDefault.GeneralMulti = 3;
            ParamsDefault.AutoStart = false;
            ParamsDefault.ForceDebug = false;
        }
        public Parametres()
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
        public void Save()
        {
            try
            {
                FileStream fs = new FileStream(_path, FileMode.Create, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, Params);

                fs.Close();
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
                FileStream fs = null;
                while (fs == null)
                {
                    try
                    {
                        fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
                    }
                    catch (FileNotFoundException e)
                    {
                        ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", false);

                        Parametres prm = new Parametres(ParamsDefault);

                        prm.Save();

                    }
                }
                BinaryFormatter bf = new BinaryFormatter();

                ParamsStruct result = (ParamsStruct)bf.Deserialize(fs);

                fs.Close();

                return result;
            }
            catch (Exception e)
            {
                ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", _debug);
                return ParamsDefault;
            }
        }
    }
}
