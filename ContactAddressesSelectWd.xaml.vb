Option Explicit On
Option Strict On

Imports System.Windows.Data
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Windows
Imports ContactAddressesSelector.ContactAddressesSelector.Models
Imports ContactAddressesSelector.ContactAddressesSelector.Business





Namespace ContactAddressesSelector.Guis


    Public Class ContactAddressesSelectWd
        Implements IDisposable


        Sub New()


            ' Dieser Aufruf ist für den Designer erforderlich.
            InitializeComponent()

            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

            picFemale1 = New BitmapImage(New Uri("../Resources/fem2.png", UriKind.Relative))
            picMale1 = New BitmapImage(New Uri("../Resources/User1.png", UriKind.Relative))
            picAuto = New BitmapImage(New Uri("../Resources/1600.png", UriKind.Relative))
            picUnknown = New BitmapImage(New Uri("../Resources/418px-User-unknown.svg.png", UriKind.Relative))
 

            Me.Topmost = True

        End Sub



        Public Shared picFemale1 As ImageSource
        Public Shared picMale1 As ImageSource
        Public Shared picAuto As ImageSource
        Public Shared picUnknown As ImageSource

        Private Sub dtGrid_ScrollChanged(sender As Object, e As ScrollChangedEventArgs)


            If e.HorizontalChange <> 0 Then
                Dim d As Double = e.HorizontalOffset


                BaseScrollViewer.ScrollToHorizontalOffset(d)


            End If

        End Sub





        Private Sub ContactAddressesSelectWd_ContentRendered(sender As Object, e As EventArgs) 'Handles Me.ContentRendered
            If CType(Me.DataContext, ContactAddressesSelectVm).canLoadDbContent Then

                Dim loadAddressTable As New LoadAddressTable
                Try

                    loadAddressTable.dbAddressesTableLoad_BuCmdMeth(CType(Me.DataContext, ContactAddressesSelectVm), True,
                                                                     ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString, _
                                                                     ContactAddressesSelectShared.contactAddressesSelectSharedInst.schemaName)


                    'CType(Me.DataContext, ContactAddressesSelectVm).dbAddressesTableLoad_BuCmdMeth(True, _
                    '                                                     ContactAddressesSelectShared.contactAddressesSelectSharedInst.connectionString, _
                    '                                                          ContactAddressesSelectShared.contactAddressesSelectSharedInst.schemaName)



                Catch ex As Exception
                    Dim hh = False
                End Try
            Else
                ContactAddressesSelectShared.contactAddressesSelectSharedInst.is_active = False

                Me.Close()


            End If

        End Sub
        Private Sub ContactAddressesSelectWd_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded


            CType(Me.DataContext, ContactAddressesSelectVm).initializeThis()


            If CType(Me.DataContext, ContactAddressesSelectVm).canLoadDbContent Then


            Else


            End If
        End Sub


        Private Sub adrDgv_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

            Try
                If IsNothing(ContactAddressesSelectShared.contactAddressesSelectSharedInst) Then Exit Sub
                If Not ContactAddressesSelectShared.contactAddressesSelectSharedInst.selectionChanging Then Exit Sub


                If IsNothing(CType(Me.DataContext, ContactAddressesSelectVm).addressesCollView) Then Exit Sub
                If IsNothing(CType(Me.DataContext, ContactAddressesSelectVm).addressesCollView.CurrentItem) Then Exit Sub
                adrDgv.ScrollIntoView(CType(Me.DataContext, ContactAddressesSelectVm).addressesCollView.CurrentItem)

            Catch ex As Exception
                Dim jj = False
            End Try


        End Sub





        Private Sub adrDgv_MouseDoubleClick(sender As Object, e As Windows.Input.MouseButtonEventArgs)

            If Not ContactAddressesSelectShared.contactAddressesSelectSharedInst.is_active Then
                ContactAddressesSelectShared.contactAddressesSelectSharedInst.returnValue = Nothing


            ElseIf Not IsNothing(sender) Then
                Dim dgRow As DataGridRow = CType(sender, DataGridRow)
                Dim xx As AddressesObsoMEdit = CType(dgRow.DataContext, AddressesObsoMEdit)

                If Not IsNothing(sender) Then
                    ContactAddressesSelectShared.contactAddressesSelectSharedInst.returnValue = xx
                    ' Me.DialogResult = True

                Else
                    ContactAddressesSelectShared.contactAddressesSelectSharedInst.returnValue = Nothing
                    ' Me.DialogResult = False
                End If


            Else
                ContactAddressesSelectShared.contactAddressesSelectSharedInst.returnValue = Nothing
                '  Me.DialogResult = False


            End If

            Me.Close()

        End Sub

        Private Function FindVisualParent(Of T As UIElement)(element As UIElement) As T
            Dim parent As UIElement = element
            While parent IsNot Nothing
                Dim correctlyTyped As T = TryCast(parent, T)
                If correctlyTyped IsNot Nothing Then
                    Return correctlyTyped
                End If

                parent = TryCast(VisualTreeHelper.GetParent(parent), UIElement)
            End While

            Return Nothing
        End Function


        Public Sub disposeThis()

            Me.Dispose()

        End Sub




        'Private Sub Window_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Me.Dispose()
        'End Sub
        Private disposed As Boolean ' To detect redundant calls

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    'dispose managed state (managed objects).
                    'RemoveHandler Me.Loaded, AddressOf Window_Loaded
                    'RemoveHandler txtTitle.PreviewMouseDown, AddressOf txtTitle_PreviewMouseDown
                    'RemoveHandler pbMin.PreviewMouseUp, AddressOf pbMin_PreviewMouseUp
                    'RemoveHandler pbClose.PreviewMouseUp, AddressOf pbClose_PreviewMouseUp
                    'RemoveHandler txtSend.KeyUp, AddressOf txtSend_KeyUp
                    'RemoveHandler btnSend.Click, AddressOf btnSend_Click
                    'RemoveHandler Me.Closed, AddressOf Window_Closed

                    'BindingOperations.ClearBinding(txtTitle, TextBlock.TextProperty)

                    Me.Icon = Nothing
                    'ibBackground = Nothing
                    ''iDeleteBuddy = Nothing
                    ''btnAddBuddy = Nothing
                    ''iBlockUser = Nothing
                    'pbMin = Nothing
                    'pbClose = Nothing
                    'MainWin = Nothing

                    Me.Resources.Clear()

                    GC.Collect()
                End If
            End If
            Me.disposed = True
        End Sub

        Protected Overrides Sub Finalize()
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(False)
            MyBase.Finalize()
        End Sub


        Private Sub ContactAddressesSelectWd_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Closing

            'If Not IsNothing(ContactAddressesSelectShared.contactAddressesSelectSharedInst) Then
            '    ContactAddressesSelectShared.contactAddressesSelectSharedInst = Nothing
            'End If


        End Sub


    End Class


End Namespace