FactoryGirl.define do
  factory :venue do
    name { Faker::Address.street_name }
    # address_line1 { Faker::Address.street_address}
    address_line1 { "25911 W Interstate 45 Service Rd Spring, TX"}
    # city { Faker::Address.city }
    # state { Faker::Address.state }
    city { "Spring" }
    state { "TX" }
    zip { Faker::Address.zip_code }
    phone { rand(10**9..10**10)}

    factory :venue_with_address_line_2 do
      address_line2 {'Apt B'}
    end
  end
end
