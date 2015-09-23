require 'rails_helper'

RSpec.describe CheckoutController,skip: true, type: :controller do
  let(:valid_attributes) {
    build(:stored_question, question: "Stored Question 1")
    answers_array = []
    3.times do
      var newAnswer = {
              "question_id" => questions.id,
              "answer" => questions.question
          }
      answers_array.push(newAnswer)
    end
    var answer_attributes = { 'questions' => answers_array}
    answer_attributes = answers_array.to_json
    answer_attributes
  }

  describe 'GET #index' do
    context 'Customer has tickets in their cart.' do
      before :each do
        sign_in create :customer
        @venue1 = create(:venue, name: 'Test Venue1')
        @venue2 = create(:venue, name: 'Test Venue2')
        @stored_question1 = create(:stored_question, question: 'Question1', active: true, venue_id: 1)
        @stored_question2 = create(:stored_question, question: 'Question2', active: false, venue_id: 1)
        @stored_question3 = create(:stored_question, question: 'Question3', active: true, venue_id: 2)
        @stored_question4 = create(:stored_question, question: 'Question4', active: false, venue_id: 2)
        @show1 = create(:show, artist: 'Show1', venue_id: 1)
        @show2 = create(:show, artist: 'Show2', venue_id: 2)
        @ticket1 = create(:ticket, show_id: 1, user_id: 1)
        @ticket2 = create(:ticket, show_id: 2, user_id: 1)
        get :index
      end

      it 'loads up all active venue stored questions associated with tickets' do
        expect(assigns :questions).to match_array [@stored_question1, @stored_question3]
      end
    end
  end

  describe 'POST #create' do
    context 'with valid [:params]' do
      before :each do
        sign_in create :customer
      end

      it 'saves the answers the the proper question' do
        expect {
          post :create, questions: valid_attributes
          expect(response).to change(VenueAnswer, :count).by 3
        }
      end
    end
  end
end
