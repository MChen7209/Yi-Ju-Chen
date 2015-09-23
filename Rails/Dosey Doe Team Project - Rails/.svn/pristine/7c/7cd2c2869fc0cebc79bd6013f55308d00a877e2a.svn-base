require 'rails_helper'
require "./spec/support/user_that_logs_in_examples"

RSpec.describe Admin, type: :model do
  it 'has a minimum valid factory' do
    expect(build :admin).to be_valid
  end

  it 'is invalid without a role' do
    expect(build :admin, role_id: :nil).not_to be_valid
  end

  it 'belongs_to a role' do
    role_association = Admin.reflect_on_association(:role)
    expect(role_association.macro).to eq :belongs_to
  end

  it_behaves_like 'a user that logs in' do
    let(:user) {build :admin}
  end
end
