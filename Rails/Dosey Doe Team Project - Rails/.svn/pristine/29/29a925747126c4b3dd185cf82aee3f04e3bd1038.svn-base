require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Shows form', type: :feature do
  def setup
    create :venue, name: 'The Nonexistent Barn'
    create :venue, name: 'The Medium-Sized Barn'
    create :seating_chart, name: 'Seating Chart'
    login_as create :test_admin

    visit new_admin_show_path
    @artist_name = 'Radiohead'
    fill_in 'Artist', with: @artist_name
    select 'Seating Chart', from: 'show_seating_chart_id'
    select 'The Medium-Sized Barn', from: 'show_venue_id'
    select '12', from: 'show_show_date_3i'
    select 'January', from: 'show_show_date_2i'
    select Date.today.year + 1, from: 'show_show_date_1i'
    select '08 PM', from: 'show_doors_open_4i'
    select '15', from: 'show_doors_open_5i'
    select '08 PM', from: 'show_show_starts_4i'
    select '30', from: 'show_show_starts_5i'
    select '06 PM', from: 'show_dinner_starts_4i'
    select '30', from: 'show_dinner_starts_5i'
    select '07 PM', from: 'show_dinner_ends_4i'
    select '45', from: 'show_dinner_ends_5i'
  end

  after :each do
    Warden.test_reset!
  end

  describe 'admin actions' do
    context 'adding a show' do
      before :each do
        setup
        click_button 'Save Show'
      end

      it 'adds the show if the inputs are valid' do
        expect(Show.count).to eq 1
      end

      it 'sets the artist selected by the user' do
        expect(Show.where(artist: @artist_name)).to exist
      end

      it 'sets the venue selected by the user' do
        expect(Show.joins(:venue).merge(Venue.where(name: 'The Medium-Sized Barn'))).to exist
      end

      it 'sets the show_date day specified by the user' do
        expect(Show.last.show_date.day).to eq 12
      end

      it 'sets the show_date month specified by the user' do
        expect(Show.last.show_date.month).to eq 1
      end

      it 'sets the show_date year specified by the user' do
        expect(Show.find_by(artist: @artist_name).show_date.year).to eq(Date.today.year + 1)
      end

      it 'sets the doors_open hours to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).doors_open.hour).to eq 20
      end

      it 'sets the doors_open minutes to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).doors_open.min).to eq 15
      end

      it 'sets the dinner_starts hours to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).dinner_starts.hour).to eq 18
      end

      it 'sets the dinner_starts minutes to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).dinner_starts.min).to eq 30
      end

      it 'sets the dinner_ends hours to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).dinner_ends.hour).to eq 19
      end

      it 'sets the dinner_ends minutes to the time specified by the user' do
        expect(Show.find_by(artist: @artist_name).dinner_ends.min).to eq 45
      end
    end

  end
end