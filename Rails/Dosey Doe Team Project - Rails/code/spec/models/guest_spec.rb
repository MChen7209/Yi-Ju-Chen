require 'rails_helper'

RSpec.describe Guest, type: :model do
  it 'is has a minimum valid factory' do
    expect(build :guest).to be_valid
  end

  it 'is valid with an email' do
    expect(build :guest, email: Faker::Internet.email).to be_valid
  end

  it 'is valid with a first_name' do
    expect(build :guest, first_name: Faker::Name.first_name).to be_valid
  end

  it 'is valid with a last_name' do
    expect(build :guest, last_name: Faker::Name.last_name).to be_valid
  end

  it "has a value of 'Guest' for first_name" do
    expect(build(:guest).first_name).to eq 'Guest'
  end

  it "has a value of '' for last_name" do
    expect(build(:guest).last_name).to eq ''
  end
end
