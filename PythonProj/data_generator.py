import random
import main

USER_COUNT = main.USER_COUNT
MAX_HISTORY = main.MAX_HISTORY
PARAMETER = main.PARAMETER
MIN_VALUE = main.MIN_VALUE
#FILE_NAME = str(USER_COUNT) + '_' + str(MAX_CONNECT) + '.txt'
SAMPLE_NUM = main.SAMPLE_NUM
FILE_NAME = main.FILE_NAME
FIG_NAME = main.FIG_NAME
PATH = main.PATH

def data_generator(userCount):
    # add new object
    obj = dict()
    # initial while loop number
    userIdx = 0
    while userIdx < userCount:
        # setting user connect number
        connectNum = random.randint(0, userCount - 1)
        #connectNum = maxConnect
        # Generate a random array ignore userIdx
        randarray = [i for i in random.sample(range(0, userCount), userCount) if i != userIdx]
        # connect user to user
        for randomUser in random.sample(randarray, connectNum):
            # estimation userIdx is exist
            if (obj.get(userIdx, 'null') == 'null'):
                obj[userIdx] = dict()
            if(obj[userIdx].get(randomUser, 'null') == 'null'):
                obj[userIdx][randomUser] = random.randint(1, MAX_HISTORY)
        userIdx += 1
    return obj