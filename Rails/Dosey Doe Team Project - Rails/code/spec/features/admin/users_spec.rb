require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Users form', type: :feature do
  before :each do
    login_as create :admin, role: create(:role, view_admins: true)
  end

  after :each do 
      Warden.test_reset!
    end

  describe 'creating a user' do
    before :each do
      create :manager_role
      visit new_admin_user_path
      fill_in 'user_first_name', with: 'Thom'
      fill_in 'user_last_name', with: 'Yorke'
      fill_in 'user_email', with: 'thom@yorke.com'
      select 'Customer', from: 'user_type'
      fill_in 'user_password', with: 'password'
      fill_in 'user_password_confirmation', with: 'password'
    end

    context 'creating a customer' do
      before :each do
        click_button 'Create User'
      end
      it 'assigns the input first_name to the new user' do
        expect(Customer.where(first_name: 'Thom')).to exist
      end

      it 'assigns the input last_name to the new user' do
        expect(Customer.where(last_name: 'Yorke')).to exist
      end

      it 'assigns the input email to the new user' do
        expect(Customer.where(email: 'thom@yorke.com')).to exist
      end

      it 'assigns the input password to the new user' do
        logout :user
        visit new_user_session_path

        fill_in 'user_email', with: 'thom@yorke.com'
        fill_in 'user_password', with: 'password'
        click_button 'Log In'

        expect(page).to have_text 'Thom/My Account'
      end

      it 'does not have the user_role_id dropdown', js: true do
        expect(page).not_to have_css '#user_role_id'
      end

      context 'without view_admin priveleges' do

      end
    end

    context 'creating an admin' do
      context 'with view_admins priveleges' do
        before :each do
          select 'Admin', from: 'user_type'
          select 'Manager', from: 'user_role_id'
        end

        it 'displays the user_role_id dropdown when admin is selected', js: true do
          expect(page).to have_css '#user_role_id'
        end

        it 'saves the user with the role selected' do
          click_button 'Create User'
          expect(Role.find_by(name: 'Manager').admins).to exist
        end

        it 'saves the user as an admin' do
          click_button 'Create User'
          expect(Admin.where(first_name: 'Thom')).to exist
        end
      end
    end

    context 'without view_admins priveleges' do
      before :each do
        logout :user
        login_as create :admin, role: create(:role, view_customers: true, view_admins: false)
        visit new_admin_user_path
      end

      it 'does not have an option for Admin in the type dropdown' do
        expect(page).not_to have_select('user_type', options: ['Admin'])
      end

      it 'does not have a dropd-down for admin role', js: true do
        expect(page).not_to have_select('user_role_id')
      end
    end
  end

  describe 'deleting a user' do
    it 'deletes the user if the user is an admin' do
      test_admin_2 = create :admin

      expect {
        visit admin_admins_path
        click_link "delete_user#{test_admin_2.id}"
        }.to change(User, :count).by -1
    end
  end
end