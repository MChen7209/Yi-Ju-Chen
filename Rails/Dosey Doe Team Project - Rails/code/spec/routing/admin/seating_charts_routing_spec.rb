require 'rails_helper'

RSpec.describe Admin::SeatingChartsController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(:get => '/admin/seating_charts').to route_to('admin/seating_charts#index')
    end

    it 'routes to #new' do
      expect(:get => '/admin/seating_charts/new').to route_to('admin/seating_charts#new')
    end

    it 'routes to #show' do
      expect(:get => '/admin/seating_charts/1').to route_to('admin/seating_charts#show', :id => '1')
    end

    it 'routes to #edit' do
      expect(:get => '/admin/seating_charts/1/edit').to route_to('admin/seating_charts#edit', :id => '1')
    end

    it 'routes to #create' do
      expect(:post => '/admin/seating_charts').to route_to('admin/seating_charts#create')
    end

    it 'routes to #update' do
      expect(:put => '/admin/seating_charts/1').to route_to('admin/seating_charts#update', :id => '1')
    end

    it 'routes to #destroy' do
      expect(:delete => '/admin/seating_charts/1').to route_to('admin/seating_charts#destroy', :id => '1')
    end

  end
end
