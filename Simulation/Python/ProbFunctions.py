import numpy as np
import pandas as pd
import random
import os
import xlrd
#dane = [1, 1, 2, 2, 1, 1, 2]  # wartości danych cech


def funkcja(osoby, nazwa1, nazwa2, c):
    os = (osoby[osoby['' + nazwa1] == nazwa2])

    all = len(os)
    #print('os wynosi: ', all)
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

def answersSelection(dane,TeamType):
    #osoby = pd.read_excel('kopia.xlsx')

    if TeamType==1:
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
        #print(method) 2604
        c = 74



    #method = osoby.columns[19:26]
    fun1 = pd.DataFrame(index=[1, 2, 3, 4, 5], columns=osoby.columns[26:c])
    fun1 = fun1.replace(np.nan, 0)  #inaczej sa same nun trzeba zamienic
    k = 0

    for b in method:
        #print(dane[k]) #2604
        fun = funkcja(osoby, b, dane[k], c)  #dane[k]-tutaj przekaż echy osoby  osoby
        k = k + 1
        fun1 = fun1 + fun
    fun1 = fun1 / len(method)
# print(fun1)

    randarray = losowanie(fun1)
    #print(randarray) #2604
    return randarray

def A_inject(liczba):
    osoby = pd.read_excel(os.path.join('D:\ZUT\semestr5\Projekt_inżynier\IPZ_ABM', "ABM", "studenci.xlsx"),
        engine='openpyxl',)
    tab=[]
    i=0;
    for a in range(25,74):
        tab.append(osoby.iloc[liczba,a])
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