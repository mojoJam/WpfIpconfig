using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ved.Views
{
    /// <summary>
    /// Interaktionslogik für MultiSelectComboBox.xaml
    /// </summary>
    public partial class MultiSelectComboBox : UserControl
    {
        private ObservableCollection<Node> _nodeList;
        public MultiSelectComboBox()
        {
            InitializeComponent();
            _nodeList = new ObservableCollection<Node>();
        }

        #region Dependency Properties

        public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(Dictionary<string, object>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
        new PropertyChangedCallback(MultiSelectComboBox.OnItemsSourceChanged)));

        public static readonly DependencyProperty SelectedItemsProperty =
         DependencyProperty.Register("SelectedItems", typeof(Dictionary<string, object>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
     new PropertyChangedCallback(MultiSelectComboBox.OnSelectedItemsChanged)));

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register("DefaultText", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata("None"));






        public Dictionary<string, object> ItemsSource
        {
            get { return (Dictionary<string, object>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public Dictionary<string, object> SelectedItems
        {
            get { return (Dictionary<string, object>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        #endregion

        #region Events
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.DisplayInControl();
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.SelectNodes();
            control.SetText();
        }

        private object text_All = "All";
        //Convert.ToString(clickedBox.Content)




        public bool setOneSomeAllOrSingleAll
        {
            get
            {
                return _setOneSomeAllOrSingleAll;
            }
            set
            {
                _setOneSomeAllOrSingleAll = value;
                //NotifyPropertyChanged("setOneSomeAllOrSingleAll");
            }
        }
        private bool _setOneSomeAllOrSingleAll = true;

        public void fillAll()
        {
            foreach (Node node in _nodeList)
            {
                node.IsSelected = true;
            }


        }


        public void fillXOrByKey(string keyName, bool decision = true)
        {
            foreach (Node node in _nodeList)
            {
                if (node.Title == keyName)
                { node.IsSelected = decision; }

            }


        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;

            if (clickedBox.Content.Equals(text_All))
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = true;
                    }
                }
                //else
                //{
                //    foreach (Node node in _nodeList)
                //    {
                //        node.IsSelected = true;
                //        //node.IsSelected = false;
                //    }
                //}

            }
            else
            {
                int _selectedCount = 0;
                foreach (Node s in _nodeList)
                {
                    if (s.IsSelected && s.Title != "All")
                    {
                        _selectedCount++;
                    }
                }
                if (_selectedCount == _nodeList.Count - 1)
                {
                    _nodeList.FirstOrDefault(i => i.Title == "All").IsSelected = true;
                }
                if (_selectedCount == 0)
                {                    
                    _nodeList.FirstOrDefault(i => i.Title == "All").IsSelected = true;
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = true;
                    }
                }
                else
                {
                    _nodeList.FirstOrDefault(i => i.Title == "All").IsSelected = false;
                }
            }
            SetSelectedItems();
            SetText();

        }
        #endregion


        #region Methods
        private void SelectNodes()
        {
            foreach (KeyValuePair<string, object> keyValue in SelectedItems)
            {
                Node node = _nodeList.FirstOrDefault(i => i.Title == keyValue.Key);
                if (node != null)
                    node.IsSelected = true;
            }
        }



        private void SetSelectedItems()
        {
            if (SelectedItems == null)
                SelectedItems = new Dictionary<string, object>();
            SelectedItems.Clear();
            foreach (Node node in _nodeList)
            {
                if (node.IsSelected && node.Title != "All")
                {
                    if (this.ItemsSource.Count > 0)

                        SelectedItems.Add(node.Title, this.ItemsSource[node.Title]);
                }
            }
        }

        private void DisplayInControl()
        {
            _nodeList.Clear();
            if (this.ItemsSource.Count > 0)
            {
                _nodeList.Add(new Node("All"));
                _nodeList[_nodeList.Count - 1].IsSelected = true;
            }
            foreach (KeyValuePair<string, object> keyValue in this.ItemsSource)
            {
                Node node = new Node(keyValue.Key);
                if ((bool)keyValue.Value)
                {
                    node.IsSelected = true;
                }
                else
                {
                    node.IsSelected = false;
                }
                _nodeList.Add(node);
            }
            MultiSelectCombo.ItemsSource = _nodeList;
            SetSelectedItems();
            SetText();
        }



        private void SetText()
        {
            Int32 countodSelectedItems = 0;
            if (this.SelectedItems != null)
            {
                if (this.SelectedItems.Count != 0)
                {
                    StringBuilder displayText = new StringBuilder();
                    foreach (Node s in _nodeList)
                    {
                        if (s.IsSelected == true && s.Title == "All")
                        {
                            displayText = new StringBuilder();
                            displayText.Append("All");
                            break;
                        }
                        else if (s.IsSelected == true && s.Title != "All")
                        {
                            countodSelectedItems++;
                            displayText.Append(s.Title);
                            displayText.Append(',');
                        }
                    }
                    this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
                }
                else
                {
                    this.Text = this.DefaultText;
                }


                //if (setOneSomeAllOrSingleAll)
                //{
                //    if (countodSelectedItems > 1)
                //    { 
                //        if (displayText.ToString() != "All")
                //        {
                //            displayText = new StringBuilder();
                //            displayText.Append("Some");
                //            //break;
                //        }
                //     }
                //    else if (countodSelectedItems == 1)
                //    {
                //        if (displayText.ToString() != "All")
                //        {
                //            displayText = new StringBuilder();
                //            displayText.Append("One");
                //            //break;
                //        }
                //     }
                //}         




            }




            // set DefaultText if nothing else selected     string.Format("RecFm: {0}",this.DefaultText);
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;
            }



        }


        #endregion
    }

    public class Node : INotifyPropertyChanged
    {

        private string _title;
        private bool _isSelected;
        #region ctor
        public Node(string title)
        {
            Title = title;
        }
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}