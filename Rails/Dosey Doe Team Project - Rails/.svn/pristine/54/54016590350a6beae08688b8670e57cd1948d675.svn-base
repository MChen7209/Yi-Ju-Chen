require 'rails_helper'

describe 'admin/shows/show.html.haml' do
  before :each do
    @test_show = create :show
    assign :show, Show.first
    render
  end

  it 'displays the venue name' do
    expect(rendered).to have_text @test_show.venue.name
  end

  it 'displays the show_date in the form DayOfTheWeek, Month Day, Year' do
    expect(rendered).to have_text date_as_words(@test_show.show_date)
  end

  context 'it displays times in the form H:M AM/PM' do
    it 'displays the doors_open time' do
      expect(rendered).to have_text time_from_datetime(@test_show.doors_open)
    end

    it 'displays the dinner_starts time' do
      expect(rendered).to have_text time_from_datetime(@test_show.dinner_starts)
    end

    it 'displays the dinner_ends time' do
      expect(rendered).to have_text time_from_datetime(@test_show.dinner_ends)
    end

    it 'displays the show_starts time' do
      expect(rendered).to have_text time_from_datetime(@test_show.show_starts)
    end
  end

  describe 'prints the tickets for the show' do
    before :each do
      @show_with_tickets = create :show
      @show_with_tickets.tickets << create(:sold_ticket, show: @show_with_tickets)
      @show_with_tickets.tickets << create(:ticket, show: @show_with_tickets)
      @show_with_tickets.tickets << create(:ticket, show: @show_with_tickets)

      assign :show, @show_with_tickets
      render
    end
    it 'displays the tickets for the show' do
      @show_with_tickets.tickets.each do |ticket|
        expect(rendered).to have_text "Seat number: #{ticket.seat.seat_number}"
      end
    end

    it 'sets the class to .unsold_seat if the seat has no user' do
      expect(rendered).to have_css '.open_seat'
    end

    it 'sets the class to .sold_seat if the seat has a user' do
      expect(rendered).to have_css '.sold_seat'
    end
  end
end