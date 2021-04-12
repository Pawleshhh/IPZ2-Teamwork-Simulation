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
def StartSimluation(Arg):
    #  print_hi('PyCharm')
    #  a = pd.DataFrame()
    #P1 = Worker('M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert')

    #Person1 = [1, 1, 2, 3, 4, 4, 1]#studenci 1)plec 1-2 2)kierunek 1-7 3)rok 1-5 4)stopien 1-4 5)stacjonarnie nie stacjonarnie 1-2 6)osobowosc
    #Person2 = [2, 3, 4, 3, 2, 2, 2]# pracownicy  1)plec 1-2 2)wiek 1-4 3)dziedizna 1-5 4) stanowisko 1-7 5)ile w firmie 1-4 6) ile w brazny 1-5 7) 1-4 osobowsc
    #Person3 = [1, 3, 3, 4, 1, 1, 1]

    #Persons = [Person1, Person2, Person3]

    IterationNumber = 1
    TeamMemeberAmount = 50
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

   #for i in range(0,743):
        #Arg1.append(P1)
    #Arg1.append(Person2)
    #Arg1.append(Person3)

    T2 = ReadTeam(Arg)
    T2.Iteration()
    T2.display()





#745
StartSimluation(1)

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
