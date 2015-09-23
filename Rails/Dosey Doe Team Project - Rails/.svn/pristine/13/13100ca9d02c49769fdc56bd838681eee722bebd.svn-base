require 'rails_helper'

shared_examples_for 'creating a customer' do
  context 'with view_customers privileges' do
    context 'valid params' do
      it 'adds the user to the database' do
        expect {
          post :create, user: valid_customer_attributes
        }.to change(Customer, :count).by 1
      end

      it 'redirects to the admin customers index' do
        post :create, user: valid_customer_attributes
        expect(response).to redirect_to admin_customers_path
      end
    end

    context 'invalid params' do
      it 'does not save the user' do
        expect {
          post :create, user: invalid_customer_attributes
        }.to change(User, :count).by 0
      end

      it 'assigns admin_users_path to @url' do
        post :create, user: invalid_customer_attributes
        expect(assigns :url).to eq admin_users_path
      end

      it 're-renders the new template' do
        post :create, user: invalid_customer_attributes
        expect(response).to render_template :new
      end
    end
  end
end