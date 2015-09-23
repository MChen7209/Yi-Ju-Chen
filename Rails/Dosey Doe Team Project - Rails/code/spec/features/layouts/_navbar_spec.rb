require 'rails_helper'

include Warden::Test::Helpers
Warden.test_mode!

RSpec.feature 'Venues features', :type => :feature do
  describe 'On nav bar, pressing' do
    it 'Dosey Doe Logo/words brings up dosey doe main website' do
      visit root_path
      click_on 'Dosey Doe'
      href = 'http://www.doseydoe.com'
      page.should have_selector "a[href='#{href}']", text: "Dosey Doe"
    end

    it 'Contact us brings up the contact us static page' do
      visit root_path
      click_on 'Contact Us'
      expect(page).to have_text 'Contact Us'
    end

    it 'Privacy Policy brings up the privacy policy static page' do
      visit root_path
      click_on 'Privacy Policy'
      expect(page).to have_text 'Privacy Policy'
    end
  end
end