require 'rails_helper'

shared_examples_for 'a report' do
  it 'is labeled with the word \'results\'' do
    expect(rendered).to have_text 'results'
  end

  it 'has a link back to the Reports page' do
    expect(rendered).to have_link 'Back'
  end
end

describe '/admin/reports/report.html.haml' do
  context 'viewing the Venues report' do
    before :each do
      @venue1 = create :venue
      @venue2 = create :venue
      @venue3 = create :venue
      assign(:report_objects, Venue.all)
      render
    end

    it_behaves_like 'a report'

    it 'contains all of the Venue ids' do
      expect(rendered).to have_text @venue1.id
      expect(rendered).to have_text @venue2.id
      expect(rendered).to have_text @venue3.id
    end

    it 'contains all of the Venue names' do
      expect(rendered).to have_text @venue1.name
      expect(rendered).to have_text @venue2.name
      expect(rendered).to have_text @venue3.name
    end
  end

  context 'viewing the Shows report' do
    before :each do
      @show1 = create :show
      @show2 = create :show
      @show3 = create :show
      assign(:report_objects, Show.all)
      render
    end

    it_behaves_like 'a report'

    it 'contains all of the Show ids' do
      expect(rendered).to have_text @show1.id
      expect(rendered).to have_text @show2.id
      expect(rendered).to have_text @show3.id
    end

    it 'contains all of the Show\'s artist names' do
      expect(rendered).to have_text @show1.artist
      expect(rendered).to have_text @show2.artist
      expect(rendered).to have_text @show3.artist
    end
  end
end
