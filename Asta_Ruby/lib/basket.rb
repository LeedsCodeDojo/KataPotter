#five books £7 each with the discount
#github.com/LeedsCodeDojo/KataPotter
class Basket
  
  DISCOUNTS = [ 0, 0, 0.05, 0.10, 0.2, 0.25]
  PRICE = 700

  def initialize(basket_contents = [])
    @basket_contents = basket_contents
  end

  def get_discount
    unique_count = @basket_contents.uniq.length
    unique_count > 1 ? DISCOUNTS[unique_count] : 0
  end

  def check_possible_discounts_combinations
    #group items
    #@basket_contents.map{|book| }
  end

  def total
    return 0 if @basket_contents.empty? 
    #return 0.95*(700*2)+0.90*(700*3) if @basket_contents.length > 4
    total = PRICE * @basket_contents.length
    discount = PRICE * get_discount * @basket_contents.uniq.length
    return  total- discount
  end

end