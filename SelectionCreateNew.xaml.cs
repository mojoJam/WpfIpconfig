using ClibBase.Ios.IoFileExaminers;
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

namespace SmsFinalizer.Views
{
    /// <summary>
    /// Interaktionslogik für SelectionCreateNew.xaml
    /// </summary>
    public partial class SelectionCreateNew : UserControl
    {
        public SelectionCreateNew()
        {
            InitializeComponent();
        }


        private void canvas_DragEnter(object sender, DragEventArgs e)
        {

            //itsMagic.Text = "DragEnter";

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

            //var rectangle = sender as Rectangle;
            //if (rectangle != null)
            //{
            //   e.Effects = DragDropEffects.None;
            //    // Save the current Fill brush so that you can revert back to this value in DragLeave.
            //    _previousFill = rectangle.Fill;

            //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //    {
            //        var dataString = e.Data.GetData(DataFormats.FileDrop);

            //        // If the string can be converted into a Brush, convert it.

            //        if (dataString != null)
            //        {
            //            if (dataString is string[])
            //            {
            //                string[] file1d = dataString as string[];
            //                if (file1d.Length > 0)
            //                {
            //                    IoFileExamine xx = new IoFileExamine(file1d[0]);
            //                    if (!(string.IsNullOrEmpty(xx.tryDirectory)))
            //                    {
            //                        rectangle.Tag = xx.filePath;

            //                    }
            //                }

            //            }
            //            else
            //            {
            //                return;
            //            }
            //            Brush newFill = null;//;= new System.Drawing.SolidBrush(Color.FromName(dataString));
            //            //Brush newFill = new BrushConverter().ConvertFromString(dataString) as Brush;// SolidColorBrush;
            //            //Brush newFill = (Brush)converter.ConvertFromString(dataString);
            //            rectangle.Fill = newFill;

            //            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
            //            {
            //                e.Effects = DragDropEffects.Copy;
            //            }
            //            else
            //            {
            //                e.Effects = DragDropEffects.Move;
            //            }
            //        }
            //    }
            //    e.Effects = DragDropEffects.All;

            //    e.Handled = true;
            //}

        }


        //private void canvas_Drop(object sender, DragEventArgs e)
        //{

        //    itsMagic.Text = "Drop";
        //    e.Effects = DragDropEffects.None;
        //    var rectangle = sender as Canvas;
        //    if (rectangle != null)
        //    {
        //        //
        //        // Save the current Fill brush so that you can revert back to this value in DragLeave.
        //        //_previousFill = rectangle.Fill;

        //        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //        {
        //            var dataString = e.Data.GetData(DataFormats.FileDrop);

        //            // If the string can be converted into a Brush, convert it.

        //            if (dataString != null)
        //            {
        //                if (dataString is string[])
        //                {
        //                    string[] file1d = dataString as string[];

        //                    if (file1d.Length > 0)
        //                    {
        //                        IoFileExamine xx = new IoFileExamine(file1d[0]);
        //                        if (!(string.IsNullOrEmpty(xx.tryDirectory)))
        //                        {
        //                            rectangle.Tag = xx.filePath;

        //                        }
        //                    }
        //                }
        //                Brush newFill = null;//;= new System.Drawing.SolidBrush(Color.FromName(dataString));
        //                //Brush newFill = new BrushConverter().ConvertFromString(dataString) as Brush;// SolidColorBrush;
        //                //Brush newFill = (Brush)converter.ConvertFromString(dataString);
        //                //rectangle.Fill = newFill;

        //                if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
        //                {
        //                    e.Effects = DragDropEffects.Copy;
        //                }
        //                else
        //                {
        //                    e.Effects = DragDropEffects.Move;
        //                }
        //            }
        //        }



        //    }

        //    e.Effects = DragDropEffects.All;
        //    e.Handled = true;
        //}



        private Brush _previousFill = null;

        private void rectangle_DragOver(object sender, DragEventArgs e)
        {
            //itsMagic.Text = "DragOver";
            e.Handled = true;
        }


        private void rectangle_DragEnter(object sender, DragEventArgs e)
        {
            //itsMagic.Text = "DragEnter";

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

        }

        private void rectangle_DragLeave(object sender, DragEventArgs e)
        {
            //itsMagic.Text = "DragLeave";
            e.Handled = true;
        }

        private void rectangle_Drop(object sender, DragEventArgs e)
        {

            var rectangle = sender as Canvas;
            if (rectangle != null)
            {
                e.Effects = DragDropEffects.None;
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
                //_previousFill = rectangle.Fill;

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var dataString = e.Data.GetData(DataFormats.FileDrop);

                    // If the string can be converted into a Brush, convert it.

                    if (dataString != null)
                    {
                        if (dataString is string[])
                        {
                            string[] file1d = dataString as string[];

                            if (file1d.Length > 0)
                            {
                                IoFileExamine xx = new IoFileExamine(file1d[0]);
                                if (!(string.IsNullOrEmpty(xx.tryDirectory)))
                                {
                                    rectangle.Tag = xx.filePath;

                                }
                            }
                        }
                        Brush newFill = null;//;= new System.Drawing.SolidBrush(Color.FromName(dataString));
                        //Brush newFill = new BrushConverter().ConvertFromString(dataString) as Brush;// SolidColorBrush;
                        //Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        //rectangle.Fill = newFill;

                        if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                        {
                            e.Effects = DragDropEffects.Copy;
                        }
                        else
                        {
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
                e.Handled = true;

            }


        }


        private string lastText = string.Empty;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb == null) return;

            if (tb.Text.Length > 22)
            {
                tb.Text = lastText;
                return;
            }
            lastText = tb.Text;
        }


    }
}
