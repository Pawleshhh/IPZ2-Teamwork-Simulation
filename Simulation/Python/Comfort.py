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


        self.TiredWeek.append(tiredWeek) #dodaj wartosc do tej talbice
        self.BreakTime.append(breakTime)  # [tymaczasowe]
        self.Atmosfere.append(atmosfere)
        self.Ergonomics.append(ergonomics)
        self.SelfImprovement.append(selfImpovement)
        self.Tired1day.append(tired1day)

        self.TiredWeek.append(tiredWeek)
        self.BreakTime.append(breakTime)
        self.Atmosfere.append(atmosfere)
        self.Ergonomics.append(ergonomics)
        self.SelfImprovement.append(selfImpovement)
        self.Tired1day.append(tired1day)


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