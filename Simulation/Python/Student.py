from Comfort import Comfort
from TeamEffectiveness import TeamEffectiveness
from TeamCommunication import TeamCommunication
from StudyComfort import StudyComfort
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np

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
        print('suma to:', sum)
        print('suma wag to: ', WeightSum)
        tired = sum/WeightSum
        k = tired
        self.Tired_Factor.append(k)
        # wyjątek przchytywyanie błedów try()
    def calculateWorkConditionsFactor(self, i):
        a = self.Comfort.Atmosfere[i] * self.Comfort.W[0][2]
        b = self.Comfort.Ergonomics[i] * self.Comfort.W[0][3]

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
        b = self.TeamEff.Engagement[i] * self.TeamEff.W[0][2]  #konflikt wagi z śrdenia zwykla?
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

    def calculateTeamCommunicationFactor(self, i, switch):
        a = self.Help_Factor[i]
        b = self.TeamComm.ConflictsFreq[i] * self.TeamComm.W[0][4]


        if switch == 0:
            lst = (a + b)
            S = lst
            k = S / 2

        if switch == 1:
            c = self.TeamComm.RemoteComm[i] * self.TeamComm.W[0][3]
            lst = a + b + c
            S = lst
            k = S / 3

        self.TeamComm_Factor.append(k)

    def calculateStudyComfort_Factor(self,i):
        a = self.StudyComfort.KnowledgeGain[i]*self.StudyComfort.W[0][0]
        b = self.StudyComfort.ProfessorStudentComm[i]*self.StudyComfort.W[0][1]
        c = self.StudyComfort.Focus[i]*self.StudyComfort.W[0][2]
        d = self.StudyComfort.HandleYourself[i]*self.StudyComfort.W[0][3]
        e = self.StudyComfort.FormOfPassing[i]*self.StudyComfort.W[0][4]

        WeightSum = self.StudyComfort.W[0][0]+self.StudyComfort.W[0][1]+self.StudyComfort.W[0][2]+self.StudyComfort.W[0][3]+self.StudyComfort.W[0][4]

        lst = (a + b + c + d + e)  # dzielic przez sume wag czy nie?
        S = sum(lst)
        k = S / WeightSum
        self.StudyComfort_Factor.append(k)