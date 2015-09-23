require 'rails_helper'

describe '/venues/show.html.haml' do
  before :each do
    @test_venue = create :venue
    @test_show1 = create :show, venue: @test_venue
    @test_show2 = create :show, venue: @test_venue
    assign :venue, @test_venue
    assign :shows, @test_venue.shows.page(1)
    render
  end

  describe 'displays venue-specific information' do
    it "displays the venue's name" do
      expect(rendered).to have_text @test_venue.name
    end

    it "displays the venue's address" do
      expect(rendered).to have_text @test_venue.address_line1
      expect(rendered).to have_text @test_venue.city
      expect(rendered).to have_text @test_venue.state
    end
  end

  describe 'displays upcoming show information' do
    it 'displays upcoming artist names' do
      expect(rendered).to have_text @test_show1.artist
      expect(rendered).to have_text @test_show2.artist
    end

    it 'displays upcoming show dates' do
      expect(rendered).to have_text date_as_words @test_show1.show_date
      expect(rendered).to have_text date_as_words @test_show2.show_date
    end
  end
end