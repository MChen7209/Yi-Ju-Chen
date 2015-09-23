class Admin::RolesController < ApplicationController
  include Admin::AuthenticationHelper
  before_action :require_view_admins
  before_action :set_role, only: [:update, :destroy]

  def index
    @roles = Role.all
    @new_role = false
  end

  def new
    @roles = [Role.new]
    @new_role = true
    render :index
  end

  def create
    @role = Role.new(role_params)

    if @role.save
      redirect_to admin_roles_path
    else
      redirect_to admin_roles_path, notice: 'Could not save new role'
    end
  end

  def update
    if @role.update(role_params)
      redirect_to admin_roles_path, notice: "#{@role.name} permissions updated"
    else
      render :index
    end
  end

  def destroy
    role_name = @role.name
    @role.destroy
    redirect_to admin_roles_path, notice: "#{role_name} deleted"
  end

  private

  def role_params
    params.require(:role).permit(:name, :landing_page, :sell_tickets, :hold_seats, :issue_refunds, :view_reports,
                                 :view_customers, :view_admins)
  end

  def set_role
    @role = Role.find(params[:id])
  end

  def require_view_admins
    require_permission :view_admins
  end
end
