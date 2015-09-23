class AddAttachmentArtistImageToShows < ActiveRecord::Migration
  def self.up
    change_table :shows do |t|
      t.attachment :artist_image
    end
  end

  def self.down
    remove_attachment :shows, :artist_image
  end
end
