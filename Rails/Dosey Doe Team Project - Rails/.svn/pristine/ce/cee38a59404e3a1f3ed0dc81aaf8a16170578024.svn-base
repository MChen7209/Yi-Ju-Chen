class Seat < ActiveRecord::Base
  validates :x, presence: true
  validates :y, presence: true
  validates :seat_number, presence: true
  validates :table_number, presence: true

  has_many :tickets
  belongs_to :seating_chart
end
