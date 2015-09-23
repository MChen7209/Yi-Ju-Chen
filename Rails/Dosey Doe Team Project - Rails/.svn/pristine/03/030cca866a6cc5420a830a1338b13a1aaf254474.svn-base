class ShowsController < ApplicationController
  def index
    if params[:search]
      @shows = Show.where('artist like ?', "%#{params[:search]}%").page(params[:page]).order(:show_date)
    else
      @shows = Show.page(params[:page])
    end
  end

  def show
    @show = Show.find(params[:id])
    pass_data_as_json
  rescue ActiveRecord::RecordNotFound
    @venues = Venue.all
    redirect_to venues_path, notice: 'Error locating show, please try again'
  end

  private

  def pass_data_as_json
    gon.seats = @show.tickets_as_json current_or_guest_user
    return unless @show.seating_chart.chart_image.exists?
    gon.background_image = @show.seating_chart.chart_image.url
  end
end
