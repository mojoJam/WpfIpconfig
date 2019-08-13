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