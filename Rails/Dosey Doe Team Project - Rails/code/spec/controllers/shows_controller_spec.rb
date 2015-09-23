require 'rails_helper'

RSpec.describe ShowsController, type: :controller do
  describe 'Get #show' do
    context 'with valid params' do
      before :each do
        @test_show_without_dinner = create :show
        get :show, id: @test_show_without_dinner
      end
      it 'assigns the requested show to @show' do
        expect(assigns :show).to eq @test_show_without_dinner
      end

      it 'renders the show template' do
        expect(response).to render_template :show
      end
    end

    context 'with invalid params' do
      it 'does not throw an error' do
        expect { get :show, id: -1 }.not_to raise_error
      end

      it 'assigns all venues to @venues' do
        test_venue1 = create :venue
        test_venue2 = create :venue
        get :show, id: -1
        expect(assigns :venues).to match_array([test_venue1, test_venue2])
      end

      it 'redirects to the Venues index template' do
        get :show, id: -1
        expect(response).to redirect_to venues_path
      end
    end
  end

  describe 'GET #index' do
    context 'with valid params' do
      context 'with no params' do
        it 'assigns all shows to @shows' do
          test_show_1 = create :show
          test_show_2 = create :show
          get :index
          expect(assigns :shows).to match_array([test_show_1, test_show_2])
        end

        it 'renders the index template' do
          get :index
          expect(response).to render_template :index
        end
      end
    end

    context 'with invalid params'
  end

  context 'with params' do
    it 'ignores the params and populates an array with all shows' do
      test_show_1 = create :show, artist: 'mom'
      create :show, artist: 'dad'
      test_show_3 = create :show, artist: 'momdad'

      get :index, search: 'mom'
      expect(assigns :shows).to match_array([test_show_1, test_show_3])
    end

    it 'renders the :index template' do
      get :index, search: 'mom'
      expect(response).to render_template :index
    end
  end
end
