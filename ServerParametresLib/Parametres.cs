using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using ErrorsProcessingLib;

namespace ServerParametresLib;

/// <summary>
/// Structure storing runtime server configuration values.
/// </summary>
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
    private static readonly ParamsStruct ParamsDefault;
    public static string _path = $"{Assembly.GetExecutingAssembly().Location}/config.bin";
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
            using var fs = new FileStream(_path, FileMode.Create, FileAccess.Write);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, Params);
        }
        catch (Exception e)
        {
            ErrorsProc.WriteErrorAndMessage(e, "Save in Parametres.cs", _debug);
        }
    }

    /// <summary>
    /// Loads the configuration. If the file is missing it will be created with default values.
    /// </summary>
    public static ParamsStruct Load()
    {
        try
        {
            FileStream? fs = null;
            while (fs == null)
            {
                try
                {
                    fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
                }
                catch (FileNotFoundException e)
                {
                    ErrorsProc.WriteErrorAndMessage(e, "Load in Parametres.cs", false);
                    var prm = new Parametres(ParamsDefault);
                    prm.Save();
                }
            }

            var bf = new BinaryFormatter();
            var result = (ParamsStruct)bf.Deserialize(fs);
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
