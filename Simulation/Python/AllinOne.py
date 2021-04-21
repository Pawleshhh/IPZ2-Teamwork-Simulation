import pandas as pd
import numpy as np
from Worker import Worker
from Team import Team
import os
import xlrd
import matplotlib.pyplot as plt
class Comfort:
    def __init__(self, tiredWeek, breakTime, atmosfere, ergonomics, selfImpovement, tired1day):
        self.TiredWeek = [] # zaincijuj pusta tablice zeby zachowac ifno o poprzednich iteracjach
        self.BreakTime = []
        self.Atmosfere = []
        self.Ergonomics = []
        self.SelfImprovement = []
        self.Tired1day = []

        # lista wag !

        self.W = []


        #self.TiredWeek.append(tiredWeek) #dodaj wartosc do tej talbice
        #self.BreakTime.append(breakTime)  # [tymaczasowe]
        #self.Atmosfere.append(atmosfere)
        #self.Ergonomics.append(ergonomics)
        #self.SelfImprovement.append(selfImpovement)
        #self.Tired1day.append(tired1day)



    def weightsUpdate(self, w1, w2, w3, w4, w5, w6):
        k = [w1, w2, w3, w4, w5, w6]
        self.W.append(k)

    def ArgumentsUpdate(self,tiredWeek, breakTime, atmosfere, ergonomics, selfImpovement, tired1day):
        self.TiredWeek.append(tiredWeek)  # dodaj wartosc do tej talbice
        self.BreakTime.append(breakTime)
        self.Atmosfere.append(atmosfere)
        self.Ergonomics.append(ergonomics)
        self.SelfImprovement.append(selfImpovement)
        self.Tired1day.append(tired1day)


def funkcja(osoby, nazwa1, nazwa2, c):
    os = (osoby[osoby['' + nazwa1] == nazwa2])

    all = len(os)
    print('os wynosi: ', all)
    wynik = pd.DataFrame(index=[1, 2, 3, 4, 5])

    for a in os.columns[26:c]:
        p1 = len(os[os['' + str(a)] == 1]) / all
        p2 = len(os[os['' + str(a)] == 2]) / all
        p3 = len(os[os['' + str(a)] == 3]) / all
        p4 = len(os[os['' + str(a)] == 4]) / all
        p5 = len(os[os['' + str(a)] == 5]) / all
        arr = np.array([p1, p2, p3, p4, p5])
        wynik['' + str(a)] = arr
    return wynik


def losowanie(Baza):
    wylos = []
    for a in range(0, len(Baza.columns)):
        tabRand = []
        for b in range(0, 5):
            n = int(Baza.iloc[b, a] * 100)
            tabRand += n * [b + 1]
        # print(tabRand)
        rand = random.choice(tabRand)
        # print(rand)
        wylos.append(rand)
    return wylos


def answersSelection(dane, TeamType):
    # osoby = pd.read_excel('kopia.xlsx')

    if TeamType == 1:
        osoby = pd.read_excel(
            os.path.join('D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM', "ABM", "kopia.xlsx"),
            engine='openpyxl',
        )
        method = osoby.columns[19:26]
        c = 63
    else:
        osoby = pd.read_excel(
            os.path.join('D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM', "ABM", "studenci.xlsx"),
            engine='openpyxl',
        )
        method = osoby.columns[20:26]
        print(method)
        c = 74

    # method = osoby.columns[19:26]
    fun1 = pd.DataFrame(index=[1, 2, 3, 4, 5], columns=osoby.columns[26:c])
    fun1 = fun1.replace(np.nan, 0)  # inaczej sa same nun trzeba zamienic
    k = 0

    for b in method:
        print(dane[k])
        fun = funkcja(osoby, b, dane[k], c)  # dane[k]-tutaj przekaż echy osoby  osoby
        k = k + 1
        fun1 = fun1 + fun
    fun1 = fun1 / len(method)
    # print(fun1)

    randarray = losowanie(fun1)
    print(randarray)
    return randarray


def A_inject(liczba):
    osoby = pd.read_excel(os.path.join('D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM', "ABM", "studenci.xlsx"),
                          engine='openpyxl', )
    tab = []
    i = 0;
    for a in range(25, 74):
        tab.append(osoby.iloc[liczba, a])
    return tab

