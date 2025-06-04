using System;
using System.Data;
using System.Data.Odbc;

namespace MessengerServer;

public class UserDataSet : DataSet
{
    public AccountDataTable Account { get; } = new();
    public WhiteDataTable White { get; } = new();
    public BlackDataTable Black { get; } = new();
    public BanReasonsDataTable BanReasons { get; } = new();
    public BanRulesDataTable BanRules { get; } = new();
    public AlertDataTable Alert { get; } = new();

    public UserDataSet()
    {
        Tables.AddRange(new DataTable[] { Account, White, Black, BanReasons, BanRules, Alert });
    }

    public class AccountRow : DataRow
    {
        internal AccountRow(DataRowBuilder builder) : base(builder) { }
        public int Id { get => Field<int>("Id"); set => this["Id"] = value; }
        public string Login { get => Field<string>("Login"); set => this["Login"] = value; }
        public string Password { get => Field<string>("Password"); set => this["Password"] = value; }
        public string Firstname { get => Field<string>("Firstname"); set => this["Firstname"] = value; }
        public string Lastname { get => Field<string>("Lastname"); set => this["Lastname"] = value; }
        public string Email { get => Field<string>("Email"); set => this["Email"] = value; }
        public string Description { get => Field<string>("Description"); set => this["Description"] = value; }
        public bool Banned { get => Field<bool>("Banned"); set => this["Banned"] = value; }
        public DateTime BanTimespan { get => Field<DateTime>("BanTimespan"); set => this["BanTimespan"] = value; }
        public string IP { get => Field<string>("IP"); set => this["IP"] = value; }
        public bool BanByIp { get => Field<bool>("BanByIp"); set => this["BanByIp"] = value; }
        public int BanReason { get => Field<int>("BanReason"); set => this["BanReason"] = value; }
    }

    public class AccountDataTable : DataTable
    {
        public DataColumn IdColumn { get; }
        public DataColumn LoginColumn { get; }
        public DataColumn PasswordColumn { get; }
        public DataColumn FirstnameColumn { get; }
        public DataColumn LastnameColumn { get; }
        public DataColumn EmailColumn { get; }
        public DataColumn DescriptionColumn { get; }
        public DataColumn BannedColumn { get; }
        public DataColumn BanTimespanColumn { get; }
        public DataColumn IPColumn { get; }
        public DataColumn BanByIpColumn { get; }
        public DataColumn BanReasonColumn { get; }

        public AccountDataTable()
        {
            TableName = "Account";
            IdColumn = Columns.Add("Id", typeof(int));
            IdColumn.AutoIncrement = true;
            IdColumn.Unique = true;
            Columns.Add(LoginColumn = new DataColumn("Login", typeof(string)));
            Columns.Add(PasswordColumn = new DataColumn("Password", typeof(string)));
            Columns.Add(FirstnameColumn = new DataColumn("Firstname", typeof(string)));
            Columns.Add(LastnameColumn = new DataColumn("Lastname", typeof(string)));
            Columns.Add(EmailColumn = new DataColumn("Email", typeof(string)));
            Columns.Add(DescriptionColumn = new DataColumn("Description", typeof(string)));
            Columns.Add(BannedColumn = new DataColumn("Banned", typeof(bool)) { DefaultValue = false });
            Columns.Add(BanTimespanColumn = new DataColumn("BanTimespan", typeof(DateTime)) { DefaultValue = DateTime.Now });
            Columns.Add(IPColumn = new DataColumn("IP", typeof(string)));
            Columns.Add(BanByIpColumn = new DataColumn("BanByIp", typeof(bool)) { DefaultValue = false });
            Columns.Add(BanReasonColumn = new DataColumn("BanReason", typeof(int)) { DefaultValue = 0 });
            PrimaryKey = new[] { IdColumn };
        }

        protected override Type GetRowType() => typeof(AccountRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new AccountRow(builder);

        public AccountRow FindById(int id) => (AccountRow)Rows.Find(id);
        public AccountRow AddAccountRow(string login, string password, string firstname, string lastname, string email, string description, bool banned, DateTime banTimespan, string ip, bool banByIp, int banReason)
        {
            var row = (AccountRow)NewRow();
            row.Login = login;
            row.Password = password;
            row.Firstname = firstname;
            row.Lastname = lastname;
            row.Email = email;
            row.Description = description;
            row.Banned = banned;
            row.BanTimespan = banTimespan;
            row.IP = ip;
            row.BanByIp = banByIp;
            row.BanReason = banReason;
            Rows.Add(row);
            return row;
        }
    }

