class AddArtistToShows < ActiveRecord::Migration
  def change
    add_column :shows, :artist, :string
  end
end
