FactoryGirl.define do
  factory :customer do
    first_name { Faker::Name.first_name }
    last_name { Faker::Name.last_name }
    email { Faker::Internet.email }
    password { Faker::Internet.password }
    type 'Customer'

    factory :test_customer do
      email 'fake_customer@test.com'
      password 'password'
    end
  end
end
