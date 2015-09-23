require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::VenuesController, type: :controller do
  let(:valid_attributes) {
    build(:venue).attributes
  }

  let(:invalid_attributes) {
    build(:venue, name: nil).attributes
  }

  describe 'GET #index' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        get :index
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

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
  end

  describe 'GET #show' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        venue = create(:venue)
        get :show, id: venue
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

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
          expect(response).to redirect_to admin_venues_path
        end
      end
    end
  end

  describe 'GET #new' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        get :new
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      it 'assigns a new venue to @venue' do
        get :new
        expect(assigns :venue).to be_a_new Venue
      end

      it 'renders the :new template' do
        get :new
        expect(response).to render_template :new
      end
    end
  end
###
  describe 'GET #edit' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        venue = create(:venue)
        get :edit, id: venue
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid venue id' do
        it 'assigns the venue to @venue' do
          venue = create :venue
          get :edit, id: venue
          expect(assigns :venue).to eq venue
        end

        it 'renders the form template' do
          venue = create :venue
          get :edit, id: venue
          expect(response).to render_template :edit
        end
      end

      context 'with an invalid venue id' do
        it 'does not throw an error' do
          expect{get :edit, id: -1}.to_not raise_error
        end

        it 'assigns all venues to @venues' do
          venues_1 = create(:venue)
          venues_2 = create(:venue)
          get :edit, id: -1
          expect(assigns(:venues)).to match_array([venues_1, venues_2])
        end

        it 'redirects to the index template' do
          get :edit, id: 1
          expect(response).to redirect_to admin_venues_path
        end
      end
    end
  end

  describe 'POST #create' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        post :create, venue: valid_attributes
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with valid [:params]' do
        it 'saves the new venue to the database' do
          expect {
            post :create, venue: valid_attributes
          }.to change(Venue, :count).by 1
        end

        it 'redirects to the venues index' do
          post :create, venue: valid_attributes
          expect(response).to redirect_to admin_venues_path
        end
      end

      context 'with invalid [:params]' do
        it 'does not save the new venue to the database' do
          expect {
            post :create, venue: invalid_attributes
          }.not_to change(Venue, :count)
        end

        it 're-renders the new template' do
          post :create, venue: invalid_attributes
          expect(response).to render_template :new
        end
      end
    end
  end

  describe 'PATCH #update' do
    before :each do
      @venue = create :venue, name: 'The Medium-Sized Barn'
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        patch :update, id: @venue, venue: attributes_for(:venue)
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with valid attributes' do
        it 'updates the venue in the database' do
          patch :update, id: @venue, venue: attributes_for(:venue)
          expect(assigns :venue).to eq @venue
        end

        it 'redirects to the venues index' do
          patch :update, id: @venue, venue: attributes_for(:venue)
          expect(response).to redirect_to admin_venues_path
        end
      end

      context 'with invalid attributes' do
        it 'does not updates the venue' do
          patch :update, id: @venue, venue: {name: 'The Biggest Barn'}
          expect(@venue.name).to eq 'The Medium-Sized Barn'
        end

        it 're-renders the edit template' do
          patch :update, id: @venue, venue: invalid_attributes
        end
      end
    end
  end
end