   
 



Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Linq.Expressions
Imports ContactAddressesSelector.ContactAddressesSelector.Models
Imports System.Reflection
Imports ContactAddressesSelector.ContactAddressesSelector.Constants
Imports ContactAddressesSelector.ContactAddressesSelector.Business




Namespace ContactAddressesSelector.Guis

    Partial Public Class ContactAddressesSelectVm
        Implements INotifyPropertyChanged

        Public Property selectedItemAddressesObsoM As AddressesObsoMEdit
            Get
                Return _selectedItemAddressesObsoM
            End Get
            Set(ByVal value As AddressesObsoMEdit)
                _selectedItemAddressesObsoM = value

                RaisePropertyChanged(Function() Me.selectedItemAddressesObsoM)

            End Set
        End Property
        Private _selectedItemAddressesObsoM As AddressesObsoMEdit = New AddressesObsoMEdit()




        Public Property addressesColl() As AddressesColl
            Get
                Return _addressesColl
            End Get
            Set(value As AddressesColl)
                _addressesColl = value
                RaisePropertyChanged(Function() Me.addressesColl)
            End Set
        End Property
        Private _addressesColl As AddressesColl = New AddressesColl()


        Public Property addressesCollView() As ICollectionView
            Get
                Return _addressesCollView
            End Get
            Set(value As ICollectionView)
                _addressesCollView = value
                RaisePropertyChanged(Function() Me.addressesCollView)
            End Set
        End Property
        Private _addressesCollView As ICollectionView


        Public Property genderTag() As String
            Get
                Return _genderTag
            End Get
            Set(value As String)
                _genderTag = value
                RaisePropertyChanged(Function() Me.genderTag)
            End Set
        End Property
        Private _genderTag As String = "4" '"Auto"


        Public Property isDgGridEnabled() As Boolean
            Get
                Return _isDgGridEnabled
            End Get
            Set(value As Boolean)
                _isDgGridEnabled = value
                RaisePropertyChanged(Function() Me.isDgGridEnabled)
            End Set
        End Property
        Private _isDgGridEnabled As Boolean = False

        Public Property canLoadDbContent() As Boolean
            Get
                Return _canLoadDbContent
            End Get
            Set(value As Boolean)
                _canLoadDbContent = value
                RaisePropertyChanged(Function() Me.canLoadDbContent)
            End Set
        End Property
        Private _canLoadDbContent As Boolean = False


        Public Property iamIn() As Boolean
            Get
                Return _iamIn
            End Get
            Set(value As Boolean)
                _iamIn = value
                RaisePropertyChanged(Function() Me.iamIn)
            End Set
        End Property
        Private _iamIn As Boolean = False


        ' Fine
        '////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////
        ' Start objectEquals

        Public Shared Function objectEquals(Of T)(Object1 As T, object2 As T) As Boolean
            If Object.Equals(Object1, Nothing) OrElse Object.Equals(object2, Nothing) Then
                Return False
            End If
            If Not Object.Equals(Object1, object2) Then Return False

            Return True
        End Function

        ' Fine objectEquals
        '////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////
        ' Start PropertyChanged

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
            If Not PropertyChangedEvent Is Nothing Then
                RaiseEvent PropertyChanged(Me, e)
            End If
        End Sub

        Public Sub RaisePropertyChanged(Of T)(propertyName As Expression(Of Func(Of T)))
            Dim exp As MemberExpression = TryCast(propertyName.Body, MemberExpression)
            If exp IsNot Nothing Then
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(exp.Member.Name))



                If exp.Member.Name = GetPropertyName(Function() Me.selectedItemAddressesObsoM) Then


                ElseIf exp.Member.Name = GetPropertyName(Function() Me.genderTag) Then
                    Dim kk = False
                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_is_active) Then
                    Dim kk = False

                    doFilterBaseBoolThreeState("is_active", Me.input_is_active)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_primary_use) Then
                    Dim kk = False

                    doFilterBaseePrimaryUse("primary_use", Me.input_primary_use)





                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_surname) Then
                    Dim kk = False
                    doFilterBaseString("surname", Me.input_surname)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_firstname) Then
                    Dim kk = False
                    doFilterBaseString("firstname", Me.input_firstname)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_email_1) Then
                    Dim kk = False
                    doFilterBaseString("email_1", Me.input_email_1)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_email_2) Then
                    Dim kk = False
                    doFilterBaseString("email_2", Me.input_email_2)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_group_name) Then
                    Dim kk = False
                    doFilterBaseString("group_name", Me.input_group_name)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_group_email) Then
                    Dim kk = False
                    doFilterBaseString("group_email", Me.input_group_email)

                ElseIf exp.Member.Name = GetPropertyName(Function() Me.input_sg_number) Then
                    Dim kk = False
                    doFilterBaseString("sg_number", Me.input_sg_number)


                End If






                'CallByName(Me, SMSContentEnumList.sMSContentEnumList_Inst(eSMSContent.tso_dsnHsh).propName, _
                '                           CallType.Set, xtso_dsn1D(hCnt).GetHashCode())

                'End If

            End If

        End Sub




        Public Function GetPropertyName(Of T)(ByVal expression As Expression(Of Func(Of T))) As String
            Dim memberExpression As Expressions.MemberExpression = DirectCast(expression.Body, Expressions.MemberExpression)
            Return memberExpression.Member.Name
        End Function


        Private Sub doFilterBaseePrimaryUse(propertyName As String, propertyValue As Integer)

            If IsNothing(propertyValue) Then
                If columnFilters.ContainsKey(propertyName) Then
                    columnFilters.Remove(propertyName)
                End If
            ElseIf propertyValue = ePrimaryUseSearch.All Then
                If columnFilters.ContainsKey(propertyName) Then
                    columnFilters.Remove(propertyName)
                End If


            Else
                If columnFilters.ContainsKey(propertyName) Then
                    columnFilters(propertyName) = CStr(propertyValue)

                Else
                    columnFilters.Add(propertyName, CStr(propertyValue))
                End If

            End If

            ApplyFilters()
  InternShareds.addressesCollViewRefresh(addressesCollView)

        End Sub


        Private Sub doFilterBaseString(propertyName As String, propertyValue As String)

            If [String].IsNullOrEmpty(propertyValue) Then
                If columnFilters.ContainsKey(propertyName) Then
                    columnFilters.Remove(propertyName)
                End If

            Else
                If columnFilters.ContainsKey(propertyName) Then
                    columnFilters(propertyName) = propertyValue

                Else
                    columnFilters.Add(propertyName, propertyValue)
                End If

            End If

            ApplyFilters()
            InternShareds.addressesCollViewRefresh(addressesCollView)


        End Sub


        Private Sub doFilterBaseBoolThreeState(propertyName As String, propertyValue As Boolean?)
            If IsNothing(propertyValue) Then
                columnFilters.Remove(propertyName)
            Else
                If columnFilters.ContainsKey(propertyName) Then

                    If propertyValue Then
                        columnFilters(propertyName) = "1" ' "True"
                    Else
                        columnFilters(propertyName) = "0" '"False"
                    End If


                Else
                    If propertyValue Then
                        columnFilters.Add(propertyName, "1")         ' "True"
                    Else
                        columnFilters.Add(propertyName, "0")        ' "False"
                    End If

                End If

                'If columnFilters.ContainsKey(propertyName) Then

                '    If propertyValue Then
                '        columnFilters(propertyName) = "True"
                '    Else
                '        columnFilters(propertyName) = "False"
                '    End If


                'Else
                '    If propertyValue Then
                '        columnFilters.Add(propertyName, "True")
                '    Else
                '        columnFilters.Add(propertyName, "False")
                '    End If

                'End If
            End If


            ApplyFilters()
              InternShareds.addressesCollViewRefresh(addressesCollView)

        End Sub




        ' Fine PropertyChanged
        '////////////////////////////////////////////////////////////////////
        '////////////////////////////////////////////////////////////////////
        ' Start            




        Public Sub clearFilterFull()
            columnFilters = New Dictionary(Of String, String)
            ApplyFilters()
            InternShareds.addressesCollViewRefresh(addressesCollView)
             
        End Sub

        Public Sub clearFilterStuff()
            propertyCache = New Dictionary(Of String, PropertyInfo)
            columnFilters = New Dictionary(Of String, String)
            ApplyFilters()
            InternShareds.addressesCollViewRefresh(addressesCollView)

        End Sub



        Public Property columnFilters() As Dictionary(Of String, String) ' KeyValuePair(Of String, String)
            Get
                Return _columnFilters
            End Get
            Set(ByVal value As Dictionary(Of String, String))
                _columnFilters = value
            End Set
        End Property
        Private _columnFilters As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim IsFilteringCaseSensitive As Boolean = False


        Private Sub ApplyFilters()
            'Dim view As ICollectionView = CollectionViewSource.GetDefaultView(MyBase.ItemsSource)
            If (addressesCollView IsNot Nothing) Then
                addressesCollView.Filter = Function(item As Object)
                                               Dim show As Boolean = True
                                               For Each filter As KeyValuePair(Of String, String) In Me.columnFilters
                                                   Dim propertyx As Object = Me.GetPropertyValue(item, filter.Key)
                                                   If (propertyx IsNot Nothing) Then
                                                       Dim containsFilter As Boolean = False
                                                       containsFilter = If(Not Me.IsFilteringCaseSensitive, propertyx.ToString().ToLower(). _
                                                                           Contains(filter.Value.ToString().ToLower()), propertyx.ToString().Contains(filter.Value))
                                                       If (Not containsFilter) Then
                                                           show = False
                                                           Exit For
                                                       End If
                                                   End If
                                               Next
                                               Return show
                                           End Function
            End If
        End Sub




        Public Property propertyCache() As Dictionary(Of String, PropertyInfo) ' KeyValuePair(Of String, String)
            Get
                Return _propertyCache
            End Get
            Set(ByVal value As Dictionary(Of String, PropertyInfo))
                _propertyCache = value
            End Set
        End Property
        Private _propertyCache As Dictionary(Of String, PropertyInfo) = New Dictionary(Of String, PropertyInfo)


        Private Function GetPropertyValue(item As Object, [property] As String) As Object
            ' No value
            Dim value As Object = Nothing
            ' Get property  from cache
            Dim pi As PropertyInfo = Nothing
            If propertyCache.ContainsKey([property]) Then
                pi = propertyCache([property])
            Else
                pi = item.[GetType]().GetProperty([property])
                propertyCache.Add([property], pi)
            End If
            ' If we have a valid property, get the value
            If pi IsNot Nothing Then
                value = pi.GetValue(item, Nothing)
            End If
            ' Done
            Return value
        End Function



    End Class



