class AddLandingPageToRoles < ActiveRecord::Migration
  def change
    add_column :roles, :landing_page, :string
  end
end
