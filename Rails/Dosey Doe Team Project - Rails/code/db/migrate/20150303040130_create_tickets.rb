class CreateTickets < ActiveRecord::Migration
  def change
    create_table :tickets do |t|
      t.integer :user_id
      t.integer :show_id
      t.integer :seat_number

      t.timestamps null: false
    end
  end
end
