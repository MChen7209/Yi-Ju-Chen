class RemoveVenuesFromStoredQuestions < ActiveRecord::Migration
  def change
    remove_column :stored_questions, :venues, :text
  end
end
