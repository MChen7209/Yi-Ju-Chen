require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Venues features', :type => :feature do
  before :each do
      login_as create :test_admin
  end

  after :each do
    Warden.test_reset!
  end

  describe 'Adding a venue as an admin' do

    it 'adds a venue if input is valid' do
      expect {
        visit new_admin_venue_path
        fill_in 'venue_name', with: 'The Medium-Sized Barn'
        fill_in 'venue_address_line1', with: '12345 Fake St.'
        fill_in 'venue_city', with: 'Fakeland'
        fill_in 'venue_state', with: 'TX'
        fill_in 'venue_zip', with: '00000'
        fill_in 'venue_ticket_layout', with: 'Test Layout'
        click_button 'Save'
      }.to change(Venue, :count).by 1
    end

    it 'does not add a venue if input is invalid' do
      expect {
        visit new_admin_venue_path
        fill_in 'venue_name', with: ''
        click_button 'Save'
      }.to change(Venue, :count).by 0
    end
  end

  describe 'Editing a venue as an admin' do
    it 'changes the name of the venue to the input name' do
      test_venue = create :venue
      test_venue.ticket_layout = TicketLayout.new(name: 'Test', venue_id: test_venue.id)
      visit edit_admin_venue_path(test_venue)
      fill_in 'venue_name', with: 'The Somewhat-Small Barn'
      click_button 'Save'
      expect(Venue.first.name).to eq 'The Somewhat-Small Barn'
    end
  end

  describe 'On the admin venue list, clicking on' do
    it 'select routes to admins venue show page' do
      test_venue = create :venue, name: 'Test Barn', address_line1: '123 fake street', city: 'city', state: 'state', zip: '00000'
      test_venue.ticket_layout = TicketLayout.new(name: 'Test', venue_id: test_venue.id)
      visit admin_venues_path
      click_on 'Select'
      expect(page).to have_text 'Upcoming Shows'
      expect(page).to have_text '123 fake street'
    end
  end

  describe 'On the admin upcoming shows page, clicking on' do
    it 'Select Show routes to the shows seat selection page.' do
      test_venue = create :venue, name: 'Test Barn', address_line1: '123 fake street', city: 'city', state: 'state', zip: '00000'
      test_venue.ticket_layout = TicketLayout.new(name: 'Test', venue_id: test_venue.id)
      test_show = create :show, artist: 'Artist', venue: test_venue

      visit admin_venues_path
      click_on 'Select'
      click_on 'Select Show'

      expect(page).to have_text 'Artist'
      expect(page).to have_text 'Test Barn'
    end
  end
end