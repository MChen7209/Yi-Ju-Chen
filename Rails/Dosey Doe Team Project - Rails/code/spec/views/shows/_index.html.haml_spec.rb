require 'rails_helper'

describe '/shows/_index.html.haml' do
  before :each do
    @test_show_1 = create :show
    @test_show_2 = create :show
    assign :shows, Show.all.page(1)
    render
  end

  describe 'displays the data for each show' do
    it 'displays the show artist' do
      expect(rendered).to have_css "#show#{@test_show_1.id}", text: @test_show_1.artist
      expect(rendered).to have_css "#show#{@test_show_2.id}", text: @test_show_2.artist
    end

    it 'displays the dinner served times' do
      expect(rendered).to have_css "#show#{@test_show_1.id}",
                                   text: "Dinner served between #{time_from_datetime @test_show_1.dinner_starts} and #{time_from_datetime @test_show_1.dinner_ends}"
      expect(rendered).to have_css "#show#{@test_show_2.id}",
                                   text: "Dinner served between #{time_from_datetime @test_show_2.dinner_starts} and #{time_from_datetime @test_show_2.dinner_ends}"

    end
  end
end