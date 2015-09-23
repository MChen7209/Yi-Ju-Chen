class TicketsController < ApplicationController
  def reserve
    begin
      @ticket = Ticket.find(params[:id])
    rescue
      render json: nil
      return
    end
    @ticket.reserve_ticket current_or_guest_user

    render json: @ticket.show.tickets_as_json(current_or_guest_user)
  end
end
