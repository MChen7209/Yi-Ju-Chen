class AddVenueToSeatingChart < ActiveRecord::Migration
  def change
    add_column :seating_charts, :venue_id, :integer
    add_index :seating_charts, :venue_id
  end
end
