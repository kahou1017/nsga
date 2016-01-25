import random
import networkx as nx
import matplotlib.pyplot as plt
import sys
import math
import os
import main

USER_COUNT = main.USER_COUNT
MAX_HISTORY = main.MAX_HISTORY
PARAMETER = main.PARAMETER
MIN_VALUE = main.MIN_VALUE
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

def sum(data):
    sum_data = dict()
    for i in iter(data):
        for j in iter(data[i]):
            sum = 0
            if (sum_data.get(i, 'null') == 'null'):
                sum_data[i] = dict()
            if(data[i].get(j, 'null') != 'null'):
                if (sum_data[i].get(j, 'null') == 'null'):
                    sum += data[i][j]
            if(data.get(j ,'null') != 'null'):
                if(data[j].get(i, 'null') != 'null'):
                        sum += data[j][i]
            if(sum > 0):
                sum_data[i][j] = sum
    return sum_data

def sum_data(data):
    sum_data = dict()
    for i in iter(data):
        value = [value for value in range(len(data)) if value != i]
        for j in value:
            sum = 0
            if (sum_data.get(i, 'null') == 'null' and sum_data.get(j, 'null') == 'null'):
                sum_data[i] = dict()
                if(data[i].get(j, 'null') != 'null'):
                    if (sum_data[i].get(j, 'null') == 'null'):
                        sum += data[i][j]
                if(data.get(j,'null') != 'null'):
                    if(data[j].get(i, 'null') != 'null'):
                        sum += data[j][i]
                if(sum > 0):
                    sum_data[i][j] = sum
            #elif(sum_data.get(i, 'null') == 'null' and sum_data.get(j, 'null') != 'null'):
                #continue
            elif(sum_data.get(i, 'null') != 'null'):
                if(data[i].get(j, 'null') != 'null'):
                    if (sum_data[i].get(j, 'null') == 'null'):
                        sum += data[i][j]
                if(data.get(j,'null') != 'null'):
                    if(data[j].get(i, 'null') != 'null'):
                        sum += data[j][i]
                if(sum > 0):
                    sum_data[i][j] = sum
            else:
                continue
    return sum_data

def writeFile(data):
    if not os.path.exists('sample'):
        os.makedirs('sample')
    file = open(PATH + FILE_NAME, 'w')
    file.writelines('userCount: {0}\n'.format(USER_COUNT).encode('utf-8'))
    #file.writelines('maxConnect: {0}\n'.format(MAX_CONNECT).encode('utf-8'))
    file.writelines('{0:6} {1:6} {2:5}\n'.format("User(i)", "User(j)", "Count").encode('utf-8'))
    for i in iter(data):
        for j in iter(data[i]):
            file.writelines('{0:6} {1:6} {2:5}\n'.format(i, j, data[i][j]).encode('utf-8'))
    file.close()

def readFile():
    sample = dict()
    file = open(PATH + FILE_NAME, 'r')
    for i, line in enumerate(file):
        if (i >= 2):
            list = map(int, line.split())
            if(sample.get(list[0], 'null') == 'null'):
                sample[list[0]] = dict()
                sample[list[0]][list[1]] = list[2]
            else:
                if(sample[list[0]].get(list[1], 'null') == 'null'):
                    sample[list[0]][list[1]] = list[2]
    file.close()
    return sample

def drawFig(data):
    G = nx.Graph()
    sum = 0.0
    for i in iter(data):
        G.add_node(i)
        for j in iter(data[i]):
            if(data[i][j] > sum):
                sum = float(data[i][j])
    for i in iter(data):
        for j in iter(data[i]):
            value = float(data[i][j])
            edgeWeight = float(value / sum)
            G.add_edge(i, j, weight=edgeWeight)
    #print(G.edge)
    #nx.draw(G)
    #plt.show()

    #elarge = [(u,v) for (u,v,d) in G.edges(data=True) if d['weight'] >0.5]
    #esmall = [(u,v) for (u,v,d) in G.edges(data=True) if d['weight'] <=0.5]

    #pos = nx.spring_layout(G) # positions for all nodes
    pos = nx.circular_layout(G)

    # nodes
    nx.draw_networkx_nodes(G, pos, node_size=500)

    # edges
    #nx.draw_networkx_edges(G, pos, edgelist=elarge, width=2)
    #nx.draw_networkx_edges(G, pos, edgelist=esmall, width=2, alpha=0.5, edge_color='b', style='dashed')

    nx.draw_networkx_edges(G, pos)
    nx.draw_networkx_edge_labels(G, pos, font_size=10)

    # labels
    nx.draw_networkx_labels(G, pos, font_size=12, font_family='sans-serif')

    plt.axis('off')
    plt.savefig(PATH + FIG_NAME) # save as png
    #plt.show() # display

    return G.edge

def impact_ranking(group):
    rank = dict()
    edge = dict()
    weight = dict()
    sum = 0.0

    for i in iter(group):
        for j in iter(group[i]):
            if(group[i][j] > sum):
                sum = float(group[i][j])

    for i in iter(group):
        for j in iter(group[i]):
            if(edge.get(i, 'null') == 'null'):
                edge[i] = dict()
            if(edge.get(j, 'null') == 'null'):
                edge[j] = dict()
            edge[i][j] = group[i][j]
            edge[j][i] = group[i][j]

    for i in iter(edge):
        for j in iter(edge[i]):
            if(weight.get(i, 'null') == 'null'):
                weight[i] = dict()
            if(weight.get(j, 'null') == 'null'):
                weight[j] = dict()
            value = float(edge[i][j])
            edgeWeight = float(value / sum)
            weight[i][j] = edgeWeight

    count = 0
    for i in iter(edge):
        if(rank.get(count, 'null') == 'null'):
            rank[count] = dict()
        rank[count][i] = float(1.0) / float(len(edge))
    z = sys.float_info.max
    e = float(1) / float(MIN_VALUE)
    while z > e:
        value = 0.0
        for i in iter(edge):
            sum1 = 0.0
            numerator = 0.0
            denominator = 0.0
            if(rank.get(count, 'null') == 'null'):
                rank[count] = dict()
            for j in iter(edge[i]):
                sum1 += ((1 - PARAMETER) / float(len(edge))) * float(rank[count][j])
                numerator += float(weight[i][j]) * float(rank[count][j])
                #denominator += float(weight[i][j])
                denominator += float(rank[count][j])
            sum2 = float(numerator) / float(denominator)
            #sum2 = float(numerator) / float(total_count/sum)
            if(rank.get(count + 1, 'null') == 'null'):
                rank[count + 1] = dict()
            rank[count + 1][i] = sum1 + (PARAMETER * sum2)
        for x in iter(edge):
            value += math.fabs(rank[count + 1][x] - rank[count][x])
        z = value
        print z
        count += 1
    print count
    print rank[len(rank) - 1]
    temp = rank[len(rank) - 1]
    for i in iter(temp):
        temp[i] = round(temp[i] * 100, 4)
        #temp[i] = round(temp[i] * MIN_VALUE * 100, 4)
    print temp
    return rank