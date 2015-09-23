require 'rails_helper'

RSpec.describe Seat, type: :model do
  it 'has a minimum valid factory' do
    expect(build :seat).to be_valid
  end

  it 'is invalid without an x value' do
    expect(build :seat, x: nil).not_to be_valid
  end

  it 'is invalid without a y value' do
    expect(build :seat, y: nil).not_to be_valid
  end

  it 'is invalid without a seat_number value' do
    expect(build :seat, seat_number: nil).not_to be_valid
  end

  it 'is invalid without a table_number value' do
    expect(build :seat, table_number: nil).not_to be_valid
  end

  it 'belongs_to a seating chart' do
    association = Seat.reflect_on_association :seating_chart
    expect(association.macro).to eq :belongs_to
  end

  it 'has_many tickets' do
    association = Seat.reflect_on_association :tickets
    expect(association.macro).to eq :has_many
  end
end
