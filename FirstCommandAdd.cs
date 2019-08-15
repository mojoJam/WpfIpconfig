using System;
using System.Linq;
using System.Collections.ObjectModel;
using WpfAzubi.Models;
using System.Windows;


namespace WpfAzubi.Business
{
    public class FirstCommandAdd
    {





        // Diverse



        public object methStart(ViewModels.MainWindowVm mainWindowVm)
        {



            var item = new PersonDetail() { name = mainWindowVm.window1PersonDetail.name  };


            var result = getItemFrom(item, mainWindowVm.mainObser);

            if (result == null)
            {


                mainWindowVm.mainObser.Add(item);
            }
            else
            {
                if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                   
                }
                else
                {
                    //do yes stuff
                    mainWindowVm.window1.Close();
                }
            }
            return 1;


        }


        public static PersonDetail getItemFrom(PersonDetail personDetail, ObservableCollection<PersonDetail> PLUList)
        {
            PersonDetail target = PLUList.Where(z => z.name == personDetail.name && z.vorName == personDetail.vorName).FirstOrDefault();
            return target == null ? null : target;
        }


    }
}
