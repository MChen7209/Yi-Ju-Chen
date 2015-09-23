FactoryGirl.define do
  factory :seating_chart do
    name { Faker::App.name }

    #association :price_section, factory: :price_section

    factory :chart_with_seats do
      after :build do |chart|
        50.times do
          create :seat, seating_chart: chart
        end
      end
    end
  end
end
