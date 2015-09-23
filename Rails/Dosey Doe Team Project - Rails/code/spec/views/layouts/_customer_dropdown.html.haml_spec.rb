require 'rails_helper'

describe '/layouts/_customer_dropdown.html.haml' do
  before :each do
    @test_customer = create :customer, first_name: 'Fred', last_name: 'Astaire'
    sign_in @test_customer
  end

  it "displays the current user's name" do
    render

    expect(rendered).to have_css '#user_name', text: "#{@test_customer.first_name}/My Account"
  end

  it "displays the Sign Out link" do
    render
    expect(rendered).to have_link 'Sign Out', destroy_user_session_path
  end

  it 'displays the Shopping Cart link' do
    render

    expect(rendered).to have_link 'Shopping Cart', users_checkout_path
  end
end