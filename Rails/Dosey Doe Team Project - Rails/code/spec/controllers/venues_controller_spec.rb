require 'rails_helper'

RSpec.describe VenuesController, type: :controller do
  let(:valid_attributes) {
    build(:venue).attributes
  }

  let(:invalid_attributes) {
    build(:venue, name: nil).attributes
  }

  describe 'GET #index' do
    context 'with [:params]' do
      it 'ignores the parameters and populates an array with all venues' do
        venue1 = create(:venue, name: 'The Cosmic Barn')
        venue2 = create(:venue, name: 'The Average Barn')
        venue3 = create(:venue, name: 'The Microscopic Barn')
        get :index
        expect(assigns(:venues)).to match_array([venue1, venue2, venue3])
      end
    end

    context 'without [:params]' do
      it 'populates an array with all venues' do
        venue1 = create(:venue, name: 'The Big Barn')
        venue2 = create(:venue, name: 'The Little Barn')
        venue3 = create(:venue, name: 'The Medium-Sized Barn')
        get :index
        expect(assigns(:venues)).to match_array([venue1, venue2, venue3])
      end

      it 'renders the index template' do
        get :index
        expect(response).to render_template :index
      end
    end
  end

  describe 'GET #show' do
    context 'with a valid id' do
      it 'assigns that venue to @venue' do
        venue = create(:venue)
        get :show, id: venue
        expect(assigns(:venue)).to eq venue
      end

      it 'renders the :show template' do
        venue = create(:venue)
        get :show, id: venue
        expect(response).to render_template :show
      end
    end

    context 'with an invalid id' do
      it 'does not assign a venue to @venue' do
        expect{
          get :show, id: -1}.not_to raise_error
      end

      it 'assigns all venues to @venues' do
        venue1 = create :venue
        venue2 = create :venue
        get :show, id: -1
        expect(assigns :venues).to eq [venue1, venue2]
      end

      it 'renders the Venue#index template' do
        get :show, id: -1
        expect(response).to redirect_to venues_path
      end
    end
  end
end
