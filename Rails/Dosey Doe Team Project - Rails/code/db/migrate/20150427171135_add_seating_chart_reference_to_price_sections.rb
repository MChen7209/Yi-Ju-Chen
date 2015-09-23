class AddSeatingChartReferenceToPriceSections < ActiveRecord::Migration
  def change
    add_reference :price_sections, :seating_chart, index: true
    add_foreign_key :price_sections, :seating_charts
  end
end
