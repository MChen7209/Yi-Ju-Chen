module Admin::AuthenticationHelper
  def require_permission(permission_attribute_name)
    redirect_to current_or_guest_user.role.landing_page, notice: 'You do not have sufficient permissions' unless current_or_guest_user.role.send permission_attribute_name
  end
end
