using AppLib.AppDbOrgs;
using AppLib.Business.AppEnvironments.Models;
using AppLib.Constants;
using AppLib.Models;
using AppLib.Services;
using ClibBase.Constants;
using ClibBase.ExceptionWorks;
using ClibBase.ExceptionWorks.Constants;
using ClibBase.Ios.FileHandle;
using ClibBase.Ios.IoFileExaminers;
using ClibBase.Services;
using ClibBase.Utils.Reflections;
using SmsFinalizer.Business;
using SmsFinalizer.Business.ContactChecks;
using SmsFinalizer.Services;
using SmsProjectBasic.AppDbOrgs;
using SmsProjectBasic.Constants;
using SmsProjectBasic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;


// MainWindowVm.Commands


namespace SmsFinalizer.ViewModels
{
    public partial class MainWindowVm
    {



        public ICommand mainProcessCommand_BuCmd { get; set; }

        public ICommand projectTableRefreshCommand_BuCmd { get; set; }

        public ICommand openExplorerDirectorySmsListFolder_BuCmd { get; set; }

        public ICommand mainCancelCommand_BuCmd { get; set; }

        public async Task fakeBuClick(int exLibId, eAppCommandControls appCommandControls, bool canChangeDisEnable)
        {



            //List<Task> tList = new List<Task>();

            //Task.Run(() => ExecuteAsync
            ////var tokenSource = new CancellationTokenSource();
            ////var token = tokenSource.Token;


            var gg = await Task.Run(() => actionOfX(exLibId, appCommandControls, canChangeDisEnable));





            //////var t = Task.Run(() =>
            //////{

            //////    var x = actionOfX(exLibId, appCommandControls, canChangeDisEnable);
            //////    //Parallel.ForEach(Directory.GetFiles(dir),
            //////    //f =>
            //////    //{
            //////    //    if (token.IsCancellationRequested)
            //////    //        token.ThrowIfCancellationRequested();
            //////    //    var fi = new FileInfo(f);
            //////    //    lock (obj)
            //////    //    {
            //////    //        files.Add(Tuple.Create(fi.Name, fi.DirectoryName, fi.Length, fi.LastWriteTimeUtc));
            //////    //    }
            //////    //});

            //////}
            //////            , token);
            //////await Task.Yield();
            //////try
            //////{
            //////    await t;

            //////}
            //////catch (AggregateException e)
            //////{
            //////    Console.WriteLine("Exception messages:");
            //////    foreach (var ie in e.InnerExceptions)
            //////        Console.WriteLine("   {0}: {1}", ie.GetType().Name, ie.Message);

            //////    Console.WriteLine("\nTask status: {0}", t.Status);
            //////}
            //////finally
            //////{
            //////    tokenSource.Dispose();
            //////}
        }


        public bool isMasterInAsync { get; set; }



        public void fakeBuClickOrg()
        {
            int exLibId = ExLibOrg.exLibOrgInst.createOrGiveIndextoUse();
            bool canChangeDisEnable = true;


            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailBetreffReset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailHinweis3Reset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailTextReset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailTextEndeReset_Bu, canChangeDisEnable);

            var task = Task.Factory.StartNew(async () =>
            {
                await actionOfX2(exLibId, eAppCommandControls.selection_projectTableRefresh_Bu, canChangeDisEnable);
                await Task.Factory.StartNew(() => { });
            });

