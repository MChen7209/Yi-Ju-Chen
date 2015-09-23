class Ticket < ActiveRecord::Base
  include TicketsHelper

  validates :show, presence: true
  validates :status, presence: true
  validate :valid_status?, on: [:create, :save]
  validates_presence_of :reserved_until, if: -> { status == 'reserved' }

  after_find :update_status

  belongs_to :show
  belongs_to :user
  belongs_to :seat

  def valid_status?
    return unless status != 'open' && status != 'reserved' && status != 'sold'
    errors.add :status, 'must be open, reserved, or sold'
  end

  def reservation_time
    10.minutes
  end

  def as_json(current_user = nil)
    { 'id' => id, 'status' => json_status(current_user),
      'x' => seat.x, 'y' => seat.y, 'seat_number' => seat.seat_number,
      'table_number' => seat.table_number }
  end

  def reserve_ticket(user)
    update_status
    return unless self.open?
    self.reserved_until = DateTime.current + reservation_time
    self.user = user
    self.status = 'reserved'
    save
    refresh_all_tickets(user)
  end

  def update_status
    return if status == 'sold' || status == 'open'
    return if reserved_until.nil?
    return unless reserved_until.past?
    self.status = 'open'
    self.user = nil
    self.reserved_until = nil
    save
  end

  def json_status(current_user)
    return 'user reserved' if user == current_user && (status == 'sold' || status == 'reserved')
    return 'open' if status == 'open'
    'closed'
  end

  def open?
    status == 'open'
  end
end
