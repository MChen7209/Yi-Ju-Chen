require 'rails_helper'

describe 'layouts/_guest_dropdown.html.haml' do
	it 'displays guest as the current user name' do
		render

		expect(rendered).to have_text 'Guest'
	end

	it 'displays a link to sign in' do
		render

		expect(rendered).to have_link 'Sign In', user_session_path
	end
end