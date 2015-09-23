class ShowsPriceSection < ActiveRecord::Base
  belongs_to :show
  belongs_to :price_section
end
