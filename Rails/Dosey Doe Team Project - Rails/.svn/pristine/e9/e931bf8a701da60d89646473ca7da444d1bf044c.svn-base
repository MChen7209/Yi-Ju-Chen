require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::SeatingChartsController, type: :controller do
  let(:valid_attributes) {
    seating_chart = build(:seating_chart)
    seats_array = []
    3.times do
      new_seat = build :seat
      new_seat.seating_chart = seating_chart
      seats_array.push new_seat
    end
    seating_chart_attributes = seating_chart.attributes
    seating_chart_attributes[:seats] = seats_array.to_json
    seating_chart_attributes
  }

  let(:invalid_chart_attributes) {
    build(:seating_chart, name: nil).attributes
  }

  let(:invalid_seat_attributes) {
    seating_chart = build(:seating_chart)
    seats_array = []
    3.times do
      new_seat = build :seat, x: nil
      new_seat.seating_chart = seating_chart
      seats_array.push new_seat
    end
    seating_chart_attributes = seating_chart.attributes
    seating_chart_attributes[:seats] = seats_array.to_json
    seating_chart_attributes
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
        it 'ignores the params and populates an array with all seating charts' do
          chart_1 = create(:seating_chart, name: 'Chart_1')
          chart_2 = create(:seating_chart, name: 'Chart_2')
          get :index, 'something'
          expect(assigns :seating_charts).to match_array([chart_1, chart_2])
        end

        it 'renders the :index template' do
          get :index, 'something'
          expect(response).to render_template :index
        end
      end

      context 'without params' do
        it 'populates an array with all ticket layouts' do
          chart_1 = create(:seating_chart, name: 'Chart_1')
          chart_2 = create(:seating_chart, name: 'Chart_2')
          get :index
          expect(assigns :seating_charts).to match_array([chart_1, chart_2])
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
        seating_chart = create(:seating_chart)
        get :show, id: seating_chart
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid id' do
        it 'assigns the requested seating_chart to @seating_chart' do
          seating_chart = create(:seating_chart)
          get :show, id: seating_chart
          expect(assigns :seating_chart).to eq seating_chart
        end

        it 'renders the :show template' do
          seating_chart = create(:seating_chart)
          get :show, id: seating_chart
          expect(response).to render_template :show
        end
      end

      context 'with an invalid id' do
        it 'fails to assign the request Seating Chart to @seating_charts' do
          expect { get :show, id: 1 }.to_not raise_error
        end

        it 'redirects to seating_charts#index' do
          get :show, id: 1
          expect(response).to redirect_to admin_seating_charts_path
        end

        it 'assigns all seating_charts to @seating_charts' do
          chart_1 = create(:seating_chart)
          chart_2 = create(:seating_chart)
          get :show, id: -1
          expect(assigns :seating_charts).to match_array([chart_1, chart_2])
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

      it 'assigns a new seating_chart as @seating_chart' do
        get :new
        expect(assigns :seating_chart).to be_a_new SeatingChart
      end

      it 'renders the :new template' do
        get :new
        expect(response).to render_template :new
      end
    end
  end

  describe 'GET #edit' do
    it 'doesn\'t exist, thus preventing editing' do
      test_seating_chart = create :seating_chart
      expect { get :edit, id: test_seating_chart }.to raise_error(AbstractController::ActionNotFound)
    end
  end

  describe 'POST #create' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        post :create, seating_chart: valid_attributes
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end
      context 'with valid params' do
        it 'saves a new SeatingChart' do
          expect {
            post :create, seating_chart: valid_attributes
          }.to change(SeatingChart, :count).by(1)
        end

        it 'saves the seats to the database' do
          expect {
            post :create, seating_chart: valid_attributes
          }.to change(Seat, :count).by(3)
        end

        it 'renders to the seating_chart index' do
          post :create, seating_chart: valid_attributes
          expect(response).to render_template :index
        end
      end

      context 'with invalid chart params' do
        it 'does not save the new seating chart in the database' do
          expect{
            post :create, seating_chart: invalid_chart_attributes
          }.to change(SeatingChart, :count).by(0)
        end

        it 'does not save the new seats to the database' do
          expect {
            post :create, seating_chart: invalid_chart_attributes
          }.to change(Seat, :count).by(0)
        end

        it 'assigns the errors to @errors' do
          post :create, seating_chart: invalid_chart_attributes
          expect(assigns :errors).to include("Name can't be blank")
        end

        it 're-renders the seating chart template' do
          post :create, seating_chart: invalid_chart_attributes
          expect(response).to render_template 'admin/seating_charts/seating_chart.js.erb'
        end
      end
    end
  end

  describe 'DELETE #destroy' do
    before :each do
      @seating_chart = create :seating_chart
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        delete :destroy, id: @seating_chart
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      it 'deletes the ticket layout from the database' do
        expect {
          delete :destroy, id: @seating_chart
        }.to change(SeatingChart, :count).by(-1)
      end

      it 'redirects to seating_charts' do
        delete :destroy, id: @seating_chart
        expect(response).to redirect_to admin_seating_charts_path
      end
    end
  end
end
