class RemoveSeatNumberFromTickets < ActiveRecord::Migration
  def change
    remove_column :tickets, :seat_number
  end
end
