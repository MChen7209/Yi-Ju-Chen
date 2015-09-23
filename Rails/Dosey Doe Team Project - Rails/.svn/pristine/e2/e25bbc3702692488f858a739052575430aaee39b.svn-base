require 'rails_helper'
require "./spec/support/user_that_logs_in_examples"

RSpec.describe Customer, type: :model do
  it 'has a minimum valid factory' do
    expect(build :customer).to be_valid
  end

  it_behaves_like 'a user that logs in' do
    let(:user) {build :customer}
  end
end