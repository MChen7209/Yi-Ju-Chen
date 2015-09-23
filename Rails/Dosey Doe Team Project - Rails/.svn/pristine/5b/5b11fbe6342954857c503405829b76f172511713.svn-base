require 'rails_helper'

RSpec.describe Admin::RolesController, type: :controller do
  let(:valid_attributes) do
    build(:role, view_customers: true).attributes
  end

  let(:invalid_attributes) do
    build(:role, view_customers: true, name: nil).attributes
  end

  let(:admin_with_permission) do
    create :admin, role: create(:role, view_admins: true)
  end

  let(:admin_without_permission) do
    create :admin, role: create(:role, view_admins: false)
  end

  describe 'GET #index' do
    context 'admin with view_admins permission' do
      before :each do
        sign_in admin_with_permission
      end

      it 'assigns all roles to @roles' do
        test_admin_role = create :role
        get :index

        expect(assigns :roles).to match_array([test_admin_role, admin_with_permission.role])
      end

      it 'renders the roles template' do
        get :index

        expect(response).to render_template :index
      end
    end

    context 'admin without view_admin permissions' do
      it 'redirects to the landing page' do
        sign_in admin_without_permission
        get :index

        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end

    context 'non-admin user' do
      context 'guest' do
        it 'redirects to the root page' do
          sign_in create :guest
          get :index

          expect(response).to redirect_to root_path
        end
      end

      context 'customer' do
        it 'redirects to the root page' do
          sign_in create :customer
          get :index

          expect(response).to redirect_to root_path
        end
      end
    end
  end

  describe 'PATCH #update' do
    before :each do
      @test_role = create :role, view_customers: false
    end

    context 'admin with view_admin permissions' do
      before :each do
        sign_in admin_with_permission
      end
      context 'with valid attributes' do
        it 'updates the role in the database' do
          patch :update, id: @test_role, role: valid_attributes
          @test_role.reload

          expect(@test_role.view_customers).to eq true
        end

        it 'redirects to the roles index' do
          patch :update, id: @test_role, role: valid_attributes

          expect(response).to redirect_to admin_roles_path
        end
      end

      context 'with invalid attributes' do
        it 'does not update the role in the database' do
          patch :update, id: @test_role, role: invalid_attributes
          @test_role.reload

          expect(@test_role.view_customers).to eq false
        end

        it 're-renders the index template' do
          patch :update, id: @test_role, role: invalid_attributes

          expect(response).to render_template :index
        end
      end
    end

    context 'admin without view_admin permissions' do
      it 'redirects to the landing page' do
        sign_in admin_without_permission

        patch :update, id: @test_role, role: valid_attributes
        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end
  end

  describe 'DELETE #destroy' do
    before :each do
      @test_role = create :role
    end

    context 'with view_admins permissions' do
      before :each do
        sign_in admin_with_permission
      end

      it 'removes the role from the database' do
        expect{
          delete :destroy, id: @test_role
        }.to change(Role, :count).by -1
      end

      it 'redirects to the roles index' do
        delete :destroy, id: @test_role

        expect(response).to redirect_to admin_roles_path
      end
    end

    context 'admin without view_admins permissions' do
      it 'redirects to the landing page' do
        sign_in admin_without_permission
        delete :destroy, id: @test_role

        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end
  end

  describe 'POST #create' do
    context 'with view_admins access' do
      before :each do
        sign_in admin_with_permission
      end

      context 'valid params' do
        it 'adds the role to the database' do
          expect {
            post :create, role: valid_attributes
          }.to change(Role, :count).by 1
        end

        it 'redirects to the roles index' do
          post :create, role: valid_attributes

          expect(response).to redirect_to admin_roles_path
        end
      end

      context 'invalid params' do
        it 'does not add the role to the database' do
          expect{
            post :create, role: invalid_attributes
          }.to change(Role, :count).by 0
        end

        it 'redirects to the admin_roles_path' do
          post :create, role: invalid_attributes

          expect(response).to redirect_to admin_roles_path
        end
      end
    end

    context 'without view_admins access' do
      it 'redirects to the landing page' do
        sign_in admin_without_permission
        post :create, role: valid_attributes

        expect(response).to redirect_to admin_without_permission.role.landing_page
      end
    end
  end
end