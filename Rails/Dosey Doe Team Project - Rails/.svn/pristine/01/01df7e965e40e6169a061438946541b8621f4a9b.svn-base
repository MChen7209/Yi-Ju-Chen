require 'rails_helper'

describe 'admin/ticket_layouts/show.html.haml' do

  before :each do
    @layout_1 = create :ticket_layout, name: 'Layout 1'
  end

  it 'displays the ticket_layout name' do
    assign :ticket_layout, TicketLayout.first
    render

    expect(rendered).to have_text @layout_1.name
  end
end