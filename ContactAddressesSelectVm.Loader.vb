Option Explicit On
Option Strict On

Imports WPFMessageBoxMulti.Business
Imports System.Windows
Imports MySql.Data.MySqlClient
Imports ContactAddressesSelector.ContactAddressesSelector.Models
Imports System.Text
Imports ContactAddressesSelector.ContactAddressesSelector.Business
Imports ClibBase.AddressesCommons.Constants
Imports ClibBase.DataBases.DbMetaDataCommons


Namespace ContactAddressesSelector.Guis


    Partial Public Class ContactAddressesSelectVm


        'Public Function dbAddressesTableLoad_BuCmdMeth(isBoundToView As Boolean, _
        '                                               connectionString As String, schemaName As String, _
        '                                               Optional goToDbId As Integer = -1) As Integer



        '    ContactAddressesSelectShared.contactAddressesSelectSharedInst.selectionChanging = True

        '    isDgGridEnabled = False


        '    Try

        '        addressesColl.Clear()
        '        addressesCollViewRefresh()

        '    Catch ex As Exception
        '        Dim ola As Boolean = False
        '    End Try



        '    Try

        '        Dim queryString As New StringBuilder


        '        queryString.Append(String.Format("SELECT {0}, {1}, {2}, ", eAddresses.id_adr, eAddresses.is_active, eAddresses.primary_use))
        '        queryString.Append(String.Format("b1.firstnames_varchar_0090 {0}, b2.surnames_varchar_0090 {1}, ", eAddresses.firstname, eAddresses.surname))
        '        queryString.Append(String.Format("{0}, {1}, ", eAddresses.email_1, eAddresses.email_2))
        '        queryString.Append(String.Format("b3.scarceids_varchar_0045 {0}, {1}, ", eAddresses.sg_number, eAddresses.group_email))
        '        queryString.Append(String.Format("b4.text_varchar_0090 {0}, {1}, {2}, ", eAddresses.group_name, eAddresses.pcname_1, eAddresses.pcname_2))
        '        queryString.Append(String.Format("{0}, b5.titel_varchar_0045 {1} ", eAddresses.gender, eAddresses.titel))
        '        queryString.Append(String.Format("FROM {0}.{1} aadr ", schemaName, eDbTableNames.addresses))
        '        queryString.Append(String.Format("LEFT JOIN {0}.fkdtar_meta_firstnames_varchar_0090 b1 ON (b1.id_fin=aadr.{1}) ", schemaName, eAddresses.firstname))
        '        queryString.Append(String.Format("LEFT JOIN {0}.fkdtar_meta_surnames_varchar_0090 b2 ON (b2.id_sn=aadr.{1}) ", schemaName, eAddresses.surname))
        '        queryString.Append(String.Format("LEFT JOIN {0}.fkdtar_meta_scarceids_varchar_0045 b3 ON (b3.id_sci=aadr.{1}) ", schemaName, eAddresses.sg_number))
        '        queryString.Append(String.Format("LEFT JOIN {0}.fkdtar_meta_text_varchar_0090 b4 ON (b4.id_t0090=aadr.{1}) ", schemaName, eAddresses.group_name))
        '        queryString.Append(String.Format("LEFT JOIN {0}.fkdtar_meta_titel_varchar_0045 b5 ON (b5.id_ti=aadr.{1}); ", schemaName, eAddresses.titel))


        '        Dim enums = EnumUtilzStatic.GetEnumValues(Of eAddresses)()

        '        Using cn As New MySqlConnection(connectionString)
        '            Using cmd As New MySqlCommand(queryString.ToString(), cn)

        '                cn.Open()
        '                Using reader As MySqlDataReader = cmd.ExecuteReader()


        '                    While (reader.Read)
        '                        Dim custUserTableGtMTmp As New AddressesObsoMEdit

        '                        For Each xx In enums

        '                            If xx = eAddresses.id_adr Then
        '                                CallByName(custUserTableGtMTmp, xx.ToString(), _
        '                                                      CallType.Set, makeObjectToInt32(reader(xx.ToString())))


        '                            ElseIf xx = eAddresses.is_active Then

        '                                CallByName(custUserTableGtMTmp, xx.ToString(), _
        '                                                      CallType.Set, makeObjectToBoolean(reader(xx.ToString())))


        '                            Else

        '                                CallByName(custUserTableGtMTmp, xx.ToString(), _
        '                                                      CallType.Set, makeObjectToString(reader(xx.ToString())))



        '                            End If

        '                        Next

        '                        addressesColl.Add(custUserTableGtMTmp)


        '                    End While

        '                End Using

        '            End Using




        '        End Using



        '        '================================================

        '        'loadDbInitRacfsRefToolFull(AppDbConfig.appDbConfigInst.equipmentx.abccl(0))


        '        '================================================




        '        If addressesColl.Count > 0 Then

        '            If isBoundToView Then


        '                If goToDbId = -1 Then
        '                    addressesCollView.MoveCurrentToFirst()

        '                Else

        '                    goToPotentialId(goToDbId, True)

        '                End If

        '            End If
        '            isDgGridEnabled = True

        '        Else

        '        End If
        '        addressesCollViewRefresh()

        '    Catch ex As Exception
        '        Dim exMess As String = String.Empty
        '        Select Case True
        '            Case InStr(ex.Message.ToString(), "Unable to connect to any of the specified ") > 0
        '                exMess = "Keine Verbindung zu dem Server möglich"

        '            Case ex.Message.ToString() = "Unable to connect to any of the specified MySQL hosts."
        '                exMess = "Keine Verbindung zu dem Server möglich"

        '            Case InStr(ex.Message.ToString(), "You have an error in your SQL syntax;") > 0
        '                exMess = ex.Message.ToString()

        '            Case Else

        '                exMess = ex.Message.ToString()
        '                exMess = "Dam " & exMess
        '        End Select

        '        MessageBoxManager.getShowMessageBoxWithReturn("Error", exMess, _
        '                                             MessageBoxOptions.DefaultDesktopOnly, _
        '                                              "")







        '    End Try

        '    ContactAddressesSelectShared.contactAddressesSelectSharedInst.selectionChanging = False

        '    Return 100

        'End Function

        'Private Function makeObjectToString(valToConv As Object) As String
        '    If IsDBNull(valToConv) Then
        '        Return String.Empty
        '    End If
        '    Return Convert.ToString(valToConv)


        'End Function

        'Private Function makeObjectToBoolean(valToConv As Object) As Boolean
        '    If IsDBNull(valToConv) Then
        '        Return False
        '    End If
        '    If IsNumeric(valToConv) Then
        '        If Convert.ToInt32(valToConv) = 0 Then
        '            Return False
        '        ElseIf Convert.ToInt32(valToConv) = 1 Then

        '            Return True
        '        End If
        '    End If

        '    Return False


        'End Function

        'Private Function makeObjectToInt32(valToConv As Object) As Int32
        '    If IsDBNull(valToConv) Then
        '        Throw New Exception("Error Int32 is DBNull")
        '    End If
        '    Return Convert.ToInt32(valToConv)


        'End Function



        'Private Sub goToPotentialId(goToDbId As Integer, is_changeActiv As Boolean)

        '    Dim tmpId As Integer = goToDbId


        '    'For Each xx In addressesCollView
        '    '    If xx Then
        '    'Next
        '    Do
        '        If tmpId < 1 Then
        '            Exit Do
        '        End If
        '        selectedItemAddressesObsoM = addressesColl.Where(Function(t) t.id_adr = tmpId).FirstOrDefault()
        '        If IsNothing(selectedItemAddressesObsoM) Then
        '            tmpId -= 1
        '        Else
        '            Exit Do
        '        End If

        '    Loop Until True
        '    If tmpId < 1 Then
        '        Exit Sub
        '    End If


        '    selectedItemAddressesObsoM = Nothing


        '    System.Windows.Application.Current.Dispatcher.Invoke( _
        '        System.Windows.Threading.DispatcherPriority.Send, _
        '        DirectCast(Sub()

        '                       addressesCollView.MoveCurrentToFirst()

        '                       If IsNothing(selectedItemAddressesObsoM) Then

        '                       Else

        '                           If Not CType(addressesCollView.CurrentItem, AddressesObsoMEdit).id_adr = tmpId Then
        '                               While addressesCollView.MoveCurrentToNext()
        '                                   If addressesCollView.IsCurrentAfterLast Then
        '                                       addressesCollView.MoveCurrentToFirst()
        '                                       If is_changeActiv Then
        '                                           ContactAddressesSelectShared.contactAddressesSelectSharedInst.selectionChanging = False

        '                                       End If
        '                                       selectedItemAddressesObsoM = CType(addressesCollView.CurrentItem, AddressesObsoMEdit)
        '                                       Exit While

        '                                   ElseIf CType(addressesCollView.CurrentItem, AddressesObsoMEdit).id_adr = tmpId Then
        '                                       If is_changeActiv Then
        '                                           ContactAddressesSelectShared.contactAddressesSelectSharedInst.selectionChanging = False

        '                                       End If
        '                                       selectedItemAddressesObsoM = CType(addressesCollView.CurrentItem, AddressesObsoMEdit)
        '                                       Exit While

        '                                   End If
        '                               End While
        '                           End If

        '                       End If
        '                   End Sub, System.Threading.ThreadStart))
        'End Sub



        'Private Sub addressesCollViewRefresh()

        '    System.Windows.Application.Current.Dispatcher.Invoke( _
        'System.Windows.Threading.DispatcherPriority.Send, _
        'DirectCast(Sub()

        '               addressesCollView.Refresh()

        '           End Sub, System.Threading.ThreadStart))

        'End Sub





    End Class


End Namespace