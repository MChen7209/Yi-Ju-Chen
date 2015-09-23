require 'rails_helper'
require './spec/support/unauthorized_admin_page_access_attempt'

RSpec.describe Admin::TicketLayoutsController, type: :controller do

  let(:valid_attributes) {
    build(:ticket_layout).attributes
  }

  let(:invalid_attributes) {
    build(:ticket_layout, name: nil).attributes
  }

  describe "GET #index" do
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
        it 'ignores the params and populates an array with all ticket layouts' do
          ticket_layout_1 = create(:ticket_layout, name: 'Test_one')
          ticket_layout_2 = create(:ticket_layout, name: 'Test_two')
          get :index, 'something'
          expect(assigns :ticket_layouts).to match_array([ticket_layout_1, ticket_layout_2])
        end

        it 'renders the :index template' do
          get :index, 'something'
          expect(response).to render_template :index
        end
      end

      context 'without params' do
        it 'populates an array with all ticket layouts' do
          ticket_layout_1 = create(:ticket_layout, name: 'Test_one')
          ticket_layout_2 = create(:ticket_layout, name: 'Test_two')
          get :index
          expect(assigns :ticket_layouts).to match_array([ticket_layout_1, ticket_layout_2])
        end

        it 'renders the :index template' do
          get :index
          expect(response).to render_template :index
        end
      end
    end
  end

  describe "GET #show" do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        ticket_layout = create(:ticket_layout)
        get :show, id: ticket_layout
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid id' do
        it "assigns the requested ticket_layout to @ticket_layout" do
          ticket_layout = create(:ticket_layout)
          get :show, id: ticket_layout
          expect(assigns :ticket_layout).to eq ticket_layout
        end

        it 'renders the :show template' do
          ticket_layout = create(:ticket_layout)
          get :show, id: ticket_layout
          expect(response).to render_template :show
        end
      end

      context 'with an invalid id' do
        it 'fails to assign the request Ticket Layout to @ticket_layout' do
          expect{get :show, id: 1}.to_not raise_error
        end

        it 'redirects to ticket_layouts#index' do
          get :show, id: 1
          expect(response).to redirect_to admin_ticket_layouts_path
        end

        it 'assigns all ticket_layouts to @ticket_layouts' do
          ticket_layout_1 = create(:ticket_layout)
          ticket_layout_2 = create(:ticket_layout)
          get :show, id: -1
          expect(assigns :ticket_layouts).to match_array([ticket_layout_1, ticket_layout_2])
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

      it 'assigns a new ticket_layout as @ticket_layout' do
        get :new
        expect(assigns :ticket_layout).to be_a_new TicketLayout
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
        ticket_layout = create(:ticket_layout)
        get :edit, id: ticket_layout
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context 'with a valid id' do
        it 'assigns the requested ticket_layout as @ticket_layout' do
          ticket_layout = create :ticket_layout
          get :edit, id: ticket_layout
          expect(assigns(:ticket_layout)).to eq(ticket_layout)
        end

        it 'renders the :edit template' do
          ticket_layout = create :ticket_layout
          get :edit, id: ticket_layout
          expect(response).to render_template :edit
        end
      end

      context 'with an invalid id' do
        it 'does not throw an error' do
          expect{get :edit, id: -1}.to_not raise_error
        end

        it 'assigns all ticket layouts to @ticket_layouts' do
          ticket_layout_1 = create(:ticket_layout)
          ticket_layout_2 = create(:ticket_layout)
          get :edit, id: -1
          expect(assigns(:ticket_layouts)).to match_array([ticket_layout_1, ticket_layout_2])
        end

        it 'redirects to the ticket layouts index' do
          get :edit, id: 1
          expect(response).to redirect_to admin_ticket_layouts_path
        end
      end
    end
  end

  describe "POST #create" do
    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        post :create, ticket_layout: valid_attributes
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context "with valid params" do
        it "saves a new TicketLayout" do
          expect {
            post :create, ticket_layout: valid_attributes
          }.to change(TicketLayout, :count).by 1
        end

        it 'assigns a newly created ticket_layout as @ticket_layout' do
          post :create, ticket_layout: valid_attributes
          expect(assigns(:ticket_layout)).to be_a(TicketLayout)
          expect(assigns(:ticket_layout)).to be_persisted
        end

        it 'redirects to the ticket_layout index' do
          post :create, ticket_layout: valid_attributes
          expect(response).to redirect_to admin_ticket_layouts_path
        end
      end

      context "with invalid params" do
        it 'does not save the new ticket layout in the database' do
          expect{
            post :create, ticket_layout: invalid_attributes
          }.not_to change(TicketLayout, :count)
        end

        it "re-renders the 'new' template" do
          post :create, ticket_layout: invalid_attributes
          expect(response).to render_template :new
        end
      end
    end
  end

  describe 'PUT #update' do
    before :each do
      @ticket_layout = create :ticket_layout, name: 'Test_one'
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        patch :update, id: @ticket_layout, ticket_layout: attributes_for(:ticket_layout)
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      context "with valid params" do
        it "updates the requested ticket_layout in the database" do
          patch :update, id: @ticket_layout, ticket_layout: attributes_for(:ticket_layout)
          expect(assigns :ticket_layout).to eq @ticket_layout
        end

        it 'redirects to ticket_layouts index' do
          patch :update, id: @ticket_layout, ticket_layout: attributes_for(:ticket_layout)
          expect(response).to redirect_to admin_ticket_layouts_path
        end
      end

      context "with invalid params" do
        it 'does not update the ticket layouts' do
          patch :update, id: @ticket_layout, ticket_layout: invalid_attributes
          @ticket_layout.reload
          expect(@ticket_layout.name).not_to eq nil
          expect(@ticket_layout.name).to eq 'Test_one'
        end

        it "re-renders the 'edit' template" do
          put :update, id: @ticket_layout, ticket_layout: invalid_attributes
          expect(response).to render_template :edit
        end
      end
    end
  end

  describe "DELETE #destroy" do
    before :each do
      @ticket_layout = create :ticket_layout
    end

    context 'when the current user is not an admin' do
      before :each do
        sign_in create :guest
        delete :destroy, id: @ticket_layout
      end

      it_behaves_like 'unauthorized admin page access attempt'
    end

    context 'when the current user is an admin' do
      before :each do
        sign_in create :admin
      end

      it 'deletes the ticket layout from the database' do
        expect {
          delete :destroy, id: @ticket_layout
        }.to change(TicketLayout, :count).by -1
      end

      it 'redirects to ticket_layouts' do
        delete :destroy, id: @ticket_layout
        expect(response).to redirect_to(admin_ticket_layouts_path)
      end
    end
  end
end
