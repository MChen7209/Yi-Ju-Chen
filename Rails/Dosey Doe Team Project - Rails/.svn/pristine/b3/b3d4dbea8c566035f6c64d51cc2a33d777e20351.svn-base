class Admin::TicketLayoutsController < ApplicationController
  before_action :set_ticket_layout, only: [:show, :edit, :update, :destroy]
  before_action :require_admin_logged_in

  def index
    @ticket_layouts = TicketLayout.all
  end

  def new
    @ticket_layout = TicketLayout.new
  end

  def create
    @ticket_layout = TicketLayout.new(ticket_layout_params)

    if @ticket_layout.save
      redirect_to admin_ticket_layouts_path, notice: 'Ticket layout was successfully created.'
    else
      render :new
    end
  end

  def update
    if @ticket_layout.update(ticket_layout_params)
      redirect_to admin_ticket_layouts_path, notice: 'Ticket layout was successfully updated.'
    else
      render :edit
    end
  end

  def destroy
    @ticket_layout.destroy
    redirect_to admin_ticket_layouts_path, notice: 'Ticket layout was successfully destroyed.'
  end

  private

  def set_ticket_layout
    begin
      @ticket_layout = TicketLayout.find(params[:id])
    rescue ActiveRecord::RecordNotFound
      @ticket_layouts = TicketLayout.all
      redirect_to admin_ticket_layouts_path, notice: 'Error finding ticket layout, please try again.'
    end
  end

  def ticket_layout_params
    params.require(:ticket_layout).permit(:name)
  end
end