End Namespace




Copy to clipboard Download 


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Linq.Expressions;
using ContactAddressesSelector.ContactAddressesSelector.Models;
using ContactAddressesSelector.ContactAddressesSelector.Constants;
using ContactAddressesSelector.ContactAddressesSelector.Business;




namespace ContactAddressesSelector.Guis
{
    public partial class ContactAddressesSelectVm : INotifyPropertyChanged
    {
        public AddressesObsoMEdit selectedItemAddressesObsoM
        {
            get
            {
                return _selectedItemAddressesObsoM;
            }
            set
            {
                _selectedItemAddressesObsoM = value;

                RaisePropertyChanged(() => this.selectedItemAddressesObsoM);
            }
        }
        private AddressesObsoMEdit _selectedItemAddressesObsoM = new AddressesObsoMEdit();




        public AddressesColl addressesColl
        {
            get
            {
                return _addressesColl;
            }
            set
            {
                _addressesColl = value;
                RaisePropertyChanged(() => this.addressesColl);
            }
        }
        private AddressesColl _addressesColl = new AddressesColl();


        public ICollectionView addressesCollView
        {
            get
            {
                return _addressesCollView;
            }
            set
            {
                _addressesCollView = value;
                RaisePropertyChanged(() => this.addressesCollView);
            }
        }
        private ICollectionView _addressesCollView;


