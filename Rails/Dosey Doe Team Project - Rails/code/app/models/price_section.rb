class PriceSection < ActiveRecord::Base
  has_many :shows_price_sections
  has_many :shows, :through => :shows_price_sections

  belongs_to :seating_chart
end