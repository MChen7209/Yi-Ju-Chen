class CreateSeats < ActiveRecord::Migration
  def change
    create_table :seats do |t|
      t.integer :seating_chart_id
      t.integer :x
      t.integer :y

      t.timestamps null: false
    end
    add_index :seats, :seating_chart_id
  end
end