            task.Wait();

            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfInformation) > 0)
            {
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.InformationMessageFull);

            }
            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfError | eUseObj.ObjOfException) > 0)
            {
                //mainDepart.logEntries.addEntry(string.Format("Not success {0}", buttonContent));
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.ErrorEx);

            }
            ExLibOrg.exLibOrgInst.resetByIndex(exLibId);



        }




        public void fakeBuClickOrgNotAsync()
        {
            int exLibId = ExLibOrg.exLibOrgInst.createOrGiveIndextoUse();
            bool canChangeDisEnable = true;


            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailBetreffReset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailHinweis3Reset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailTextReset_Bu, canChangeDisEnable);
            startStep_fakeBuClick(exLibId, eAppCommandControls.specialTextForEMailTextEndeReset_Bu, canChangeDisEnable);

            List<eAppCommandControls> routedList = new List<eAppCommandControls>();
            Lev01StepsOfMainBase lev01StepsOfMainBase = new Lev01StepsOfMainBase();

            //eAppServiceStates success = eAppServiceStates.none;
            ////////////////CancellationTokenSource tokenSource = new CancellationTokenSource();

            if (mainDepart.myCancellationTokenSource == null || mainDepart.myCancellationTokenSource.MyIsDisposed)
            {
                mainDepart.myCancellationTokenSource = new MyCancellationTokenSource();

            }





            ServiceProcess serviceProcess = new ServiceProcess();
            object transObj = null;

            lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
            routedList.Add(eAppCommandControls.selection_projectTableRefresh_Bu);

            serviceProcess = sessionBegin2(exLibId, lev01StepsOfMainBase, serviceProcess,
                                          AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode,
                                          mainDepart.myCancellationTokenSource.Token,
                                          mainDepart, routedList, transObj);





            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfInformation) > 0)
            {
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.InformationMessageFull);

            }
            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfError | eUseObj.ObjOfException) > 0)
            {
                //mainDepart.logEntries.addEntry(string.Format("Not success {0}", buttonContent));
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.ErrorEx);

            }
            ExLibOrg.exLibOrgInst.resetByIndex(exLibId);




        }


        // https://msdn.microsoft.com/en-us/magazine/dn605875.aspx


        private void startStep_fakeBuClick(int exLibId, eAppCommandControls appCommandControls, bool canChangeDisEnable)
        {

            Lev01StepsOfMainBase lev01StepsOfMainBase = new Lev01StepsOfMainBase();
            lev01StepsOfMainBase.Add(new SmsSpecialText());

            //, finalizeChooseMailSendCode  wird hier nicht benötigt
            var transObj = new object[] { string.Empty, appCommandControls };
            if (mainDepart.myCancellationTokenSource == null || mainDepart.myCancellationTokenSource.MyIsDisposed)
            {
                mainDepart.myCancellationTokenSource = new MyCancellationTokenSource();

            }

            ServiceProcess serviceProcess = new ServiceProcess();
            foreach (var xx in lev01StepsOfMainBase)
            {


                var dd = xx.methStart(exLibId, AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode,
                    mainDepart.myCancellationTokenSource.Token, mainDepart, serviceProcess, transObj);




            }


        }




        private async Task<int> meth_projectTableRefreshCommand_BuCmd(object obj)
        {

            await Task.Delay(100);

            int exLibId = ExLibOrg.exLibOrgInst.createOrGiveIndextoUse();
            eAppCommandControls commandName = eAppCommandControls.none;
            if (obj is Button)
            {
                //buttonName = (obj as Button).Name;
                commandName = (eAppCommandControls)Enum.Parse(typeof(eAppCommandControls), (obj as Button).Name, true);
                //(obj as Button).IsEnabled = false;
            }
            else if (obj is eAppCommandControls)
            {

                //commandName = (eAppCommandControls)obj;
                commandName = eAppCommandControls.selection_projectTableRefresh_Bu;
            }
            else if (obj == null)
            {

                //commandName = (eAppCommandControls)obj;
                commandName = eAppCommandControls.selection_projectTableRefresh_Bu;
            }

            bool canChangeDisEnable = true;
            canChangeDisEnable = await Task.Run(() => actionOfX2(exLibId, commandName, canChangeDisEnable));



            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfInformation) > 0)
            {
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.InformationMessageFull);

            }
            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfError | eUseObj.ObjOfException) > 0)
            {
                //mainDepart.logEntries.addEntry(string.Format("Not success {0}", buttonContent));
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.ErrorEx);

            }
            ExLibOrg.exLibOrgInst.resetByIndex(exLibId);


            if (canChangeDisEnable)
            {
                (obj as Button).IsEnabled = true;

            }



            return 100;


        }




        private async Task<int> meth_openExplorerDirectorySmsListFolder_BuCmd(object obj)
        {

            await Task.Delay(100);

            //var command = new AppLib.Commands.RelayCommand(this.meth_openExplorerDirectorySmsListFolder);
            //await command.Execute();



            var result = await Task.Run(() => meth_openExplorerDirectorySmsListFolder(mainDepart.directorySmsListFolder));

            return 100;


        }

        private int meth_openExplorerDirectorySmsListFolder(string filePath)
        {


            IoFileExamine ioFileExamine = new IoFileExamine(filePath);

            if (ioFileExamine.directoryExists)
            {
                Process.Start("explorer.exe", filePath);

            }
            //if (LibFileHandleCheck.isFilePathExists(filePath))

            return 100;


        }


        private async Task<int> meth_mainCancelCommand_BuCmd(object obj)
        {

            await Task.Delay(100);
            //meth_mainCancelCommand_BuCmd
            //If codePageCheckScannerCancelToken IsNot Nothing Then
            //      codePageCheckScannerCancelToken.Cancel(False)

            //  End If
            if (mainDepart.myCancellationTokenSource != null)
            {
                if (!mainDepart.myCancellationTokenSource.MyIsDisposed)
                {
                    mainDepart.myCancellationTokenSource.Cancel(false);
                }
            }
            ////if (mainDepart.myCancellationTokenSource != null)
            ////{
            ////    mainDepart.myCancellationTokenSource.Dispose();
            ////}

            //codePageCheckScannerProcessCancel_BuEnDisbled = False
            return 100;


        }



        private async Task<int> meth_mainProcessCommand_BuCmd(object obj)
        {
            //private async Task<Int32> meth_commandPending()
            //{
            if (isMainInAsync || isMasterInAsync)
            {
                return 0;
            }
            isMainInAsync = true;
            await Task.Delay(100);


            int exLibId = ExLibOrg.exLibOrgInst.createOrGiveIndextoUse();

            storyboard1.Begin();

            eAppCommandControls commandName = eAppCommandControls.none;
            if (obj is Button)
            {
                //buttonName = (obj as Button).Name;
                commandName = (eAppCommandControls)Enum.Parse(typeof(eAppCommandControls), (obj as Button).Name, true);
                //(obj as Button).IsEnabled = false;
            }
            else if (obj is eAppCommandControls)
            {

                //commandName = (eAppCommandControls)obj;
                commandName = eAppCommandControls.selection_projectTableRefresh_Bu;
            }
            else if (obj == null)
            {

                //commandName = (eAppCommandControls)obj;
                commandName = eAppCommandControls.selection_projectTableRefresh_Bu;
            }



            bool canChangeDisEnable = true;

            mainDepart.logEntries.addEntry("Command start:" + commandName.ToString());


            canChangeDisEnable = await Task.Run(() => actionOfX(exLibId, commandName, canChangeDisEnable));





            storyboard1.Stop();




            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfInformation) > 0)
            {
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.InformationMessageFull);

            }
            if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.getCountOf(eUseObj.ObjOfError | eUseObj.ObjOfException) > 0)
            {
                //mainDepart.logEntries.addEntry(string.Format("Not success {0}", buttonContent));
                ExLibOrg.exLibOrgInst.trySendTextTo_MainFehlerDialog(ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern, eMessageTypes.ErrorEx);

            }
            ExLibOrg.exLibOrgInst.resetByIndex(exLibId);


            if (canChangeDisEnable)
            {
                (obj as Button).IsEnabled = true;

            }

            isMainInAsync = false;

            return 100;


        }





        private async Task<bool> actionOfX2(int exLibId, eAppCommandControls commandName, bool canChangeDisEnable)
        {


            List<eAppCommandControls> routedList = new List<eAppCommandControls>();
            Lev01StepsOfMainBase lev01StepsOfMainBase = new Lev01StepsOfMainBase();

            eAppServiceStates success = eAppServiceStates.none;

            ServiceProcess serviceProcess = new ServiceProcess();
            object transObj = null;

            try
            {

                if (commandName == eAppCommandControls.selection_projectTableRefresh_Bu)
                {
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);

                }

                if (mainDepart.myCancellationTokenSource == null || mainDepart.myCancellationTokenSource.MyIsDisposed)
                {
                    mainDepart.myCancellationTokenSource = new MyCancellationTokenSource();

                }

                //mainDepart.tokenSource = new CancellationTokenSource();
                //CancellationTokenSource tokenSource = new CancellationTokenSource();

                serviceProcess.success = success;

                serviceProcess = await Task.Run(() => sessionBegin2(exLibId, lev01StepsOfMainBase, serviceProcess,
                                                AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode,
                                                mainDepart.myCancellationTokenSource.Token,
                                                mainDepart, routedList, transObj));




                //mainDepart.logEntries.addEntry("Command success:" + serviceProcess.success.ToString());
                success = serviceProcess.success;


            }
            catch (Exception ex)
            {
                ExcepTransObj excepTransObj = new ExcepTransObj();
                excepTransObj.setContentParams(eUseObj.ObjOfException, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others, ex);
                ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);

            }
            //controlList_Out.Add(commandName);
            isMasterInAsync = false;

            return canChangeDisEnable;





        }


        //private static List<eAppCommandControls> controlList_In = new List<eAppCommandControls>();
        //private static List<eAppCommandControls> controlList_Out = new List<eAppCommandControls>();


        private async Task<bool> actionOfX(int exLibId, eAppCommandControls commandName, bool canChangeDisEnable)
        {
            if (isMasterInAsync)
            {
                return canChangeDisEnable;
            }
            isMasterInAsync = true;
            //controlList_In.Add(commandName);

            List<eAppCommandControls> routedList = new List<eAppCommandControls>();
            Lev01StepsOfMainBase lev01StepsOfMainBase = new Lev01StepsOfMainBase();
            //object returnCode = null;
            eAppServiceStates success = eAppServiceStates.none;

            //string buttonName = string.Empty;
            ServiceProcess serviceProcess = new ServiceProcess();
            object transObj = null;



            try
            {
                //string database = AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.database;
                //string connectionString = AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.demi();
                //var relayCommand = (RelayCommand)obj;


                //var relayCommand1 = obj as ICommand;
                //var relayCommand2 = obj as RelayCommand;



                if (commandName == eAppCommandControls.selection_projectLoad_Bu)
                {
                    lev01StepsOfMainBase.Add(new SmsProjectLoad());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);


                }
                else if (commandName == eAppCommandControls.selection_createProjectnameFromFilename_Bu)
                {

                    lev01StepsOfMainBase.Add(new CreateNewFromFilename());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { filePath_sms_source };
                    //success = MainAppConfig.mainAppConfigInst.Make_Change_AuftragsTyp_Manuell(exLibId,
                    //                                            success, mainDepart);
                    //returnCode = await Task.Run(() => commandPendingSub.makeDispatcherStartDownload(doUpdate, mainDepart.appCntrlSetterColl));



                }
                else if (commandName == eAppCommandControls.selection_createNewProject_Bu)
                {

                    lev01StepsOfMainBase.Add(new SmsProjectCreateNewProject());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { filePath_sms_source, createNewProjectWorkFolder };
                    //success = MainAppConfig.mainAppConfigInst.Make_Change_AuftragsTyp_Manuell(exLibId,
                    //                                            success, mainDepart);
                    //returnCode = await Task.Run(() => commandPendingSub.makeDispatcherStartDownload(doUpdate, mainDepart.appCntrlSetterColl));



                }
                else if (commandName == eAppCommandControls.selection_projectUnLoad_Bu)
                {

                    lev01StepsOfMainBase.Add(new SmsSelectionProjectUnLoad());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName, projectWorkFolderComboValue };
                    //success = MainAppConfig.mainAppConfigInst.Make_Change_AuftragsTyp_Manuell(exLibId,
                    //                                            success, mainDepart);
                    //returnCode = await Task.Run(() => commandPendingSub.makeDispatcherStartDownload(doUpdate, mainDepart.appCntrlSetterColl));

                    projectWorkFolderComboValue = eSmsWorkFolders.none;

                }

                else if (commandName == eAppCommandControls.selection_moveTo_Bu)
                {

                    lev01StepsOfMainBase.Add(new SmsSelectionProjectMoveTo());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName, projectWorkFolderComboValue };
                    //success = MainAppConfig.mainAppConfigInst.Make_Change_AuftragsTyp_Manuell(exLibId,
                    //                                            success, mainDepart);
                    //returnCode = await Task.Run(() => commandPendingSub.makeDispatcherStartDownload(doUpdate, mainDepart.appCntrlSetterColl));



                }
                else if (commandName == eAppCommandControls.selection_editSessionConfirm_Bu
                    || commandName == eAppCommandControls.selection_editSessionResetToDefault_Bu)
                {

                    lev01StepsOfMainBase.Add(new SmsSelectionEditSession());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };
                    //success = MainAppConfig.mainAppConfigInst.Make_Change_AuftragsTyp_Manuell(exLibId,
                    //                                            success, mainDepart);
                    //returnCode = await Task.Run(() => commandPendingSub.makeDispatcherStartDownload(doUpdate, mainDepart.appCntrlSetterColl));



                }




                // /////////////////////////////////////////////////////////////////////////
                // workflow 
                else if (commandName == eAppCommandControls.workflow_sms_prepare_process_Bu)
                {
                    canChangeDisEnable = false;
                    lev01StepsOfMainBase.Add(new WorkflowSmsPrepareProcess());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = string.Empty;

                }
                else if (commandName == eAppCommandControls.workflow_sms_prepare_process_Reset_Bu)
                {

                    mainDepart.smsFinalizerSession.sms_prepare_process = false;


                }
                else if (commandName == eAppCommandControls.workflow_sms_start_process_Bu
                        || commandName == eAppCommandControls.workflow_smsList1_Bu
                        || commandName == eAppCommandControls.workflow_smsList2_Bu
                        || commandName == eAppCommandControls.workflow_smsList3_Bu
                        || commandName == eAppCommandControls.workflow_smsList4_Bu
                        || commandName == eAppCommandControls.workflow_smsList5_Bu
                        || commandName == eAppCommandControls.workflow_smsList6_Bu
                        || commandName == eAppCommandControls.workflow_smsList7_Bu
                        || commandName == eAppCommandControls.workflow_smsList8_Bu
                        || commandName == eAppCommandControls.workflow_smsList9_Bu)
                {
                    canChangeDisEnable = false;
                    lev01StepsOfMainBase.Add(new WorkflowSmsStartProcess());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }
                else if (commandName == eAppCommandControls.workflow_sms_start_process_Reset_Bu)
                {

                    mainDepart.smsFinalizerSession.sms_start_process = false;


                }
                else if (commandName == eAppCommandControls.workflow_sms_prae_ready_create_Bu)
                {
                    canChangeDisEnable = false;
                    lev01StepsOfMainBase.Add(new WorkflowSmsPraeReadyCreate());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = string.Empty;

                }
                else if (commandName == eAppCommandControls.workflow_sms_prae_ready_create_Reset_Bu)
                {

                    mainDepart.smsFinalizerSession.sms_prae_ready_create = false;


                }
                else if (commandName == eAppCommandControls.workflow_sms_finally_create_Bu)
                {
                    canChangeDisEnable = false;
                    lev01StepsOfMainBase.Add(new WorkflowSmsFinallyCreate());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = string.Empty;

                }
                else if (commandName == eAppCommandControls.workflow_sms_finally_create_Reset_Bu)
                {

                    mainDepart.smsFinalizerSession.sms_finally_create = false;


                }
                else if (commandName == eAppCommandControls.workflow_privateContact_Bu
                    || commandName == eAppCommandControls.workflow_eMailContact_Bu)
                {

                    lev01StepsOfMainBase.Add(new ContactCheckOrg());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }


                // /////////////////////////////////////////////////////////////////////////
                // FinalizeUc 
                else if (commandName == eAppCommandControls.finalizePrintCode1_Bu
                        || commandName == eAppCommandControls.finalizePrintCode3_Bu
                        || commandName == eAppCommandControls.finalizePrintCode8_Bu)
                {

                    lev01StepsOfMainBase.Add(new FinalizeSmsPrintCode());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }
                else if (commandName == eAppCommandControls.finalizeEmailNameSort_Bu
                        || commandName == eAppCommandControls.finalizeEmailNameBind_Bu
                        || commandName == eAppCommandControls.finalizeMsgSplit_Bu
                        || commandName == eAppCommandControls.finalizeMsgCreate_Bu
                        || commandName == eAppCommandControls.finalizeEmailNameSort_Reset_Bu
                        || commandName == eAppCommandControls.finalizeEmailNameBind_Reset_Bu
                        || commandName == eAppCommandControls.finalizeMsgSplit_Reset_Bu
                        || commandName == eAppCommandControls.finalizeMsgCreate_Reset_Bu)
                {
                    canChangeDisEnable = false;
                    lev01StepsOfMainBase.Add(new FinalizeEmailPrepare());
                    lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }
                else if (commandName == eAppCommandControls.finalizeChooseMailSendCode1_Bu
                                  || commandName == eAppCommandControls.finalizeChooseMailSendCode8_Bu)
                {

                    canChangeDisEnable = false;

                    if (commandName == eAppCommandControls.finalizeChooseMailSendCode1_Bu)
                    {
                        mainDepart.finalizeChooseMailSendCode = 1;

                    }
                    else if (commandName == eAppCommandControls.finalizeChooseMailSendCode8_Bu)
                    {
                        mainDepart.finalizeChooseMailSendCode = 8;


                    }





                }
                // /////////////////////////////////////////////////////////////////////////
                // SpecialText
                else if (commandName == eAppCommandControls.specialTextUserOnly_Bu
                                  || commandName == eAppCommandControls.specialTextUserOnlyTest_Bu)
                {


                    if (commandName == eAppCommandControls.specialTextUserOnly_Bu)
                    {
                        mainDepart.specialTextUserOnly_Bu_DisEnabled = false;
                        mainDepart.specialTextUserOnlyTest_Bu_DisEnabled = true;

                    }
                    else
                        if (commandName == eAppCommandControls.specialTextUserOnlyTest_Bu)
                        {
                            mainDepart.specialTextUserOnly_Bu_DisEnabled = true;
                            mainDepart.specialTextUserOnlyTest_Bu_DisEnabled = false;

                        }



                }
                else if (commandName == eAppCommandControls.specialTextForEMailBetreffReset_Bu
                        || commandName == eAppCommandControls.specialTextForEMailHinweis1Reset_Bu
                        || commandName == eAppCommandControls.specialTextForEMailHinweis2Reset_Bu
                        || commandName == eAppCommandControls.specialTextForEMailHinweis3Reset_Bu
                        || commandName == eAppCommandControls.specialTextForEMailTextReset_Bu
                        || commandName == eAppCommandControls.specialTextForEMailTextEndeReset_Bu)
                {

                    lev01StepsOfMainBase.Add(new SmsSpecialText());
                    //lev01StepsOfMainBase.Add(new SmsProjectTableRefresh());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }


               // /////////////////////////////////////////////////////////////////////////
                else if (commandName == eAppCommandControls.workflow_smsListResetAll_Bu
                        || commandName == eAppCommandControls.workflow_smsList1_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList2_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList3_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList4_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList5_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList6_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList7_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList8_Reset_Bu
                        || commandName == eAppCommandControls.workflow_smsList9_Reset_Bu)
                {
                    lev01StepsOfMainBase.Add(new WorkflowSmsListResetAll());
                    routedList.Add(commandName);
                    transObj = new object[] { string.Empty, commandName };

                }

                //else if ()
                //{
                //    canChangeDisEnable = false;
                //    lev01StepsOfMainBase.Add(new SmsPartList());
                //    routedList.Add(commandName);


                //}




                mainDepart.myCancellationTokenSource = new MyCancellationTokenSource();


                serviceProcess.success = success;

                serviceProcess = await Task.Run(() => sessionBegin(exLibId, lev01StepsOfMainBase, serviceProcess,
                                                AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode,
                                                mainDepart.myCancellationTokenSource.Token,
                                                mainDepart, routedList, transObj));


                if (commandName == eAppCommandControls.selection_createProjectnameFromFilename_Bu)
                {
                    mainDepart.createNewProjectDesignations.projectName = serviceProcess.valueString;


                }
                mainDepart.logEntries.addEntry("Command success:" + serviceProcess.success.ToString());
                success = serviceProcess.success;





            }
            catch (OperationCanceledException ex)
            {
                ExcepTransObj excepTransObj = new ExcepTransObj();
                excepTransObj.setContentParams(eUseObj.ObjOfInformation, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others, ex.Message.ToString());
                ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);

            }
            catch (Exception ex)
            {
                ExcepTransObj excepTransObj = new ExcepTransObj();
                excepTransObj.setContentParams(eUseObj.ObjOfException, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others, ex);
                ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);

            }
            //controlList_Out.Add(commandName);
            isMasterInAsync = false;

            return canChangeDisEnable;

        }





        private ServiceProcess sessionBegin(Int32 exLibId, Lev01StepsOfMainBase list, ServiceProcess serviceProcess,
            AppEnvironmentConnectionModus currentMode,
            CancellationToken cancellationToken,
             MainDepart t_mainDepart, List<eAppCommandControls> routedList, object transObj)
        {


            if (Convert.ToString(t_mainDepart.smsFinalizerCntrlSetter.id_smsfz).Equals("0"))
            {
                ExcepTransObj excepTransObj = new ExcepTransObj();
                excepTransObj.setContentParams(eUseObj.ObjOfError, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others,
                   "FinalizerCntrlSetter Id darf nicht den Wert 0 haben!");
                ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);
                return serviceProcess;
            }
            //
            if (Convert.ToString(t_mainDepart.smsFinalizerSession.id_smsfs).Equals("0"))
            {


                if (routedList.Contains(eAppCommandControls.selection_projectLoad_Bu))
                {
                    //if (!t_mainDepart.smsFinalizerSession.IsSelected)
                    //{
                    if (t_mainDepart.smsFinalizerSelectedRow == null || t_mainDepart.smsFinalizerSelectedRow.id_smsfs == 0)
                    {

                        ExcepTransObj excepTransObj = new ExcepTransObj();
                        excepTransObj.setContentParams(eUseObj.ObjOfError, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others,
                            "Bitte zuerst ein Projekt auswählen!");
                        ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);
                        return serviceProcess;

                    }

                }
                else if (!(routedList.Contains(eAppCommandControls.selection_projectUnLoad_Bu)
                    || routedList.Contains(eAppCommandControls.selection_createNewProject_Bu)
                    || routedList.Contains(eAppCommandControls.selection_createProjectnameFromFilename_Bu)))
                {
                    //  
                    ExcepTransObj excepTransObj = new ExcepTransObj();
                    excepTransObj.setContentParams(eUseObj.ObjOfError, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others,
                        "Kein Projekt ausgewählt!");
                    ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);
                    return serviceProcess;

                }

            }

            foreach (var xx in list)
            {


                serviceProcess = xx.methStart(exLibId, currentMode, cancellationToken, t_mainDepart, serviceProcess, transObj);


                if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.mainMethodsExit)
                {
                    serviceProcess.success = eAppServiceStates.StandBy;
                    return serviceProcess;
                }
                serviceProcess.success = eAppServiceStates.Active;

            }


            if (t_mainDepart.smsFinalizerCntrlSetter.id_smsfz > 0)
            {
                AppDbUpdateRegisterDelegate<SmsFinalizerCntrlSetter, eSmsFinalizerColsCntrlSetter>.appDbUpdateRegisterDelegateCreateDoMain(
                        t_mainDepart.smsFinalizerCntrlSetter, AppDbPartColHelper.smsFinalizerCntrlSetterUpdtCreate.appUseableCols,
                        AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.demi(), AppDbController.appDbControllerInst.appDbConfig.dbSchemaAndDbSmsFinalizerCntrlSetterToString,
                       eSmsFinalizerColsCntrlSetter.id_smsfz.ToString(), Convert.ToInt32(t_mainDepart.smsFinalizerCntrlSetter.id_smsfz), 0);

                t_mainDepart.smsFinalizerCntrlSetter.resetHasChanged();

            }

            if (t_mainDepart.smsFinalizerSession.id_smsfs > 0)
            {
                AppDbUpdateRegisterDelegate<SmsFinalizerSession, eSmsFinalizerColsSession>.appDbUpdateRegisterDelegateCreateDoMain(
                      t_mainDepart.smsFinalizerSession, AppDbPartColHelper.smsFinalizerCntrlSetterUpdtCreate.appSessionsUseableCols,
                       AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.demi(), AppDbController.appDbControllerInst.appDbConfig.dbSchemaAndDbSmsFinalizerSessionToString,
                     eSmsFinalizerColsSession.id_smsfs.ToString(), Convert.ToInt32(t_mainDepart.smsFinalizerSession.id_smsfs), 0);

                t_mainDepart.smsFinalizerSession.resetHasChanged();
            }
            return serviceProcess;
        }




        private ServiceProcess sessionBegin2(Int32 exLibId, Lev01StepsOfMainBase list, ServiceProcess serviceProcess,
         AppEnvironmentConnectionModus currentMode,
         CancellationToken cancellationToken,
          MainDepart t_mainDepart, List<eAppCommandControls> routedList, object transObj)
        {


            //if (Convert.ToString(mainDepart.smsFinalizerCntrlSetter.id_smsfz).Equals("0"))
            //{

            //    ExcepTransObj excepTransObj = new ExcepTransObj();
            //    excepTransObj.setContentParams(eUseObj.ObjOfError, eExceptionLevelCode.critical, eLateExceptUserAction.DefaultHandle, eExcepTransOperation.others,
            //        "FinalizerCntrlSetter Id darf nicht den Wert 0 haben!");
            //    ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.innerHandleInsert(excepTransObj);
            //    return serviceProcess;
            //}


            foreach (var xx in list)
            {



                serviceProcess = xx.methStart(exLibId, currentMode, cancellationToken, t_mainDepart, serviceProcess, transObj);


                if (ExLibOrg.exLibOrgInst.listExLib[exLibId].listExcepLibIntern.mainMethodsExit)
                {
                    serviceProcess.success = eAppServiceStates.StandBy;
                    return serviceProcess;
                }
                serviceProcess.success = eAppServiceStates.Active;

            }

            //AppDbUpdateRegisterDelegate<SmsFinalizerCntrlSetter, eSmsFinalizerColsCntrlSetter>.appDbUpdateRegisterDelegateCreateDoMain(
            //        mainDepart.smsFinalizerCntrlSetter, AppDbPartColHelper.smsFinalizerCntrlSetterUpdtCreate.appUseableCols,
            //        AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.demi(), AppDbController.appDbControllerInst.appDbConfig.dbSchemaAndDbSmsFinalizerCntrlSetterToString,
            //       eSmsFinalizerColsCntrlSetter.id_smsfz.ToString(), Convert.ToInt32(mainDepart.smsFinalizerCntrlSetter.id_smsfz), 0);

            //mainDepart.smsFinalizerCntrlSetter.resetHasChanged();


            //AppDbUpdateRegisterDelegate<SmsFinalizerSession, eSmsFinalizerColsSession>.appDbUpdateRegisterDelegateCreateDoMain(
            //      mainDepart.smsFinalizerSession, AppDbPartColHelper.smsFinalizerCntrlSetterUpdtCreate.appSessionsUseableCols,
            //       AppEnvironmentConnectionModi.appEnvironmentConnectionModiInst.currentMode.abc.demi(), AppDbController.appDbControllerInst.appDbConfig.dbSchemaAndDbSmsFinalizerSessionToString,
            //     eSmsFinalizerColsSession.id_smsfs.ToString(), Convert.ToInt32(mainDepart.smsFinalizerSession.id_smsfs), 0);

            //mainDepart.smsFinalizerSession.resetHasChanged();

            return serviceProcess;
        }




    }
}
