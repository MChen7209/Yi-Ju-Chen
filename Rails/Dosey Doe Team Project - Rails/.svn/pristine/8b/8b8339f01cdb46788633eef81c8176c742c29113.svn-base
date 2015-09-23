require 'rails_helper'

RSpec.describe Ticket, type: :model do
  it 'has a valid factory' do
    expect(build :ticket).to be_valid
  end

  it 'has a valid customer_reserved_ticket factory' do
    expect(build :customer_reserved_ticket).to be_valid
  end

  it 'has a valid admin_reserved_ticket factory' do
    expect(build :admin_reserved_ticket).to be_valid
  end

  it 'has a valid guest_reserved_ticket factory' do
    expect(build :guest_reserved_ticket).to be_valid
  end

  it 'has a valid sold_ticket factory' do
    expect(build :sold_ticket).to be_valid
  end

  it 'is invalid without a show' do
    expect(build :ticket, show: nil).not_to be_valid
  end

  it 'is valid without a user' do
    expect(build :ticket, user: nil).to be_valid
  end

  it 'is valid without a reserved_until' do
    expect(build :ticket, reserved_until: nil).to be_valid
  end

  it 'is invalid without a status' do
    expect(build :ticket, status: nil).not_to be_valid
  end

  context 'is valid with a status of' do
    it 'open' do
      expect(build :ticket, status: :open).to be_valid
    end

    it 'reserved' do
      expect(build :admin_reserved_ticket).to be_valid
    end

    it 'sold' do
      expect(build :ticket, status: :sold).to be_valid
    end
  end

  it 'is invalid without a status of open, reserved, or sold' do
    expect(build :ticket, status: :whatever).not_to be_valid
  end

  it 'is invalid without a reserved_until if its status is reserved' do
    expect(build :ticket, status: :reserved, reserved_until: nil).not_to be_valid
  end

  it 'belongs_to a user' do
    user_association = Ticket.reflect_on_association :user
    expect(user_association.macro).to eq :belongs_to
  end

  it 'belongs_to a show' do
    show_association = Ticket.reflect_on_association :show
    expect(show_association.macro).to eq :belongs_to
  end

  it 'belongs to a seat' do
    seat_association = Ticket.reflect_on_association :seat
    expect(seat_association.macro).to eq :belongs_to
  end

  describe 'Ticket#update_status' do
    it 'does not modify the status if the status is sold' do
      sold_ticket = create :ticket, status: 'sold'
      sold_ticket.update_status
      expect(sold_ticket.status).to eq 'sold'
    end

    it 'does not modify the status if the ticket is reserved until a future time' do
      reserved_ticket = create :ticket, status: 'reserved',
                                        reserved_until: DateTime.current + 10.minutes
      reserved_ticket.update_status
      expect(reserved_ticket.status).to eq 'reserved'
    end

    it 'sets the status to open if its reserved until time is past' do
      reserved_ticket = create :ticket, status: 'reserved',
                                        reserved_until: DateTime.current - 10.minutes
      reserved_ticket.update_status
      expect(reserved_ticket.status).to eq 'open'
    end
  end
end
