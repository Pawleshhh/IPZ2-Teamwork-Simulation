import pandas as pd
import numpy as np
from Worker import Worker
from Team import Team
import os
import xlrd

def ReadPerson(TeamArgs):
    Persons = []
    for i in range(1, len(TeamArgs)):#zapisz wszytkie sosoby od 1 do max osob
        Persons.append(TeamArgs[i])

    return Persons

def ReadTeam(TeamArgs):
    TeamMemeberAmount = len(TeamArgs) - 1
    TeamType = TeamArgs[0][0]#pierwsza kolumna
    TeamWorkType = TeamArgs[0][1]
    IterationNumber = TeamArgs[0][2]


    Persons = ReadPerson(TeamArgs)

    return Team(TeamMemeberAmount, IterationNumber, TeamWorkType, Persons, TeamType)

    #T.Iteration(3)

def ReadParemeters(Arg):

    IterationNumber = 3
    TeamMemeberAmount = 3
    TeamType = 0  # zdalne1 lub stacjonarne 0
    TeamWorkType = 0  # pracownik 1 student 0
    #Arg[0][0] - 1 firma / 0 uniwersytet
    #Arg[0][1] - 0 stacjonarnie 1 zdalnie
    #Arg[0][2] - liczba iteracji
    #Arg[N][0] - student/worker
    #Arg[0][0] =



