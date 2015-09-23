class AddSeatingChartToShow < ActiveRecord::Migration
  def change
    add_column :shows, :seating_chart_id, :integer
    add_index :shows, :seating_chart_id
  end
end
