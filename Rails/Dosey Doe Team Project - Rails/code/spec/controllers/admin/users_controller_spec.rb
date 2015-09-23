require 'rails_helper'
require './spec/support/creating_a_customer'
require './spec/support/updating_a_customer'
require './spec/support/get_new_with_ability'

RSpec.describe Admin::UsersController, type: :controller do
  let(:valid_customer_attributes) {attributes_for :customer}

  let(:invalid_customer_attributes) {
    build(:customer, first_name: nil).attributes
  }

  let(:valid_admin_attributes) {
    build(:admin, role: create(:manager_role)).attributes
  }

  let(:invalid_admin_attributes) {
    build(:admin, first_name: nil).attributes
  }

  let(:admin_with_view_admins_permissions) {
    create :admin, role: create(:role, view_admins: true)
  }

  let(:admin_with_view_customers_permissions) {
    create :admin, role: create(:role, view_customers: true)
  }

  let(:admin_without_permission) {
    create :admin, role: create(:role, view_admins: false, view_customers: false)
  }

  describe 'GET #find_customers' do
    context 'admins can find customers' do
      before :each do
        sign_in create :admin
        @customer1 = create(:customer, first_name: 'Customer1', last_name: 'Customer1', email: 'customer1@test.com')
        @customer2 = create(:customer, first_name: 'Customer2', last_name: 'Customer2', email: 'customer2@test.com')
        @customer3 = create(:customer, first_name: 'Customer3', last_name: 'Customer3', email: 'customer3@test.com')
      end

      context 'without [:params]' do
        it 'returns all customers in the database' do
          get :find_customers
          expect(assigns :customers).to match_array([@customer1,@customer2,@customer3])
        end
      end

      context 'with [:params]' do
        it 'returns matching first_name customers in the database' do
          get :find_customers, first_name: 'Customer1'
          expect(assigns :customers).to match_array([@customer1])
        end

        it 'returns matching last_name customers in the database' do
          get :find_customers, last_name: 'Customer2'
          expect(assigns :customers).to match_array([@customer2])
        end

        it 'returns matching email customers in the database' do
          get :find_customers, email: 'Customer3'
          expect(assigns :customers).to match_array([@customer3])
        end

        it 'returns matching all customer fields in the database' do
          get :find_customers, first_name: 'Customer1', last_name: 'Customer1', email: 'customer1@test.com'
          expect(assigns :customers).to match_array([@customer1])
        end

        it 'returns multiple(all) matching customer fields in the database' do
          get :find_customers, first_name: 'customer'
          expect(assigns :customers).to match_array([@customer1,@customer2,@customer3])
        end

        it 'returns multiple(all) matching customer fields in the database with multiple fields' do
          get :find_customers, first_name: 'customer', last_name: 'customer', email: 'customer'
          expect(assigns :customers).to match_array([@customer1,@customer2,@customer3])
        end

        it 'returns nothing when no correct customers are found' do
          get :find_customers, first_name: 'customer1337'
            expect(assigns :customers).to match_array([])
        end
      end
    end
  end

  describe 'GET #customers' do
    context 'admin has view_admins priveleges' do
      before :each do
        @test_customer_1 = create :customer
        @test_customer_2 = create :customer
        create :guest
        sign_in admin_with_view_admins_permissions
        get :customers
      end
      it 'populates @users with all customers' do
        expect(assigns :users).to match_array [@test_customer_1, @test_customer_2]
      end
      it "assigns 'Customer' to @user_type" do
        expect(assigns :user_type).to eq 'Customer'
      end
    end

    context 'admin only has view_customers priveleges' do
      before :each do
        @test_customer_1 = create :customer
        @test_customer_2 = create :customer
        create :guest
        sign_in admin_with_view_customers_permissions
        get :customers
      end
      it 'populates @users with all customers' do
        expect(assigns :users).to match_array([@test_customer_1, @test_customer_2])
      end

      it "assigns 'Customer' to @user_type" do
        expect(assigns :user_type).to eq 'Customer'
      end
    end

    context 'admin does not have view_customers or view_admins priveleges' do
      before :each do
        sign_in admin_without_permission
      end

      it 'assigns nil to @users' do
        create :customer
        get :customers

        expect(assigns :users).to eq nil
      end

      it 'redirects to the landing page' do
        get :customers

        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end

    it 'renders the index template' do
      sign_in admin_with_view_admins_permissions
      get :customers

      expect(response).to render_template :index
    end
  end

  describe 'GET #admins' do
    context 'admin has view_admins priveleges' do
      before :each do
        test_customer_1 = create :customer
        create :guest
        @test_admin_1 = admin_with_view_admins_permissions
        @test_admin_2 = create :admin
        sign_in @test_admin_1
        get :admins
      end
      it 'populates @users with all admins' do
        expect(assigns :users).to match_array [@test_admin_1, @test_admin_2]
      end

      it "assigns 'Admin' to @user_type" do
        expect(assigns :user_type).to eq 'Admin'
      end
    end

    context 'admin only has view_customers priveleges' do
      it 'assigns nil to @users' do
        test_customer_1 = create :customer
        test_customer_2 = create :customer
        create :guest
        test_role = create :role, view_customers: true, view_admins: false
        test_admin = create :admin, role: test_role
        sign_in test_admin
        get :admins

        expect(assigns :users).to eq nil
      end
    end

    context 'admin does not have view_customers or view_admins priveleges' do
      before :each do
        sign_in admin_without_permission
      end

      it 'assigns nil to @users' do
        create :customer
        get :customers

        expect(assigns :users).to eq nil
      end

      it 'redirects to the landing page' do
        get :customers

        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end

    it 'renders the index template' do
      sign_in admin_with_view_admins_permissions
      get :customers

      expect(response).to render_template :index
    end
  end

  describe 'GET #edit' do
    context 'admin with view_admins permissions' do
      before :each do
        @test_admin = admin_with_view_admins_permissions
        sign_in @test_admin
      end

      context 'editing a customer' do
        context 'valid params' do
          before :each do
            @test_customer = create :customer
            get :edit, id: @test_customer
          end

          it 'assigns the requested user to @user' do
            expect(assigns :user).to eq @test_customer do
            end
          end

          it 'assigns the admin_user_path to @url' do
            expect(assigns :url).to eq admin_user_path
          end

          it 'renders the edit template' do
            expect(response).to render_template :edit
          end
        end
      end

      context 'editing an admin' do
        before :each do
          @test_admin = create :admin
          get :edit, id: @test_admin
        end

        it 'assigns the requested admin to @user' do
          expect(assigns :user).to eq @test_admin
        end

        it 'assigns the admin_user_path to @url' do
          expect(assigns :url).to eq admin_user_path
        end

        it 'renders the edit template' do
          expect(response).to render_template :edit
        end
      end

      context 'invalid params' do
        it 'does not throw an error' do
          expect{get :edit, id: -1}.not_to raise_error
        end

        it 'assigns all customers to @users' do
          test_customer_1 = create :customer
          test_customer_2 = create :customer
          create :guest
          get :edit, id: -1
          expect(assigns :users).to match_array([test_customer_1, test_customer_2])
        end

        it 'redirects to the admin users index' do
          get :edit, id: -1
          expect(response).to redirect_to admin_customers_path
        end
      end
    end

    context 'admin with only view_customers permissions' do
      before :each do
        @test_customer = create :customer
        sign_in create :admin, role: create(:role, view_customers: true)
      end

      context 'valid params' do
        context 'for a customer' do
          before :each do
            get :edit, id: @test_customer
          end
          it 'assigns the customer to @user' do
            expect(assigns :user).to eq @test_customer
          end

          it 'assigns admin_user_path to @url' do
            expect(assigns :url).to eq admin_user_path
          end

          it 'renders the edit template' do
            expect(response).to render_template :edit
          end
        end

        context 'for an admin' do
          it 'redirects to the admin_users_path' do
            test_admin = create :admin
            get :edit, id: test_admin

            expect(response).to redirect_to test_admin.role.landing_page
          end
        end
      end

      context 'invalid params' do
        context 'for a customer' do
          it 'redirects to the admin_users_path' do
            get :edit, id: -1

            expect(response).to redirect_to admin_customers_path
          end
        end

        context 'for an admin' do
          it 'redirects to the admin_users_path' do
            get :edit, id: -1

            expect(response).to redirect_to admin_customers_path
          end
        end
      end

      context 'without view_admins or view_customers permission' do
        it 'redirects to the landing page' do
          test_admin = create :admin
          sign_in test_admin
          get :edit, id: @test_customer

          expect(response).to redirect_to test_admin.role.landing_page
        end
      end
    end
  end

  describe 'PATCH #update' do
    context 'with view_admins permissions' do
      before :each do
        sign_in admin_with_view_admins_permissions
      end

      describe 'updating a customer' do
        it_behaves_like 'updating a customer'
      end

      describe 'updating an admin' do
        before :each do
          @test_admin = create :admin
        end

        context 'with valid parameters' do
          before :each do
            valid_admin_attributes['type'] = 'User'
            patch :update, id: @test_admin, user: valid_admin_attributes
            @test_admin.reload
          end

          it 'updates the first_name' do
            expect(@test_admin.first_name).to eq valid_admin_attributes['first_name']
          end

          it 'updates the last_name' do
            expect(@test_admin.last_name).to eq valid_admin_attributes['last_name']
          end

          it 'updates the email' do
            expect(@test_admin.email).to eq valid_admin_attributes['email']
          end

          it 'does not update the type' do
            expect(@test_admin.type).to eq 'Admin'
            expect(@test_admin.type).to eq 'Admin'
          end

          it 'updates the role' do
            expect(@test_admin.role.id).to eq valid_admin_attributes['role_id']
          end

          it 'redirects to the admin_users_path' do
            expect(response).to redirect_to admin_users_path
          end
        end

        context 'with invalid parameters' do
          before :each do
            @test_admin_attributes = @test_admin.attributes
            patch :update, id: @test_admin, user: invalid_admin_attributes
            @test_admin.reload
          end
          it 'does not update the first_name' do
            expect(@test_admin.first_name).to eq @test_admin_attributes['first_name']
          end

          it 'does not update the last_name' do
            expect(@test_admin.last_name).to eq @test_admin_attributes['last_name']
          end

          it 'does not update the email' do
            expect(@test_admin.email).to eq @test_admin_attributes['email']
          end

          it 'does not update the type' do
            expect(@test_admin.type).to eq @test_admin_attributes['type']
          end

          it 'does not update the role' do
            expect(@test_admin.role.id).to eq @test_admin_attributes['role_id']
          end

          it 'assigns the admin user page to @url' do
            expect(assigns :url).to eq admin_user_path
          end

          it 're-renders the edit template' do
            expect(response).to render_template :edit
          end
        end
      end
    end

    context 'with only view_customers permissions' do
      before :each do
        sign_in admin_with_view_customers_permissions
      end

      describe 'updating a customer' do
        it_behaves_like 'updating a customer'
      end

      describe 'updating an admin' do
        before :each do
          @test_admin = create :admin
          @test_admin_attributes = @test_admin.attributes
          patch :update, id: @test_admin, user: valid_admin_attributes
          @test_admin.reload
        end
        it 'redirects to the admin users index' do
          expect(response).to redirect_to admin_with_view_customers_permissions.role.landing_page
        end

        it 'does not change the first_name' do
          expect(@test_admin.first_name).to eq @test_admin_attributes['first_name']
        end

        it 'does not change the last_name' do
          expect(@test_admin.last_name).to eq @test_admin_attributes['last_name']
        end

        it 'does not change the email' do
          expect(@test_admin.email).to eq @test_admin_attributes['email']
        end

        it 'does not change the role' do
          expect(@test_admin.role.id).to eq @test_admin_attributes['role_id']
        end

        it 'does not change the type' do
          expect(@test_admin.type).to eq @test_admin_attributes['type']
        end
      end
    end

    context 'without view_admins or view_customers permissions' do
      before :each do
        sign_in admin_without_permission
      end
      describe 'updating a customer' do
        before :each do
          @test_customer = create :customer
          @test_customer_attributes = @test_customer.attributes
          patch :update, id: @test_customer, user: valid_customer_attributes
          @test_customer.reload
        end
        it 'does not update the first_name' do
          expect(@test_customer.first_name).to eq @test_customer_attributes['first_name']
        end

        it 'does not update the last_name' do
          expect(@test_customer.last_name).to eq @test_customer_attributes['last_name']
        end

        it 'does not update the email' do
          expect(@test_customer.email).to eq @test_customer_attributes['email']
        end

        it 'does not update the type' do
          expect(@test_customer.type).to eq @test_customer_attributes['type']
        end

        it 'redirects to the landing page' do
          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end

      describe 'updating an admin' do
        before :each do
          @test_admin = create :admin
          @test_admin_attributes = @test_admin.attributes
          patch :update, id: @test_admin, user: valid_admin_attributes
          @test_admin.reload
        end
        it 'does not update the first_name' do
          expect(@test_admin.first_name).to eq @test_admin_attributes['first_name']
        end

        it 'does not update the last_name' do
          expect(@test_admin.last_name).to eq @test_admin_attributes['last_name']
        end

        it 'does not update the email' do
          expect(@test_admin.email).to eq @test_admin_attributes['email']
        end

        it 'does not update the type' do
          expect(@test_admin.type).to eq @test_admin_attributes['type']
        end

        it 'does not update the role' do
          expect(@test_admin.role.id).to eq @test_admin_attributes['role_id']
        end

        it 'redirects to the admin customers index' do
          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end
    end
  end

  describe 'DELETE #destroy' do
    context 'with view_admins permission' do
      before :each do
        @current_admin_user = admin_with_view_admins_permissions
        sign_in @current_admin_user
      end
      describe 'deleting a customer' do
        it 'does not delete' do
          test_customer = create :customer
          expect{delete :destroy, id: test_customer}.to change(User, :count).by 0
        end

        it 'assigns all customers to @users' do
          test_customer_1 = create :customer
          test_customer_2 = create :customer
          delete :destroy, id: test_customer_1

          expect(assigns :users).to match_array([test_customer_1, test_customer_2])
        end

        it 'redirects to the admin users index' do
          test_customer = create :customer
          delete :destroy, id: test_customer

          expect(response).to redirect_to admin_customers_path
        end
      end

      describe 'deleting an admin' do
        before :each do
            @test_admin_1 = create :admin
            @test_admin_2 = create :admin
        end
        context 'valid parameters' do  
          it 'destroys the admin if the admin is not the current user' do
            expect{delete :destroy, id: @test_admin_1}.to change(User, :count).by -1
          end

          it 'does not destroy the admin if the admin is not the current user' do
            expect{delete :destroy, id: admin_with_view_admins_permissions}.to change(User, :count).by 0
          end

          it 'assigns all admins to @users' do
            delete :destroy, id: @test_admin_1
            expect(assigns :users).to match_array([@test_admin_2, @current_admin_user])
          end

          it 'redirects to the admin index' do
            delete :destroy, id: @test_admin_1
            expect(response).to redirect_to admin_admins_path
          end
        end

        context 'invalid parameters' do
          it 'assigns all customers to @users' do
            test_customer = create :customer
            sign_in admin_with_view_admins_permissions
            create :guest

            delete :destroy, id: -100
            expect(assigns :users).to match_array([test_customer])
          end

          it 'redirects to the user index template' do
            sign_in admin_with_view_admins_permissions
            delete :destroy, id: -100
            expect(response).to redirect_to admin_customers_path
          end
        end
      end
    end

    context 'with only view_customers permissions' do
      before :each do
        sign_in admin_with_view_customers_permissions
      end
      context 'deleting a customer' do
        it 'does not delete' do
          test_customer = create :customer
          expect{delete :destroy, id: test_customer}.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          test_customer = create :customer
          delete :destroy, id: test_customer

          expect(response).to redirect_to admin_with_view_customers_permissions.role.landing_page
        end
      end

      context 'deleting an admin' do
        it 'does not delete' do
          test_admin = create :admin
          expect {delete :destroy, id: test_admin}.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          test_admin = create :admin
          delete :destroy, id: test_admin

          expect(response).to redirect_to admin_with_view_customers_permissions.role.landing_page
        end
      end
    end

    context 'without view_customers or view_admins permissions' do
      before :each do
        sign_in admin_without_permission
      end
      context 'deleting a customer' do
        it 'does not delete' do
          test_customer = create :customer
          expect{delete :destroy, id: test_customer}.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          test_customer = create :customer
          delete :destroy, id: test_customer

          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end

      context 'deleting an admin' do
        it 'does not delete' do
          test_admin = create :admin
          expect {delete :destroy, id: test_admin}.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          test_admin = create :admin
          delete :destroy, id: test_admin

          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end
    end
  end

  describe 'GET #new' do
    context 'with view_admins permissions' do
      before :each do
        sign_in admin_with_view_admins_permissions
      end
      it_behaves_like 'GET #new with create customer ability'
    end

    context 'with only view_customers permissions' do
      before :each do
        sign_in admin_with_view_customers_permissions
      end
      it_behaves_like 'GET #new with create customer ability'
    end

    context 'without view_admins or view_customers permissions' do
      before :each do
        sign_in admin_without_permission
      end
      it 'does not assign a new user to @user' do
        get :new
        expect(assigns :user).not_to be_a_new User
      end

      it 'redirects to the landing page' do
        get :new
        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end
  end

  describe 'POST #create' do
    context 'with view_admins permissions' do
      before :each do
        sign_in admin_with_view_admins_permissions
      end
      it_behaves_like 'creating a customer'

      describe 'creating an admin' do
        before :each do
          valid_admin_attributes[:password] = 'password'
          valid_admin_attributes[:password_confirmation] = 'password'
        end
        it 'adds the admin to the database' do
          expect{
            post :create, user: valid_admin_attributes
          }.to change(Admin, :count).by 1
        end

        it 'redirects to the admin users index' do
          post :create, user: valid_admin_attributes

          expect(response).to redirect_to admin_customers_path
        end
      end
    end

    context 'with only view_customers permissions' do
      before :each do
        sign_in admin_with_view_customers_permissions
      end
      it_behaves_like 'creating a customer'

      describe 'creating an admin' do
        before :each do
          valid_admin_attributes[:password] = 'password'
          valid_admin_attributes[:password_confirmation] = 'password'
        end
        it 'does not add the admin to the databse' do
          expect {
            post :create, user: valid_admin_attributes
          }.to change(User, :count).by 0
        end

        it 'redirects to the admin users index' do
          post :create, user: valid_admin_attributes

          expect(response).to redirect_to admin_users_path
        end
      end
    end

    context 'without view_customers or view_admins permissions' do
      before :each do
        sign_in admin_without_permission
      end
      describe 'creating an admin' do
        before :each do
          valid_admin_attributes[:password] = 'password'
          valid_admin_attributes[:password_confirmation] = 'password'
        end
        it 'does not add the customer to the database' do
          expect{
            post :create, user: valid_admin_attributes
          }.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          post :create, user: valid_admin_attributes

          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end

      describe 'creating a customer' do
        it 'does not add the admin to the databse' do
          expect{
            post :create, user: valid_customer_attributes
          }.to change(User, :count).by 0
        end

        it 'redirects to the landing page' do
          post :create, user: valid_customer_attributes
          expect(response).to redirect_to admin_without_permission.role.landing_page
        end
      end
    end
  end
end