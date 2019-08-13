Option Explicit On
Option Strict On




Namespace ContactAddressesSelector.Guis


    Partial Public Class ContactAddressesSelectVm



        Public Property input_is_active() As Boolean?
            Get
                Return _input_is_active
            End Get
            Set(value As Boolean?)
                _input_is_active = value
                RaisePropertyChanged(Function() Me.input_is_active)
            End Set
        End Property
        Private _input_is_active As Boolean? = True


        Public Property input_surname() As String
            Get
                Return _input_surname
            End Get
            Set(value As String)
                _input_surname = value
                RaisePropertyChanged(Function() Me.input_surname)
            End Set
        End Property
        Private _input_surname As String = String.Empty


        Public Property input_primary_use() As Int32
            Get
                Return _input_primary_use
            End Get
            Set(value As Int32)
                _input_primary_use = value
                RaisePropertyChanged(Function() Me.input_primary_use)
            End Set
        End Property
        Private _input_primary_use As Int32 = 0



        Public Property input_firstname() As String
            Get
                Return _input_firstname
            End Get
            Set(value As String)
                _input_firstname = value
                RaisePropertyChanged(Function() Me.input_firstname)
            End Set
        End Property
        Private _input_firstname As String = String.Empty


        Public Property input_email_1() As String
            Get
                Return _input_email_1
            End Get
            Set(value As String)
                _input_email_1 = value
                RaisePropertyChanged(Function() Me.input_email_1)
            End Set
        End Property
        Private _input_email_1 As String = String.Empty


        Public Property input_email_2() As String
            Get
                Return _input_email_2
            End Get
            Set(value As String)
                _input_email_2 = value
                RaisePropertyChanged(Function() Me.input_email_2)
            End Set
        End Property
        Private _input_email_2 As String = String.Empty


        Public Property input_group_name() As String
            Get
                Return _input_group_name
            End Get
            Set(value As String)
                _input_group_name = value
                RaisePropertyChanged(Function() Me.input_group_name)
            End Set
        End Property
        Private _input_group_name As String = String.Empty


        Public Property input_group_email() As String
            Get
                Return _input_group_email
            End Get
            Set(value As String)
                _input_group_email = value
                RaisePropertyChanged(Function() Me.input_group_email)
            End Set
        End Property
        Private _input_group_email As String = String.Empty

        Public Property input_sg_number() As String
            Get
                Return _input_sg_number
            End Get
            Set(value As String)
                _input_sg_number = value
                RaisePropertyChanged(Function() Me.input_sg_number)
            End Set
        End Property
        Private _input_sg_number As String = String.Empty












    End Class


End Namespace