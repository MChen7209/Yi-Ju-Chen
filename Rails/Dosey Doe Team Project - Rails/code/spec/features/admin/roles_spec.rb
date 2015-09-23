require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Roles features', type: :feature do
  def update_and_reload_role
    click_button 'Update'
    @test_role.reload
  end

  after :each do
    Warden.test_reset!
  end

  let(:admin_with_permission) {
    create :admin, role: create(:role, view_admins: true)
  }

  describe 'editing a role' do
    before :each do
      @test_role = create :role, name: :test, sell_tickets: false, hold_seats: false,
                   issue_refunds: false, view_reports: false, view_customers: false, view_admins: false
      login_as admin_with_permission
      visit admin_roles_path
    end

    it 'updates the role name' do
      within '#test_row' do
        fill_in 'role_name', with: 'Updated Name'
        update_and_reload_role
      end

      expect(@test_role.name).to eq 'Updated Name'
    end

    it 'updates the landing_page' do
      within '#test_row' do
        fill_in 'role_landing_page', with: '/landing/page'
        update_and_reload_role
      end

      expect(@test_role.landing_page).to eq '/landing/page'
    end

    it 'updates the sell_tickets' do
      within '#test_row' do
        check 'role_sell_tickets'
        update_and_reload_role
      end

      expect(@test_role.sell_tickets).to eq true
    end

    it 'updates the hold_seats' do
      within '#test_row' do
        check 'role_hold_seats'
      update_and_reload_role
      end

      expect(@test_role.hold_seats).to eq true
    end

    it 'updates the issue_refunds' do
      within '#test_row' do
        check 'role_issue_refunds'
      update_and_reload_role
      end

      expect(@test_role.issue_refunds).to eq true
    end

    it 'updates the view_reports' do
      within '#test_row' do
        check 'role_view_reports'
      update_and_reload_role
      end

      expect(@test_role.view_reports).to eq true
    end

    it 'updates the view_customers' do
      within '#test_row' do
        check 'role_view_customers'
        update_and_reload_role
      end

      expect(@test_role.view_customers).to eq true
    end

    it 'updates the view_admins' do
      within '#test_row' do
        check 'role_view_admins'
        update_and_reload_role
      end

      expect(@test_role.view_admins).to eq true
    end
  end

  describe 'adding a role' do
    before :each do
      create :manager_role
      login_as admin_with_permission
      visit admin_roles_path
      click_link 'Add Role'
      within '#new_role_attributes' do
        @test_role_name = 'Test Role'
        fill_in 'role_name', with: @test_role_name
        fill_in 'role_landing_page', with: '/landing/page'
        check 'role_sell_tickets'
        check 'role_hold_seats'
        check 'role_view_customers'
      end
    end

    it 'saves the new role in the database' do
      expect {
        click_button 'Add'
        }.to change(Role, :count).by 1
    end

    it 'saves the role with the name value' do
      click_button 'Add'

      expect(Role.where(name: @test_role_name)).to exist
    end

    it 'saves the landing page value' do
      click_button 'Add'

      expect(Role.where(landing_page: '/landing/page')).to exist
    end

    it 'saves the role with the sell_tickets value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).sell_tickets).to eq true
    end

    it 'saves the role with the hold_seats value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).hold_seats).to eq true
    end

    it 'saves the role with the issue_refunds value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).issue_refunds).to eq false
    end

    it 'saves the role with the view_reports value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).view_reports).to eq false
    end

    it 'saves the role with the view_customers value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).view_customers).to eq true
    end

    it 'saves the role with the view_admins value' do
      click_button 'Add'

      expect(Role.find_by(name: @test_role_name).view_admins).to eq false
    end
  end

  describe 'redirect on sign in' do
    it "redirects to the role's landing page" do
      test_admin = create :test_admin
      visit new_user_session_path
      fill_in 'user_email', with: 'fake_admin@test.com'
      fill_in 'user_password', with: 'password'
      click_button 'Log In'

      expect(current_path).to eq test_admin.role.landing_page
    end
  end
end