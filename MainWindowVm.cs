using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using WpfAzubi.Business;
using WpfAzubi.Commands;
using WpfAzubi.Models;
using WpfAzubi.Views;
 

namespace WpfAzubi.ViewModels
{
    public partial class MainWindowVm
    {
                      private object _koennenObserSync = new object();
        private object _mainObserSync = new object();
                
        public MainWindowVm()
        {
            mainObser.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(mainObserOnCollectionChanged);
            BindingOperations.EnableCollectionSynchronization(mainObser, _mainObserSync);
            BindingOperations.EnableCollectionSynchronization(koennenObser, _koennenObserSync);
            mainObserView = CollectionViewSource.GetDefaultView(mainObser);
            koennenObserView = CollectionViewSource.GetDefaultView(koennenObser);
             

            firstCommand_BuCmd = new RelayCommand((param) =>
            { var xx = firstCommandMeth(param); });

            secCommand_BuCmd = new RelayCommand((param) =>
            { var xx = secCommandMeth(param); });

            firstCommandAdd_BuCmd = new RelayCommand((param) =>
            { var xx = firstCommandAddMeth(param); });
            var tempk = new List<Koennen>();
            tempk.Add(new Koennen() { name = "ABC" + 0.ToString() , IsSelected=true});
            tempk.Add(new Koennen() { name = "ABC" + 3.ToString(), IsSelected = true });

            mainObser.Add(new PersonDetail() { name = "ffffffff", koennenObser = tempk });

            for (int hCnt = 0; hCnt < 10;hCnt++ )
            {

                koennenObser.Add(new Koennen() { name = "ABC" + hCnt.ToString() });
            }

        }

      




        private void mainObserOnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
         









        }

        private async Task<Int32> firstCommandAddMeth(object param)
        {



            FirstCommandAdd firstCommandAdd = new FirstCommandAdd();

            var serviceProcess = firstCommandAdd.methStart(this);





            return 0;
        }


        private async Task<Int32> firstCommandMeth(object param)
        {

            openCodePageCheckExtern();
            return 0;
        }

      
        public bool isOpenCodePageCheckExtern = false;
        private void openCodePageCheckExtern()
        {
            if (isOpenCodePageCheckExtern)
            {
                return;
            }
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));

                //Window1 window1 = new Window1(this);
                window1 = new Window1(this);
                //codePageCheckExternWd.Closing += CodePageCheckExternWd_Closing;
                window1.Closed += new EventHandler(window1_Closed);
                window1.Show();
                isOpenCodePageCheckExtern = true;



            }), DispatcherPriority.ContextIdle, null);
        }

        private void window1_Closed(object sender, EventArgs e)
        {
            Window w = ((Window)(sender));
            w.Closed -= new EventHandler(window1_Closed);
            if (w is IDisposable)
            {
                (w as IDisposable).Dispose();
            }
            isOpenCodePageCheckExtern = false;

        }

        private async Task<Int32> secCommandMeth(object param)
        {
            

            return 0;
        }



    }
}
