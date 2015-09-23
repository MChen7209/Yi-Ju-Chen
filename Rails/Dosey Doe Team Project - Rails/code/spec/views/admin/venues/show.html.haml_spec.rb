require 'rails_helper'

describe 'admin/venues/show.html.haml' do
  before :each do
    @venue_test = create :venue, name: 'The Average-Sized Barn'
  end

  it 'displays the venue name for the selected venue' do
    assign(:venue, @venue_test)
    render

    expect(rendered).to have_text @venue_test.name
  end

  it 'displays the contact information address' do
  assign(:venue, @venue_test)
    render

    expect(rendered).to have_text @venue_test.address_line1
  end

  it 'displays the contact information phone number' do
    assign(:venue, @venue_test)
    render

    expect(rendered).to have_text number_to_phone @venue_test.phone
  end

  it 'displays the contact information email' do
    assign(:venue, @venue_test)
    render

    expect(rendered).to have_text 'placeholder@doseydoe.com'
  end
end