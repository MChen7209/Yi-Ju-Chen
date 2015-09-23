class AddSeatAndTableNumberToSeats < ActiveRecord::Migration
  def change
    add_column :seats, :seat_number, :integer
    add_column :seats, :table_number, :integer
  end
end
