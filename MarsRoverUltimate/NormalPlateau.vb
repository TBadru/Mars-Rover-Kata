' option Explicit on
' option Strict on   

Imports System
Imports MarsRoverUltimate.MarsRover


#Region "Wrapper"
Namespace MarsRover
    Public Class NormalPlateau

        Implements IPlateau ' implementing interface declared for the Rover class

        ' declaring x and y coordinates as property with the "public" access modifier to make code accessible to all classes

        Private Property X As Integer Implements IPlateau.X
        Private Property Y As Integer Implements IPlateau.Y
        Private Property Gradient As Integer

        Property PositionX As Integer
            Get
                Return X
            End Get
            Set
                X = Value
            End Set
        End Property

        Property PositionY As Integer
            Get
                Return Y
            End Get
            Set
                Y = Value
            End Set
        End Property

        Property Ggradient As Integer
            Get
                Return Gradient
            End Get
            Set
                Gradient = Value
            End Set
        End Property


        ' Width and height of the Plateau/grid
        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.X = x
            Me.Y = y
        End Sub
    End Class

End Namespace
#End Region