using System;
using System.Windows.Forms;

namespace MessengerServer;

internal static class ServerProgram
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
