require 'rails_helper'

RSpec.describe TicketsController, type: :routing do
  describe 'routing' do

    it 'routes to #reserve' do
      expect(put: '/tickets/reserve/1'). to route_to('tickets#reserve', id: '1')
    end

  end
end
