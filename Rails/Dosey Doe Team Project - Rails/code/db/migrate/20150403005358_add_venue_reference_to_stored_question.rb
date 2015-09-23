class AddVenueReferenceToStoredQuestion < ActiveRecord::Migration
  def change
    add_reference :stored_questions, :venue, index: true
  end
end
