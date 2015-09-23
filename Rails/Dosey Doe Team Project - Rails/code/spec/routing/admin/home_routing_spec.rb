require 'rails_helper'

RSpec.describe Admin::HomeController, type: :routing do
  describe 'routing' do
    it 'routes to #index' do
      expect(get: '/admin').to route_to('admin/home#index')
    end
  end
end