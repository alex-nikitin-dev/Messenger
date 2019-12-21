using System.ComponentModel;
namespace ClientConnectionLib
{
    public class MessageHelper
    {
        public enum State
        {
            [Description("В сети")]
            OnLine,
            [Description("Занят")]
            Busy,
            [Description("Нет на месте")]
            Away,
            [Description("Скоро вернусь")]
            ComeBackSoon,
            [Description("Обед")]
            Lunch,
            [Description("Обращаться в крайнем случае")]
            BadMood,
            [Description("la'ac")]
            Lahac,
            [Description("Невидимый")]
            Invisible,
            [Description("Не в сети")]
            Off
        }
    }
}
