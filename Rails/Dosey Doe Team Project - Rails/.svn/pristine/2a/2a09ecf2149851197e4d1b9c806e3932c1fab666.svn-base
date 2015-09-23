require 'rails_helper'

describe '/admin/seating_charts/index.html.haml' do
  before :each do
    @chart_1 = create :seating_chart, name: 'Chart One'
    @chart_2 = create :seating_chart, name: 'Chart Two'
  end

  context 'displays all seating charts assigned to @seating_charts' do
    it 'displays the chart name for all shows' do
      assign(:seating_charts, SeatingChart.all)
      render

      expect(rendered).to have_text @chart_1.name
      expect(rendered).to have_text @chart_2.name
    end
  end
end