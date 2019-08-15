using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using WpfAzubi.Models;
using WpfAzubi.Views;


namespace WpfAzubi.ViewModels
{
    public partial class MainWindowVm : INotifyPropertyChanged
    {
        public ObservableCollection<Koennen> koennenObser
        {
            get { return _koennenObser; }
            set
            {
                _koennenObser = value;
                RaisePropertyChanged(() => this.koennenObser);
            }
        }
        private ObservableCollection<Koennen> _koennenObser = new ObservableCollection<Koennen>();

        public MainObser mainObser
        {
            get { return _mainObser; }
            set
            {
                _mainObser = value;
                RaisePropertyChanged(() => this.mainObser);
            }
        }
        private MainObser _mainObser = new MainObser();


        public PersonDetail mainObserLine
        {
            get { return _mainObserLine; }
            set
            {
                _mainObserLine = value;
                RaisePropertyChanged(() => this.mainObserLine);
            }
        }
        private PersonDetail _mainObserLine = new PersonDetail();

        public PersonDetail window1PersonDetail
        {
            get { return _window1PersonDetail; }
            set
            {
                _window1PersonDetail = value;
                RaisePropertyChanged(() => this.window1PersonDetail);
            }
        }
        private PersonDetail _window1PersonDetail = new PersonDetail();

        public ICollectionView mainObserView
        {
            get { return _mainObserView; }
            set
            {
                _mainObserView = value;
                RaisePropertyChanged(() => this.mainObserView);
            }
        }
        private ICollectionView _mainObserView;

        public ICollectionView koennenObserView
        {
            get { return _koennenObserView; }
            set
            {
                _koennenObserView = value;
                RaisePropertyChanged(() => this.koennenObserView);
            }
        }
        private ICollectionView _koennenObserView;

           
        public Window1 window1
        {
            get { return _window1; }
            set
            {
                _window1 = value;
                RaisePropertyChanged(() => this.window1);
            }
        }
        private Window1 _window1;// = new Window1();

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





    }
}
