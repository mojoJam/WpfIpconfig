using AppLib.Business.AppManagements;
using AppLib.Constants;
using AppLib.Models;
using ClibBase.DataBases.DbMySqlAbcs;
using ClibBase.Ios.IoFileExaminers;
using ClibBase.Systems.Generics.Comparers;
using ClibBase.Utils.Enums;
using SmsProjectBasic.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


// MainWindowVm.Base


namespace SmsFinalizer.ViewModels
{
    public partial class MainWindowVm : INotifyPropertyChanged
    {


        // ======================================================================================



        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
                RaisePropertyChanged(() => this.Width);
            }
        }
        private double _Width = Double.NaN;

           public bool doClose
        {
            get { return _doClose; }
            set
            {
                _doClose = value;
                RaisePropertyChanged(() => this.doClose);
            }
        }
        private bool _doClose = false;

          


        public AppManager appManager = new AppManager();


        public MainDepart mainDepart
        {
            get { return _mainDepart; }
            set
            {
                _mainDepart = value;
                RaisePropertyChanged(() => this.mainDepart);
            }
        }
        private MainDepart _mainDepart = new MainDepart();


        public bool onClosedMainWindow
        {
            get { return _onClosedMainWindow; }
            set
            {
                _onClosedMainWindow = value;
                RaisePropertyChanged(() => this.onClosedMainWindow);
            }
        }
        private bool _onClosedMainWindow = false;


        // ======================================================================================



        public ICollectionView mainTableObsoView
        {
            get { return _mainTableObsoView; }
            set
            {
                _mainTableObsoView = value;
                RaisePropertyChanged(() => this.mainTableObsoView);
            }
        }
        private ICollectionView _mainTableObsoView;





        [DefaultValue(eSmsWorkFolders.none)]
        public eSmsWorkFolders projectWorkFolderComboValue
        {
            get { return _projectWorkFolderComboValue; }
            set
            {
                _projectWorkFolderComboValue = value;
                RaisePropertyChanged(() => this.projectWorkFolderComboValue);
            }
        }
        private eSmsWorkFolders _projectWorkFolderComboValue;



        [DefaultValue(eSmsWorkFolders.XXX_Ainc)]
        public eSmsWorkFolders projectPatternWorkFolderComboValue
        {
            get { return _projectPatternWorkFolderComboValue; }
            set
            {
                _projectPatternWorkFolderComboValue = value;
                RaisePropertyChanged(() => this.projectPatternWorkFolderComboValue);
            }
        }
        private eSmsWorkFolders _projectPatternWorkFolderComboValue = eSmsWorkFolders.XXX_Ainc;






        // ======================================================================================

        [DefaultValue(eSmsWorkFolders.XXX_Ainc)]
        public eSmsWorkFolders createNewProjectWorkFolder
        {
            get { return _createNewProjectWorkFolder; }
            set
            {
                _createNewProjectWorkFolder = value;
                RaisePropertyChanged(() => this.createNewProjectWorkFolder);
            }
        }
        private eSmsWorkFolders _createNewProjectWorkFolder = eSmsWorkFolders.XXX_Ainc;







        // ======================================================================================


        /// <summary>
        /// Input file which contains HSM SMS Dataset Names       
        /// </summary>
        public IoFileExamine filePath_sms_source
        {
            get { return _filePath_sms_source; }
            set
            {
                _filePath_sms_source = value;
                RaisePropertyChanged(() => this.filePath_sms_source);
            }
        }
        private IoFileExamine _filePath_sms_source = null;

        // ======================================================================================
        // createNew


        //public IoFileExamine createNewFilePath
        //{
        //    get { return _createNewFilePath; }
        //    set
        //    {
        //        _createNewFilePath = value;
        //        RaisePropertyChanged(() => this.createNewFilePath);
        //    }
        //}
        //private IoFileExamine _createNewFilePath = null;




        /// <summary>
        /// Store dropped filePath       
        /// </summary>
        public string createNewDropFilePath
        {
            get { return _createNewDropFilePath; }
            set
            {
                _createNewDropFilePath = value;
                RaisePropertyChanged(() => this.createNewDropFilePath);
            }
        }
        private string _createNewDropFilePath = string.Empty;

        // ======================================================================================



        public int mainTabcontrolSelectedIndex
        {
            get { return _mainTabcontrolSelectedIndex; }
            set
            {
                _mainTabcontrolSelectedIndex = value;
                RaisePropertyChanged(() => this.mainTabcontrolSelectedIndex);
            }
        }
        private int _mainTabcontrolSelectedIndex = 0;


        public int takeAcionTabcontrolSelectedIndex
        {
            get { return _takeAcionTabcontrolSelectedIndex; }
            set
            {
                _takeAcionTabcontrolSelectedIndex = value;
                RaisePropertyChanged(() => this.takeAcionTabcontrolSelectedIndex);
            }
        }
        private int _takeAcionTabcontrolSelectedIndex = 0;





        public double ValueRepeatButtonWidth
        {
            get { return _ValueRepeatButtonWidth; }
            set
            {
                _ValueRepeatButtonWidth = value;
                RaisePropertyChanged(() => this.ValueRepeatButtonWidth);
            }
        }
        private double _ValueRepeatButtonWidth = 30;




        public string mainSelectionUcTabItemHeader
        {
            get { return _mainSelectionUcTabItemHeader; }
            set
            {
                _mainSelectionUcTabItemHeader = value;
                RaisePropertyChanged(() => this.mainSelectionUcTabItemHeader);
            }
        }
        private string _mainSelectionUcTabItemHeader = EnumUtilzStatic.GetDescription(eControlNamesExplicit.mainSelectionUc_TabItem).Split('|')[1];



        public string workflowUcTabItemHeader
        {
            get { return _workflowUcTabItemHeader; }
            set
            {
                _workflowUcTabItemHeader = value;
                RaisePropertyChanged(() => this.workflowUcTabItemHeader);
            }
        }
        private string _workflowUcTabItemHeader = EnumUtilzStatic.GetDescription(eControlNamesExplicit.workflowUc_TabItem).Split('|')[1];



        public string finalizeUcTabItemHeader
        {
            get { return _finalizeUcTabItemHeader; }
            set
            {
                _finalizeUcTabItemHeader = value;
                RaisePropertyChanged(() => this.finalizeUcTabItemHeader);
            }
        }
        private string _finalizeUcTabItemHeader = EnumUtilzStatic.GetDescription(eControlNamesExplicit.finalizeUc_TabItem).Split('|')[1];



        public string emailContentUcTabItemHeader
        {
            get { return _emailContentUcTabItemHeader; }
            set
            {
                _emailContentUcTabItemHeader = value;
                RaisePropertyChanged(() => this.emailContentUcTabItemHeader);
            }
        }
        private string _emailContentUcTabItemHeader = EnumUtilzStatic.GetDescription(eControlNamesExplicit.emailContentUc_TabItem).Split('|')[1];

        // ======================================================================================

        public bool baseWindowGridDisEnabled
        {
            get { return _baseWindowGridDisEnabled; }
            set
            {
                _baseWindowGridDisEnabled = value;
                RaisePropertyChanged(() => this.baseWindowGridDisEnabled);
            }
        }
        private bool _baseWindowGridDisEnabled = false;





        // ======================================================================================

        // Fine
        //////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////
        // Start PropertyChanged


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> x)
        {
            var body = x.Body as MemberExpression;

            if (body != null)
            {

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));

                }




            }
        }




        public string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            System.Linq.Expressions.MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }



        // ======================================================================================







        internal void Window_Closing(object sender, EventArgs e)
        {
            doClose = true;
        }
    }
}
