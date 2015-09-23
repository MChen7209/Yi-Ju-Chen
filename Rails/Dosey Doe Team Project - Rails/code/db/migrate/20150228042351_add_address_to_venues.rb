class AddAddressToVenues < ActiveRecord::Migration
  def change
    add_column :venues, :address_line1, :string
    add_column :venues, :address_line2, :string
    add_column :venues, :city, :string
    add_column :venues, :state, :string
    add_column :venues, :zip, :string
  end
end
