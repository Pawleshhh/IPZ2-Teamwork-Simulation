import pandas as pd
import numpy as np


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




