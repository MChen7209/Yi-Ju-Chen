class AddDinnerServedToShows < ActiveRecord::Migration
  def change
    add_column :shows, :dinner_served, :boolean
  end
end
