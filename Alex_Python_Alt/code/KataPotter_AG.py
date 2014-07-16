class BookPurchase:
    
    _basePrice = 7.00
    _discountedRates = { 2: 0.95, 3: 0.90, 4: 0.80, 5: 0.75 }
    
    def __init__(self, TitleList):
        self.Counts = {}
        for t in TitleList:
            self.Counts[t] = self.Counts.get(t, 0) + 1	
            
    @property
    def Price(self):
        """Public property used to return discounted price for entire purchase."""
        return self._calcPrice(self.Counts)

    def _priceDistinctSet(self, Count):
        """Calculates price for a set of distinct books."""
        return Count * self._basePrice * self._discountedRates.get(Count, 1)

    def _calcPrice(self, CountDict, Iteration=0):
        """Calculates and sums distinct set prices in multiple recursive passes."""
        distinctCount = len([i for i in CountDict.items() if i[1] > Iteration])
        if distinctCount == 0:
            return 0
        else:
            iterationPrice = self._priceDistinctSet(distinctCount)
            return  iterationPrice + self._calcPrice(CountDict, Iteration + 1)
