class UsersController < ApplicationController
  def checkout
    @tickets = current_or_guest_user.tickets.where(status: 'reserved')
  end

  def purchases
    @tickets = current_or_guest_user.tickets.where(status: 'sold')
  end
end
