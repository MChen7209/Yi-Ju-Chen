class AddVenueReferenceToTicketLayouts < ActiveRecord::Migration
  def change
    add_reference :ticket_layouts, :venue, index: true
    add_foreign_key :ticket_layouts, :venues
  end
end