# co się kryje pod kazdym elementem randarray
# STACJONARNE
# randarray[0] ZMĘCZENIE PO TYGODNIU
# randarray[1] CZAS NA PRZERWĘ
# randarray[2] ATMOSFERA
# randarray[3] ERGONOMIA
# randarray[4]SAMODOSKONALENIE SIĘ
# randarray[5] REALIZACJA TWOICH CELÓW [Delays]
# randarray[6] REALIZACJA CELÓW TWOJEGO ZESPOŁU [ProjectComp]
# randarray[7] NIE ZREALIZOWANIE TWOICH CELÓW [kontrolne nie pod uwage]
# randarray[8] MOTYWACJA DO PRACY [Engagment]
# randarray[9] ZMĘCZENIE PO DNIU [comfort]
# randarray[10] WPŁYW MIEJSCA NA TWOJĄ ORGANIZACJĘ
# randarray[11]ORGANIZACJA PRACY [Coordynation]
# randarray[12]JAK CZĘSTO POMAGASZ INNYM [proactive]
# randarray[13]JAK CZĘSTO  INNI POMAGAJĄ TOBIE [reactive]
# randarray[14] KONFLIKTY [ConflictsFreq]
# ZDALNE
# randarray[15]PREFERENCJA PRACY ZDALNEJ(RACZEJ NIE WAŻNE)
# randarray[16]ZMĘCZENIE PO TYGODNIU
# randarray[17]CZAS NA PRZERWĘ
# randarray[18]ATMOSFERA
# randarray[19]ERGONOMIA
# randarray[20]SAMODOSKONALENIE SIĘ
# randarray[21]REALIZACJA TWOICH CELÓW
# randarray[22]REALIZACJA CELÓW TWOJEGO ZESPOŁU
# randarray[23]NIE ZREALIZOWANIE TWOICH CELÓW
# randarray[24]MOTYWACJA DO PRACY
# randarray[25]ZMĘCZENIE PO DNIU
# randarray[26]WPŁYW MIEJSCA NA TWOJĄ ORGANIZACJĘ
# randarray[27]ORGANIZACJA PRACY
# randarray[28]JAK CZĘSTO POMAGASZ INNYM
# randarray[29]JAK CZĘSTO  INNI POMAGAJĄ TOBIE
# randarray[30]KONFLIKTY
# randarray[31]JAKI KOMUNIKATOR?
# randarray[32]JAKOSC KOMUNIKACJI
# randarray[33] CZY KAMERA JEST?
# randarray[34]JAKOŚĆ AUDIO I VIDEO
# randarray[35]PROBLEMY ZE ZROZUMIENIEM KONTEKSTU WYPOWIEDZI

