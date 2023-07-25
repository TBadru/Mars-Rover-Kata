
' option Explicit on
' option Strict on   

Imports System
Imports MarsRoverUltimate.MarsRover

Namespace MarsRover

    Public Class Plateau


        Public Property X As Integer
        Public Property Y As Integer

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            Me.X = x
            Me.Y = y
        End Sub

    End Class
    Public Class Program

        'Public Shared Property plateau1 As NormalPlateau


        Public Shared Sub Main(ByVal args As String())  ' Main method - Sub Main() - passing value types by value


            Dim Plateaunormal As NormalPlateau = New NormalPlateau(x:=5, y:=5)

            Dim Plateaurocky As New RockyPlateau(x:=3, y:=4)                         ' simplified object


            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.DarkYellow
            Console.WriteLine(Environment.UserName)
            Console.WriteLine(Environment.OSVersion)
            Console.WriteLine(Environment.UserDomainName)
            Console.WriteLine(Environment.Version)
            Console.WriteLine(Environment.CommandLine)


            Console.WriteLine("")
            Console.WriteLine("Test input to command the rover:")
            Console.WriteLine("")
            Console.WriteLine("5 5 - Normal Plateau")          ' rovers using plateau dimension of 5 5/ plateau upper right coordinates
            Console.WriteLine("3 4 - Rocky Plateau")

            Console.WriteLine("")

            Console.WriteLine("*  1 2 N - first rover starting point and heading using normal plateau")   ' first rover starting point and heading
            Dim firstRover As New Rover(1, 2, Rover.Direction.N, Plateaunormal)
            Console.WriteLine("*  LMLMLMLMM - first rover movement commands")
            firstRover.Command("LMLMLMLMM")  'first rover movement commands

            Console.WriteLine("")

            Dim secondRover As New Rover(3, 3, Rover.Direction.E, Plateaunormal)
            Console.WriteLine("*  3 3 E - second rover starting point and heading using normal plateau")  ' second rover starting point and heading
            Console.WriteLine("*  MMRMMRMRRM - second rover movement commands")
            secondRover.Command("MMRMMRMRRM") ' second rover movement commands

            Console.WriteLine("")

            Dim thirdRover As New Rover(1, 2, Rover.Direction.N, Plateaurocky)
            Console.WriteLine("*  1 2 N - third rover starting point and heading using rocky plateau")  ' third rover starting point and heading
            Console.WriteLine("*  LMLMLMLMM - third rover movement commands")
            thirdRover.Command("LMLMLMLMM") ' third rover movement commands

            Console.WriteLine("")

            Dim fourthRover As New Rover(3, 3, Rover.Direction.E, Plateaurocky)
            Console.WriteLine("*  3 3 E - fourth rover starting point and heading using rocky plateau")  ' third rover starting point and heading
            Console.WriteLine("*  MMRMMRMRRM - fourth rover movement commands")
            fourthRover.Command("LMLMLMLMM") ' third rover movement commands

            Console.WriteLine("")

            Dim quickesttwitchroveronnormal As New QuickTwitchRover(3, 3, QuickTwitchRover.Direction.E, Plateaunormal)
            Console.WriteLine("*  3 3 E - quick twitch rover starting point and heading using normal plateau")  ' quick twitch rover starting point and heading
            Console.WriteLine("*  MMRMMRMRRMRMM - quick twitch rover movement commands")
            quickesttwitchroveronnormal.Commando("MMRMMRMRRMRMM") ' quick twitch rover movement commands

            Console.WriteLine("")
			
            Dim quickesttwitchroveronrocky As New QuickTwitchRover(3, 3, QuickTwitchRover.Direction.E, Plateaurocky)
            Console.WriteLine("*  3 3 E - quick twitch rover starting point and heading using rocky plateau")  ' quick twitch rover starting point and heading
            Console.WriteLine("*  LMLMLMLMMRMR - quick twitch rover movement commands")
            quickesttwitchroveronrocky.Commando("LMLMLMLMMRMR") ' quick twitch rover movement commands


            Console.WriteLine(Environment.NewLine)
            Console.WriteLine("Test output after implementing the commands on the plateau:")
            Console.WriteLine("")
            firstRover.GetPosition()     'Using function GetPosition statement on Rover class to display result/output
            Console.WriteLine("")
            secondRover.GetPosition()
            Console.WriteLine("")
            thirdRover.GetPosition()
            Console.WriteLine("")
            fourthRover.GetPosition()
            Console.WriteLine("")
            quickesttwitchroveronnormal.GetPositionTwitch()
            Console.WriteLine("")
            quickesttwitchroveronrocky.GetPositionTwitch()

            Console.Readkey()            ' returns a string
        End Sub

        'Public Sub ValidateRoverMovement(ByVal errormessage As String)
        '    Try
        '      [ tryStatements ]
        '      [ Exit Try ]
        '[ Catch [ exception [ As type ] ] [ When expression ]
        '      [ catchStatements ]
        '      [ Exit Try ] ]
        '[ Catch ... ]
        '[ Finally
        '      [ finallyStatements ] ]
        'End Try
        'End Sub

    End Class
End Namespace