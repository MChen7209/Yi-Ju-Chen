class ApplicationController < ActionController::Base
  include AuthorizationHelper

  protect_from_forgery with: :exception

  before_filter :configure_permitted_parameters, if: :devise_controller?

  def require_admin_logged_in
    unless current_or_guest_user.admin?
      redirect_to root_path
    end
  end

  private

  # Overwriting the sign_out redirect path method
  def after_sign_out_path_for(resource_or_scope)
    root_path
  end

  def after_sign_in_path_for(resource)
    stored_location_for(resource) ||
      resource.role.landing_page
  end

  def configure_permitted_parameters
    registration_params = [:first_name, :last_name, :email, :password, :password_confirmation, :type]

    if params[:action] == 'update'
      devise_parameter_sanitizer.for(:account_update) {
        |u| u.permit(registration_params << :current_password)
      }
    elsif params[:action] == 'create'
      devise_parameter_sanitizer.for(:sign_up) {
        |u| u.permit(registration_params)
      }
    end
  end
end
