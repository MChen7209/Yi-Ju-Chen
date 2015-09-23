require 'rails_helper'

shared_examples_for 'unauthorized admin page access attempt' do
  it 'redirects to the root page' do
    expect(response).to redirect_to root_path
  end

  it 'doesn\'t display a warning notice' do
    expect(flash[:notice]).to be nil
  end
end
