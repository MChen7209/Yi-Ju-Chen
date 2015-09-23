require 'rails_helper'

describe 'admin/users/index.html.haml' do
  before :each do
      @test_customer_1 = create(:customer, first_name: 'Alice', last_name: 'Anderson', email: 'aa@awesome.com')
      @test_customer_2 = create(:customer, first_name: 'Bob', last_name: 'Burkholder', email: 'bb@business.com')
      @test_admin_1 = create(:test_manager, first_name: 'Chris', last_name: 'Christophsen', email: 'cc@charity.com')
      @test_admin_2 = create(:admin, first_name: 'Dave', last_name: 'Davidson', email: 'dd@doctors.com')
  end
  context 'displaying customers' do
    before :each do
      assign :users, Customer.all
      assign :user_type, 'Customer'
      render
    end

    it 'displays the first name of all customers' do
      expect(rendered).to have_text @test_customer_1.first_name
      expect(rendered).to have_text @test_customer_2.first_name
    end

    it 'does not display the first name of any admins' do
      expect(rendered).not_to have_text @test_admin_1.first_name
      expect(rendered).not_to have_text @test_admin_2.first_name
    end

    it 'displays the last name of all customers' do
      expect(rendered).to have_text @test_customer_1.last_name
      expect(rendered).to have_text @test_customer_2.last_name
    end

    it 'does not display the last name of any admins' do
      expect(rendered).not_to have_text @test_admin_1.last_name
      expect(rendered).not_to have_text @test_admin_2.last_name
    end

    it 'displays the email of all customers' do
      expect(rendered).to have_text @test_customer_1.email
      expect(rendered).to have_text @test_customer_2.email      
    end

    it 'does not display the email of any admins' do
      expect(rendered).not_to have_text @test_admin_1.email
      expect(rendered).not_to have_text @test_admin_2.email
    end

    it 'displays the user type of customer' do
      expect(rendered).to have_text 'Customer'
    end

    it 'does not display the user type of admin' do
      expect(rendered).not_to have_text 'Admin'
    end

    it 'displays an edit button' do
      expect(rendered).to have_link 'edit', edit_admin_user_path(@test_customer_1)
      expect(rendered).to have_link 'edit', edit_admin_user_path(@test_customer_2)
    end

    it 'displays a link to create a new user' do
      expect(rendered).to have_link 'New User', new_admin_user_path
    end
  end

  context 'displaying admins' do
    before :each do
      assign :users, Admin.all
      assign :user_type, 'Admin'
      render
    end
    it 'displays the first name of all admins' do
      expect(rendered).to have_text @test_admin_1.first_name
      expect(rendered).to have_text @test_admin_2.first_name
    end

    it 'does not display the first name of any customers' do
      expect(rendered).not_to have_text @test_customer_1.first_name
      expect(rendered).not_to have_text @test_customer_2.first_name
    end

    it 'displays the last name of all admins' do
      expect(rendered).to have_text @test_admin_1.last_name
      expect(rendered).to have_text @test_admin_2.last_name
    end

    it 'does not display the first name of any customers' do
      expect(rendered).not_to have_text @test_customer_1.last_name
      expect(rendered).not_to have_text @test_customer_2.last_name
    end

    it 'displays the email of all admins' do
      expect(rendered).to have_text @test_admin_1.email
      expect(rendered).to have_text @test_admin_2.email
    end

    it 'does not display the email of any customers' do
      expect(rendered).not_to have_text @test_customer_1.email
      expect(rendered).not_to have_text @test_customer_2.email
    end

    it 'displays the user type of admin' do
      expect(rendered).to have_text 'Admin'
    end

    it 'does not display the user type of customer' do
      expect(rendered).not_to have_text 'Customer'
    end

    it 'displays an edit button' do
      expect(rendered).to have_link 'edit', edit_admin_user_path(@test_admin_1)
      expect(rendered).to have_link 'edit', edit_admin_user_path(@test_admin_2)
    end

    it 'displays a delete button' do
      expect(rendered).to have_link 'delete', admin_user_path(@test_admin_1)
      expect(rendered).to have_link 'delete', admin_user_path(@test_admin_2)
    end

    it 'displays a link to create a new user' do
      expect(rendered).to have_link 'New User', new_admin_user_path
    end
  end
end