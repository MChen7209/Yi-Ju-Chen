FactoryGirl.define do
  factory :ticket do
    status :open

    association :show, factory: :show
    association :seat, factory: :seat

    factory :customer_reserved_ticket do
      reserved_until { DateTime.current + 10.minutes }
      association :user, factory: :customer
    end

    factory :admin_reserved_ticket do
      reserved_until { DateTime.current + 10.minutes }
      association :user, factory: :admin
    end

    factory :guest_reserved_ticket do
      reserved_until { DateTime.current + 10.minutes }
      association :user, factory: :guest
    end

    factory :sold_ticket do
      status :sold
      association :user, factory: :customer
    end
  end
end
