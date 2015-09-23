require 'rails_helper'

describe '/shows/show.html.haml' do
  before :each do
    @test_show = create :show, show_date: Date.new.change(month: 4, day: 5, year: 2020)
    assign :show, @test_show
    @test_ticket_1 = create :sold_ticket, show: @test_show
    @test_ticket_2 = create :customer_reserved_ticket, show: @test_show
  end

  it 'displays the show artist' do
    render

    expect(rendered).to have_text @test_show.artist
  end

  it "displays the show's venue" do
    render

    expect(rendered).to have_text @test_show.venue.name
  end

  it "displays the show's date in DayOfTheWeek, Month Day, Year format" do
    render

    expect(rendered).to have_text 'Sunday, April 5, 2020'
  end

  it 'displays the doors open time in Hour:Minute AM/PM format' do
    render

    expect(rendered).to have_text time_from_datetime(@test_show.doors_open)
  end
end
