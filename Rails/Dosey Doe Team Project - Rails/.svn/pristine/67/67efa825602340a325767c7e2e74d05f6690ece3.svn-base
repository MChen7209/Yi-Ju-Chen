class AddAttachmentChartImageToSeatingCharts < ActiveRecord::Migration
  def self.up
    change_table :seating_charts do |t|
      t.attachment :chart_image
    end
  end

  def self.down
    remove_attachment :seating_charts, :chart_image
  end
end