class Student:
    def __init__(self, sex, fieldofstudy, yearOfStudy, degree, studyMode, character):
        #  konstruktor do osoby nazewnisctwo angielskie?
        self.Sex = sex  # argumenty kalsy z duzej litery?
        #self.Age = age
        self.FieldOfStudy = fieldofstudy
        self.StudyMode = studyMode# do poprawu
        self.YearOfStudy = yearOfStudy
        self.Degree = degree
        self.Character = character

        self.Chartable = [sex, fieldofstudy, yearOfStudy, degree, studyMode, character]  # to samo do studenta [kolejność cech przekazywancyh]

        self.IterationN = 0  # numer iteracji do poruszania sie po danych i aktualziacji

        self.Tired_Factor = []
        self.WorkConditions_Factor = []
        self.Comfort_Factor = []
        self.SelfImprovement_Factor = []
        self.TeamEffectiveness_Factor = []
        self.Help_Factor = []
        self.TeamComm_Factor = []
        self.StudyComfort_Factor = []

        self.Comfort = Comfort(1, 1, 1, 1, 1, 1) # tu nadac poczatkowa wartosci dla 1 iteracji
        self.TeamEff = TeamEffectiveness(2, 2, 2, 2)
        self.TeamComm = TeamCommunication(3, 3, 3, 3, 0)
        self.StudyComfort = StudyComfort()#tylko dla studentow



    def calculateTirednessFactor(self, i):
        a = self.Comfort.TiredWeek[i] * self.Comfort.W[0][0]
        b = self.Comfort.BreakTime[i] * self.Comfort.W[0][1]
        f = self.Comfort.Tired1day[i] * self.Comfort.W[0][5]

        WeightSum = self.Comfort.W[i][0] + self.Comfort.W[i][1] + self.Comfort.W[i][5]
        sum = (a + b + f)
        #print('suma to:', sum)
        #print('suma wag to: ', WeightSum)
        tired = sum/WeightSum
        k = tired
        self.Tired_Factor.append(k)
        # wyjątek przchytywyanie błedów try()
    def calculateWorkConditionsFactor(self, i):
        a = self.Comfort.Atmosfere[i] * self.Comfort.W[0][2]
        b = self.Comfort.Ergonomics[i] * self.Comfort.W[0][3]

        WeightSum = self.Comfort.W[i][2] + self.Comfort.W[0][3]
        sum = (a + b)
        #print('suma to:', sum)
        #print('suma wag to: ', WeightSum)
        tired = sum/WeightSum
        k = tired
        self.WorkConditions_Factor.append(k)

    def calculateComfortFactor(self, i):
        a = self.Tired_Factor[i]
        b = self.WorkConditions_Factor[i]
        lst = (a + b)  #  dzielic przez sume wag czy nie?
        S = lst
        k = S / 2
        self.Comfort_Factor.append(k)

    def calculateSelfImprovementFactor(self, i):
        a = self.Tired_Factor[i]
        b = self.TeamEff.Engagement[i] * self.TeamEff.W[0][2]  #konflikt wagi z śrdenia zwykla?
        lst = (a + b)  # dzielic przez sume wag czy nie?
        S = lst
        k = S / 1 + self.TeamEff.W[0][2]
        self.SelfImprovement_Factor.append(k)

    def calculateTeamEffectivnessFactor(self, i):
        a = [self.TeamEff.ProjectComp[i] * self.TeamEff.W[0][0]]
        b = [self.TeamEff.Coordination[i] * self.TeamEff.W[0][3]]
        c = [self.SelfImprovement_Factor[i]]
        lst = (a + b + c)  # dzielic przez sume wag czy nie?
        S = sum(lst)
        k = S / 1 + self.TeamEff.W[0][0] + self.TeamEff.W[0][3]
        self.TeamEffectiveness_Factor.append(k)


    def calculateHelpFactor(self, i):
        a = self.TeamComm.ProactiveComm[i] * self.TeamComm.W[0][1]
        b = self.TeamComm.ReactiveComm[i] * self.TeamComm.W[0][2]
        WeightSum = self.TeamComm.W[i][1] + self.TeamComm.W[0][2]
        sum = (a + b)
        tired = sum / WeightSum
        k = tired

        self.Help_Factor.append(k)

    def calculateTeamCommunicationFactor(self, i, switch):
        a = self.Help_Factor[i]
        b = self.TeamComm.ConflictsFreq[i] * self.TeamComm.W[0][4]



        if switch == 0:
            lst = (a + b)
            S = lst
            k = S / 1 + self.TeamComm.W[0][4]

        if switch == 1:
            WeightSum = self.TeamComm.W[0][3] + self.TeamComm.W[0][4] + self.TeamComm.W[0][5]
            c = self.TeamComm.R_ComQuality[i] * self.TeamComm.W[0][3]
            d = self.TeamComm.R_ComQuality[i] * self.TeamComm.W[0][4]
            e = self.TeamComm.R_ComQuality[i] * self.TeamComm.W[0][5]
            lst = a + b + c
            S = lst
            k = S / 3

        self.TeamComm_Factor.append(k)

    def calculateStudyComfort_Factor(self,i):
        a = self.StudyComfort.KnowledgeGain[i] * self.StudyComfort.W[0][0]
        b = self.StudyComfort.ProfessorStudentComm[i] *  self.StudyComfort.W[0][1]
        c = self.StudyComfort.Focus[i]*self.StudyComfort.W[0][2]
        d = self.StudyComfort.HandleYourself[i]*self.StudyComfort.W[0][3]
        e = self.StudyComfort.FormOfPassing[i]*self.StudyComfort.W[0][4]

        WeightSum = self.StudyComfort.W[0][0]+self.StudyComfort.W[0][1]+self.StudyComfort.W[0][2]+self.StudyComfort.W[0][3]+self.StudyComfort.W[0][4]

        lst = a + b + c + d + e  # dzielic przez sume wag czy nie?
        #S = sum(lst)
        k = lst / WeightSum
        self.StudyComfort_Factor.append(k)

