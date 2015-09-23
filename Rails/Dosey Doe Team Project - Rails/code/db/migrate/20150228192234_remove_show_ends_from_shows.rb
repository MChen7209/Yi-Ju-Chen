class RemoveShowEndsFromShows < ActiveRecord::Migration
  def change
    remove_column :shows, :show_ends
  end
end
