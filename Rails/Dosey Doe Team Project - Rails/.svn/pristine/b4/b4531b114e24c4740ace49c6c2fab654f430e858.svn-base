class SeatingChart < ActiveRecord::Base
  require 'json'
  has_attached_file :chart_image
  validates_attachment_content_type :chart_image, :content_type => /\Aimage\/.*\Z/
  validates :name, presence: true

  has_many :seats
  has_many :shows
  has_many :price_sections
end
