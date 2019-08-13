using SmsFinalizer.Business;
using AppLib.Models;
using AppLib.Services;
using AppLib.Utils;
using ClibBase.DataBases.DbMySqlAbcs;
using ClibBase.Systems.Generics.Clonings;
using ClibBase.Systems.Generics.Comparers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;
using ClibBase.ExceptionWorks.Models;
using AppLib.Constants;
using WPFMessageBoxMulti.Business;
using AppLib.AppCoreConfigs;
using MySql.Data.MySqlClient;
using ClibBase.ExceptionWorks.Constants;
using SmsFinalizer.Services;


// MainWindowVm.Common

namespace SmsFinalizer.ViewModels
{
    public partial class MainWindowVm
    {


        public Storyboard storyboard1
        {
            get
            {
                return _Storyboard1;
            }
            set
            {
                _Storyboard1 = value;
                RaisePropertyChanged(() => this.storyboard1);
            }
        }
        private Storyboard _Storyboard1;


        public bool isMainInAsync
        {
            get
            {
                return _isMainInAsync;
            }
            set
            {
                if (ObjectComparer.objectEquals<bool>(_isMainInAsync, value)) { return; }
                _isMainInAsync = value;
                RaisePropertyChanged(() => this.isMainInAsync);
            }
        }
        private bool _isMainInAsync = false;



        public bool mainWindowLoaded
        {
            get { return _mainWindowLoaded; }
            set
            {
                _mainWindowLoaded = value;
                RaisePropertyChanged(() => this.mainWindowLoaded);
            }
        }
        private bool _mainWindowLoaded;


        /// <summary>
        /// steer of mainTimer stop start by change
        /// </summary>
        public string dbConnectionNamesComboValue
        {
            get { return _dbConnectionNamesComboValue; }
            set
            {
                if (!string.IsNullOrEmpty(_dbConnectionNamesComboValue))
                {
                    dbConnectionNamesComboValueCurrentSafe = _dbConnectionNamesComboValue;
                }
                _dbConnectionNamesComboValue = value;
                RaisePropertyChanged(() => this.dbConnectionNamesComboValue);
            }
        }
        private string _dbConnectionNamesComboValue = string.Empty;

        public string dbConnectionNamesComboValueCurrentSafe
        {
            get { return _dbConnectionNamesComboValueCurrentSafe; }
            set
            {
                _dbConnectionNamesComboValueCurrentSafe = value;
                RaisePropertyChanged(() => this.dbConnectionNamesComboValueCurrentSafe);
            }
        }
        private string _dbConnectionNamesComboValueCurrentSafe = string.Empty;


        public Dictionary<string, Abc> dbConnectionNamesDictionary
        {
            get { return _dbConnectionNamesDictionary; }
            set
            {
                _dbConnectionNamesDictionary = value;
                RaisePropertyChanged(() => this.dbConnectionNamesDictionary);
            }
        }
        private Dictionary<string, Abc> _dbConnectionNamesDictionary = new Dictionary<string, Abc>();

        public string dbCurrentSelectedConnectionName
        {
            get { return _dbCurrentSelectedConnectionName; }
            set
            {
                _dbCurrentSelectedConnectionName = value;
                RaisePropertyChanged(() => this.dbCurrentSelectedConnectionName);
            }
        }
        private string _dbCurrentSelectedConnectionName = string.Empty;



        public ObservableCollection<MyDataType> dbConnectionNamesCombo
        {
            get { return _dbConnectionNamesCombo; }
            set
            {
                _dbConnectionNamesCombo = value;
                RaisePropertyChanged(() => this.dbConnectionNamesCombo);
            }
        }
        private ObservableCollection<MyDataType> _dbConnectionNamesCombo = new ObservableCollection<MyDataType>();


        public bool iamInitialized
        {
            get { return _iamInitialized; }
            set
            {
                _iamInitialized = value;
                RaisePropertyChanged(() => this.iamInitialized);
            }
        }
        private bool _iamInitialized = false;


        public bool isActiveChangeConnection
        {
            get { return _isActiveChangeConnection; }
            set
            {
                _isActiveChangeConnection = value;
                RaisePropertyChanged(() => this.isActiveChangeConnection);
            }
        }
        private bool _isActiveChangeConnection = false;




        // ======================================================================================
        //async Task
       


           
        // ======================================================================================

