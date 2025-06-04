using System;
using System.Net;
using System.Text.RegularExpressions;
using MessengerServer.UserDataSetTableAdapters;
using TextOperations;

namespace MessengerServer;

internal sealed class RegistrationService
{
    private readonly UserDataSet.AccountDataTable _accountTable;
    private readonly AccountTableAdapter _accountAdapter;
    private readonly UserDataSet.BlackDataTable _blackTable;
    private readonly BlackTableAdapter _blackAdapter;

    public RegistrationService(
        UserDataSet.AccountDataTable accountTable,
        AccountTableAdapter accountAdapter,
        UserDataSet.BlackDataTable blackTable,
        BlackTableAdapter blackAdapter)
    {
        _accountTable = accountTable;
        _accountAdapter = accountAdapter;
        _blackTable = blackTable;
        _blackAdapter = blackAdapter;
    }

    public enum AddAccountError
    {
        NoProblem,
        LoginAlreadyExist,
        DatabaseException
    }

    public bool VerifyData(string[] data)
    {
        try
        {
            var rName = new Regex(@"^[A-Za-zА-Яа-я-]+$");
            var rMail = new Regex(@"^[^ @]+@[^ @]+\\.[^ \\.@]+$");

            for (var i = 0; i < data.Length && i < 6; i++)
            {
                switch ((MainForm.UserData)i)
                {
                    case MainForm.UserData.Login:
                        if (_Text.IsEmpty(data[i])) return false;
                        data[i] = _Text.Normalize(data[i]);
                        break;
                    case MainForm.UserData.Password:
                        if (data[i].Length < 6) return false;
                        break;
                    case MainForm.UserData.Firstname:
                        if (rName.Matches(data[i]).Count == 0) return false;
                        break;
                    case MainForm.UserData.Lastname:
                        if (rName.Matches(data[i]).Count == 0) return false;
                        break;
                    case MainForm.UserData.Email:
                        if (rMail.Matches(data[i]).Count == 0) return false;
                        break;
                    case MainForm.UserData.Description:
                        if (data[i] == null) return false;
                        break;
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public AddAccountError AddNewAccount(string[] data, IPAddress ip)
    {
        var findRes = FindUserId(data[0]);
        if (findRes > -1) return AddAccountError.LoginAlreadyExist;
        if (findRes == -2) return AddAccountError.DatabaseException;

        try
        {
            var bt = new UserDataSet.BanReasonsDataTable();
            var br = bt.NewBanReasonsRow();
            br.Reason = string.Empty;

            var hashed = PasswordHelper.HashPassword(data[1]);
            var row = _accountTable.AddAccountRow(
                data[0],
                hashed,
                data[2],
                data[3],
                data[4],
                data[5],
                false,
                DateTime.Now,
                ip.ToString(),
                false,
                br);

            _accountAdapter.Update(_accountTable);
            _blackTable.AddBlackRow(row.Id, 1);
            _blackAdapter.Update(_blackTable);

            return AddAccountError.NoProblem;
        }
        catch
        {
            return AddAccountError.DatabaseException;
        }
    }

    public AddAccountError EditAccount(int userId, string[] data)
    {
        try
        {
            var row = _accountTable.FindById(userId);
            row.Login = data[0];
            row.Password = PasswordHelper.HashPassword(data[1]);
            row.Firstname = data[2];
            row.Lastname = data[3];
            row.Email = data[4];
            row.Description = data[5];

            _accountAdapter.Update(_accountTable);
            return AddAccountError.NoProblem;
        }
        catch
        {
            return AddAccountError.DatabaseException;
        }
    }

    public int FindUserId(string login)
    {
        try
        {
            foreach (UserDataSet.AccountRow row in _accountTable.Rows)
            {
                if (string.Compare(row.Login, login, StringComparison.OrdinalIgnoreCase) == 0)
                    return row.Id;
            }

            return -1;
        }
        catch
        {
            return -2;
        }
    }
}