    public class BanReasonsRow : DataRow
    {
        internal BanReasonsRow(DataRowBuilder builder) : base(builder) { }
        public int id { get => Field<int>("id"); set => this["id"] = value; }
        public string Reason { get => Field<string>("Reason"); set => this["Reason"] = value; }
    }

    public class BanReasonsDataTable : DataTable
    {
        public DataColumn IdColumn { get; }
        public DataColumn ReasonColumn { get; }
        public BanReasonsDataTable()
        {
            TableName = "BanReasons";
            IdColumn = Columns.Add("id", typeof(int));
            IdColumn.AutoIncrement = true;
            IdColumn.Unique = true;
            Columns.Add(ReasonColumn = new DataColumn("Reason", typeof(string)));
            PrimaryKey = new[] { IdColumn };
        }
        protected override Type GetRowType() => typeof(BanReasonsRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new BanReasonsRow(builder);
        public BanReasonsRow FindByid(int id) => (BanReasonsRow)Rows.Find(id);
        public BanReasonsRow AddBanReasonsRow(string reason)
        {
            var row = (BanReasonsRow)NewRow();
            row.Reason = reason;
            Rows.Add(row);
            return row;
        }
    }

    public class BanRulesRow : DataRow
    {
        internal BanRulesRow(DataRowBuilder builder) : base(builder) { }
        public int id { get => Field<int>("id"); set => this["id"] = value; }
        public int Reason { get => Field<int>("Reason"); set => this["Reason"] = value; }
        public int GeneralTime { get => Field<int>("GeneralTime"); set => this["GeneralTime"] = value; }
        public string TimeView { get => Field<string>("TimeView"); set => this["TimeView"] = value; }
    }

    public class BanRulesDataTable : DataTable
    {
        public DataColumn IdColumn { get; }
        public DataColumn ReasonColumn { get; }
        public DataColumn GeneralTimeColumn { get; }
        public DataColumn TimeViewColumn { get; }
        public BanRulesDataTable()
        {
            TableName = "BanRules";
            IdColumn = Columns.Add("id", typeof(int));
            IdColumn.AutoIncrement = true;
            IdColumn.Unique = true;
            Columns.Add(ReasonColumn = new DataColumn("Reason", typeof(int)));
            Columns.Add(GeneralTimeColumn = new DataColumn("GeneralTime", typeof(int)));
            Columns.Add(TimeViewColumn = new DataColumn("TimeView", typeof(string)));
            PrimaryKey = new[] { IdColumn };
        }
        protected override Type GetRowType() => typeof(BanRulesRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new BanRulesRow(builder);
        public BanRulesRow FindByid(int id) => (BanRulesRow)Rows.Find(id);
        public BanRulesRow AddBanRulesRow(BanReasonsRow reasonRow, int generalTime, string timeView)
        {
            var row = (BanRulesRow)NewRow();
            row.Reason = reasonRow.id;
            row.GeneralTime = generalTime;
            row.TimeView = timeView;
            Rows.Add(row);
            return row;
        }
    }

    public class WhiteRow : DataRow
    {
        internal WhiteRow(DataRowBuilder builder) : base(builder) { }
        public int Id { get => Field<int>("Id"); set => this["Id"] = value; }
        public int Login { get => Field<int>("Login"); set => this["Login"] = value; }
        public int Friend { get => Field<int>("Friend"); set => this["Friend"] = value; }
    }

    public class WhiteDataTable : DataTable
    {
        public WhiteDataTable()
        {
            TableName = "White";
            var id = Columns.Add("Id", typeof(int));
            id.AutoIncrement = true;
            id.Unique = true;
            Columns.Add("Login", typeof(int));
            Columns.Add("Friend", typeof(int));
            PrimaryKey = new[] { id };
        }
        protected override Type GetRowType() => typeof(WhiteRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new WhiteRow(builder);
        public WhiteRow AddWhiteRow(int login, int friend)
        {
            var row = (WhiteRow)NewRow();
            row.Login = login;
            row.Friend = friend;
            Rows.Add(row);
            return row;
        }
    }

