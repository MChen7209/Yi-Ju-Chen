FactoryGirl.define do
  factory :venue_answer do
    answer {Faker::Lorem.sentence}

    association :stored_question, factory: :stored_question
  end
end
