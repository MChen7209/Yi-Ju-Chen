class ChangeStringToTextInStoredQuestions < ActiveRecord::Migration
  def up
    change_column :stored_questions, :question, :text
  end

  def down
    change_column :stored_questions, :question, :string
  end
end
