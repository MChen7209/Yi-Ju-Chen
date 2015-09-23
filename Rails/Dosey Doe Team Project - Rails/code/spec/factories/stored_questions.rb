FactoryGirl.define do
  factory :stored_question do
    question {Faker::Lorem.sentence}
    active {Faker::Number.between(0,1)}

    association :venue, factory: :venue
  end

end