class StudyComfort:
    def __init__(self):

        self.KnowledgeGain = []
        self.ProfessorStudentComm = []
        self.Focus = []
        self.HandleYourself = []
        self.FormOfPassing = []

        self.W = []

    def weightsUpdate(self, w1, w2, w3, w4, w5):
        k = [w1, w2, w3, w4, w5]
        self.W.append(k)

    def ArgumentsUpdate(self, knowledgegain, professorStudentComm, focus, handleYourself, formOfPassing ):  # wariant na zdalne
        self.KnowledgeGain.append(knowledgegain)
        self.ProfessorStudentComm.append(professorStudentComm)
        self.Focus.append(focus)
        self.HandleYourself.append(handleYourself)
        self.FormOfPassing.append(formOfPassing)

class Team:
    def __init__(self, teamMemAmount, iterationAmount, mode, Persons, mode2):  # mode zdalne lub stacjonarne

        self.PersonList = []
        self.TeamMemAmount = teamMemAmount
        self.IterationAmount = iterationAmount

        self.Team_Tired_Factor = []
        self.Team_WorkConditions_Factor = []
        self.Team_Comfort_Factor = []
        self.Team_SelfImprovement_Factor = []
        self.Team_TeamEffectiveness_Factor = []
        self.Team_Help_Factor = []
        self.Team_TeamComm_Factor = []

        self.Team_Study_Comfort_Factor = []

        self.TeamWorkType = mode  # zdalne1 lub stacjonarne 0
        self.TeamType = mode2  # pracownik 1 student 0

        if mode2 == 1:  # dwie opcje
            for i in range(teamMemAmount):
                self.PersonList.append(
                    Worker(Persons[i][0], Persons[i][1], Persons[i][2], Persons[i][3], Persons[i][4], Persons[i][5],
                           Persons[i][6]))  # 'M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert'
        if mode2 == 0:
            for i in range(teamMemAmount):
                self.PersonList.append(
                    Student(Persons[i][0], Persons[i][1], Persons[i][2], Persons[i][3], Persons[i][4],
                            Persons[i][5]))  # 'M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert'

    def calculateIteration(self, iteration, remoteSwitch):

        sumT = 0
        sumWC = 0
        sumC = 0
        sumSI = 0
        sumTE = 0
        sumH = 0
        sumTC = 0
        sumSC = 0

        for i in range(self.TeamMemAmount):  # aktualizowanie wag do przeliczalnia tutaj
            if (self.TeamWorkType == 1):  # kalibracja dla zdalnych
                self.PersonList[i].TeamComm.weightsUpdate(1, 1, 1, 1, 0.75, 1)
                self.PersonList[i].Comfort.weightsUpdate(1, 7, 1, 0.5, 1, 1)
                self.PersonList[i].TeamEff.weightsUpdate(1, 1, 1.2, 1)
                if (self.TeamType == 0):
                    self.PersonList[i].StudyComfort.weightsUpdate(2, 2, 10, 2, 0.5)

            if (self.TeamWorkType == 0):  # kalibracja dla stacjonarnych
                self.PersonList[i].TeamComm.weightsUpdate(0.2, 0.2, 0.2, 0.2, 0.2, 0.2)
                self.PersonList[i].Comfort.weightsUpdate(1, 0.9, 1, 1, 1, 1)
                self.PersonList[i].TeamEff.weightsUpdate(0.05, 1.2, 0.1, 0.05)
                if (self.TeamType == 0):
                    self.PersonList[i].StudyComfort.weightsUpdate(2, 2, 10, 2, 0.5)

        for i in range(self.TeamMemAmount):
            self.PersonList[i].calculateTirednessFactor(iteration)
            self.PersonList[i].calculateWorkConditionsFactor(iteration)
            self.PersonList[i].calculateComfortFactor(iteration)
            self.PersonList[i].calculateSelfImprovementFactor(iteration)
            self.PersonList[i].calculateTeamEffectivnessFactor(iteration)
            self.PersonList[i].calculateHelpFactor(iteration)
            self.PersonList[i].calculateTeamCommunicationFactor(iteration, remoteSwitch)

            self.PersonList[i].calculateStudyComfort_Factor(iteration)

            sumT = sumT + self.PersonList[i].Tired_Factor[iteration]
            sumWC = sumWC + self.PersonList[i].WorkConditions_Factor[iteration]
            sumC = sumC + self.PersonList[i].Comfort_Factor[iteration]
            sumSI = sumSI + self.PersonList[i].SelfImprovement_Factor[iteration]
            sumTE = sumTE + self.PersonList[i].TeamEffectiveness_Factor[iteration]
            sumH = sumH + self.PersonList[i].Help_Factor[iteration]
            sumTC = sumTC + self.PersonList[i].TeamComm_Factor[iteration]
            sumSC = sumSC + self.PersonList[i].StudyComfort_Factor[iteration]

        self.Team_Tired_Factor.append(sumT / self.TeamMemAmount)
        self.Team_WorkConditions_Factor.append(sumWC / self.TeamMemAmount)
        self.Team_Comfort_Factor.append(sumC / self.TeamMemAmount)
        self.Team_SelfImprovement_Factor.append(sumSI / self.TeamMemAmount)
        self.Team_TeamEffectiveness_Factor.append(sumTE / self.TeamMemAmount)
        self.Team_Help_Factor.append(sumH / self.TeamMemAmount)
        self.Team_TeamComm_Factor.append(sumTC / self.TeamMemAmount)

        self.Team_Study_Comfort_Factor.append(sumSC / self.TeamMemAmount)

    def plotData(self):  # to idzie  do team
        names = ['Tired_Factor', 'WorkConditions_Factor', 'Comfort_Factor', 'SelfImprovement_Factor', ]

        plt.figure(1)
        plt.plot(np.arange(len(self.Team_Tired_Factor)), self.Team_Tired_Factor)
        plt.title('Tired_Factor')

        plt.figure(2)
        plt.plot(np.arange(len(self.Team_WorkConditions_Factor)), self.Team_WorkConditions_Factor)
        plt.title('WorkConditions_Factor')

        plt.figure(3)
        plt.plot(np.arange(len(self.Team_Comfort_Factor)), self.Team_Comfort_Factor)
        plt.title('Comfort_Factor')

        plt.figure(4)
        plt.plot(np.arange(len(self.Team_SelfImprovement_Factor)), self.Team_SelfImprovement_Factor)
        plt.title('SelfImprovement_Factor')

        plt.figure(5)
        plt.plot(np.arange(len(self.Team_TeamEffectiveness_Factor)), self.Team_TeamEffectiveness_Factor)
        plt.title('TeamEffectiveness_Factor')

        plt.figure(6)
        plt.plot(np.arange(len(self.Team_Help_Factor)), self.Team_Help_Factor)
        plt.title('Help_Factor')

        plt.figure(7)
        plt.plot(np.arange(len(self.Team_TeamComm_Factor)), self.Team_TeamComm_Factor)
        plt.title('TeamComm_Factor')

        plt.figure(8)
        plt.plot(np.arange(len(self.Team_Study_Comfort_Factor)), self.Team_Study_Comfort_Factor)
        plt.title('Team_Study_Comfort_Factor')

        plt.show()

    def plotDataV2(self):  # to idzie  do team
        names = ['Tired_Factor', 'WorkConditions_Factor', 'Comfort_Factor', 'SelfImprovement_Factor', ]

        fig, axs = plt.subplots(3, 3)
        axs[0, 0].set_title('Tired_Factor')
        axs[0, 0].plot(np.arange(len(self.Team_Tired_Factor)), self.Team_Tired_Factor)

        axs[0, 1].set_title('WorkConditions_Factor')
        axs[0, 1].plot(np.arange(len(self.Team_WorkConditions_Factor)), self.Team_WorkConditions_Factor)

        axs[1, 0].set_title('Comfort_Factor')
        axs[1, 0].plot(np.arange(len(self.Team_Comfort_Factor)), self.Team_Comfort_Factor)

        axs[2, 0].set_title('SelfImprovement_Factor')
        axs[2, 0].plot(np.arange(len(self.Team_SelfImprovement_Factor)), self.Team_SelfImprovement_Factor)

        axs[0, 2].set_title('TeamEffectiveness_Factor')
        axs[0, 2].plot(np.arange(len(self.Team_TeamEffectiveness_Factor)), self.Team_TeamEffectiveness_Factor)

        axs[1, 2].set_title('Help_Factor')
        axs[1, 2].plot(np.arange(len(self.Team_Help_Factor)), self.Team_Help_Factor)

        axs[2, 2].set_title('TeamComm_Factor')
        axs[2, 2].plot(np.arange(len(self.Team_TeamComm_Factor)), self.Team_TeamComm_Factor)

        axs[2, 2].set_title('TeamComm_Factor')
        axs[2, 2].plot(np.arange(len(self.Team_TeamComm_Factor)), self.Team_TeamComm_Factor)

        axs[1, 1].set_title('Team_Study_Comfort_Factor')
        axs[1, 1].plot(np.arange(len(self.Team_Study_Comfort_Factor)), self.Team_Study_Comfort_Factor)

        # subplots_adjust(left=None, bottom=None, right=None, top=None, wspace=None, hspace=None)

        left = 0.125  # the left side of the subplots of the figure
        right = 0.9  # the right side of the subplots of the figure
        bottom = 0.1  # the bottom of the subplots of the figure
        top = 0.9  # the top of the subplots of the figure
        wspace = 0.2  # the amount of width reserved for blank space between subplots
        hspace = 0.6  # the amount of height reserved for white space between subplots

        plt.subplots_adjust(left, bottom, right, top, wspace, hspace)
        plt.show()

    def Iteration(self):
        index = 0
        for j in range(self.IterationAmount):

            for i in range(self.TeamMemAmount):
                # Answers = ProbFunctions.answersSelection(self.PersonList[i].Chartable, self.TeamType)
                # Answers = ProbFunctions.A_inject(index)
                Answers = np.linspace(0, 43, 42)

                index = index + 1
                print("poszlo ", index)
                if self.TeamWorkType == 0:
                    self.PersonList[i].Comfort.ArgumentsUpdate(Answers[0],
                                                               Answers[1], Answers[2], Answers[3], Answers[4],
                                                               Answers[9])
                    self.PersonList[i].TeamEff.ArgumentsUpdate(Answers[6], Answers[5], Answers[8], Answers[11])
                    self.PersonList[i].TeamComm.ArgumentsUpdate(Answers[13], Answers[12], Answers[14])
                    self.PersonList[i].StudyComfort.ArgumentsUpdate(Answers[15], Answers[16], Answers[17], Answers[18],
                                                                    Answers[20])

                    # self.PersonList[i].TeamComm.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe] tymczasowy update wag
                    # self.PersonList[i].TeamEff.weightsUpdate(1, 2, 3, 4)  # [tymaczasowe]
                    # self.PersonList[i].Comfort.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe]

                if self.TeamWorkType == 1:
                    self.PersonList[i].Comfort.ArgumentsUpdate(Answers[22],
                                                               Answers[23], Answers[24], Answers[25], Answers[26],
                                                               Answers[31])
                    self.PersonList[i].TeamEff.ArgumentsUpdate(Answers[28], Answers[27], Answers[30], Answers[33])
                    self.PersonList[i].TeamComm.R_ArgumentsUpdate(Answers[35], Answers[34], Answers[36], Answers[46],
                                                                  Answers[45], Answers[47])
                    self.PersonList[i].StudyComfort.ArgumentsUpdate(Answers[37], Answers[38], Answers[39], Answers[40],
                                                                    Answers[42])
                    # self.PersonList[i].TeamComm.weightsUpdate(1, 2, 3, 4, 5)  # # [tymaczasowe] tymczasowy update wag
                    # self.PersonList[i].TeamEff.weightsUpdate(1, 2, 3, 4)  # [tymaczasowe]
                    # self.PersonList[i].Comfort.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe]

            self.calculateIteration(j, self.TeamWorkType)

        # self.plotData()
        self.plotDataV2()

    def display(self):
        print("tired: ", self.Team_Tired_Factor)
        print("work conditions: ", self.Team_WorkConditions_Factor)
        print("comfort: ", self.Team_Comfort_Factor)
        print("selfimprov: ", self.Team_SelfImprovement_Factor)
        print("team eff: ", self.Team_TeamEffectiveness_Factor)
        print("help: ", self.Team_Help_Factor)
        print("team communication: ", self.Team_TeamComm_Factor)
        print("study comfort: ", self.Team_Study_Comfort_Factor)

