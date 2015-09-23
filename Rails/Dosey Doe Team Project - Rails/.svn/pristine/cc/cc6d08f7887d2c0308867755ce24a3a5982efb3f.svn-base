FactoryGirl.define do
  factory :role do
    name { Faker::Name.first_name}
    sell_tickets false
    hold_seats false
    issue_refunds false
    view_reports false
    view_customers false
    view_admins false
    landing_page '/venues'

    factory :admin_role do
      name :Admin
      sell_tickets true
      hold_seats true
      issue_refunds true
      view_reports true
      view_customers true
      view_admins true
    end

    factory :manager_role do
      name :Manager
      sell_tickets true
      hold_seats true
      issue_refunds true
      view_reports true
      view_customers true
      view_admins true
    end

    factory :sales_role do
      name :Sales
      sell_tickets true
      hold_seats false
      issue_refunds true
      view_reports true
      view_customers true
      view_admins false
    end
  end
end