require 'rails_helper'

include Warden::Test::Helpers

RSpec.feature 'signing up' do
  before :each do
    visit new_user_registration_path
    @user_email = 'fake_email@test.com'
    @user_password = 'password'
    fill_in 'user_first_name', with: 'Thom'
    fill_in 'user_last_name', with: 'Yorke'
    fill_in 'user_email', with: @user_email
    fill_in 'user_password', with: @user_password
    fill_in 'user_password_confirmation', with: @user_password
    click_button 'Sign Up'
  end

  it 'creates a new customer with the input first name' do
    expect(Customer.where(first_name: 'Thom')).to exist
  end

  it 'creates a new customer with the input last name' do
    expect(Customer.where(last_name: 'Yorke')).to exist
  end

  it 'creates a new customer with the input email' do
    expect(Customer.where(email: @user_email)).to exist
  end

  it 'assigns the input password to the customer' do
    logout
    visit new_user_session_path
    fill_in 'user_email', with: @user_email
    fill_in 'user_password', with: @user_password
    click_button 'Log In'
    expect(page).to have_text 'Thom'
  end
end