require 'rails_helper'

RSpec.describe Admin::ShowsController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(:get => '/admin/shows').to route_to('admin/shows#index')
    end

    it 'routes to #new' do
      expect(:get => '/admin/shows/new').to route_to('admin/shows#new')
    end

    it 'routes to #show' do
      expect(:get => '/admin/shows/1').to route_to('admin/shows#show', :id => '1')
    end

    it 'routes to #edit' do
      expect(:get => '/admin/shows/1/edit').to route_to('admin/shows#edit', :id => '1')
    end

    it 'routes to #create' do
      expect(:post => '/admin/shows').to route_to('admin/shows#create')
    end

    it 'routes to #update' do
      expect(:put => '/admin/shows/1').to route_to('admin/shows#update', :id => '1')
    end

    it 'routes to #destroy' do
      expect(:delete => '/admin/shows/1').to route_to('admin/shows#destroy', :id => '1')
    end
  end
end
