import numpy as np
import pandas as pd
import random
import sqlite3


def sql(which,character, characterint):
        conn = sqlite3.connect('D:\\ZUT\\semestr5\\Projekt\\IPZ2-Teamwork-Simulation\\Data\\DB\\ankieta.db')
        cur = conn.cursor()
        test = '' + character
       # print("SELECT Count(*) FROM studenci WHERE " + str(test) + " =" + str(characterint))
        cur.execute("SELECT Count(*) FROM studenci WHERE " + str(test) + " =" + str(characterint))
        result1 = cur.fetchall()
        ilosc = sum(result1[0])
        wynik = pd.DataFrame(index=[1, 2, 3, 4, 5])
        if which==0:
          for i in range(1, 23):
            tab = []
            for a in range(1, 6):
                 #print("SELECT Count(*) FROM studenci_stacjo WHERE " + str(test) + " ='" + str(characterint)+"' AND st_pyt" + str(i) + "=" + str(a))
                 # cur.execute("SELECT Count(*) FROM ipz WHERE Cecha="+str(test)+" AND Pyt"+str(i)+"="+str(a))
                cur.execute(
                    "SELECT Count(*) FROM studenci_stacjo JOIN studenci on studenci.student_id=studenci_stacjo.student_id WHERE studenci." + str(
                        test) + " ='" + str(characterint) + "' AND st_pyt" + str(i) + "=" + str(a))
                result = cur.fetchall()
                tab.append(sum(result[0]))
                #wynik[a][i] = sum(result[0])
            #print(tab)
            wynik['' + str(i - 1)] = tab
          wynik = wynik / ilosc
          return wynik
        else:
            for i in range(1, 28):
                tab = []
                for a in range(1, 6):
                    # print("SELECT Count(*) FROM studenci_stacjo WHERE " + str(test) + " ='" + str(characterint)+"' AND st_pyt" + str(i) + "=" + str(a))
                    cur.execute(
                        "SELECT Count(*) FROM studenci_zdal JOIN studenci on studenci.student_id=studenci_zdal.student_id WHERE studenci." + str(
                            test) + " ='" + str(characterint) + "' AND zd_pyt" + str(i) + "=" + str(a))
                    result = cur.fetchall()
                    tab.append(sum(result[0]))
                    #wynik[a][i]=sum(result[0])
                wynik['' + str(i - 1)] = tab

            wynik = wynik / ilosc
            #print("test2",wynik)
            return wynik


def losowanie(Baza):
    wylos = []
    for a in range(0, len(Baza.columns)):
        tabRand = []
        for b in range(0, 5):
            n = int(Baza.iloc[b, a] * 100)
            tabRand += n * [b + 1]
        #print(tabRand)
        if len(tabRand)!=0:
         rand = random.choice(tabRand)
        else:
            rand=0
        # print(rand)
        wylos.append(rand)
    return wylos

def answersSelection(dane,TeamType):
    #method = osoby.columns[19:26]
    if(TeamType==0):
        #print(fun1)
     fun1 = pd.DataFrame(index=[1, 2, 3, 4, 5])
     fun1 = fun1.replace(np.nan, 0)  #inaczej sa same nun trzeba zamienic
    else:
        fun1 = pd.DataFrame(index=[1, 2, 3, 4, 5])
        fun1 = fun1.replace(np.nan, 0)  # inaczej sa same nun trzeba zamienic
    k = 0
    #method=['plec','kierunek','rok','stopien','tryb']#co z osobowoscia? Bo 1-6 pytan
    method = ['kierunek', 'rok', 'stopien', 'tryb','osobowosc']
    fun1=sql(TeamType,'plec',dane[k])
    for meth in method:
       # print(dane[k])
        fun = sql(TeamType,meth,dane[k])
        k = k + 1
        fun1 = fun + fun1
    fun1 = fun1 / (len(method)+1)
    print(fun1)

    randarray = losowanie(fun1)
    #print(randarray)
    return randarray

#Interesujące nas wartości
#dla 22 pytan(stacjo)
#[1]zmęczenie  tygodniowe
#[2]czas na przerwę
#[3]atmosfera
#[4]ergonomia
#[5]samodoskonalenie
#[6]Jak często udaje Ci się zrealizować na czas zadania, które dostajesz na zajęciach praktycznych w trybie stacjonarnym?
#[7]Jak często udaje się zrealizować na czas projekty zespołowe w trybie stacjonarnym?
#[8]Jak często nie udaje Ci się zrealizować zadań do wykonania podczas nauki stacjonarnej?
#[9] motywacja
#[10] zmęczenie po dniu
#[11] wpływ miejsca
#[12]organizacja nauki
#[13]pomaganie innym
#[14] pomaganie tobie
#[15]konflikty
#[16]przyrost wiedzy
#[17]kontakt z prowadzącym
#[18]skupienie
#[19]radzenie sobie na studiach
#[21]formy zaliczeń

#dla 27 pytan(zdal)
#[1]zmęczenie  tygodniowe
#[2]czas na przerwę
#[3]atmosfera
#[4]ergonomia
#[5]samodoskonalenie
#[6]Jak często udaje Ci się zrealizować na czas zadania, które dostajesz na zajęciach praktycznych w trybie stacjonarnym?
#[7]Jak często udaje się zrealizować na czas projekty zespołowe w trybie stacjonarnym?
#[8]Jak często nie udaje Ci się zrealizować zadań do wykonania podczas nauki stacjonarnej?
#[9] motywacja
#[10] zmęczenie po dniu
#[11] wpływ miejsca
#[12]organizacja nauki
#[13]pomaganie innym
#[14] pomaganie tobie
#[15]konflikty
#[16]przyrost wiedzy
#[17]kontakt z prowadzącym
#[18]skupienie
#[19]radzenie sobie na studiach
#[21]formy zaliczeń
#[22]komunikator
#[23]kamera
#[24]jakość audi i video
#[25] jakość komunikatora
#[26]Problemy ze zrozumieniem