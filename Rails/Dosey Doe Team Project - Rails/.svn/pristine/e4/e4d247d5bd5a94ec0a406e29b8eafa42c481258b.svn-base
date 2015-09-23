class CreateShows < ActiveRecord::Migration
  def change
    create_table :shows do |t|
      t.date :show_date
      t.datetime :doors_open
      t.datetime :dinner_starts
      t.datetime :dinner_ends
      t.datetime :show_starts
      t.datetime :show_ends


      t.timestamps null: false
    end
  end
end
