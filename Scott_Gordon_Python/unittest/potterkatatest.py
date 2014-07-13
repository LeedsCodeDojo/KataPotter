
import unittest
import sys
import math

pathtofolder = '<PATHTOFOLDER>\\potterkata'
sys.path.append(pathtofolder +'\\code')
sys.path.append(pathtofolder +'\\unittest')

import potterkata

class TestPotterKata(unittest.TestCase):

	def test_checkoutClass(self):
		listOfBooks = []
		test_obj = potterkata.PotterKata(listOfBooks)
		self.assertIsInstance(test_obj, potterkata.PotterKata)
		
	def test_bookClassSingleBook(self):
		listOfBooks = [potterkata.Book("A")]
		test_obj = potterkata.PotterKata(listOfBooks)
		self.assertEqual(7, test_obj.total())
		
	def test_bookClassThreeDistinctBooks(self):
		listOfBooks = [potterkata.Book("A"), potterkata.Book("B"), potterkata.Book("C")]
		test_obj = potterkata.PotterKata(listOfBooks)
		self.assertTrue(abs(21*0.90 - test_obj.total()) < 0.01)
		
	def test_bookClassFiveBooks(self):
		listOfBooks = [potterkata.Book("A"), potterkata.Book("B"), potterkata.Book("C"), potterkata.Book("D"), potterkata.Book("E")]
		test_obj = potterkata.PotterKata(listOfBooks)
		self.assertTrue(abs(35*0.75 - test_obj.total()) < 0.01)
		
	def test_bookClassThreeNondistinctBooks(self):
		listOfBooks = [potterkata.Book("A"), potterkata.Book("B"), potterkata.Book("A")]
		test_obj = potterkata.PotterKata(listOfBooks)
		expectedPrice = 14*0.95 + 7
		self.assertTrue(abs(expectedPrice - test_obj.total()) < 0.01)
		
	
	def test_bookClassSevenBooksWithFiveDistinct(self):
		listOfBooks = [potterkata.Book("A"), potterkata.Book("B"), potterkata.Book("C"), potterkata.Book("D"), potterkata.Book("E"), potterkata.Book("D"), potterkata.Book("E")]
		test_obj = potterkata.PotterKata(listOfBooks)
		expectedPrice = 35*0.75 + 14
		self.assertTrue(abs(expectedPrice - test_obj.total()) < 0.01)
		
		
if __name__ == '__main__':
    unittest.main()