# Press the green button in the gutter to run the script.
def StartSimulation(Arg):
    #  print_hi('PyCharm')
    #  a = pd.DataFrame()
    #P1 = Worker('M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert')

    Person1 = [1, 1, 1, 1, 1, 1]#studenci 1)plec 1-2 2)kierunek 1-7 3)rok 1-5 4)stopien 1-4 5)stacjonarnie nie stacjonarnie 1-2 6)osobowosc
    #Person2 = [2, 3, 4, 3, 2, 2, 2]# pracownicy  1)plec 1-2 2)wiek 1-4 3)dziedizna 1-5 4) stanowisko 1-7 5)ile w firmie 1-4 6) ile w brazny 1-5 7) 1-4 osobowsc
    #Person3 = [1, 3, 3, 4, 1, 1, 1]

    #Persons = [Person1, Person2, Person3]

    IterationNumber = 1
    TeamMemeberAmount = 10
    TeamType = 0#pracownik 1 student 0
    TeamWorkType = 0# zdalne1 lub stacjonarne 0

    #print('test 10.1  tablica tablic : ', Persons[0][2])

    #T = Team(TeamMemeberAmount, IterationNumber, TeamWorkType, Persons, TeamType)
    #T.Iteration()

    #print('test 9.2  klasa team : ', T.PersonList[0].Comfort.Atmosfere)
    #Arg[0][0] - 1 firma / 0 uniwersytet
    #Arg[0][1] - 0 stacjonarnie 1 zdalnie
    #Arg[0][2] - liczba iteracji
    #Arg[N][0] - student/worker

    Arg1 = []
    Arg1.append([TeamType, TeamWorkType, IterationNumber])

    for i in range(0,10):
        Arg1.append(Person1)

    #Arg1.append(Person2)
    #Arg1.append(Person3)
    # P1 = [1, 1, 2, 1, 1, 1]  # informatycy
    # P2 = [1, 1, 2, 1, 1, 1]
    # P3 = [1, 1, 2, 1, 1, 2]
    # P4 = [1, 2, 2, 1, 1, 3]
    # P5 = [1, 2, 2, 1, 1, 3]
    # P6 = [1, 2, 2, 1, 1, 3]
    # P7 = [2, 3, 2, 1, 1, 2]
    # P8 = [2, 3, 3, 1, 1, 1]
    # P9 = [2, 4, 3, 2, 1, 4]
    # P10 = [2, 5, 3, 2, 1, 4]
    # P11 = [1, 1, 2, 1, 1, 1]
    # P12 = [1, 1, 2, 1, 1, 1]
    # P13 = [1, 1, 2, 1, 1, 2]
    # P14 = [1, 2, 2, 1, 1, 3]
    # P15 = [1, 2, 2, 1, 1, 3]
    # P16 = [1, 2, 2, 1, 1, 3]
    # P17 = [2, 3, 2, 1, 1, 2]
    # P18 = [2, 3, 3, 1, 1, 1]
    # P19 = [2, 4, 3, 2, 1, 4]
    # P20 = [2, 5, 3, 2, 1, 4]  # infomracytyc
    # P21 = [1, 3, 1, 1, 1, 1]  # zarządzanie
    # P22 = [1, 3, 2, 2, 1, 2]
    # P23 = [2, 3, 3, 3, 1, 3]
    # P24 = [2, 3, 4, 4, 2, 4]
    # P25 = [1, 3, 2, 2, 1, 2]
    # P26 = [1, 3, 3, 2, 1, 3]
    # P27 = [2, 3, 4, 4, 2, 4]  # zarządzanie
    # P28 = [1, 2, 1, 2, 1, 1]  # ekonomia
    # P29 = [2, 2, 2, 2, 1, 2]
    # P30 = [1, 2, 1, 2, 1, 3]
    # P31 = [2, 2, 2, 2, 2, 4]  # ekonomia
    # P32 = [1, 4, 1, 2, 1, 1]  # psychologia
    # P33 = [2, 4, 2, 2, 1, 2]
    # P34 = [1, 4, 1, 2, 1, 3]
    # P35 = [2, 4, 2, 2, 2, 4]  # psychologia
    # P36 = [1, 5, 1, 2, 1, 1]  # mechatronika
    # P37 = [2, 5, 2, 2, 1, 2]
    # P38 = [1, 5, 1, 2, 1, 3]
    # P39 = [2, 5, 2, 2, 2, 4]  # mechatronika
    # P40 = [1, 6, 1, 2, 1, 1]  # medycyna
    # P41 = [2, 6, 2, 2, 1, 2]
    # P42 = [1, 6, 1, 2, 1, 3]
    # P43 = [2, 6, 2, 2, 2, 4]  # medycyna
    # P44 = [1, 7, 1, 1, 1, 1]  # inne
    # P45 = [2, 7, 2, 1, 1, 2]
    # P46 = [1, 7, 1, 2, 1, 3]
    # P47 = [2, 7, 2, 1, 2, 4]
    # P48 = [1, 7, 1, 2, 1, 1]
    # P49 = [2, 7, 2, 4, 1, 2]
    # P50 = [1, 7, 1, 2, 1, 3]  # inne

    # P19 = [2, 4, 4, 2, 1, 4]
    # P20 = [1, 4, 4, 2, 1, 4]
    # P21 = [1, 5, 4, 2, 1, 4]
    # P22 = [2, 5, 4, 2, 1, 4]
    # P23 = [1, 5, 4, 2, 1, 4]
    # P24 = [1, 6, 4, 2, 1, 4]
    # P25 = [2, 6, 4, 2, 1, 4]
    # P26 = [1, 7, 4, 2, 1, 4]
    # P27 = [2, 7, 4, 2, 1, 4]
    # P28 = [1, 7, 4, 2, 1, 4]
    # P29 = [1, 7, 4, 2, 1, 4]
    # P30 = [1, 7, 4, 2, 1, 4]

    # Arg1.append(P1)
    # Arg1.append(P2)
    # Arg1.append(P3)
    # Arg1.append(P4)
    # Arg1.append(P5)
    # Arg1.append(P6)
    # Arg1.append(P7)
    # Arg1.append(P8)
    # Arg1.append(P9)
    # Arg1.append(P10)
    # Arg1.append(P11)
    # Arg1.append(P12)
    # Arg1.append(P13)
    # Arg1.append(P14)
    # Arg1.append(P15)
    # Arg1.append(P16)
    # Arg1.append(P17)
    # Arg1.append(P18)
    # Arg1.append(P19)
    # Arg1.append(P20)
    # Arg1.append(P21)
    # Arg1.append(P22)
    # Arg1.append(P23)
    # Arg1.append(P24)
    # Arg1.append(P25)
    # Arg1.append(P26)
    # Arg1.append(P27)
    # Arg1.append(P28)
    # Arg1.append(P29)
    # Arg1.append(P30)
    # Arg1.append(P31)
    # Arg1.append(P32)
    # Arg1.append(P33)
    # Arg1.append(P34)
    # Arg1.append(P35)
    # Arg1.append(P36)
    # Arg1.append(P37)
    # Arg1.append(P38)
    # Arg1.append(P39)
    # Arg1.append(P40)
    # Arg1.append(P41)
    # Arg1.append(P42)
    # Arg1.append(P43)
    # Arg1.append(P44)
    # Arg1.append(P45)
    # Arg1.append(P46)
    # Arg1.append(P47)
    # Arg1.append(P48)
    # Arg1.append(P49)
    # Arg1.append(P50)



    T2 = ReadTeam(Arg1)
    T2.Iteration()
    T2.display()

    ListMain = []

    Team_Tired_F = []
    Team_WorkConditions_F = []
    Team_Comfort_F = []
    Team_SelfImprovement_F = []
    Team_TeamEffectiveness_F = []
    Team_Help_F = []
    Team_Help_F = []
    Team_Study_Comfort_F = []
    Team_TeamComm_F = []

    TT1 = []
    TT2 = []
    Team_Tired_F.append(TT1)
    Team_Tired_F.append(TT2)

    TW1 = []
    TW2 = []
    Team_WorkConditions_F.append(TW1)
    Team_WorkConditions_F.append(TW2)

    TC1 = []
    TC2 = []
    Team_Comfort_F.append(TC1)
    Team_Comfort_F.append(TC2)

    TS1 = []
    TS2 = []
    Team_SelfImprovement_F.append(TS1)
    Team_SelfImprovement_F.append(TS2)

    TT1 = []
    TT2 = []
    Team_TeamEffectiveness_F.append(TT1)
    Team_TeamEffectiveness_F.append(TT2)

    TH1 = []
    TH2 = []
    Team_Help_F.append(TH1)
    Team_Help_F.append(TH2)

    TTC1 = []
    TTC2 = []
    Team_TeamComm_F.append(TTC1)
    Team_TeamComm_F.append(TTC2)

    TSC1 = []
    TSC2 = []
    Team_Study_Comfort_F.append(TSC1)
    Team_Study_Comfort_F.append(TSC2)

    ox = list(range(0, T2.IterationAmount))
    print('test arange:', ox)

    for i in range(0, len(T2.Team_Tired_Factor)):
        Team_Tired_F[0].append(ox[i])  # 1
        Team_Tired_F[1].append(T2.Team_Tired_Factor[i])  # 2

        Team_WorkConditions_F[0].append(ox[i])
        Team_WorkConditions_F[1].append(T2.Team_WorkConditions_Factor[i])

        Team_Comfort_F[0].append(ox[i])
        Team_Comfort_F[1].append(T2.Team_Tired_Factor[i])

        Team_SelfImprovement_F[0].append(ox[i])
        Team_SelfImprovement_F[1].append(T2.Team_SelfImprovement_Factor[i])

        Team_TeamEffectiveness_F[0].append(ox[i])
        Team_TeamEffectiveness_F[1].append(T2.Team_TeamEffectiveness_Factor[i])

        Team_Help_F[0].append(ox[i])
        Team_Help_F[1].append(T2.Team_Help_Factor[i])

        Team_TeamComm_F[0].append(ox[i])
        Team_TeamComm_F[1].append(T2.Team_TeamComm_Factor[i])

        Team_Study_Comfort_F[0].append(ox[i])
        Team_Study_Comfort_F[1].append(T2.Team_Comfort_Factor[i])

    ListMain.append(Team_Tired_F)
    ListMain.append(Team_WorkConditions_F)
    ListMain.append(Team_Comfort_F)
    ListMain.append(Team_SelfImprovement_F)
    ListMain.append(Team_TeamEffectiveness_F)
    ListMain.append(Team_Help_F)
    ListMain.append(Team_TeamComm_F)
    ListMain.append(Team_Study_Comfort_F)

    ListMain.append([[1], [1]])

    return ListMain



     
        
        
    
    
    
    
    #8 argumentow
    
    
    




#745
StartSimulation(1)

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
