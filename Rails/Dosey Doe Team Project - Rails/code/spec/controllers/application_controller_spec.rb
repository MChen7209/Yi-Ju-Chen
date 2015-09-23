require 'rails_helper'

RSpec.describe ApplicationController, type: :controller, private: true do
  it 'redirects to the root path after sign out' do
    test_customer = sign_in create :customer
    expect(subject.after_sign_out_path_for(test_customer)).to eq root_path
  end
end
