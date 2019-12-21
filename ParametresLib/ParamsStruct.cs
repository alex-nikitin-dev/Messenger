using System;
using System.Drawing;

namespace ParametresLib
{
    [Serializable]
    public struct ParamsStruct
    {
        public string ServerIp;
        public int    Port;
        public string Login;
        public string Password;
        public bool   Bayda;
        public bool   SavePassword;
        public int    SendDelay;
        public bool   WatchForce;
        public bool   AutoStart;

        /************************/
        /*  цвета главного чата */
        public Color MChatOwnForeColor;
        public Color MChatOwnBackColor;

        public Color MChatUserForeColor;
        public Color MChatUserBackColor;

        public Color MChatUListForeColor;
        public Color MChatUListBackColor;

        public Color MessageTextForeColor;
        public Color MessageTextBackColor;

        public Color TimeForeColor;
        public Color TimeBackColor;

        public Color MChatBackColor;
        /************************/

        /************************/
        /*  цвета привата       */
        public Color PChatViewForeColor;
        public Color PChatViewBackColor;

        public Color PChatMTextForeColor;
        public Color PChatMTextBackColor;

        public Color PChatTimeForeColor;
        public Color PChatTimeBackColor;

        public Color PChatBtnSendForeColor;
        public Color PChatBtnSendBackColor;

        public Color PChatOwnForeColor;
        public Color PChatOwnBackColor;

        public Font  PChatOwnerFont;

        /************************/

    }
}