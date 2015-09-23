require 'rails_helper'

describe '/admin/reports/index.html.haml' do
  before :each do
    assign(:available_reports, Admin::ReportsController.available_reports)
    render
  end

  it 'is labeled with the word \'Reports\'' do
    expect(rendered).to have_text 'Reports'
  end

  it 'contains a link to the Venues report' do
    expect(rendered).to have_link 'Venues'
  end

  it 'contains a link to the Shows report' do
    expect(rendered).to have_link 'Shows'
  end

  it 'is slightly self-conscious' do
    expect(rendered).to have_text 'placeholder'
  end
end