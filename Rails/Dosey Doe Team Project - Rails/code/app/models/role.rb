class Role < ActiveRecord::Base
  validates :name, presence: true
  validates :sell_tickets, inclusion: [true, false]
  validates :hold_seats, inclusion: [true, false]
  validates :issue_refunds, inclusion: [true, false]
  validates :view_reports, inclusion: [true, false]
  validates :view_customers, inclusion: [true, false]
  validates :view_admins, inclusion: [true, false]
  validate :view_admins_permission, on: [:create, :update]
  validates :landing_page, presence: true

  def view_admins_permission
    return unless view_admins
    self.view_customers = true
  end

  has_many :admins
end
