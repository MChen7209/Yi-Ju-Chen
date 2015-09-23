class AddStatusAndReservedUntilToTickets < ActiveRecord::Migration
  def change
    add_column :tickets, :status, :string
    add_column :tickets, :reserved_until, :datetime
  end
end
