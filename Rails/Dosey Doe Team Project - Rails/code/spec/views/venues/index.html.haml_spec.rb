# require 'rails_helper'
#
# describe '/shows/index.html.haml' do
#   before :each do
#     @venue_without_address_2 = create :venue, name: 'The Small Barn'
#     @venue_with_address_2 = create :venue_with_address_line_2, name: 'The Medium-Sized Barn'
#   end
#
#   context 'displays all venues assigned to @venues'
#   it 'displays all venues names in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_without_address_2.name
#     expect(rendered).to have_text @venue_with_address_2.name
#   end
#
#   it 'displays the address_2 of all venues in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_without_address_2.address_line2
#     expect(rendered).to have_text @venue_with_address_2.address_line2
#   end
#
#   it 'displays the address_1 of all venues in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_with_address_2.address_line1
#     expect(rendered).to have_text @venue_without_address_2.address_line1
#   end
#
#   it 'displays the city of all venues in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_with_address_2.city
#     expect(rendered).to have_text @venue_without_address_2.city
#   end
#
#   it 'displays the state of all venues in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_with_address_2.state
#     expect(rendered).to have_text @venue_without_address_2.state
#   end
#
#   it 'displays the zip of all venues in the database' do
#     assign(:venues, Venue.all)
#     render
#
#     expect(rendered).to have_text @venue_with_address_2.zip
#     expect(rendered).to have_text @venue_without_address_2.zip
#   end
# end