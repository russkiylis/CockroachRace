Module Module1
    Dim Cockroach_Names() As String = {"Мякоть", "Малый", "Дио", "Камень", "Прыгун", "Добрый", "Смелый", "Славный", "Глазик", "Вася"}
    Dim YourMoney As Integer = 10000
    Dim BetUpgradeCost As Integer = 20000
    Dim SpeedUpgradeCost As Integer = 15000
    Dim SpeedMultiplier, FailChanceMultiplier, BetMultiplier, DifficultyMultiplier As Single
    Dim IsCockroachYours As Boolean


    'выставляет правильный размер консоли, чтобы не вылетало
    Sub RightConsoleSize()
        Console.WindowHeight = 30
        Console.WindowWidth = 120

    End Sub

    'главное меню
    Sub Menu()
        Console.CursorVisible = True
        RightConsoleSize()
        Dim MenuChoice As String
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Green
        MenuName(7, 2)

        Console.ForegroundColor = ConsoleColor.DarkYellow
        For i = 0 To Console.WindowHeight - 1
            Console.SetCursorPosition(5, i)
            Console.Write("||")
            Console.SetCursorPosition(113, i)
            Console.Write("||")
        Next

        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.SetCursorPosition(90, 28)
        Console.Write("Made by M.Koshcheev")
        Console.SetCursorPosition(100, 29)
        Console.Write("v1.2 2020")

        Console.ForegroundColor = ConsoleColor.Magenta
        Console.SetCursorPosition(48, 10) : Console.Write("1  НАЧАТЬ ГОНКУ  1")

        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.SetCursorPosition(48, 12) : Console.Write("2  ПРАВИЛА ИГРЫ  2")

        Console.SetCursorPosition(48, 14) : Console.Write("3 НАСТРОЙКИ ИГРЫ 3")

        Console.SetCursorPosition(48, 16) : Console.Write("4 УЛУЧШЕН. ГОНОК 4")

        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(48, 18) : Console.Write("5 ВЫХОД ИЗ ГОНКИ 5")

        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.SetCursorPosition(48, 22) : Console.Write("#   ТВОЙ ВЫБОР   #")

        Do While True

            Console.SetCursorPosition(56, 23) : Console.Write("                       ")
            Console.SetCursorPosition(56, 23) : Console.Write("-") : MenuChoice = Console.ReadLine

            Select Case MenuChoice
                Case = 1
                    Race()
                Case = 2
                    Rules()
                Case = 3
                    Settings()
                Case = 4
                    Upgrades()
                Case = 5
                    End

            End Select
        Loop

    End Sub

    'Демонстрирует пользователю правила игры
    Sub Rules()
        RightConsoleSize()
        Console.Clear()
        MenuName(7, 2)

        Console.ForegroundColor = ConsoleColor.DarkYellow



        Console.SetCursorPosition(19, 10)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("Cockroach Race - небольшая игра про тараканов, соревнующихся между собой." & vbCrLf _
                        & Space(18) & " У тебя есть 10000$ (Зимбабвийских). Деньги можно поставить на любого таракана." & vbCrLf _
                        & Space(18) & " За 1-3 место ты получаешь свою ставку*множитель ставки. Множитель можно улучшать." & vbCrLf _
                        & Space(18) & " За 4-7 место тебе возвращается ставка. За 7-10  место ставка сгорает. За полученные" & vbCrLf _
                        & Space(18) & " деньги можно улучшить множитель ставки, скорости таракана." & vbCrLf _
                        & vbCrLf _
                        & Space(19) & "Забег тараканов делится на промежутки в 0,3 секунды. За каждый промежуток таракан или" & vbCrLf _
                        & Space(18) & " преодолевает от 1 до 2*множитель скорости пунктов пути, или застревает - становится *" & vbCrLf _
                        & Space(18) & " с определённой вероятностью. ")

        Console.ForegroundColor = ConsoleColor.DarkYellow
        For i = 0 To Console.WindowHeight - 1
            Console.SetCursorPosition(5, i)
            Console.Write("||")
            Console.SetCursorPosition(113, i)
            Console.Write("||")
        Next

        Console.SetCursorPosition(19, 20)
        Console.Write("Нажмите любую клавишу для продолжения...")

        Console.ReadKey()
        Menu()
    End Sub

    'Открывает меню с настройками
    Sub Settings()
        RightConsoleSize()
        Dim MenuChoice, temp, password As String
        Dim temp1 As Integer
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Green
        MenuName(7, 2)
        Console.ForegroundColor = ConsoleColor.DarkYellow
        For i = 0 To Console.WindowHeight - 1
            Console.SetCursorPosition(5, i)
            Console.Write("||")
            Console.SetCursorPosition(113, i)
            Console.Write("||")
        Next

        Console.SetCursorPosition(15, 10)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write("1 - Шанс тараканов застрять на ход (текущ. - " & FailChanceMultiplier & ". От 0 до 1) = ")

        Console.SetCursorPosition(15, 12)
        Console.Write("2 - Сложность, т.е. множитель скорости для тараканов-соперников (текущ. - " & DifficultyMultiplier & ". От 0) = ")

        Console.SetCursorPosition(15, 14)
        Console.Write("3 - Ввести пароль разработчика для изменения всех переменных (деньги, скорость и т.д.) = ")

        Console.SetCursorPosition(15, 16)
        Console.Write("4 - Выход в меню ")


        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.SetCursorPosition(15, 18) : Console.Write("Твой выбор - ")
        MenuChoice = Console.ReadLine

        Console.ForegroundColor = ConsoleColor.Yellow
        Select Case MenuChoice
            Case = 1
                Do
                    Console.SetCursorPosition(78, 10) : Console.Write("                        ")
                    Console.SetCursorPosition(78, 10)
                    temp = Console.ReadLine
                    If IsNumeric(temp) = True Then
                        If temp >= 0 And temp <= 1 Then
                            FailChanceMultiplier = temp
                            temp1 = 1
                        End If

                    End If
                Loop Until temp1 = 1
                Settings()
            Case = 2
                Do
                    Console.SetCursorPosition(100, 12) : Console.Write("             ")
                    Console.SetCursorPosition(100, 12)
                    temp = Console.ReadLine
                    If IsNumeric(temp) = True Then
                        If temp >= 0 Then
                            DifficultyMultiplier = temp
                            temp1 = 1
                        End If

                    End If
                Loop Until temp1 = 1
                Settings()
            Case = 3
                Console.SetCursorPosition(104, 14) : Console.Write("     ")
                Console.SetCursorPosition(104, 14)
                password = Console.ReadLine
                If password = "Dzyaben" Then DeveloperSettings()
                Settings()
            Case = 4
                Menu()
            Case Else
                Settings()
        End Select
        Console.ReadKey()
    End Sub

    'Открывает меню с улучшениями
    Sub Upgrades()
        RightConsoleSize()
        Dim MenuChoice As String

        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Green
        MenuName(7, 2)
        Console.ForegroundColor = ConsoleColor.DarkYellow
        For i = 0 To Console.WindowHeight - 1
            Console.SetCursorPosition(5, i)
            Console.Write("||")
            Console.SetCursorPosition(113, i)
            Console.Write("||")
        Next

        Console.SetCursorPosition(15, 10)
        If YourMoney < SpeedUpgradeCost Then
            Console.ForegroundColor = ConsoleColor.Red
        Else
            Console.ForegroundColor = ConsoleColor.Green
        End If
        Console.WriteLine("1 - Улучшить множитель скорости на 0,1 (текущ. - " & SpeedMultiplier & ") - " & SpeedUpgradeCost)

        Console.SetCursorPosition(15, 12)
        If YourMoney < BetUpgradeCost Then
            Console.ForegroundColor = ConsoleColor.Red
        Else
            Console.ForegroundColor = ConsoleColor.Green
        End If
        Console.WriteLine("2 - Улучшить множитель ставки на 1 (текущ. - " & BetMultiplier & ") - " & BetUpgradeCost)

        Console.ForegroundColor = ConsoleColor.Gray
        Console.SetCursorPosition(15, 16)
        Console.WriteLine("3 - Вернуться в меню")

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.SetCursorPosition(15, 18)
        Console.WriteLine("Твой выбор - ")

        Console.SetCursorPosition(15, 25)
        Console.WriteLine("Твои деньги - " & YourMoney)

        Do While True
            Console.SetCursorPosition(28, 18)
            MenuChoice = Console.ReadLine
            If IsNumeric(MenuChoice) = True Then
                Select Case MenuChoice
                    Case = 1
                        If YourMoney < SpeedUpgradeCost Then
                            Console.SetCursorPosition(15, 20)
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.WriteLine("Недостаточно денег!")
                            pause(2)
                            Upgrades()
                        End If
                        SpeedMultiplier += 0.1
                        YourMoney -= SpeedUpgradeCost
                        SpeedUpgradeCost += 5000
                        Console.SetCursorPosition(15, 20)
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine("Успешная покупка!")
                        pause(2)
                        Upgrades()
                    Case = 2
                        If YourMoney < BetUpgradeCost Then
                            Console.SetCursorPosition(15, 20)
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.WriteLine("Недостаточно денег!")
                            pause(2)
                            Upgrades()
                        End If
                        BetMultiplier += 1
                        YourMoney -= BetUpgradeCost
                        BetUpgradeCost += 10000
                        Console.SetCursorPosition(15, 20)
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine("Успешная покупка!")
                        pause(2)
                        Upgrades()
                    Case = 3
                        Menu()
                End Select

            End If
            Upgrades()
        Loop
    End Sub

    'Открывает "секретное" меню для дяди девелопера(пароль Dzyaben)
    Sub DeveloperSettings()
        RightConsoleSize()
        Dim command As String
        Dim SplittedCommand() As String
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Gray
        Do While True
            command = Console.ReadLine
            SplittedCommand = Split(command)
            Select Case SplittedCommand(0)
                Case = "yourmoney"
                    YourMoney = SplittedCommand(1)
                    Console.WriteLine("YourMoney is now " & YourMoney)

                Case = "speedmultiplier"
                    SpeedMultiplier = SplittedCommand(1)
                    Console.WriteLine("SpeedMultiplier is now " & SpeedMultiplier)

                Case = "failchancemultiplier"
                    FailChanceMultiplier = SplittedCommand(1)
                    Console.WriteLine("FailChanceMultiplier is now " & FailChanceMultiplier)

                Case = "betmultiplier"
                    BetMultiplier = SplittedCommand(1)
                    Console.WriteLine("BetMultiplier is now " & BetMultiplier)

                Case = "difficultymultiplier"
                    DifficultyMultiplier = SplittedCommand(1)
                    Console.WriteLine("DifficultyMultiplier is now " & DifficultyMultiplier)

                Case = "back"
                    Exit Sub
            End Select

        Loop
    End Sub

    'Выводит огромный КОКРОАЧ РЕЙС на экран
    Sub MenuName(xpos As Integer, ypos As Integer)
        Dim temp As Integer
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░█████╗░░█████╗░░█████╗░██╗░░██╗██████╗░░█████╗░░█████╗░░█████╗░██╗░░██╗  ██████╗░░█████╗░░█████╗░███████╗")
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░██║  ██╔══██╗██╔══██╗██╔══██╗██╔════")
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██║░░╚═╝██║░░██║██║░░╚═╝█████═╝░██████╔╝██║░░██║███████║██║░░╚═╝███████║  ██████╔╝███████║██║░░╚═╝█████╗░")
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██║░░██╗██║░░██║██║░░██╗██╔═██╗░██╔══██╗██║░░██║██╔══██║██║░░██╗██╔══██║  ██╔══██╗██╔══██║██║░░██╗██╔══╝░░")
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("╚█████╔╝╚█████╔╝╚█████╔╝██║░╚██╗██║░░██║╚█████╔╝██║░░██║╚█████╔╝██║░░██║  ██║░░██║██║░░██║╚█████╔╝███████╗")
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░╚════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝  ╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚══════╝")
    End Sub

    'Выводит огромный КОКРОАЧ РЕЙС на экран, но с анимацией
    Sub MenuNameAnim(xpos As Integer, ypos As Integer)
        Dim temp As Integer
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░█████╗░░█████╗░░█████╗░██╗░░██╗██████╗░░█████╗░░█████╗░░█████╗░██╗░░██╗  ██████╗░░█████╗░░█████╗░███████╗") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░██║  ██╔══██╗██╔══██╗██╔══██╗██╔════") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██║░░╚═╝██║░░██║██║░░╚═╝█████═╝░██████╔╝██║░░██║███████║██║░░╚═╝███████║  ██████╔╝███████║██║░░╚═╝█████╗░") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("██║░░██╗██║░░██║██║░░██╗██╔═██╗░██╔══██╗██║░░██║██╔══██║██║░░██╗██╔══██║  ██╔══██╗██╔══██║██║░░██╗██╔══╝░░") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("╚█████╔╝╚█████╔╝╚█████╔╝██║░╚██╗██║░░██║╚█████╔╝██║░░██║╚█████╔╝██║░░██║  ██║░░██║██║░░██║╚█████╔╝███████╗") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░╚════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝  ╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚══════╝") : pause(0.5)
    End Sub

    'Выводит огромный ВЕЛКОУМ ТУ на экран, с анимацией
    Sub WelcomeTo(xpos As Integer, ypos As Integer)
        Dim temp As Integer
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝") : pause(0.5)
        Console.SetCursorPosition(xpos, ypos + temp) : temp += 1 : Console.WriteLine("░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░") : pause(0.5)
    End Sub

    'заставка и начальные значения множителей
    Sub Main()
        RightConsoleSize()
        Console.CursorVisible = False
        SpeedMultiplier = 1
        FailChanceMultiplier = 0.3
        BetMultiplier = 2
        DifficultyMultiplier = 1

        pause(1)
        For i = 0 To 15
            Console.Clear()
            Console.SetCursorPosition(i, 20)
            Console.Write("#")
            pause(0.2)
        Next
        pause(1)
        Console.SetCursorPosition(16, 19)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Пора узнать, кто из нас быстрее!")
        Console.ForegroundColor = ConsoleColor.Green

        pause(3)
        Console.Clear()
        WelcomeTo(17, 2)
        pause(2)

        Console.Clear()
        MenuNameAnim(7, 2)

        Menu()
    End Sub

    'Суб Race инициирует гонку из меню
    Sub Race()
        RightConsoleSize()
        Console.Clear()
        Dim YourCockroach_Name As String
        Dim yourCockroach_Name_Number As String
        Dim YourCockroach_Bet As String
        Dim CheckTemp As Integer
        Dim RaceMenu As String

        RacePreview("null") 'показ гоночного стола с тараканами и их именами, но до старта

        Console.SetCursorPosition(17, 22)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.BackgroundColor = ConsoleColor.Black

        Console.Write("Ваш таракан: " & Space(15) & "Ваша ставка: " & Space(7) & "$" & Space(15) & "Деньги: " & YourMoney & Space(3) & "$") 'Надписи под гоночным столом


        Do
            'Получение имени таракана, на которого ставим
            Console.SetCursorPosition(30, 22)
            Console.Write("             ")
            Console.SetCursorPosition(30, 22)
            yourCockroach_Name_Number = Console.ReadLine
            If IsNumeric(yourCockroach_Name_Number) = True Then
                If yourCockroach_Name_Number > 0 And yourCockroach_Name_Number < 11 Then
                    YourCockroach_Name = Cockroach_Names(yourCockroach_Name_Number - 1)
                    CheckTemp = 1

                End If
            End If
        Loop While CheckTemp = 0

        'Получение ставки на таракана
        Console.SetCursorPosition(58, 22)
        YourCockroach_Bet = Console.ReadLine
        If IsNumeric(YourCockroach_Bet) Then
            If YourCockroach_Bet > YourMoney Or YourCockroach_Bet <= 0 Then
                Console.SetCursorPosition(58, 23)
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write("Очень смешно. Браво.")
                pause(1.5)
                Race()
            End If
            YourMoney = YourMoney - YourCockroach_Bet
        Else
            Console.SetCursorPosition(58, 23)
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Что-то не так в этом числе...")
            pause(2)
            Race()
        End If


        'Сбрасываем консоль и отображаем все ещё раз, но уже с заданными параметрами
        Console.Clear()
        RacePreview(YourCockroach_Name)
        UnderRace_Info(YourCockroach_Name, YourCockroach_Bet)


        'Спрашиваем у пользователя дальнейшие действия
        Console.SetCursorPosition(23, 25)
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.Write("Начать гонку - 1     || Изменить ставки - 2     || Выйти в меню - 3   ")



        Do
            Console.SetCursorPosition(39, 27)
            Console.Write("Ваш выбор: ")
            RaceMenu = Console.ReadLine

            Select Case RaceMenu
                Case = "1"
                    RaceProceed(YourCockroach_Name, YourCockroach_Bet)
                Case = "2"
                    YourMoney += YourCockroach_Bet
                    Race()
                Case = "3"
                    Menu()
                Case Else
                    Console.SetCursorPosition(50, 27)
                    Console.Write(Space(20))
                    CheckTemp = 2
            End Select
        Loop While CheckTemp = 2

    End Sub

    'Суб CheckColor проверяет каждого таракана, и, если на него поставили, красит таракана и дорожку в другой цвет, также говорит о том, что таракан под номером i выбранный
    Sub CheckColor(YourCockroach_Name As String, Cockroach_Name As String)
        RightConsoleSize()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.BackgroundColor = ConsoleColor.Black

        If YourCockroach_Name = Cockroach_Name Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.BackgroundColor = ConsoleColor.DarkGray
            IsCockroachYours = True
        End If
    End Sub

    'суб RacePreview отвечает за отрисовку гоночной доски до старта гонки
    Sub RacePreview(YourCockroach_Name As String)
        RightConsoleSize()

        For i = 0 To UBound(Cockroach_Names)

            CheckColor(YourCockroach_Name, Cockroach_Names(i))
            Console.Write(i + 1 & "-")
            If i < 9 Then Console.Write(Cockroach_Names(i) & Space(8 - Len(Cockroach_Names(i))))
            If i = 9 Then Console.Write(Cockroach_Names(i) & Space(7 - Len(Cockroach_Names(i))))
            Console.Write("||" & Space(3))
            Console.Write("#")
            Console.Write(Space(100) & "||")
            Console.WriteLine(vbCrLf)

        Next
        Console.ResetColor()
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.Write(StrDup(Console.WindowWidth, "="))
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    'обычная пауза, ничего удивительного
    Sub pause(t As Single)
        Dim time As Single
        time = Timer
        Do Until Timer - time > t
        Loop
    End Sub

    'Суб UnderRace_Info отвечает за показ уже введённой информации о таракане и деньгах под гоночной доской
    Sub UnderRace_Info(YourCockroach_Name As String, YourCockroach_Bet As Integer)
        RightConsoleSize()
        Console.SetCursorPosition(17, 22)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.BackgroundColor = ConsoleColor.Black

        Console.Write("Ваш таракан: " & Space(15) & "Ваша ставка: " & Space(7) & "$" & Space(15) & "Деньги: ")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(YourMoney & Space(3))
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write("$")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.SetCursorPosition(30, 22)
        Console.Write(YourCockroach_Name)
        Console.SetCursorPosition(58, 22)
        Console.Write(YourCockroach_Bet)
    End Sub

    'Суб RaceProceed отвечает за гонку тараканов, их движение, выход из строя и т.д.
    Sub RaceProceed(YourCockroach_name As String, YourCockroach_Bet As Integer)
        RightConsoleSize()
        Console.CursorVisible = False
        Dim CockroachPositionArray() = {15, 15, 15, 15, 15, 15, 15, 15, 15, 15}
        Dim cockroachScoreArray(9) As Integer
        Dim score As Integer = 1

        Console.Clear()
        RacePreview(YourCockroach_name)
        UnderRace_Info(YourCockroach_name, YourCockroach_Bet)
        Randomize()

        Do 'начинаем движение. Каждый цикл ДУ это один шаг таракашек


            For i = 0 To UBound(CockroachPositionArray)
                IsCockroachYours = False
                CheckColor(YourCockroach_name, Cockroach_Names(i)) 'Цвет таракана


                Console.SetCursorPosition(CockroachPositionArray(i), i * 2) 'Ставим курсор в место таракана


                If Rnd() <= FailChanceMultiplier Then
                    If cockroachScoreArray(i) = 0 Then Console.Write("*") 'шанс сработал, таракашка устал :(
                Else
                    Console.Write(" ") 'удаляем таракана
                    If IsCockroachYours = True Then 'Твой таракан, не твой - не важно. Меняется только SpeedMultiplier или DifficultyMultiplier

                        If CockroachPositionArray(i) < 114 Then 'Если не дальше финиша

                            CockroachPositionArray(i) = CockroachPositionArray(i) + Int(((2 * SpeedMultiplier) - 1 + 1) * Rnd() + 1) 'Положение таракана сместилось вперед
                            If CockroachPositionArray(i) > 114 Then 'Ставим таракана на 114 иначе может вылететь
                                CockroachPositionArray(i) = 114
                                Console.SetCursorPosition(114, i * 2)
                                Console.Write("#")

                            Else
                                Console.SetCursorPosition(CockroachPositionArray(i), i * 2) 'ставим таракана на новое место
                                Console.Write("#")
                            End If
                        Else

                            If cockroachScoreArray(i) = 0 Then 'если таракану не присвоено место то присваиваем
                                cockroachScoreArray(i) = score
                                score += 1
                            End If
                            Console.SetCursorPosition(110, i * 2)
                            Console.Write(cockroachScoreArray(i))
                        End If

                    Else
                        'аналогично верхнему
                        If CockroachPositionArray(i) < 114 Then

                            CockroachPositionArray(i) = CockroachPositionArray(i) + Int(((2 * DifficultyMultiplier) - 1 + 1) * Rnd() + 1)
                            If CockroachPositionArray(i) > 114 Then
                                CockroachPositionArray(i) = 114
                                Console.SetCursorPosition(114, i * 2)
                                Console.Write("#")
                            Else
                                Console.SetCursorPosition(CockroachPositionArray(i), i * 2)
                                Console.Write("#")
                            End If
                        Else

                            If cockroachScoreArray(i) = 0 Then
                                cockroachScoreArray(i) = score
                                score += 1
                            End If
                            Console.SetCursorPosition(110, i * 2)
                            Console.Write(cockroachScoreArray(i))
                        End If

                    End If

                End If

            Next
            pause(0.3)
        Loop Until score = 11
        Console.BackgroundColor = ConsoleColor.Black
        Console.SetCursorPosition(37, 25)
        Console.WriteLine("Нажмите любую клавишу для продолжения...")
        Console.ReadKey()

        For i = 0 To UBound(Cockroach_Names)
            If YourCockroach_name = Cockroach_Names(i) Then
                BetCounter(YourCockroach_Bet, cockroachScoreArray(i))
            End If
        Next

    End Sub

    'суб BetCounter считает выигрыш(или проигрыш)
    Sub BetCounter(Bet As Integer, score As Integer)
        RightConsoleSize()
        Dim MoneyForRace As Integer
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.DarkYellow
        For i = 0 To Console.WindowHeight - 1
            Console.SetCursorPosition(5, i)
            Console.Write("||")
            Console.SetCursorPosition(113, i)
            Console.Write("||")
        Next
        Console.ForegroundColor = ConsoleColor.Yellow

        pause(1)
        Console.SetCursorPosition(20, 5)
        Console.Write("Позиция в гонке: ")
        If score <= 3 Then
            Console.ForegroundColor = ConsoleColor.Green
        ElseIf score <= 7 Then
            Console.ForegroundColor = ConsoleColor.DarkYellow
        Else
            Console.ForegroundColor = ConsoleColor.Red
        End If
        Console.Write(score)
        Console.ForegroundColor = ConsoleColor.Yellow

        pause(3)
        Console.SetCursorPosition(20, 10)
        Console.Write("Твоя ставка: ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.Write(Bet)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(" $")

        pause(3)
        Console.SetCursorPosition(20, 20)
        Console.Write("Твой выигрыш: ")
        If score <= 3 Then
            Console.ForegroundColor = ConsoleColor.Green
            MoneyForRace = Bet * BetMultiplier
        ElseIf score <= 7 Then
            Console.ForegroundColor = ConsoleColor.DarkYellow
            MoneyForRace = Bet
        Else
            Console.ForegroundColor = ConsoleColor.Red
        End If
        Console.Write(MoneyForRace)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(" $")


        pause(3)
        Console.SetCursorPosition(20, 25)
        Console.Write("Твои деньги: ")
        YourMoney += MoneyForRace
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.Write(YourMoney)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(" $")

        pause(3)
        Console.SetCursorPosition(60, 25)
        Console.WriteLine("Нажмите любую клавишу для продолжения...")
        Console.ReadKey()
        Menu()
    End Sub
End Module
