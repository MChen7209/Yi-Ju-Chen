class AddStoredQuestionReferenceToVenueAnswer < ActiveRecord::Migration
  def change
    add_reference :venue_answers, :stored_question, index: true
  end
end
