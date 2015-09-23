require 'rails_helper'

shared_examples_for 'GET #new with create customer ability' do
  it 'assigns a new user to @user' do
    get :new
    expect(assigns :user).to be_a_new User
  end

  it 'assigns the admin_users_path to @url' do
    get :new
    expect(assigns :url).to eq admin_users_path
  end

  it 'renders the new admin user template' do
    get :new
    expect(response).to render_template :new
  end
end