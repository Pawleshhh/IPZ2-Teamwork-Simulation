
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
            self.KnowledgeGainappend(knowledgegain)
            self.ProfessorStudentComm.append(professorStudentComm)
            self.Focus.append(focus)
            self.HandleYourself.append(handleYourself)
            self.FormOfPassing.append(formOfPassing)

