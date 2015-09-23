class Show < ActiveRecord::Base
  include ShowsHelper

  validates :show_date, presence: true
  validate :show_date_is_in_future, on: :create
  validates :doors_open, presence: true
  validates :show_starts, presence: true
  validates :venue, presence: true
  validates :artist, presence: true
  validates :dinner_starts, presence: true
  validates :dinner_ends, presence: true
  validates :seating_chart, presence: true

  belongs_to :venue
  belongs_to :seating_chart
  has_many :tickets
  has_many :shows_price_sections
  has_many :price_sections, through: :shows_price_sections

  after_initialize :set_default_times

  has_attached_file :artist_image, :styles => { :medium => "300x300>", :thumb => "100x100>" }, :default_url => "test_image_1.jpg"
  validates_attachment_content_type :artist_image, :content_type => /\Aimage\/.*\Z/

  def set_default_times
    self.doors_open = utc_datetime_from_time('6:00 PM') if doors_open.nil?
    self.dinner_starts = utc_datetime_from_time('6:00 PM') if dinner_starts.nil?
    self.dinner_ends = utc_datetime_from_time('7:30 PM') if dinner_ends.nil?
    self.show_starts = utc_datetime_from_time('8:30 PM') if show_starts.nil?
  end

  def show_date_is_in_future
    return unless show_date.present? && show_date < Time.zone.today
    errors.add(:show_date, 'must not be in the past')
  end

  self.per_page = 7

  def tickets_as_json(current_user)
    ticket_array = []
    tickets.each do |ticket|
      ticket_array.push ticket.as_json(current_user)
    end
    ticket_array
  end
end