class TeamCommunication:  # jakosc komuikacj zdalnej jak zrobic ??
    def __init__(self, reactiveComm, proactiveComm, remotecomm, conflictsfreq, remoteswitch):
        self.ReactiveComm = []
        self.ProactiveComm = []
        self.ConflictsFreq = []

        self.R_ComQuality = []  # R_ czyli remote paramtry tylko dla zdalnej
        self.R_AudioVideoQuality = []
        self.R_Understanding = []

        self.W = []
        self.RemoteSwitch = remoteswitch

        # self.ReactiveComm.append(reactiveComm)# [tymaczasowe]
        # self.ProactiveComm.append(proactiveComm)
        # self.ConflictsFreq.append(conflictsfreq)
        # self.R_ComQuality.append(conflictsfreq)
        # self.R_AudioVideoQuality.append(conflictsfreq)
        # self.R_Understanding.append(conflictsfreq)

    def weightsUpdate(self, w1, w2, w3, w4, w5, w6):
        k = [w1, w2, w3, w4, w5, w6]
        self.W.append(k)

    def ArgumentsUpdate(self, reactiveComm, proactiveComm, conflicts):  # wariant na zdalne
        self.ReactiveComm.append(reactiveComm)
        self.ProactiveComm.append(proactiveComm)
        self.ConflictsFreq.append(conflicts)

    def R_ArgumentsUpdate(self, reactiveComm, proactiveComm, conflicts, r_ComQuality, r_AudioVideoQuality,
                          r_Understanding):  # wariant na zdalne
        self.ReactiveComm.append(reactiveComm)
        self.ProactiveComm.append(proactiveComm)
        self.ConflictsFreq.append(conflicts)
        self.R_ComQuality.append(r_ComQuality)
        self.R_AudioVideoQuality.append(r_AudioVideoQuality)
        self.R_Understanding.append(r_Understanding)

