require_relative '../lib/basket'

describe Basket do 
  it 'should return 700 of one selection' do
    my_basket = Basket.new(["one"])
    expect(my_basket.total).to eq 700
  end

  it 'should return 0 if the basket is empty' do
    my_basket = Basket.new
    expect(my_basket.total).to eq 0
  end

  it 'should make 5% of for two books' do
    my_basket = Basket.new(["one","two"])
    expect(my_basket.total).to eq 0.95*(700*2)
  end

  it 'should return 10% when three unique books are in the basket' do
    my_basket = Basket.new(["one","two", "three"])
    expect(my_basket.get_discount).to eq 0.10
  end

  it 'should return 20% when 4 unique books' do
    my_basket = Basket.new(["one", "two", "three", "Four"])
    expect(my_basket.get_discount).to eq 0.2
  end

  it 'should return 1400 total for two same books' do
    my_basket = Basket.new(["one", "one"])
    expect(my_basket.total).to eq 1400
  end

  it 'should calculate total correctly for two different books and one same' do
    my_basket = Basket.new(["one", "one", "two"])
    expect(my_basket.total).to eq 0.95*(700*2)+700
  end

  # it 'should calculate total correctly for two different sets of discounted books' do
  #   my_basket = Basket.new(["one", "one", "two", "two", "three"])
  #   expect(my_basket.total).to eq 0.95*(700*2)+0.90*(700*3)
  # end

end