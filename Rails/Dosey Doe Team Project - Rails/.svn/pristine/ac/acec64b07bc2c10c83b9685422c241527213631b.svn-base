class Admin::SeatingChartsController < ApplicationController
  before_action :set_seating_chart, only: [:show, :destroy]
  before_action :require_admin_logged_in

  def show
    gon.seats = @seating_chart.seats
    return unless @seating_chart.chart_image.exists?
    gon.background_image = @seating_chart.chart_image.url
  end

  def index
    @seating_charts = SeatingChart.all
  end

  def new
    @seating_chart = SeatingChart.new
    gon.seats = []
  end

  def create
    @errors = []
    create_chart_with_seats
    if @errors.empty?
      @seating_charts = SeatingChart.all
      render :index, notice: 'Seating chart successfully created.'
    else
      render 'seating_chart.js.erb'
    end
  end

  def destroy
    @seating_chart.destroy
    redirect_to admin_seating_charts_path, notice: 'Seating chart was successfully destroyed.'
  end

  private

  def set_seating_chart
    @seating_chart = SeatingChart.find(params[:id])
    rescue ActiveRecord::RecordNotFound
      @seating_charts = SeatingChart.all
      redirect_to admin_seating_charts_path, notice: 'Error finding the seating chart, please try again.'
  end

  def seating_chart_params
    params.require(:seating_chart).permit(:name, :chart_image, :venue_id)
  end

  def create_chart_with_seats
    SeatingChart.transaction do
      save_seats(save_chart)
      fail ActiveRecord::Rollback unless @errors.empty?
    end
  end

  def save_chart
    seating_chart = SeatingChart.new seating_chart_params
    begin
      seating_chart.save!
    rescue ActiveRecord::RecordInvalid
      seating_chart.errors.full_messages.each { |msg| @errors << msg }
    end
    seating_chart
  end

  def save_seats(seating_chart)
    return if params.require(:seating_chart)[:seats].nil?
    JSON.parse(params.require(:seating_chart)[:seats]).each do |seat_params|
      add_seat(seat_params, seating_chart)
    end
  end

  def add_seat(params, seating_chart)
    new_seat = Seat.new params.except('radius', 'id')
    new_seat.seating_chart = seating_chart
    new_seat.save!
    rescue ActiveRecord::RecordInvalid
      new_seat.errors.full_messages.each { |msg| @errors << "Seat error: #{msg}" }
  end
end
