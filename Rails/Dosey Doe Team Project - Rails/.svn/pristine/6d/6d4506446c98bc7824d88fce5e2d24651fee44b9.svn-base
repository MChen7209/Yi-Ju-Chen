require 'rails_helper'

RSpec.describe Admin::TicketLayoutsController, type: :routing do
  describe 'routing' do

    it 'routes to #index' do
      expect(:get => '/admin/ticket_layouts').to route_to('admin/ticket_layouts#index')
    end

    it 'routes to #new' do
      expect(:get => '/admin/ticket_layouts/new').to route_to('admin/ticket_layouts#new')
    end

    it 'routes to #show' do
      expect(:get => '/admin/ticket_layouts/1').to route_to('admin/ticket_layouts#show', :id => '1')
    end

    it 'routes to #edit' do
      expect(:get => '/admin/ticket_layouts/1/edit').to route_to('admin/ticket_layouts#edit', :id => '1')
    end

    it 'routes to #create' do
      expect(:post => '/admin/ticket_layouts').to route_to('admin/ticket_layouts#create')
    end

    it 'routes to #update' do
      expect(:put => '/admin/ticket_layouts/1').to route_to('admin/ticket_layouts#update', :id => '1')
    end

    it 'routes to #destroy' do
      expect(:delete => '/admin/ticket_layouts/1').to route_to('admin/ticket_layouts#destroy', :id => '1')
    end
  end
end
