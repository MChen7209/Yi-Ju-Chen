require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::HomeController, type: :controller do
  describe 'GET #index' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        get :index
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      it 'allows the page to be rendered' do
        sign_in create :admin
        get :index
        expect(response).to render_template :index
      end
    end
  end
end
