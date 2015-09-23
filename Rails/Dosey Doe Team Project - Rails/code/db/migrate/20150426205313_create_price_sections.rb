class CreatePriceSections < ActiveRecord::Migration
  def change
    create_table :price_sections do |t|
      t.string :name
      t.boolean :reserved

      t.timestamps null: false
    end
  end
end
