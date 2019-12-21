using System;
using System.Collections;
using DS =  MessengerServer.UserDataSet;
using MessengerServer.UserDataSetTableAdapters;
using ErrorsProcessingLib;
namespace MessengerServer
{
    class AlertSystem
    {
        #region свойства и конструкторы
        public bool Debug;
        readonly DS.AlertDataTable _alertTable   = new DS.AlertDataTable();
        readonly AlertTableAdapter _alertAdapter = new AlertTableAdapter();
        public UserDataSet.AlertDataTable Table => _alertTable;

        public AlertSystem()
        {
#if DEBUG 
            Debug = true;
#endif
            _alertAdapter.Fill(_alertTable);
        }
        #endregion

        /// <summary>
        /// поставить на учёт
        /// </summary>
        /// <param name="login"></param>
        /// <param name="guest"></param>
        public void Watch(int login, int guest)
        {
            try
            {
                int id = FindId(login, guest);
                if (id < 0)
                {
                    _alertTable.AddAlertRow(login, guest);
                    _alertAdapter.Update(_alertTable);
                }
                else if (id == -1)
                {
                    ErrorsProc.WriteErrorAndMessage("запись не найдена", "Watch(int login, int guest) in AlertSystem.cs", Debug);  
                }

            }
            catch (Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "Watch(int login, int guest) in AlertSystem.cs", Debug);
            }
        }
        /// <summary>
        /// снять с учёта
        /// </summary>
        /// <param name="login"></param>
        /// <param name="guest"></param>
        public void Release(int login, int guest)
        {
            try
            {
                int id = FindId(login, guest);
                if (id > -1)
                {
                    _alertTable.FindById(id).Delete();
                    _alertAdapter.Update(_alertTable);
                }
                else if (id == -1)
                {
                    ErrorsProc.WriteErrorAndMessage("запись не найдена", "Release(int login, int guest) in AlertSystem.cs", Debug);
                }
            }
            catch (Exception e){
                ErrorsProc.WriteErrorAndMessage(e, "Release(int login, int guest) in AlertSystem.cs", Debug);
            }
        }
        public int[] Guests(int login)
        {
            ArrayList gst = new ArrayList();
            foreach (DS.AlertRow row in _alertTable)
            {
                if (row.Login == login)
                {
                    gst.Add(row.Guest);
                }
            }
            return (int[])gst.ToArray(typeof(int));
        }
        private int FindId(int login, int guest)
        {
            try
            {
                foreach (DS.AlertRow row in _alertTable)
                {
                    if (login == row.Login && row.Guest == guest)
                    {
                        return row.Id;
                    }
                }
                return -1;
            }
            catch{
                return -2;
            }
        }
        public void Flush()
        {
            _alertAdapter.Update(_alertTable);
        }
    }
}
