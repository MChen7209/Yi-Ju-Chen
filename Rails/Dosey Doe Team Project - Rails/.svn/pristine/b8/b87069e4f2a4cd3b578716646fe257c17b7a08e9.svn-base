class AddSeatToTicket < ActiveRecord::Migration
  def change
    add_column :tickets, :seat_id, :integer
    add_index :tickets, :seat_id
  end
end
