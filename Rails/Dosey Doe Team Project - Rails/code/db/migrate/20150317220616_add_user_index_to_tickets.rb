class AddUserIndexToTickets < ActiveRecord::Migration
  def change
    add_index :tickets, :user_id
  end
end