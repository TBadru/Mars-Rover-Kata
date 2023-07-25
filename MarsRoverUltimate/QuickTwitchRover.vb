' option Explicit on
' option Strict on           - turned off In order To allow late binding 

Imports System
Imports MarsRoverUltimate.MarsRover

#Region "Wrapper"
Namespace MarsRover

    Public Class QuickTwitchRover ' this QuickTwitchRover moves and spins at 2x in comparison to the Rover.
        Private ReadOnly _V1 As Integer
        Private ReadOnly _V2 As Integer
        Private ReadOnly _N As Direction
        Private Property __PositionX As Integer
        Private Property __PositionY As Integer
        Private Property __RoverDirection As Direction
        Private Property plateau As IPlateau

        ' encapsulation - putting all data and functions in a class MarsRover
        ' getters - setters
        Public Property PositionXX As Integer
            Get
                Return __PositionX
            End Get
            Set
                __PositionX = Value
            End Set
        End Property
        Public Property PositionYY As Integer
            Get
                Return __PositionY
            End Get
            Set
                __PositionY = Value
            End Set
        End Property
        Public Property RoverDirection As Direction
            Get
                Return __RoverDirection
            End Get
            Set
                __RoverDirection = Value
            End Set
        End Property
        Public Property __plateau As IPlateau
            Get
                Return plateau
            End Get
            Set
                plateau = Value
            End Set
        End Property
        Public ReadOnly Property V1 As Integer
            Get
                Return _V1
            End Get
        End Property

        Public ReadOnly Property V2 As Integer
            Get
                Return _V2
            End Get
        End Property

        Public ReadOnly Property N As Direction
            Get
                Return _N
            End Get
        End Property

        ' declare enumeration within a class with it's datatype values
        'indicate rover directions 
        ' makes it easy to change the values in the future
        ' modifiers 
        Public Enum Direction
            N = 180
            E = 360
            S = 540
            W = 720
        End Enum

        ' Constructor of the class 

        'Public Sub New(v1 As Integer, v2 As Integer, n As Direction, plateau As IPlateau)
        '    Me.V1 = v1
        '    Me.V2 = v2
        '    Me.N = n
        '    Me.plateau = plateau
        'End Sub

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal direction As Direction, ByVal plateau As IPlateau)
            PositionXX = x
            PositionYY = y
            RoverDirection = direction
            Me.plateau = plateau
        End Sub

        ' Movements of rover based on direction N,E,S,W
        Private Sub Goo()
            If RoverDirection = Direction.N AndAlso plateau.Y > PositionYY Then
                PositionYY += 1
            ElseIf RoverDirection = Direction.E AndAlso plateau.X > PositionXX Then
                PositionXX += 1
            ElseIf RoverDirection = Direction.S AndAlso PositionYY > 0 Then
                PositionYY -= 1
            ElseIf RoverDirection = Direction.W AndAlso PositionXX > 0 Then
                PositionXX -= 1
            End If
        End Sub

        ' Change the direction of the rover
        Private Sub ChangeDirectionTwitch(ByVal directionCode As Char)  ' using char since it's a single character
            ' Rover spins 180 degrees left and right

            If directionCode = "L"c Then
                RoverDirection = If((RoverDirection - 180) < Direction.N, Direction.W, RoverDirection - 180)
            ElseIf directionCode = "R"c Then
                RoverDirection = If((RoverDirection + 180) > Direction.W, Direction.N, RoverDirection + 180)
            End If
        End Sub

        ' Processing the command string for rover movement commands
        Public Sub Commando(ByVal commandStr As String)

            For Each command As Char In commandStr
                If command = "L"c OrElse command = "R"c Then
                    ChangeDirectionTwitch(command)
                ElseIf command = "M"c Then
                    Goo()
                End If
            Next
        End Sub

        ' Get position and direction of the rover at the end of the command
        Public Function GetPositionTwitch() As String
            Dim printedRoverPosition As String = String.Format("{0} {1} {2}", PositionXX, PositionYY, RoverDirection)
            Console.WriteLine(printedRoverPosition)
            Return printedRoverPosition
        End Function
    End Class
End Namespace
#End Region
