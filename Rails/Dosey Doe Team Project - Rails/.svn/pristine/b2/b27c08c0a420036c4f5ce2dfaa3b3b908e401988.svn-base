require 'rails_helper'

RSpec.describe Venue, type: :model do
  it 'has a minimum valid factory' do
    expect(build :venue).to be_valid
  end

  it 'is invalid without a name' do
    expect(build :venue, name: nil).not_to be_valid
  end

  it 'is invalid without an address_line1' do
    expect(build :venue, address_line1: nil).not_to be_valid
  end

  it 'is invalid without a city' do
    expect(build :venue, city: nil).not_to be_valid
  end

  it 'is invalid without a state' do
    expect(build :venue, state: nil).not_to be_valid
  end

  it 'is invalid without a zip' do
    expect(build :venue, zip: nil).not_to be_valid
  end

  it 'has_many shows' do
    association = Venue.reflect_on_association(:shows)
    expect(association.macro).to eq :has_many
  end
end
