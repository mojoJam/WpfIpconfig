using AppLib.AppCoreConfigs;
using AppLib.AppDbOrgs;
using AppLib.Business.AppEnvironments.Models;
using AppLib.Commands;
using AppLib.Constants;
using AppLib.Models;
using AppLib.Services;
using ClibBase.Constants;
using ClibBase.DataBases.DbMySqlAbcs;
using ClibBase.ExceptionWorks;
using ClibBase.ExceptionWorks.Constants;
using ClibBase.ExceptionWorks.Models;
using ClibBase.Ios.IoFileExaminers;
using ClibBase.Services;
using SmsProjectBasic.Constants;
using SmsProjectBasic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;


// MainWindowVm

namespace SmsFinalizer.ViewModels
{
    public partial class MainWindowVm
    {

        public MainWindowVm()
        {




            LogProUcInitial();



            initializeCommands();


        }


        private object _collectionOfMainTableSync = new object();
        private object _dbConnectionNamesComboSync = new object();


        public void initializeCommands()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(mainViewModel_PropertyChanged);
            //mainDepart.mainTableObso.Clear();
            if (AppShared.inDesignMode)
            {
                for (int hCnt = 0; hCnt < 200; hCnt++)
                {
                    //mainDepart.logEntries.addEntry("Command startCommand startCommand startCommand startCommand startCommand start:");
                    mainDepart.mainTableObso.Add(new SmsFinalizerSession()
                    {
                        project_name = "Test" + Convert.ToString(hCnt),
                        sms_process_step = eSmsProcessSteps.none,
                        description = "OlaOla"

                    });

                }
            }








            mainTableObsoView = CollectionViewSource.GetDefaultView(mainDepart.mainTableObso);
            BindingOperations.EnableCollectionSynchronization(mainDepart.mainTableObso, _collectionOfMainTableSync);

            BindingOperations.EnableCollectionSynchronization(dbConnectionNamesCombo, _dbConnectionNamesComboSync);


            //smsFinalizerSessionView = CollectionViewSource.GetDefaultView(mainDepart.smsFinalizerSession);
            //BindingOperations.EnableCollectionSynchronization(mainDepart.smsFinalizerSession, _collectionOfSmsFinalizerSessionSync);

            mainDepart.g000XMoooodInfo.GroupsforAlienList.Add(eContentIdentGroupNamesDb.adabas);
            mainDepart.g000XMoooodInfo.GroupsforAlienList.Add(eContentIdentGroupNamesDb.kultus);
            mainDepart.g000XMoooodInfo.GroupsforAlienList.Add(eContentIdentGroupNamesDb.sysgr);
            mainDepart.g000XMoooodInfo.GroupsforAlienList.Add(eContentIdentGroupNamesDb.nouse);


            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("F");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("FB");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("V");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("VB");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("FBA");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("VBA");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("FBM");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("VBM");
            mainDepart.g000XMoooodInfo.MY_recfm_OK_List.Add("U");


            mainDepart.g000XMoooodInfo.MY_DSORG_OK_List.Add("");
            mainDepart.g000XMoooodInfo.MY_DSORG_OK_List.Add("DATA");

            initializeSpecialText();



            //var now = DateTimeOffset.Now;
            mainDepart.myCancellationTokenSource = new MyCancellationTokenSource();

            mainCancelCommand_BuCmd = new RelayCommand((param) =>
            { var xx = meth_mainCancelCommand_BuCmd(param); });

            openExplorerDirectorySmsListFolder_BuCmd = new RelayCommand((param) =>
            { var xx = meth_openExplorerDirectorySmsListFolder_BuCmd(param); });



            mainProcessCommand_BuCmd = new RelayCommand((param) =>
            { var xx = meth_mainProcessCommand_BuCmd(param); });

            projectTableRefreshCommand_BuCmd = new RelayCommand((param) =>
            { var xx = meth_projectTableRefreshCommand_BuCmd(param); });




        }

        private void mainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {



            if (e.PropertyName == this.GetPropertyName(() => isMainInAsync))
            {
                if (storyboard1 == null)
                {
                    return;
                }

                if (isMainInAsync)
                {
                    baseWindowGridDisEnabled = false;
                    storyboard1.Begin();

                }
                else
                {
                    storyboard1.Stop();
                    baseWindowGridDisEnabled = true;
                }

            }
            else if (e.PropertyName == this.GetPropertyName(() => isActiveChangeConnection))
            {

                if (isActiveChangeConnection)
                {
                    mainDepart.isEnabled_dbConnectionNamesCombo = false;

                }
                else
                {
                    mainDepart.isEnabled_dbConnectionNamesCombo = true;

                }

            }
            else if (e.PropertyName == GetPropertyName(() => this.mainWindowLoaded))
            {

                if (mainWindowLoaded)
                {
                    var jj = initializieMe();
                }

            }
            else if (e.PropertyName == GetPropertyName(() => this.dbConnectionNamesComboValue))
            {
                isMainInAsync = true;
                var t = Task.Factory.StartNew(async () =>
                {
                    await doDbConnectionChange().ConfigureAwait(true);
                });

                t.Wait();



            }
            else if (e.PropertyName == this.GetPropertyName(() => onClosedMainWindow))
            {

                if (onClosedMainWindow)
                {
                    Abc abcFake = new Abc();
                    DbConnectionChangeHelp dbConnectionChangeHelp = new DbConnectionChangeHelp();
                    appManager.dbConnectionChange(mainDepart, abcFake, dbConnectionChangeHelp, false, false, false);


                    if (mainDepart.myCancellationTokenSource == null)
                    {
                        return;
                    }
                    else if (mainDepart.myCancellationTokenSource.MyIsDisposed)
                    {
                        return;
                    }
                    mainDepart.myCancellationTokenSource.Cancel(false);

                }
               



            }
            else if (e.PropertyName == this.GetPropertyName(() => createNewDropFilePath))
            {
                filePath_sms_source = new IoFileExamine(createNewDropFilePath);
            }
            else if (e.PropertyName == this.GetPropertyName(() => doClose))
            {
                if (doClose)
                {
                    if (mainDepart.myCancellationTokenSource != null)
                    {
                        if (!mainDepart.myCancellationTokenSource.MyIsDisposed)
                        {
                            mainDepart.myCancellationTokenSource.Cancel(false);
                        }
                    }
                    onClosedMainWindow = true;
                }

            }



        }

        private void initializeSpecialText()
        {

            mainDepart.specialTextUserOnly_Bu_DisEnabled = false;
            mainDepart.specialTextUserOnlyTest_Bu_DisEnabled = true;

        }




    }
}
