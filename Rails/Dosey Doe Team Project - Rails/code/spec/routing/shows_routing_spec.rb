require 'rails_helper'

RSpec.describe ShowsController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(get: '/shows'). to route_to('shows#index')
    end

    it 'routes to #show' do
      expect(get: '/shows/1'). to route_to('shows#show', id: '1')
    end

  end
end
