class CreateShowsPriceSections < ActiveRecord::Migration
  def change
    create_table :shows_price_sections do |t|
      t.belongs_to :show, index: true
      t.belongs_to :price_section, index: true
      t.float :actual_price
      t.timestamps null: true
    end
  end
end
