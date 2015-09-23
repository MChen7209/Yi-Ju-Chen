require 'rails_helper'

describe 'admin/ticket_layouts/index.html.haml' do
  before :each do
    @layout_1 = create :ticket_layout, name: 'Layout 1'
    @layout_2 = create :ticket_layout, name: 'Layout 2'
  end

  context 'displays all ticket layouts assigned to @ticket_layouts' do
    it 'displays all ticket layouts' do
      assign(:ticket_layouts, TicketLayout.all)
      render

      expect(rendered).to have_text @layout_1.name
      expect(rendered).to have_text @layout_2.name
    end
  end
end