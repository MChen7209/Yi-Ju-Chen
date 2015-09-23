require 'rails_helper'

describe 'admin/shows/index.html.haml' do
  before :each do
    @test_show1 = create :show
    @test_show2 = create :show
    assign(:shows, Show.all)
    render
  end

  context 'displays all shows assigned to @shows in ascending
           order of their show_date' do
    it 'displays the artist for all shows' do
      expect(rendered).to have_text @test_show1.artist
      expect(rendered).to have_text @test_show2.artist
    end

    it 'displays the show date for all shows in the form DayOfTheWeek,
        Month Day, Year' do
      expect(rendered).to have_text date_as_words(@test_show1.show_date)
      expect(rendered).to have_text date_as_words(@test_show2.show_date)
    end

    it 'displays the doors_open time in the form H:M AM/PM' do
      expect(rendered).to have_text time_from_datetime(@test_show1.doors_open)
      expect(rendered).to have_text time_from_datetime(@test_show1.doors_open)
    end
  end

  it 'displays the venue that is hosting each show' do
    expect(rendered).to have_text @test_show1.venue.name
    expect(rendered).to have_text @test_show2.venue.name
  end

  it 'displays dinner_starts time' do
    within "#show#{@test_show1.id}_dinner_starts" do
      expect(rendered).to have_text(time_from_datetime(@test_show1.dinner_starts))
    end
    within "#show#{@test_show2.id}_dinner_starts" do
      expect(rendered).to have_text(time_from_datetime(@test_show2.dinner_starts))
    end
  end

  it 'displays dinner_ends time' do
    within "#show#{@test_show1.id}_dinner_ends" do
      expect(rendered).to have_text(time_from_datetime(@test_show1.dinner_ends))
    end
    within "#show#{@test_show2.id}_dinner_ends" do
      expect(rendered).to have_text(time_from_datetime(@test_show2.dinner_ends))
    end
  end
end