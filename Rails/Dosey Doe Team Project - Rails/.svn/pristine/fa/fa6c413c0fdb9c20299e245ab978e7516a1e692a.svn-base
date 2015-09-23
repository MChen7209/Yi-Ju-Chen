require 'rails_helper'

describe 'layouts/_navbar.html.haml' do
  it 'has a link to the DoseyDoe main web site' do
    render

    expect(rendered).to have_link 'dosey_doe_link', href: 'http://www.doseydoe.com'
  end

  it 'has a link to the Dosey Doe Tickets home page' do
    render

    expect(rendered).to have_link 'dosey_doe_tickets_link', href: root_path
  end

  context 'sign up link' do
    it 'has the link if the user is a guest' do
      sign_in create :guest
      render

      expect(rendered).to have_link 'Sign Up', href: new_user_registration_path
    end

    it 'does not have the link if the user is an admin' do
      sign_in create :admin
      render

      expect(rendered).not_to have_link 'Sign Up', href: new_user_registration_path
    end

    it 'does not have the link if the user is a customer' do
      sign_in create :customer
      render

      expect(rendered).not_to have_link 'Sign Up', href: new_user_registration_path
    end
  end

  describe 'displays a different user dropdown depending on the user type' do
    it 'displays the admin_dropdown partial when an admin is logged in' do
      sign_in create :admin
      render

      expect(rendered).to have_css '#admin_navbar_dropdown'
    end

    it 'displays the user_dropdown when a regular user is logged in' do
      sign_in create :customer
      render

      expect(rendered).to have_css '#customer_dropdown'
    end

    it 'displays the guest_dropdown when a guest is logged in' do
      render

      expect(rendered).to have_css '#guest_dropdown'
    end
  end

  describe 'displays a shopping cart link based on the number of tickets' do
    before :each do
      @test_user = create :customer
      sign_in @test_user
    end

    it 'does not show the shopping cart link when the cart is empty' do
      render
      expect(rendered).to_not have_text 'ticket in cart'
      expect(rendered).to_not have_text 'tickets in cart'
    end

    it 'shows the shopping cart link when there is one ticket' do
      create :customer_reserved_ticket, user_id: @test_user.id, status: 'reserved'
      render
      expect(rendered).to have_link '1 ticket in cart'
    end

    it 'shows the shopping cart link when there are several tickets' do
      22.times { create :customer_reserved_ticket, user_id: @test_user.id, status: 'reserved' }
      render
      expect(rendered).to have_link '22 tickets in cart'
    end

    it 'only shows tickets that are reserved' do
      create :customer_reserved_ticket, user_id: @test_user.id, status: 'reserved'
      create :customer_reserved_ticket, user_id: @test_user.id, status: 'sold'
      render
      expect(@test_user.tickets.count). to eq 2
      expect(rendered).to have_link '1 ticket in cart'
    end
  end
end
