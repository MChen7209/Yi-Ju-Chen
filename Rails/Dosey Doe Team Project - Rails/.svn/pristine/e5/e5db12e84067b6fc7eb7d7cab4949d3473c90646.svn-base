module NavbarHelper
  def current_user_reserved_tickets
    Ticket.where(user_id: current_or_guest_user.id, status: 'reserved')
  end

  def reserved_ticket_count
    current_user_reserved_tickets.count
  end

  def seconds_until_ticket_expiration
    next_expiration_time = current_user_reserved_tickets.map(&:reserved_until).min
    next_expiration_datetime = datetime_from_time(next_expiration_time)

    ((next_expiration_datetime - DateTime.now) * 24 * 60 * 60).to_i
  end

  def datetime_from_time(t)
    DateTime.new(t.year, t.month, t.day, t.hour, t.min, t.sec, Rational(t.gmt_offset / 3600, 24))
  end
end
