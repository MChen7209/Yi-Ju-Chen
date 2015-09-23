require 'rails_helper'

RSpec.describe Admin::VenuesController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(:get => '/admin/venues').to route_to('admin/venues#index')
    end

    it 'routes to #new' do
      expect(:get => '/admin/venues/new').to route_to('admin/venues#new')
    end

    it 'routes to #show' do
      expect(:get => '/admin/venues/1').to route_to('admin/venues#show', :id => '1')
    end

    it 'routes to #edit' do
      expect(:get => '/admin/venues/1/edit').to route_to('admin/venues#edit', :id => '1')
    end

    it 'routes to #create' do
      expect(:post => '/admin/venues').to route_to('admin/venues#create')
    end

    it 'routes to #update' do
      expect(:put => '/admin/venues/1').to route_to('admin/venues#update', :id => '1')
    end

    it 'routes to #destroy' do
      expect(:delete => '/admin/venues/1').to route_to('admin/venues#destroy', :id => '1')
    end

  end
end