        public string genderTag
        {
            get
            {
                return _genderTag;
            }
            set
            {
                _genderTag = value;
                RaisePropertyChanged(() => this.genderTag);
            }
        }
        private string _genderTag = "4"; // "Auto"


        public bool isDgGridEnabled
        {
            get
            {
                return _isDgGridEnabled;
            }
            set
            {
                _isDgGridEnabled = value;
                RaisePropertyChanged(() => this.isDgGridEnabled);
            }
        }
        private bool _isDgGridEnabled = false;

        public bool canLoadDbContent
        {
            get
            {
                return _canLoadDbContent;
            }
            set
            {
                _canLoadDbContent = value;
                RaisePropertyChanged(() => this.canLoadDbContent);
            }
        }
        private bool _canLoadDbContent = false;


        public bool iamIn
        {
            get
            {
                return _iamIn;
            }
            set
            {
                _iamIn = value;
                RaisePropertyChanged(() => this.iamIn);
            }
        }
        private bool _iamIn = false;


        // Fine
        // ////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////
        // Start objectEquals

        public static bool objectEquals<T>(T Object1, T object2)
        {
            if (object.Equals(Object1, null) || object.Equals(object2, null))
                return false;
            if (!object.Equals(Object1, object2))
                return false;

            return true;
        }

