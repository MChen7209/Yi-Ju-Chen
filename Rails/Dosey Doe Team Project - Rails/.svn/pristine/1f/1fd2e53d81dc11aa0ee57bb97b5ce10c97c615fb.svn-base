require 'rails_helper'

shared_examples_for 'a user that logs in' do
  let(:user) {}

  it 'is invalid without a first_name' do
    user.first_name = nil
    expect(user).not_to be_valid
  end

  it 'is invalid without a last_name' do
    user.last_name = nil
    expect(user).not_to be_valid
  end

  it 'is invalid without an email' do
    user.email = nil
    expect(user).not_to be_valid
  end

  it 'is invalid without a password' do
    user.password = nil
    user.encrypted_password = nil
    expect(user).not_to be_valid
  end
end
