import sys
import math

PARAMETER = 0
MIN_VALUE = 1000000000

class impact_ranking:
    def impact_ranking(self, group):
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
                    sum1 += ((1 - PARAMETER) / float(len(edge))) * rank[count][j]
                    numerator += float(weight[i][j]) * float(rank[count][j])
                    denominator += float(weight[i][j])
                sum2 = float(numerator) / float(denominator)
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
            temp[i] = round(temp[i] * MIN_VALUE * 100, 4)
        print temp
        return rank