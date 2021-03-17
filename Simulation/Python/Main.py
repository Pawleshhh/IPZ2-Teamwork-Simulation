import pandas as pd
import numpy as np
from Worker import Worker
from Team import Team
import os
import xlrd

def ReadPerson(TeamArgs):
    Persons = []
    for i in range(1, len(TeamArgs)):
        Persons.append(TeamArgs[i])

    return Persons

def ReadTeam(TeamArgs):
    TeamMemeberAmount = len(TeamArgs) - 1
    TeamType = TeamArgs[0][0]
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
def StartSimluation(Arg):
    #  print_hi('PyCharm')
    #  a = pd.DataFrame()
    P1 = Worker('M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert')


    print('test 1 parametr age: ', P1.Age)
    print('test 2 atmosfere:', P1.Comfort.Atmosfere)
    print('test 3 team cord:', P1.TeamEff.Coordination)
    print('test 4 teamcom:', P1.TeamComm.ProactiveComm)
    P1.Comfort.Atmosfere.append(2)
    print('test5 kolejen iteracje wartosci:', P1.Comfort.Atmosfere)

    P1.TeamEff.weightsUpdate(1, 2, 3, 4)
    print('test 6.1 update wag: ', P1.TeamEff.W)
    print('test 6.2 update wag: ', P1.TeamEff.W[0])

    P1.Comfort.weightsUpdate(1, 2, 3, 4, 5, 6)
    print('test 6.3 update wag: ', P1.Comfort.W[0])

    P1.TeamComm.weightsUpdate(1, 2, 3, 4, 5, 6)
    print('test 6.4 update wag: ', P1.TeamComm.W[0][2])


    print('test 6.5 update wag: ', P1.Comfort.W[:][:])



    P1.calculateWorkConditionsFactor(0)
    print('test 7.1  obliczania warunkow pracy: ', P1.WorkConditions_Factor[0])

    P1.Comfort.weightsUpdate(7, 8, 9, 10, 11, 12)
    print('test 7.2 update wag: ', P1.Comfort.W[:][:])

    P1.calculateTirednessFactor(0)
    print('test 7.3  obliczania zmeczenia 2 iteracja: ', P1.Tired_Factor)

    P1.calculateComfortFactor(0)
    print('test 7.4  obliczania commfortfactor: ', P1.Comfort_Factor[0])

    P1.calculateSelfImprovementFactor(0)
    print('test 7.5  selfimprovement ', P1.SelfImprovement_Factor[0])

    P1.calculateTeamEffectivnessFactor(0)
    print('test 7.6  obliczania teameff: ', P1.TeamEffectiveness_Factor[0])

    P1.calculateHelpFactor(0)
    print('test 7.7  obliczania helpfactor: ', P1.Help_Factor[0])

    P1.calculateTeamCommunicationFactor(0,1)
    print('test 7.8  obliczania tteamcomm: ', P1.TeamComm_Factor[0])


    #P1.calculateTirednessFactor(0)
    P1.calculateTirednessFactor(1)
    print('test 7.1  obliczania zmeczenia: ', P1.Tired_Factor[0])
    P1.Comfort.weightsUpdate(10, 10, 10, 10, 10, 10)
    P1.Comfort.ArgumentsUpdate(2, 2, 2, 2, 2, 2)
    P1.calculateTirednessFactor(2)
    print('test 8.1  dane do wykresu: ', P1.Tired_Factor)
    print('test pusha nr 1')


    #P1.plotData()


    #osoby = pd.read_excel(r'D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM\ABM\kopia.xlsx')

    #df1 = pd.read_excel(
        #os.path.join('D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM', "ABM", "kopia.xlsx"),
        #engine='openpyxl',
    #)

    #Person1 = [1, 1, 2, 3, 4, 4, 1]#studenci 1)plec 1-2 2)kierunek 1-7 3)rok 1-5 4)stopien 1-4 5)stacjonarnie nie stacjonarnie 1-2 6)osobowosc
    #Person2 = [2, 3, 4, 3, 2, 2, 2]# pracownicy  1)plec 1-2 2)wiek 1-4 3)dziedizna 1-5 4) stanowisko 1-7 5)ile w firmie 1-4 6) ile w brazny 1-5 7) 1-4 osobowsc
    #Person3 = [1, 3, 3, 4, 1, 1, 1]




    #Person1 = [1, 1, 1, 1, 1, 1]
    #Person2 = [1, 6, 3, 3, 1, 1]
    #Person3 = [1, 7, 4, 2, 1, 4]
    Person1 = [1, 1, 1, 1, 1, 1]
    Person2 = [1, 6, 3, 1, 1, 1]
    Person3 = [1, 1, 1, 1, 1, 1]

    #Persons = [Person1, Person2, Person3]

    IterationNumber = 3
    TeamMemeberAmount = 3
    TeamType = 0# zdalne1 lub stacjonarne 0
    TeamWorkType = 0#pracownik 1 student 0

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
    Arg1.append(Person1)
    Arg1.append(Person2)
    Arg1.append(Person3)

    T2 = ReadTeam(Arg1)
    T2.Iteration()





StartSimluation(1)
# See PyCharm help at https://www.jetbrains.com/help/pycharm/
