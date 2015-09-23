class VenuesController < ApplicationController
  def index
    @venues = Venue.all
  end

  def show
    @venue = Venue.find(params[:id])
    @shows = @venue.shows.page(params[:page])
    rescue ActiveRecord::RecordNotFound
      @venues = Venue.all
      redirect_to venues_path, notice: 'Error locating venue, please try again.'
  end
end