    public class BlackRow : DataRow
    {
        internal BlackRow(DataRowBuilder builder) : base(builder) { }
        public int Id { get => Field<int>("Id"); set => this["Id"] = value; }
        public int Login { get => Field<int>("Login"); set => this["Login"] = value; }
        public int Enemy { get => Field<int>("Enemy"); set => this["Enemy"] = value; }
    }

    public class BlackDataTable : DataTable
    {
        public BlackDataTable()
        {
            TableName = "Black";
            var id = Columns.Add("Id", typeof(int));
            id.AutoIncrement = true;
            id.Unique = true;
            Columns.Add("Login", typeof(int));
            Columns.Add("Enemy", typeof(int));
            PrimaryKey = new[] { id };
        }
        protected override Type GetRowType() => typeof(BlackRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new BlackRow(builder);
        public BlackRow AddBlackRow(int login, int enemy)
        {
            var row = (BlackRow)NewRow();
            row.Login = login;
            row.Enemy = enemy;
            Rows.Add(row);
            return row;
        }
    }

    public class AlertRow : DataRow
    {
        internal AlertRow(DataRowBuilder builder) : base(builder) { }
        public int Id { get => Field<int>("Id"); set => this["Id"] = value; }
        public int Login { get => Field<int>("Login"); set => this["Login"] = value; }
        public int Guest { get => Field<int>("Guest"); set => this["Guest"] = value; }
    }

    public class AlertDataTable : DataTable
    {
        public AlertDataTable()
        {
            TableName = "Alert";
            var id = Columns.Add("Id", typeof(int));
            id.AutoIncrement = true;
            id.Unique = true;
            Columns.Add("Login", typeof(int));
            Columns.Add("Guest", typeof(int));
            PrimaryKey = new[] { id };
        }
        protected override Type GetRowType() => typeof(AlertRow);
        protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => new AlertRow(builder);
        public AlertRow AddAlertRow(int login, int guest)
        {
            var row = (AlertRow)NewRow();
            row.Login = login;
            row.Guest = guest;
            Rows.Add(row);
            return row;
        }
    }
}

namespace MessengerServer.UserDataSetTableAdapters;

public abstract class TableAdapterBase<T> where T : DataTable, new()
{
    protected readonly string ConnectionString;
    private readonly string _tableName;

    protected TableAdapterBase(string cs, string table)
    {
        ConnectionString = cs;
        _tableName = table;
    }

    public bool ClearBeforeFill { get; set; } = true;

    protected OdbcDataAdapter CreateAdapter()
    {
        var adapter = new OdbcDataAdapter($"SELECT * FROM {_tableName}", ConnectionString);
        var builder = new OdbcCommandBuilder(adapter);
        return adapter;
    }

    public virtual int Fill(T table)
    {
        using var adapter = CreateAdapter();
        if (ClearBeforeFill) table.Clear();
        return adapter.Fill(table);
    }

    public virtual int Update(T table)
    {
        using var adapter = CreateAdapter();
        return adapter.Update(table);
    }

    public T GetData()
    {
        var t = new T();
        Fill(t);
        return t;
    }
}

public class AccountTableAdapter : TableAdapterBase<UserDataSet.AccountDataTable>
{
    public AccountTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "Account") { }
}

public class BanReasonsTableAdapter : TableAdapterBase<UserDataSet.BanReasonsDataTable>
{
    public BanReasonsTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "BanReasons") { }
}

public class BanRulesTableAdapter : TableAdapterBase<UserDataSet.BanRulesDataTable>
{
    public BanRulesTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "BanRules") { }
}

public class WhiteTableAdapter : TableAdapterBase<UserDataSet.WhiteDataTable>
{
    public WhiteTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "White") { }
}

public class BlackTableAdapter : TableAdapterBase<UserDataSet.BlackDataTable>
{
    public BlackTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "Black") { }
}

public class AlertTableAdapter : TableAdapterBase<UserDataSet.AlertDataTable>
{
    public AlertTableAdapter() : base(Properties.Settings.Default.UserConnectionString, "Alert") { }
}
