class Admin::ShowsController < ApplicationController
  before_action :set_show, only: [:show, :edit, :update, :destroy]
  before_action :require_admin_logged_in

  def index
    if params[:search]
      @shows = Show.where("artist like ?", "%#{params[:search]}%").order(:show_date)
    else
      @shows = Show.all.order(:show_date)
    end
  end

  def new
    @show = Show.new
  end

  def show
    @tickets = @show.tickets
  end

  def create
    @show = Show.new(show_params)

    if @show.save
      @show.seating_chart.seats.each do |seat|
        ticket = Ticket.new
        ticket.show = @show
        ticket.seat = seat
        ticket.status = 'open'
        ticket.save
      end
      redirect_to admin_shows_path, notice: 'Show was successfully created.'
    else
      render :new
    end
  end

  def update
    if @show.update(show_params)
      redirect_to admin_shows_path, notice: 'Show was successfully updated.'
    else
      render :edit
    end
  end

  def destroy
    @show.destroy
    redirect_to admin_shows_path, notice: 'Show was successfully destroyed.'
  end

  private

  def set_show
    begin
      @show = Show.find(params[:id])
    rescue ActiveRecord::RecordNotFound
      @shows = Show.all
      redirect_to admin_shows_path, notice: 'Error finding show, please try again.'
    end
  end

  def show_params
    params.require(:show).permit(:venue_id, :show_date, :doors_open, :dinner_starts,
                                 :dinner_ends, :show_starts, :artist, :seating_chart_id,
                                 :artist_image)
  end
end
