Option Explicit On
Option Strict On


Imports ContactAddressesSelector.ContactAddressesSelector.Business
Imports ContactAddressesSelector.ContactAddressesSelector.Models
Imports WPFMessageBoxMulti.Business
Imports System.Windows
Imports MySql.Data.MySqlClient
Imports System.Windows.Data




Namespace ContactAddressesSelector.Guis


    Partial Public Class ContactAddressesSelectVm

        Private _addressesCollLock As Object = New Object()


        Sub New()

            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(addressesColl, _addressesCollLock)
            addressesCollView = CollectionViewSource.GetDefaultView(addressesColl)


        End Sub

        Public Sub initializeThis()

            canLoadDbContent = True

            If Not IsNothing(ContactAddressesSelectShared.contactAddressesSelectSharedInst) Then

                If Not IsNothing(ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString) Then
                    If ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString.Length > 0 Then
                        canLoadDbContent = True

                    End If

                End If
            End If

            Dim fastConnectionCheck As FastConnectionCheck = Nothing
            If canLoadDbContent Then
                fastConnectionCheck = DBConnectionStatus(ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString)

                If fastConnectionCheck.isConnected Then


                    'dbFkdtar_meta_email_extensionTableLoad_BuCmdMeth()

                Else
                    canLoadDbContent = False
                    MessageBoxManager.getShowMessageBoxWithReturn("Error", "Db Connection Failed", _
                                                          MessageBoxOptions.DefaultDesktopOnly, _
                                                           "")
                End If

            End If






        End Sub

        Public Sub loadWtxInfoOneTime()

            Dim loadAddressTable As New LoadAddressTable
            Try



                loadAddressTable.dbAddressesTableLoad_BuCmdMeth(Me, False, _
                                                 ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString, _
                                                ContactAddressesSelectShared.contactAddressesSelectSharedInst.schemaName)

            Catch ex As Exception
                Dim kjjk = False
            End Try

            'MsgBox(wdk_idX)      wdk_idX As String
            'If IsNothing(wdk_idX) Then Exit Sub
            'If wdk_idX = "" OrElse wdk_idX = "0" Then
            '    'thorwAnError()
            '    Exit Sub
            'End If


            'dbAddressesTableLoad_BuCmdMeth(False)




        End Sub


        Private Function DBConnectionStatus(ByRef TheConnectionString As String) As FastConnectionCheck
            Dim fastConnectionCheck As New FastConnectionCheck
            fastConnectionCheck.isConnected = False
            Try
                Using sqlConn As New MySqlConnection(TheConnectionString)
                    sqlConn.Open()
                    ' Return (sqlConn.State = ConnectionState.Open)
                    fastConnectionCheck.isConnected = True
                End Using
                Return fastConnectionCheck
            Catch e1 As MySqlException
                fastConnectionCheck.isConnected = False
                fastConnectionCheck.exception = e1
            Catch e2 As Exception
                fastConnectionCheck.isConnected = False
                fastConnectionCheck.exception = e2
            End Try
            Return fastConnectionCheck
        End Function

    End Class


End Namespace