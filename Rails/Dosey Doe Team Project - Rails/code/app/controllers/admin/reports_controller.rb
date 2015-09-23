class Admin::ReportsController < ApplicationController
  before_action :require_admin_logged_in

  def index
    @available_reports = Admin::ReportsController.available_reports
  end

  def self.available_reports
    { report_venues: 'Venues report', report_shows: 'Shows report' }
  end

  def report
    @report_objects = send(params[:id])
  end

  def report_venues
    Venue.all
  end

  def report_shows
    Show.all
  end
end
