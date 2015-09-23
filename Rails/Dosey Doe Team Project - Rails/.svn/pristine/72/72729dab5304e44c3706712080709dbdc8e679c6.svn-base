require 'rails_helper'

RSpec.describe Role, type: :model do
  it 'has a valid role factory' do
    expect(build :role).to be_valid
  end

  it 'has a valid manager factory' do
    expect(build :manager_role).to be_valid
  end

  it 'has a valid admin factory' do
    expect(build :admin_role).to be_valid
  end

  it 'has a valid sales factory' do
    expect(build :sales_role).to be_valid
  end

  it 'view_customers is true if view_admins is true' do
    test_role = create :role, view_admins: true
    expect(test_role.view_customers).to eq true
  end

  it 'is invalid without a landing page' do
    expect(build :role, landing_page: nil).not_to be_valid
  end

  it 'is invalid with a name' do
    expect(build :role, name: nil).not_to be_valid
  end

  it 'is invalid with a sell_tickets value' do
    expect(build :role, sell_tickets: nil).not_to be_valid
  end

  it 'is invalid without a hold_seats value' do
    expect(build :role, hold_seats: nil).not_to be_valid
  end

  it 'is invalid without an issue_refunds value' do
    expect(build :role, issue_refunds: nil).not_to be_valid
  end

  it 'is invalid without a view_reports value' do
    expect(build :role, view_reports: nil).not_to be_valid
  end

  it 'is invalid without a view_customers value' do
    expect(build :role, view_customers: nil).not_to be_valid
  end

  it 'is invalid without a view_admins value' do
    expect(build :role, view_admins: nil).not_to be_valid
  end

  it 'has_many admins' do
    admin_association = Role.reflect_on_association :admins
    expect(admin_association.macro).to eq :has_many
  end
end
