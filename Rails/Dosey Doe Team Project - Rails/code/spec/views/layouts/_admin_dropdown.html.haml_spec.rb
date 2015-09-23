require 'rails_helper'

describe 'layouts/_admin_dropdown.html.haml' do
  context 'with no permissions' do
    before :each do
      sign_in create(:admin, first_name: 'Fake', last_name: 'Admin')
      render
    end

    it 'displays the name of the logged-in admin' do
      expect(rendered).to have_css '#user_name', text: 'Fake Admin'
    end

    it 'displays the Dashboard link' do
      expect(rendered).to have_link 'Dashboard', '/admin'
    end

    it 'displays a link to view shows' do
      expect(rendered).to have_link 'View Shows', admin_shows_path
    end

    it 'displays a link to create a show' do
      expect(rendered).to have_link 'Add Show', new_admin_show_path
    end

    it 'does not display a link to view/edit admins' do
      expect(rendered).not_to have_link 'View/Edit Admins', admin_users_path
    end

    it 'does not display a link to view/edit customers' do
      expect(rendered).not_to have_link 'View/Edit Customers', admin_users_path
    end

    it 'does not display an Admin Roles link' do
      expect(rendered).not_to have_link 'Admin Roles', admin_roles_path
    end

    it 'displays a link to the admin view of venues' do
      expect(rendered).to have_link 'View Venues', admin_venues_path
    end

    it 'displays a link to create a new venue' do
      expect(rendered).to have_link 'Add Venue', new_admin_venue_path
    end

    it 'displays a link to the ticket layouts page' do
      expect(rendered).to have_link 'Ticket Layouts', admin_ticket_layouts_path
    end
    
    it 'displays a link to sign out' do
      expect(rendered).to have_link 'Sign Out', destroy_user_session_path
    end
  end

  context 'with view_admins permissions' do
    before :each do
      sign_in create :admin, role: create(:role, view_admins: true)
      render
    end
    it 'displays a link to view and edit admins' do
      expect(rendered).to have_link 'View/Edit Admins', admin_admins_path
    end

    it 'displays a link to view and edit customers' do
      expect(rendered).to have_link 'View/Edit Customers', admin_customers_path
    end

    it 'displays a link to create a new user' do
      expect(rendered).to have_link 'Create New User', new_admin_user_path
    end

    it 'displays a link to modify admin roles' do
      expect(rendered).to have_link 'Admin Roles', admin_roles_path
    end
  end

  context 'with only view_customers permissions' do
    before :each do
      sign_in create :admin, role: create(:role, view_customers: true)
      render
    end
    it 'displays a link to view and edit users' do
      expect(rendered).to have_link 'View/Edit Customers', admin_users_path
    end

    it 'does not display a link to view and edit admin' do
      expect(rendered).not_to have_link 'View/Edit Admins', admin_users_path
    end

    it 'displays a link to create a new user' do
      expect(rendered).to have_link 'Create New User', new_admin_user_path
    end

    it 'does not display a link to modify admin roles' do
      expect(rendered).not_to have_link 'Admin Roles', admin_roles_path
    end
  end
end
