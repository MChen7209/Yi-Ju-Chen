require 'rails_helper'

RSpec.describe NullRole, type: :model do
  it "it has 'No Role' for a name" do
    expect(NullRole.instance.name).to eq('No role')
  end

  it "has a value of 'false' for sell_tickets" do
    expect(NullRole.instance.sell_tickets).to equal(false)
  end

  it "has a value of 'false' for hold_seats" do
    expect(NullRole.instance.hold_seats).to equal(false)
  end

  it "has a value of 'false' for issue_refunds" do
    expect(NullRole.instance.issue_refunds).to equal(false)
  end

  it "has a value of 'false' for view_reports" do
    expect(NullRole.instance.view_reports).to equal(false)
  end

  it "has a value of 'false' for view_customers" do
    expect(NullRole.instance.view_customers).to equal(false)
  end

  it "has a value of 'false' for view_admins" do
    expect(NullRole.instance.view_admins).to equal(false)
  end

  it "has a value of '/' for landing_page" do
    expect(NullRole.instance.landing_page).to eq('/')
  end
end
