
import unittest
import sys
import math
import os

# Step out of "unittests" dir, into "code" - add to list of module locations
sys.path.append(os.path.join(os.path.dirname(os.path.realpath(__file__)), os.pardir, "code"))

import KataPotter_AG as kp

class TestPotterKata(unittest.TestCase):

    def assertInMarginOfError(self, expected, actual, margin=0.01):
        self.assertTrue(abs(expected - actual) < margin)

    def test_BookPurchaseCounts(self):
        countDict = kp.BookPurchase(("A", "B", "B", "C", "C", "C")).Counts
        self.assertEqual(3, len(countDict))
        self.assertEqual(countDict["A"], 1)
        self.assertEqual(countDict["B"], 2)
        self.assertEqual(countDict["C"], 3)        
        
    def test_Cost_SingleBook(self):
        bp = kp.BookPurchase(("A"))
        self.assertEqual(7, bp.Price)
		
    def test_Cost_ThreeDistinctBooks(self):
        bp = kp.BookPurchase(("A", "B", "C"))
        self.assertInMarginOfError(21 * 0.90, bp.Price)
            
    def test_Cost_FiveBooks(self):
        bp = kp.BookPurchase(("A", "B", "C", "D", "E"))
        self.assertInMarginOfError(35 * 0.75, bp.Price)
            
    def test_Cost_ThreeNondistinctBooks(self):
        bp = kp.BookPurchase(("A", "B", "A"))
        self.assertInMarginOfError((14 * 0.95) + 7, bp.Price)
            
    def test_Cost_SevenBooksWithFiveDistinct(self):
        bp = kp.BookPurchase(("A", "B", "C", "D", "E", "D", "E"))
        # NB: This is effectively 5 distinct plus 2 distinct.
        expectedPrice = (35 * 0.75) + (14 * 0.95)
        self.assertInMarginOfError(expectedPrice, bp.Price)
        		
		
if __name__ == '__main__':
    unittest.main()
