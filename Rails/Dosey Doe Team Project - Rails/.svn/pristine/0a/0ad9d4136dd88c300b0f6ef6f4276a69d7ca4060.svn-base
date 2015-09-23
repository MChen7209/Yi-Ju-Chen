require 'rails_helper'

shared_examples_for 'updating a customer' do
  before :each do
    @test_customer = create :customer
  end
  context 'with valid parameters' do
    before :each do
      valid_customer_attributes[:type] = 'Admin'
      patch :update, id: @test_customer, user: valid_customer_attributes
      @test_customer.reload
    end

    it 'updates the first_name in the database' do
      expect(@test_customer.first_name).to eq valid_customer_attributes[:first_name]
    end

    it 'updates the last_name in the database' do
      expect(@test_customer.last_name).to eq valid_customer_attributes[:last_name]
    end

    it 'updates the email in the database' do
      expect(@test_customer.email).to eq valid_customer_attributes[:email]
    end

    it 'does not update the type' do
      expect(@test_customer.type).to eq 'Customer'
    end

    it 'redirects to the admin users index' do
      expect(response).to redirect_to admin_users_path
    end
  end

  context 'with invalid parameters' do
    before :each do
      @test_customer_attributes = @test_customer.attributes
      patch :update, id: @test_customer, user: invalid_customer_attributes
      @test_customer.reload
    end

    it 'does not update the user first_name' do
      expect(@test_customer.first_name).to eq @test_customer_attributes['first_name']
    end

    it 'does not update the user last_name' do
      expect(@test_customer.last_name).to eq @test_customer_attributes['last_name']
    end

    it 'does not update the user email' do
      expect(@test_customer.email).to eq @test_customer_attributes['email']
    end

    it 'does not update the user type' do
      expect(@test_customer.type).to eq @test_customer_attributes['type']
    end

    it 'assigns the admin_user_path to @url' do
      expect(assigns :url).to eq admin_user_path
    end

    it 're-renders the edit template' do
      expect(response).to render_template :edit
    end
  end
end