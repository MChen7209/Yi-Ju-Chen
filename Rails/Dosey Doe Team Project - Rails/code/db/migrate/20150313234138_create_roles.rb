class CreateRoles < ActiveRecord::Migration
  def change
    create_table :roles do |t|
      t.string :name

      t.boolean :sell_tickets
      t.boolean :hold_seats
      t.boolean :issue_refunds
      t.boolean :view_reports
      t.boolean :view_customers
      t.boolean :view_admins

      t.timestamps null: false
    end
  end
end
