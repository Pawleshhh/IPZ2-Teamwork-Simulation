from Worker import Worker
from Student import Student

import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
import ProbFunctions

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

        self.TeamWorkType = mode # zdalne1 lub stacjonarne 0
        self.TeamType = mode2 #pracownik 1 student 0

        if mode2 == 1:#dwie opcje
            for i in range(teamMemAmount):
                self.PersonList.append(
                    Worker(Persons[i][0],Persons[i][1],Persons[i][2],Persons[i][3],Persons[i][4],Persons[i][5],Persons[i][6]))  # 'M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert'
        if mode2 == 0:
            for i in range(teamMemAmount):
                self.PersonList.append(
                    Student(Persons[i][0],Persons[i][1],Persons[i][2],Persons[i][3],Persons[i][4],Persons[i][5]))  # 'M', '30-40', 'IT', 'Specjalist', '2', '3-5 years', 'introvert'

    def calculateIteration(self, iteration, remoteSwitch):

        sumT = 0
        sumWC = 0
        sumC = 0
        sumSI = 0
        sumTE = 0
        sumH = 0
        sumTC = 0
        sumSC = 0

        for i in range(self.TeamMemAmount):#aktualizowanie wag do przeliczalnia tutaj
            self.PersonList[i].TeamComm.weightsUpdate(1, 1, 1, 1, 1, 1)
            self.PersonList[i].Comfort.weightsUpdate(1, 6, 1, 1, 1, 1)
            self.PersonList[i].TeamEff.weightsUpdate(1, 1, 1, 1)
            if(self.TeamType==0):
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

        self.Team_Study_Comfort_Factor.append(sumSC/self.TeamMemAmount)

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

        #subplots_adjust(left=None, bottom=None, right=None, top=None, wspace=None, hspace=None)

        left = 0.125  # the left side of the subplots of the figure
        right = 0.9  # the right side of the subplots of the figure
        bottom = 0.1  # the bottom of the subplots of the figure
        top = 0.9  # the top of the subplots of the figure
        wspace = 0.2  # the amount of width reserved for blank space between subplots
        hspace = 0.6  # the amount of height reserved for white space between subplots

        plt.subplots_adjust(left, bottom, right, top, wspace, hspace)
        plt.show()

    def Iteration(self):
        index=0
        for j in range(self.IterationAmount):

            for i in range(self.TeamMemAmount):
                Answers = ProbFunctions.answersSelection(self.PersonList[i].Chartable, self.TeamType)
                #Answers = ProbFunctions.A_inject(index)
                index = index +1
                print("poszlo ",index)
                if self.TeamWorkType == 0:
                    self.PersonList[i].Comfort.ArgumentsUpdate(Answers[0],
                    Answers[1], Answers[2], Answers[3], Answers[4], Answers[9])
                    self.PersonList[i].TeamEff.ArgumentsUpdate(Answers[6], Answers[5], Answers[8], Answers[11])
                    self.PersonList[i].TeamComm.ArgumentsUpdate(Answers[13], Answers[12], Answers[14])
                    self.PersonList[i].StudyComfort.ArgumentsUpdate(Answers[15],Answers[16],Answers[17],Answers[18],Answers[20])

                    #self.PersonList[i].TeamComm.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe] tymczasowy update wag
                    #self.PersonList[i].TeamEff.weightsUpdate(1, 2, 3, 4)  # [tymaczasowe]
                    #self.PersonList[i].Comfort.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe]

                if self.TeamWorkType == 1:
                    self.PersonList[i].Comfort.ArgumentsUpdate(Answers[22],
                    Answers[23], Answers[24], Answers[25], Answers[26], Answers[31])
                    self.PersonList[i].TeamEff.ArgumentsUpdate(Answers[28], Answers[27], Answers[30], Answers[33])
                    self.PersonList[i].TeamComm.R_ArgumentsUpdate(Answers[35], Answers[34], Answers[36], Answers[46], Answers[45],Answers[47] )
                    self.PersonList[i].StudyComfort.ArgumentsUpdate(Answers[37], Answers[38], Answers[39], Answers[40],
                                                                    Answers[42])
                    #self.PersonList[i].TeamComm.weightsUpdate(1, 2, 3, 4, 5)  # # [tymaczasowe] tymczasowy update wag
                    #self.PersonList[i].TeamEff.weightsUpdate(1, 2, 3, 4)  # [tymaczasowe]
                    #self.PersonList[i].Comfort.weightsUpdate(1, 2, 3, 4, 5, 6)  # [tymaczasowe]

            self.calculateIteration(j, self.TeamWorkType)

        #self.plotData()
        self.plotDataV2()

    def display(self):
        print("tired: ",self.Team_Tired_Factor)
        print("work conditions: ",self.Team_WorkConditions_Factor)
        print("comfort: ",self.Team_Comfort_Factor)
        print("selfimprov: ",self.Team_SelfImprovement_Factor)
        print("team eff: ",self.Team_TeamEffectiveness_Factor)
        print("help: ",self.Team_Help_Factor)
        print("team communication: ",self.Team_TeamComm_Factor)
        print("study comfort: ",self.Team_Study_Comfort_Factor)
