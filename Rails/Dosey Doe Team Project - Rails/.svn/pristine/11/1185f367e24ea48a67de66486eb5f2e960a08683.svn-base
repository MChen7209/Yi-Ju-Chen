require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::ReportsController, type: :controller do
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

      it 'renders the :index template' do
        get :index
        expect(response).to render_template :index
      end

      it 'contains the two reports we expect it to have' do
        get :index
        expect(assigns(:available_reports).values).to match_array ['Venues report', 'Shows report']
      end
    end
  end

  describe 'GET #report' do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        get :report, id: :report_venues # we have to specify a report here; doesn't matter which
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'for Venues report' do
        it 'renders the report template' do
          get :report, id: :report_venues
          expect(response).to render_template :report
        end

        it 'populates the controller with all of the Venues' do
          get :report, id: :report_venues
          expect(assigns :report_objects).to match_array Venue.all
        end
      end

      context 'for Shows report' do
        it 'renders the report template' do
          get :report, id: :report_shows
          expect(response).to render_template :report
        end

        it 'populates the controller with all of the Shows' do
          get :report, id: :report_shows
          expect(assigns :report_objects).to match_array Show.all
        end
      end
    end
  end
end
