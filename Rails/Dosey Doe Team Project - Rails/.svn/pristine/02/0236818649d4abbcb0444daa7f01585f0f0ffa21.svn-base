require 'rails_helper'

RSpec.describe UsersController, skip: true, type: :controller do
  describe 'GET #checkout' do
    context 'signed-in user' do
      it 'assigns all the tickets reserved by that user to @tickets' do
        test_customer = create :customer
        sign_in test_customer
        test_ticket1 = create :customer_reserved_ticket, user: test_customer
        test_ticket2 = create :customer_reserved_ticket, user: test_customer
        create :customer_reserved_ticket
        create :admin_reserved_ticket
        create :guest_reserved_ticket
        get :checkout

        expect(assigns :tickets).to match_array([test_ticket1, test_ticket2])
      end

      it 'renders the checkout template' do
        sign_in create :customer
        get :checkout

        expect(response).to render_template :checkout
      end
    end
  end
end
