require 'rails_helper'

RSpec.describe Admin::ReportsController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(get: '/admin/reports'). to route_to('admin/reports#index')
    end

    it 'routes to #report' do
      expect(get: '/admin/reports/1'). to route_to('admin/reports#report', id: '1')
    end

  end
end
