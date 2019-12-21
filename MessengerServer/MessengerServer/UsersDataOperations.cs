using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerServer.UsersDataSetTableAdapters;

namespace MessengerServer
{
    class UsersDataOperations
    {
        private readonly UsersDataSet.AccountDataTable _accountTable = new UsersDataSet.AccountDataTable();
        private readonly AccountTableAdapter _accountAdapter = new AccountTableAdapter();

        private readonly WhiteListTableAdapter _whiteListAdapter = new WhiteListTableAdapter();
        private readonly UsersDataSet.WhiteListDataTable _whiteListTable = new UsersDataSet.WhiteListDataTable();

        private readonly BlackListTableAdapter _blackListAdapter = new BlackListTableAdapter();
        private readonly UsersDataSet.BlackListDataTable _blackListTable = new UsersDataSet.BlackListDataTable();

        private readonly RoomTableAdapter _roomTableAdapter = new RoomTableAdapter();
        private readonly UsersDataSet.RoomDataTable _roomDataTable = new UsersDataSet.RoomDataTable();

        Dictionary<string,(string reason,DateTime banTimeSpan, int id)> _bannedByIP = new Dictionary<string, (string reason, DateTime banTimeSpan, int id)>();

        private void GetBannedByIP()
        {
            var br = new UsersDataSet.BanReasonsDataTable();
            var ba = new BanReasonsTableAdapter();
            ba.Fill(br);
            foreach (var row in _accountTable)
                if (row.BanByIP && row.Banned)
                {
                    var reason = br.FindByID(row.BanReasonID).Reason;
                    var data = (reason, row.BanTimeSpan, row.ID);
                    _bannedByIP.Add(row.IP, data);
                }
        }

        private void FillUserDataSet()
        {
            _accountAdapter.Fill(_accountTable);
            _whiteListAdapter.Fill(_whiteListTable);
            _blackListAdapter.Fill(_blackListTable);
            _roomTableAdapter.Fill(_roomDataTable);
        }
    }
}