        //private async Task<object> initializieMe()
        //{
        //    await Task.Delay(100);
        private object initializieMe()
        {
            //await Task.Delay(100);
            //Application.Current.Dispatcher.Invoke(new Action(() =>
            //{



                if (AppShared.dbConnectionNamesDictionary.Count > 0)
                {
                    dbConnectionNamesDictionary = Cloner.CloneTt<Dictionary<String, Abc>>(AppShared.dbConnectionNamesDictionary);
                    dbCurrentSelectedConnectionName = AppShared.dbCurrentSelectedConnectionName;
                }
                else
                {
                    dbConnectionNamesDictionary.Add("Ola", new Abc());
                    dbCurrentSelectedConnectionName = "Ola";
                }




                AppShared.dbCurrentSelectedConnectionName = null;
                AppShared.dbConnectionNamesDictionary = null;

                // ==========================================================

                foreach (var xx in dbConnectionNamesDictionary)
                {
                    dbConnectionNamesCombo.Add(new MyDataType()
                    {
                        name = xx.Key,
                        numericValue = Convert.ToString(dbConnectionNamesCombo.Count)

                    });

                }





            //}), DispatcherPriority.ContextIdle, null);
            iamInitialized = true;

            dbConnectionNamesComboValue = dbCurrentSelectedConnectionName;

            return 100;

        }


        // ======================================================================================

        private bool isFirstChange = true;





        //private object doDbConnectionChange()
        //{

        private async Task<object> doDbConnectionChange()
        {
            await Task.Delay(100);
          
           
            if (iamInitialized)
            {

                if (!isActiveChangeConnection)
                {

                    isActiveChangeConnection = true;
                    var result = await Task.Run(() => doDbConnectionChangeBegin());

                    isActiveChangeConnection = false;
                
                }

            }
            AppShared.innerWork = false;


            isMainInAsync = false;

            return new object();

        }


        /// <summary>
        /// 
        /// </summary>
        // private async Task<int> doDbConnectionChangeBegin()
        //{

        //private async Task<object> doDbConnectionChangeBegin()
        //{
        //    await Task.Delay(100);

        private int doDbConnectionChangeBegin()
        {
            AppShared.innerWork = true;
         


           
            mainDepart.removeAppInterval();
            mainDepart.mainTableObso.Clear();

            DbConnectionChangeHelp dbConnectionChangeHelp = new DbConnectionChangeHelp();
            dbConnectionChangeHelp.iamInitialized = iamInitialized;
            dbConnectionChangeHelp.isActiveChangeConnection = isActiveChangeConnection;
            //dbConnectionChangeHelp.dbConnectionNamesDictionary = Cloner.CloneTt<Dictionary<String, Abc>>(AppShared.dbConnectionNamesDictionary);
            dbConnectionChangeHelp.dbConnectionNamesDictionary = dbConnectionNamesDictionary;
            dbConnectionChangeHelp.isMainInAsync = isMainInAsync;
            dbConnectionChangeHelp.isFirstChange = isFirstChange;


            ConnectionAndStateChange connectionAndStateChange = new ConnectionAndStateChange();

            dbConnectionChangeHelp = connectionAndStateChange.connStateChangeStart(mainDepart, appManager,
                dbConnectionNamesComboValue, dbConnectionNamesComboValueCurrentSafe, dbConnectionChangeHelp);

            fakeBuClickOrgNotAsync();
             

            isMainInAsync = false;
            //////isFirstChange = dbConnectionChangeHelp.isFirstChange;
            //////iamInitialized = dbConnectionChangeHelp.iamInitialized;
            //////isActiveChangeConnection = dbConnectionChangeHelp.isActiveChangeConnection;
 

            return 100;

        }




        // ======================================================================================



        //private  async Task<ExcepDefaultResponse> startxxTemp()
        //{
        //    return await Task<ExcepDefaultResponse>.Factory.StartNew(() => startxx().Result);
        //}


        //private async Task<ExcepDefaultResponse> IntermediateMethod()
        //{
        //    return await startxx(); // MyMethodAsync also returns Task<string> in this example
        //}

        //private ExcepDefaultResponse startxxd()
        //{
        //    return   Task<ExcepDefaultResponse>.Factory.StartNew(() => startxx());
        //} 







    }
}
