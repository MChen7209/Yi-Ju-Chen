require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::ShowsController, type: :controller do
  let(:valid_attributes) {
    build(:show).attributes
  }

  let(:invalid_attributes) {
    build(:show, show_date: nil).attributes
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

      context 'without params[:letter]' do
        it 'populates an array with all shows' do
          today = create(:show, show_date: Time.zone.today)
          tomorrow = create(:show, show_date: Time.zone.tomorrow)
          get :index
          expect(assigns(:shows)).to match_array([today, tomorrow])
        end

        it 'renders the :index template' do
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
        show = create(:show)
        get :show, id: show
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid id' do
        it 'assigns the requested Show to @show' do
          show = create(:show)
          get :show, id: show
          expect(assigns(:show)).to eq show
        end

        it 'assigns all seats associated with the show to @show' do
          show = create :show_with_tickets
        end

        it 'renders the :show template' do
          show = create(:show)
          get :show, id: show
          expect(response).to render_template :show
        end
      end

      context 'with an invalid id' do
        it 'fails to assign the request Show to @show' do
          expect { get :show, id: 1 }.to_not raise_error
        end

        it 'redirects to shows#index' do
          get :show, id: 1
          expect(response).to redirect_to admin_shows_path
        end

        it 'assigns all shows to @shows' do
          show_1 = create(:show)
          show_2 = create(:show)
          get :show, id: -1
          expect(assigns(:shows)).to match_array([show_1, show_2])
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

      it 'assigns a new Show to @show' do
        get :new
        expect(assigns :show).to be_a_new Show
      end

      it 'renders the :new template' do
        get :new
        expect(response).to render_template :new
      end
    end
  end

  describe 'GET #edit' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        show = create :show
        get :edit, id: show
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid id' do
        it 'assigns the requested show to @show' do
          show = create :show
          get :edit, id: show
          expect(assigns :show).to eq show
        end

        it 'renders the :edit template' do
          show = create :show
          get :edit, id: show
          expect(response).to render_template :edit
        end
      end

      context 'with an invalid id' do
        it 'does not throw an error' do
          expect { get :edit, id: -1 }.to_not raise_error
        end

        it 'assigns all shows to @shows' do
          show_1 = create(:show)
          show_2 = create(:show)
          get :edit, id: -1
          expect(assigns(:shows)).to match_array([show_1, show_2])
        end

        it 'redirects to the shows index' do
          get :edit, id: 1
          expect(response).to redirect_to admin_shows_path
        end
      end
    end
  end

  describe 'POST #create' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        post :create, show: valid_attributes
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with valid attributes' do
        it 'saves the new show to the database' do
          # add seating chart attributes
          expect {
            post :create, show: valid_attributes
          }.to change(Show, :count).by 1
        end

        it 'redirects to shows index' do
          post :create, show: valid_attributes
          expect(response).to redirect_to admin_shows_path
        end
      end

      context 'with invalid attributes' do
        it 'does not save the new show in the database' do
          expect {
            post :create, show: invalid_attributes
          }.not_to change(Show, :count)
        end

        it 're-renders the new template' do
          post :create, show: invalid_attributes
          expect(response).to render_template :new
        end
      end
    end
  end

  describe 'PATCH #update' do
    before :each do
      @show = create :show, show_date: Time.zone.today
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        patch :update, id: @show, show: attributes_for(:show)
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with valid attributes' do
        it 'updates the show in the database' do
          patch :update, id: @show, show: attributes_for(:show)
          expect(assigns :show).to eq @show
        end

        it 'redirects to shows index' do
          patch :update, id: @show, show: attributes_for(:show)
          expect(response).to redirect_to admin_shows_path
        end
      end

      context 'with invalid attributes' do
        it 'does not update the show' do
          patch :update, id: @show, show: invalid_attributes
          @show.reload
          expect(@show.show_date).not_to eq Time.zone.tomorrow
          expect(@show.show_date).to eq Time.zone.today
        end

        it 're-renders the :edit template' do
          patch :update, id: @show, show: invalid_attributes
          expect(response).to render_template :edit
        end
      end
    end
  end

  describe 'DELETE #destroy' do
    before :each do
      @show = create :show
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        delete :destroy, id: @show
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      it 'deletes the show from the database' do
        expect {
          delete :destroy, id: @show
        }.to change(Show, :count).by(-1)
      end

      it 'redirects to shows' do
        delete :destroy, id: @show
        expect(response).to redirect_to admin_shows_path
      end
    end
  end
end
