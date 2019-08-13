using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ved.ViewModels;
using Ved.Views.Solos;
using AppLib.Business;
using AppLib.Business.AppBindMasters;
using AppLib.Business.AppCntlConstants;
using AppLib.Constants;
using AppLib.Services;
using AppLib.Business.AppInitializerLists;

namespace Ved.Views
{
    /// <summary>
    /// Interaktionslogik für Menue1Uc.xaml
    /// </summary>
    public partial class Menue1Uc : UserControl
    {
        public Menue1Uc()
        {
            InitializeComponent();



            Array allValues = Enum.GetValues(typeof(eDcbDsOrg));
            //  Dim _nodeList2 As New List(Of ItemViewModel)
            Dictionary<string, object> itemCollectionDsOrg = new Dictionary<string, object>();
            Dictionary<string, object> itemCollectionSelectedItemsDsOrg = new Dictionary<string, object>();
            foreach (var valX in allValues)
            {
                itemCollectionDsOrg.Add(valX.ToString(), true);
                itemCollectionSelectedItemsDsOrg.Add(valX.ToString(), true);
                //  _nodeList2.Add(New ItemViewModel With {.name = valX.ToString(), .isSelected = False, .isDeSelected = False}) , New Object
            }

            multiSelectComboBoxDsOrg.ItemsSource = itemCollectionDsOrg;


            multiSelectComboBoxDsOrg.fillAll();


            LiveUpdateDepend.liveUpdateDependInst.setBindingItemCollectionSelectedItemsDsOrg(multiSelectComboBoxDsOrg, "SelectedItems");

            ////damItToday
            ((MultiSelectPairViewVm)(WpfMultiSelectPairViewDsOrgContent).DataContext).MasterViewModelCreateNewList();
            try
            {
                LiveUpdateDepend.liveUpdateDependInst.setBindingWpfMultiSelectPairViewDsOrgItems(((MultiSelectPairView)WpfMultiSelectPairViewDsOrgContent).DataContext, "Items");

            }
            catch (Exception ex)
            {
                Exception exi = ex;
            }


            LeftOptMenuUc_Initialized();

            AppInitializerColl.appInitializerCollInst.addLine("Menue1Uc", "Menue1Uc", true);

        }





        private void LeftOptMenuUc_Initialized()
        {
            if (BoundCntlDepart.boundCntlDepartInst == null)
            {
                BoundCntlDepart.boundCntlDepartInst = new BoundCntlDepart();
            }


            Application.Current.Dispatcher.Invoke(new Action(delegate
            {


                BoundCntlDepart.boundCntlDepartInst.boundCntlMaster.addingControlBinding(
                                       new List<Control>{  
                                                                        groupDecision_DetailsExpander,  
                                                                        dsn_Search1_TBox,  
                                                                        dsn_Search2_TBox,  
                                                                        stQu_Search1_TBox,
                                       stQu_Search2_TBox,
                                       singleQu_Search1_TBox,
                                       singleQu_Search2_TBox,
                                       year_Search1_TBox,
                                       year_Search2_TBox,
                                       material_Search1_TBox,
                                       material_Search2_TBox,
                                       dsnFilterOrElse_Bu,
                                       stQuFilterOrElse_Bu,
                                       materialFilterOrElse_Bu,
                                       singleQuFilterOrElse_Bu,
                                       yearFilterOrElse_Bu,
                                       dsn_Searchbox1_clear_Bu,
                                       dsn_Searchbox2_clear_Bu,
                                       stQu_Searchbox1_clear_Bu,
                                       stQu_Searchbox2_clear_Bu,
                                       singleQu_Searchbox1_clear_Bu,
                                       singleQu_Searchbox2_clear_Bu,
                                       material_Searchbox1_clear_Bu,
                                       material_Searchbox2_clear_Bu,
                                       year_QU_Searchbox1_clear_Bu,
                                       year_QU_Searchbox2_clear_Bu,
                                         dsnInTBoxView_Bu,
                                         cellValueInTBoxView_Bu},
                                  new List<eBoundCntlGuiBindingTypes>{ 
                                                       eBoundCntlGuiBindingTypes.Enabled},
                                            new List<eBoundCntlGuiCategory>{  
                                                                      eBoundCntlGuiCategory.refToolSelect}, false, false);





            }), System.Windows.Threading.DispatcherPriority.ContextIdle, null);



        }

        private void Mat_FilterBu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SI_QU_FilterBu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ST_Qu_Filter_Bu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DSN_Filter_Bu_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Year_QU_FilterBu_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void dsnInTBoxView_Bu_Click(object sender, RoutedEventArgs e)
        {

        }


        private string toolTip_year_Search1_TBox;
        private void OnError_year_Search1_TBox(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                toolTip_year_Search1_TBox = year_Search1_TBox.ToolTip.ToString();
                year_Search1_TBox.ClearValue(TextBox.ToolTipProperty);
            }
            else
            {
                year_Search1_TBox.SetValue(TextBox.ToolTipProperty, toolTip_year_Search1_TBox);
            }
        }

        private string toolTip_year_Search2_TBox;
        private void OnError_year_Search2_TBox(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                toolTip_year_Search2_TBox = year_Search2_TBox.ToolTip.ToString();
                year_Search2_TBox.ClearValue(TextBox.ToolTipProperty);
            }
            else
            {
                year_Search2_TBox.SetValue(TextBox.ToolTipProperty, toolTip_year_Search2_TBox);
            }
        }


    }
}
