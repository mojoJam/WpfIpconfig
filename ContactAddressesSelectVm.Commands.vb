Option Strict On
Option Explicit On

Imports System.Windows.Input
Imports LibVbBlCntlsWpf.LibVbBlCntlsWpf.Business.Commands
Imports System.Windows
Imports WPFMessageBoxMulti.Business
Imports ContactAddressesSelector.ContactAddressesSelector.Business




Namespace ContactAddressesSelector.Guis

    'ContactAddressesSelectVm.Commands


    Partial Public Class ContactAddressesSelectVm

        Public _some_BuCmd As ICommand = _
      New ActionCommand(New Action(Of Object)(Sub(p)
                                                  Dim dd = some_BuCmdMeth(p)
                                              End Sub))

        Public ReadOnly Property some_BuCmd() As ICommand
            Get
                Return _some_BuCmd
            End Get
        End Property






        Public Async Function some_BuCmdMeth(obj As Object) As Task(Of Integer)

            Await Task.Delay(10)
            If iamIn Then Return 1
            iamIn = True

            Dim theButName As String = String.Empty
            Try

                System.Windows.Application.Current.Dispatcher.Invoke( _
                                  System.Windows.Threading.DispatcherPriority.Send, _
                                  DirectCast(Sub()

                                                 theButName = CStr(obj)
                                             End Sub, System.Threading.ThreadStart))


                Dim t2 As Integer = 0
                Dim load_id As Integer = 0
                If Not IsNothing(selectedItemAddressesObsoM) Then
                    load_id = selectedItemAddressesObsoM.id_adr
                End If
                'WTXK_EditalsoLoad_BU   wtxDbTableFullLoad_Bu
                If theButName = "dbRefresh_Bu" Then


                    Dim loadAddressTable As New LoadAddressTable


                    t2 = Await Task.Run(Function() loadAddressTable.dbAddressesTableLoad_BuCmdMeth(Me, True,
                                                                       ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString, _
                                                                       ContactAddressesSelectShared.contactAddressesSelectSharedInst.schemaName))

 




                End If

            Catch ex As Exception


                Dim exMess = ex.Message.ToString()

                MessageBoxManager.getShowMessageBoxWithReturn("Error", exMess, _
                                                     MessageBoxOptions.DefaultDesktopOnly, _
                                                      "")
                iamIn = False
                Return 20

            End Try

            iamIn = False

            Return 100
        End Function



    End Class



End Namespace


