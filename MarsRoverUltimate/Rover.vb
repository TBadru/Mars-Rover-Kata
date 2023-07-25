' option explicit on
' option strict on

Imports System
Imports MarsRoverUltimate.MarsRover


Namespace MarsRover
    Public Class Rover
        Public Property PositionX As Integer
        Public Property PositionY As Integer
        Private Property RoboticRoverDirection As Direction
        Private Property Plateau As IPlateau

        ' declare enumeration within a class with it's datatype values
        'indicate rover directions 
        '  makes it easy to change the values in the future
        ' modifiers 
        Public Enum Direction
            N = 90
            E = 180
            S = 270
            W = 360
        End Enum

        ' Constructor of the class 
        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal direction As Direction, ByVal plateau As IPlateau)
            PositionX = x
            PositionY = y
            RoboticRoverDirection = direction
            Me.Plateau = plateau
        End Sub

        ' Movements of rover based on direction N,E,S,W
        Private Sub Go()
            If RoboticRoverDirection = Direction.N AndAlso Plateau.Y > PositionY Then
                PositionY += 1
            ElseIf RoboticRoverDirection = Direction.E AndAlso Plateau.X > PositionX Then
                PositionX += 1
            ElseIf RoboticRoverDirection = Direction.S AndAlso PositionY > 0 Then
                PositionY -= 1
            ElseIf RoboticRoverDirection = Direction.W AndAlso PositionX > 0 Then
                PositionX -= 1
            End If
        End Sub

        ' Change the direction of the rover
        Private Sub ChangeDirection(ByVal directionCode As Char)
            If directionCode = "L"c Then
                RoboticRoverDirection = If((RoboticRoverDirection - 90) < Direction.N, Direction.W, RoboticRoverDirection - 90)
            ElseIf directionCode = "R"c Then
                RoboticRoverDirection = If((RoboticRoverDirection + 90) > Direction.W, Direction.N, RoboticRoverDirection + 90)
            End If
        End Sub

        ' Processing the command string for rover movement commands
        Public Sub Command(ByVal commandStr As String)
            For Each command As Char In commandStr
                If command = "L"c OrElse command = "R"c Then
                    ChangeDirection(command)
                ElseIf command = "M"c Then
                    Go()
                End If
            Next
        End Sub

        ' Get position and direction of the rover at the end of the command
        Public Function GetPosition() As String
            Dim printedRoverPosition As String = String.Format("{0} {1} {2}", PositionX, PositionY, RoboticRoverDirection)
            Console.WriteLine(printedRoverPosition)
            Return printedRoverPosition
        End Function
    End Class
End Namespace

