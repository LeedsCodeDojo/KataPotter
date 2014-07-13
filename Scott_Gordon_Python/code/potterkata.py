
class PotterKata:

	basePrice = 7.00
	discounts = {2: 0.95, 3: 0.90, 4:0.80, 5:0.75}

	def __init__(self, bookArray):
		self.books = bookArray
				
	def total(self):
		price = self.basePrice
		
		distinctBooks = len(self.findDistinctBooks())
		numOfBooks = len(self.books)
		
		if distinctBooks in self.discounts:
			price *= self.discounts[distinctBooks]
			
		total = distinctBooks*price
		
		remainingBooks = numOfBooks - distinctBooks
		if remainingBooks:
			total += self.basePrice * remainingBooks
	
		return total
	
	def findDistinctBooks(self):
		distinctBooks = {}
		
		for book in self.books:
			distinctBooks[book.title] = distinctBooks.get(book.title, 0) + 1
			
		return distinctBooks
		
class Book:
	def __init__(self, title):
		self.title = title
		
	def __str__(self):
		return 'Book(' + self.title + ')'
		
	def __repr__(self):
		return 'Book(' + self.title + ')'