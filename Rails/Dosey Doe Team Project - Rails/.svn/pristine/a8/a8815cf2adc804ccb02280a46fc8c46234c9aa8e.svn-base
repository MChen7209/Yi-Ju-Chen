class CheckoutController < ApplicationController
  def index
    @tickets = current_or_guest_user.tickets.where(status: 'reserved')
    @venues = []
    @questions = []
    @tickets.each { |ticket| @venues << ticket.show.venue }
    @venues.uniq.each do |venue|
      venue.stored_questions.each do |question|
        if question.active
          @questions << question
        end
      end
    end
  end

  def create
    current_or_guest_user.tickets.where(status: 'reserved').each do |ticket|
      ticket.status = 'sold'
      ticket.save
    end

    if !params[:questions].nil?
      params.require(:questions).each do |answer|
        @answer = VenueAnswer.new(stored_question_id: answer['question_id'], answer: answer['answer'])
        @answer.save
      end
    end
    render :js => "window.location = '/'"
  end
end
