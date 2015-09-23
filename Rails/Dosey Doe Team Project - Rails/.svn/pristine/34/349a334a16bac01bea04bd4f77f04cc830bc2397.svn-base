require 'action_view/helpers/url_helper'

module Admin::UsersHelper
  def edit_user_button(user)
    link_to 'edit', edit_admin_user_path(user), class: 'btn btn-default', id: "edit_user#{user.id}"
  end

  def delete_user_button(user)
    link_to 'delete', admin_user_path(user), 'method' => :delete,
              data: {confirm: "Are you sure you want to delete #{user.first_name} #{user.last_name}?"},
              class: 'btn btn-default', id: "delete_user#{user.id}"
  end
end