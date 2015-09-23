require 'rails_helper'

RSpec.describe TicketLayout, type: :model do
  it 'has minimum valid factory' do
    expect(build :ticket_layout).to be_valid
  end

  it 'is invalid without a name' do
    expect(build :ticket_layout, name: nil).not_to be_valid
  end
end
