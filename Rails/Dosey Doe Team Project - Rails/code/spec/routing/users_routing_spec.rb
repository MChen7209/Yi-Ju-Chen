require 'rails_helper'

RSpec.describe UsersController, type: :routing do
  describe 'routing' do

    it 'routes to #checkout' do
      expect(get: '/users/checkout'). to route_to('users#checkout')
    end

  end
end
