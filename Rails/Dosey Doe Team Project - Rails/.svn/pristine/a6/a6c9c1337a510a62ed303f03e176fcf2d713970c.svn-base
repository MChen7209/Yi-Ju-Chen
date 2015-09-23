class CreateStoredQuestions < ActiveRecord::Migration
  def change
    create_table :stored_questions do |t|
      t.string :question
      t.text :venues

      t.timestamps null: false
    end
  end
end