        // Fine objectEquals
        // ////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////
        // Start PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (!PropertyChangedEvent == null)
                PropertyChanged?.Invoke(this, e);
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyName)
        {
            MemberExpression exp = propertyName.Body as MemberExpression;
            if (exp != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(exp.Member.Name));



                if (exp.Member.Name == GetPropertyName(() => this.selectedItemAddressesObsoM))
                {
                }
                else if (exp.Member.Name == GetPropertyName(() => this.genderTag))
                    var kk = false;
                else if (exp.Member.Name == GetPropertyName(() => this.input_is_active))
                {
                    var kk = false;

                    doFilterBaseBoolThreeState("is_active", this.input_is_active);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_primary_use))
                {
                    var kk = false;

                    doFilterBaseePrimaryUse("primary_use", this.input_primary_use);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_surname))
                {
                    var kk = false;
                    doFilterBaseString("surname", this.input_surname);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_firstname))
                {
                    var kk = false;
                    doFilterBaseString("firstname", this.input_firstname);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_email_1))
                {
                    var kk = false;
                    doFilterBaseString("email_1", this.input_email_1);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_email_2))
                {
                    var kk = false;
                    doFilterBaseString("email_2", this.input_email_2);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_group_name))
                {
                    var kk = false;
                    doFilterBaseString("group_name", this.input_group_name);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_group_email))
                {
                    var kk = false;
                    doFilterBaseString("group_email", this.input_group_email);
                }
                else if (exp.Member.Name == GetPropertyName(() => this.input_sg_number))
                {
                    var kk = false;
                    doFilterBaseString("sg_number", this.input_sg_number);
                }
            }
        }




        public string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            System.Linq.Expressions.MemberExpression memberExpression = (System.Linq.Expressions.MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }


        private void doFilterBaseePrimaryUse(string propertyName, int propertyValue)
        {
            if (Information.IsNothing(propertyValue))
            {
                if (columnFilters.ContainsKey(propertyName))
                    columnFilters.Remove(propertyName);
            }
            else if (propertyValue == ePrimaryUseSearch.All)
            {
                if (columnFilters.ContainsKey(propertyName))
                    columnFilters.Remove(propertyName);
            }
            else if (columnFilters.ContainsKey(propertyName))
                columnFilters[propertyName] = System.Convert.ToString(propertyValue);
            else
                columnFilters.Add(propertyName, System.Convert.ToString(propertyValue));

            ApplyFilters();
            InternShareds.addressesCollViewRefresh(addressesCollView);
        }


        private void doFilterBaseString(string propertyName, string propertyValue)
        {
            if (String.IsNullOrEmpty(propertyValue))
            {
                if (columnFilters.ContainsKey(propertyName))
                    columnFilters.Remove(propertyName);
            }
            else if (columnFilters.ContainsKey(propertyName))
                columnFilters[propertyName] = propertyValue;
            else
                columnFilters.Add(propertyName, propertyValue);

            ApplyFilters();
            InternShareds.addressesCollViewRefresh(addressesCollView);
        }


        private void doFilterBaseBoolThreeState(string propertyName, bool? propertyValue)
        {
            if (Information.IsNothing(propertyValue))
                columnFilters.Remove(propertyName);
            else if (columnFilters.ContainsKey(propertyName))
            {
                if (propertyValue)
                    columnFilters[propertyName] = "1"; // "True"
                else
                    columnFilters[propertyName] = "0";// "False"
            }
            else if (propertyValue)
                columnFilters.Add(propertyName, "1");         // "True"
            else
                columnFilters.Add(propertyName, "0");// "False"


            ApplyFilters();
            InternShareds.addressesCollViewRefresh(addressesCollView);
        }




        // Fine PropertyChanged
        // ////////////////////////////////////////////////////////////////////
        // ////////////////////////////////////////////////////////////////////
        // Start            




        public void clearFilterFull()
        {
            columnFilters = new Dictionary<string, string>();
            ApplyFilters();
            InternShareds.addressesCollViewRefresh(addressesCollView);
        }

        public void clearFilterStuff()
        {
            propertyCache = new Dictionary<string, PropertyInfo>();
            columnFilters = new Dictionary<string, string>();
            ApplyFilters();
            InternShareds.addressesCollViewRefresh(addressesCollView);
        }



        public Dictionary<string, string> columnFilters
        {
            get
            {
                return _columnFilters;
            }
            set
            {
                _columnFilters = value;
            }
        }// KeyValuePair(Of String, String)
        private Dictionary<string, string> _columnFilters = new Dictionary<string, string>();

        private bool IsFilteringCaseSensitive = false;


        private void ApplyFilters()
        {
            // Dim view As ICollectionView = CollectionViewSource.GetDefaultView(MyBase.ItemsSource)
            if ((addressesCollView != null))
            {
                addressesCollView.Filter = object item =>
                {
                    bool show = true;
                    foreach (KeyValuePair<string, string> filter in this.columnFilters)
                    {
                        object propertyx = this.GetPropertyValue(item, filter.Key);
                        if ((propertyx != null))
                        {
                            bool containsFilter = false;
                            containsFilter = !this.IsFilteringCaseSensitive ? propertyx.ToString().ToLower().Contains(filter.Value.ToString().ToLower()) : propertyx.ToString().Contains(filter.Value);
                            if ((!containsFilter))
                            {
                                show = false;
                                break;
                            }
                        }
                    }
                    return show;
                };
            }
        }




        public Dictionary<string, PropertyInfo> propertyCache
        {
            get
            {
                return _propertyCache;
            }
            set
            {
                _propertyCache = value;
            }
        }// KeyValuePair(Of String, String)
        private Dictionary<string, PropertyInfo> _propertyCache = new Dictionary<string, PropertyInfo>();


        private object GetPropertyValue(object item, string property)
        {
            // No value
            object value = null;
            // Get property  from cache
            PropertyInfo pi = null;
            if (propertyCache.ContainsKey(property))
                pi = propertyCache[property];
            else
            {
                pi = item.GetType().GetProperty(property);
                propertyCache.Add(property, pi);
            }
            // If we have a valid property, get the value
            if (pi != null)
                value = pi.GetValue(item, null);
            // Done
            return value;
        }
    }
}








 
