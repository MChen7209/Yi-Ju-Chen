require 'rails_helper'

describe '/admin/seating_charts/show.html.haml' do
  before :each do
    @chart_1 = create :seating_chart, name: 'Layout 1'
  end

  it 'displays the seating chart name' do
    assign(:seating_chart, @chart_1)
    render

    expect(rendered).to have_text @chart_1.name
  end
end