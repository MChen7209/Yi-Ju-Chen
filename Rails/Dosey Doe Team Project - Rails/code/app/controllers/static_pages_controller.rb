class StaticPagesController < ApplicationController
  before_action :require_admin_logged_in, only: [:customer_service]

  def contact_us
  end

  def privacy_policy
  end

  def customer_service
  end
end
