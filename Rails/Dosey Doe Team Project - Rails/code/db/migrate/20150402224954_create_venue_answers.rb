class CreateVenueAnswers < ActiveRecord::Migration
  def change
    create_table :venue_answers do |t|
      t.text :answer

      t.timestamps null: false
    end
  end
end
