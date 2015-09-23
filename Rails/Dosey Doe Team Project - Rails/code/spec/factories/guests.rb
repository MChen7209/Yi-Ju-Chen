FactoryGirl.define do
  factory :guest, parent: :user, class: :Guest do
    type 'Guest'
  end
end
