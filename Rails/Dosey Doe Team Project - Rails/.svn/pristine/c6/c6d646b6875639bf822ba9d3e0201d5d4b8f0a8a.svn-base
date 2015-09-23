class Admin::VenuesController < ApplicationController
  before_action :set_venue, only: [:show, :edit, :update]
  before_action :require_admin_logged_in

  def index
    @venues = Venue.all
  end

  def new
    @venue = Venue.new
  end

  def create
    @venue = Venue.new(venue_params)
    ticket_layout = params[:venue].delete(:ticket_layout)
    TicketLayout.create(name: ticket_layout, venue: @venue)

    if @venue.save
      redirect_to admin_venues_path, notice: 'Venue was successfully created.'
    else
      render :new
    end
  end

  def update
    if @venue.update(venue_params)
      redirect_to admin_venues_path, notice: 'Venue was successfully updated.'
    else
      render :edit
    end
  end

  private

  def set_venue
    begin
      @venue = Venue.find(params[:id])
    rescue ActiveRecord::RecordNotFound
      @venues = Venue.all
      redirect_to admin_venues_path, notice: 'Error locating venue, please try again.'
    end
  end

  def venue_params
    params.require(:venue).permit(:name, :address_line1, :address_line2, :city, :state,
                                :zip, :image, :phone)
  end
end