class TeamEffectiveness:
    def __init__(self, projetcomp, delays, engagment, coordination):
        self.ProjectComp = []  #ProjectComp-> Project Completion (realizacja celow zalozen)
        self.Delays = []
        self.Engagement = []
        self.Coordination = []

        self.W = []

        #self.ProjectComp.append(projetcomp) # [tymaczasowe]
        #self.Delays.append(delays)
        #self.Engagement.append(engagment)
        #self.Coordination.append(coordination)

    def weightsUpdate(self, w1, w2, w3, w4):
        k = [w1, w2, w3, w4]
        self.W.append(k)

    def ArgumentsUpdate(self,  projetcomp, delays, engagment, coordination):
        self.ProjectComp.append(projetcomp)
        self.Delays.append(delays)
        self.Engagement.append(engagment)
        self.Coordination.append(coordination)

class Worker:
    def __init__(self, sex, age, fieldofwork, position, timeincompany, expirience, character):
        #  konstruktor do osoby nazewnisctwo angielskie?
        self.Sex = sex  # argumenty kalsy z duzej litery?
        self.Age = age
        self.FieldOfWork = fieldofwork
        self.Position = position
        self.Timeincompany = timeincompany
        self.Expirience = expirience
        self.Character = character

        self.Chartable = [sex, age, fieldofwork, position, timeincompany, expirience, character]#to samo do studenta [kolejność cech przekazywancyh]


        self.IterationN = 0  # numer iteracji do poruszania sie po danych i aktualziacji

        #pole na zdalne lub stacjonarne
        self.Tired_Factor = []
        self.WorkConditions_Factor = []
        self.Comfort_Factor = []
        self.SelfImprovement_Factor = []
        self.TeamEffectiveness_Factor = []
        self.Help_Factor = []
        self.TeamComm_Factor = []
        self.RemoteCommFactor = []#[do zrobienia]

        self.Comfort = Comfort(1, 1, 1, 1, 1, 1) # tu nadac poczatkowa wartosci dla 1 iteracji
        self.TeamEff = TeamEffectiveness(2, 2, 2, 2)
        self.TeamComm = TeamCommunication(3, 3, 3, 3, 0)

    def calculateTirednessFactor(self, i):
        a = self.Comfort.TiredWeek[i] * self.Comfort.W[0][0]
        b = self.Comfort.BreakTime[i] * self.Comfort.W[0][1]
        f = self.Comfort.Tired1day[i] * self.Comfort.W[0][5]

        WeightSum = self.Comfort.W[i][0] + self.Comfort.W[i][1] + self.Comfort.W[i][5]
        sum = (a + b + f)
        print('suma to:', sum)
        print('suma wag to: ', WeightSum)
        tired = sum/WeightSum
        k = tired
        self.Tired_Factor.append(k)
        # wyjątek przchytywyanie błedów try()
    def calculateWorkConditionsFactor(self, i):
        a = self.Comfort.Atmosfere[i] * self.Comfort.W[0][2]
        b = self.Comfort.Ergonomics[i] * self.Comfort.W[0][3]#sprawdzic

        WeightSum = self.Comfort.W[i][2] + self.Comfort.W[0][3]
        sum = (a + b)
        print('suma to:', sum)
        print('suma wag to: ', WeightSum)
        tired = sum/WeightSum
        k = tired
        self.WorkConditions_Factor.append(k)

    def calculateComfortFactor(self, i):
        a = self.Tired_Factor[i]
        b = self.WorkConditions_Factor[i]
        lst = (a + b)  #  dzielic przez sume wag czy nie?
        S = lst
        k = S / 2
        self.Comfort_Factor.append(k)

    def calculateSelfImprovementFactor(self, i):
        a = self.Tired_Factor[i]
        b = self.TeamEff.Engagement[i] * self.TeamEff.W[i][2]  #konflikt wagi z śrdenia zwykla?
        lst = (a + b)  # dzielic przez sume wag czy nie?
        S = lst
        k = S / 2
        self.SelfImprovement_Factor.append(k)

    def calculateTeamEffectivnessFactor(self, i):
        a = [self.TeamEff.ProjectComp[i] * self.Comfort.W[0][0]]
        b = [self.TeamEff.Coordination[i] * self.Comfort.W[0][3]]
        c = [self.SelfImprovement_Factor[i]]
        lst = (a + b + c)  # dzielic przez sume wag czy nie?
        S = sum(lst)
        k = S / 3
        self.TeamEffectiveness_Factor.append(k)


    def calculateHelpFactor(self, i):
        a = self.TeamComm.ProactiveComm[i] * self.TeamComm.W[0][1]
        b = self.TeamComm.ReactiveComm[i] * self.TeamComm.W[0][2]
        WeightSum = self.TeamComm.W[i][1] + self.TeamComm.W[0][2]
        sum = (a + b)
        tired = sum / WeightSum
        k = tired

        self.Help_Factor.append(k)

    def calculateRemoteFactor(self,i):
        b = self.TeamComm.R_ComQuality[i] * self.TeamComm.W[0][3]
        a = self.TeamComm.R_AudioVideoQuality[i] * self.TeamComm.W[0][4]
        c = self.TeamComm.R_Understanding[i] * self.TeamComm.W[0][5]

        lst = a + b + c
        S = lst
        k = S / 3
        self.RemoteCommFactor.append(k)

    def calculateTeamCommunicationFactor(self, i, switch):
        a = self.Help_Factor[i]
        b = self.TeamComm.ConflictsFreq[i] * self.TeamComm.W[0][4]


        if switch == 0:
            lst = (a + b)

            k = lst / 2

        if switch == 1:
            self.calculateRemoteFactor(i)
            c = self.RemoteCommFactor[i]
            lst = a + b + c
            S = lst
            k = S / 3

        self.TeamComm_Factor.append(k)


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

    ListMain.append([[1],[1]])

    return ListMain
#745
StartSimluation(1)



