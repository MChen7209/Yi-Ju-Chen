require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Ticket Layout features', :type => :feature do
  before :each do
    login_as create :admin
  end

  after :each do
    Warden.test_reset!
  end

  describe 'Editing a ticket layout as an Admin' do

    it 'changes a ticket layout name if a ticket layout name is valid' do
        layout = create :ticket_layout, name: 'Ticket Layout 1'
        visit edit_admin_ticket_layout_path(layout)
        fill_in 'ticket_layout_name', with: 'Test 1 2'
        click_button 'Save'
        expect(TicketLayout.first.name).to eq 'Test 1 2'
    end
  end
end