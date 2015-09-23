FactoryGirl.define do
  factory :show do
    show_date { Faker::Date.forward 30 }
    # default doors_open, dinner_starts, dinner_ends,
    # show_starts are filled in model
    artist { Faker::Name.name }

    association :venue, factory: :venue
    association :seating_chart, factory: :seating_chart

    factory :dinner_and_a_show do
      dinner_served true
      dinner_starts { Faker::Time.forward 30, :afternoon }
      dinner_ends { Faker::Time.forward 30, :afternoon }
    end

    factory :show_with_tickets do
      after(:build) do |show|
        10.times do
          create(:ticket, show: show)
        end
      end
    end
  end
end
