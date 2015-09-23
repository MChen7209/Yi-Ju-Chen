module ShowsHelper
  def open_class(ticket)
    ticket.open? ? 'open_seat' : 'sold_seat'
  end

  def utc_datetime_from_time(time_string)
    DateTime.strptime("#{time_string} +0", '%I:%M %p %z')
  end
end
