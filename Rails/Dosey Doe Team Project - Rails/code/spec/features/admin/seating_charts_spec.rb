require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Seating Charts features', type: :feature do
  let :create_seating_chart do

  end

  before :each do
    login_as create :godmode_admin
    visit root_path
    click_link 'user_name'
    click_link 'admin_navbar_seating_charts'
    click_link 'New Seating Chart'
  end

  after :each do
    Warden.test_reset!
  end

  describe 'Adding a seating chart as an Admin', js: true do
    xit 'adds a seating chart if a seating chart is valid' do
      expect{
        fill_in 'seating_chart_name', with: 'Test'
        fill_in 'sidebar_seat_number', with: 20
        fill_in 'sidebar_table_number', with: 30
        click_button 'Save'
      }.to change(SeatingChart, :count).by(1)
    end

    xit 'adds a seat if the seating chart is valid' do
      expect{
        create_seating_chart
      }.to change(Seat, :count).by(1)
    end

    xit 'does not add a seat if the seat number is invalid' do
      expect {
        visit new_admin_seating_chart_path
        fill_in 'seating_chart_name', with: 'Test'
        fill_in 'sidebar_table_number', with: 30
        click_button 'Save'
      }.to change(Seat, :count).by(0)
    end

    xit 'does not add a seat if the table number is invalid' do
      expect {
        visit new_admin_seating_chart_path
        fill_in 'seating_chart_name', with: 'Test'
        fill_in 'sidebar_seat_number', with: 20
        click_button 'Save'
      }.to change(Seat, :count).by(0)
    end

    xit 'does not update seating chart if a seating chart name is invalid' do
      expect{
        visit new_admin_seating_chart_path
        fill_in 'seating_chart_name', with: ''
        fill_in 'sidebar_seat_number', with: 20
        fill_in 'sidebar_table_number', with: 30
        click_button 'Save'
      }.to change(SeatingChart, :count).by 0
    end
  end
end
