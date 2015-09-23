FactoryGirl.define do
  factory :admin, parent: :user, class: :Admin do
    email { Faker::Internet.email }
    password { Faker::Internet.password }
    first_name { Faker::Name.first_name }
    last_name { Faker::Name.last_name }
    type 'Admin'

    association :role, factory: :role

    factory :godmode_admin do
      association :role, factory: :admin_role
    end

    factory :test_admin do
      email 'fake_admin@test.com'
      password 'password'
      association :role, factory: :admin_role
    end

    factory :test_manager do
      email 'fake_manager@test.com'
      password 'password'
      association :role, factory: :manager_role
    end

    factory :test_sales do
      email 'fake_sales@test.com'
      password 'password'
      association :role, factory: :sales_role
    end
  end
end
