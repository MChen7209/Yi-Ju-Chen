Rake::Task['db:reset'].invoke

# create 3 venues, each with 1 seating chart
# create shows, each show should have a seating chart for its venue
#

5.times do
  FactoryGirl.create :customer
end

3.times do
  venue = FactoryGirl.create :venue
  FactoryGirl.create :ticket_layout, venue_id: venue.id
end

20.times do
  FactoryGirl.create :show_with_tickets, venue_id: (rand(3) + 1)
end

5.times do
  FactoryGirl.create :stored_question, venue_id: (rand(3) + 1)
end

5.times do
  FactoryGirl.create :venue_answer, stored_question_id: (rand(5) + 1)
end

FactoryGirl.create :test_sales
FactoryGirl.create :test_manager
FactoryGirl.create :test_admin

FactoryGirl.create :test_customer
