
class TeamCommunication:  # jakosc komuikacj zdalnej jak zrobic ??
    def __init__(self, reactiveComm, proactiveComm, remotecomm, conflictsfreq, remoteswitch):

        self.ReactiveComm = []
        self.ProactiveComm = []
        self.ConflictsFreq = []

        self.R_ComQuality = []# R_ czyli remote paramtry tylko dla zdalnej
        self.R_AudioVideoQuality = []
        self.R_Understanding = []

        self.W = []
        self.RemoteSwitch = remoteswitch

        #self.ReactiveComm.append(reactiveComm)# [tymaczasowe]
        #self.ProactiveComm.append(proactiveComm)
        #self.ConflictsFreq.append(conflictsfreq)
        #self.R_ComQuality.append(conflictsfreq)
        #self.R_AudioVideoQuality.append(conflictsfreq)
        #self.R_Understanding.append(conflictsfreq)

    def weightsUpdate(self, w1, w2, w3, w4, w5, w6):
        k = [w1, w2, w3, w4, w5, w6]
        self.W.append(k)

    def ArgumentsUpdate(self,  reactiveComm, proactiveComm, conflicts):#wariant na zdalne
        self.ReactiveComm.append(reactiveComm)
        self.ProactiveComm.append(proactiveComm)
        self.ConflictsFreq.append(conflicts)


    def R_ArgumentsUpdate(self,  reactiveComm, proactiveComm, conflicts, r_ComQuality, r_AudioVideoQuality ,r_Understanding ):#wariant na zdalne
        self.ReactiveComm.append(reactiveComm)
        self.ProactiveComm.append(proactiveComm)
        self.ConflictsFreq.append(conflicts)
        self.R_ComQuality.append(r_ComQuality)
        self.R_AudioVideoQuality.append(r_AudioVideoQuality)
        self.R_Understanding.append(r_Understanding)