module TicketsHelper
  def refresh_all_tickets(user)
    # describe_tickets user
    user.tickets.each do |t|
      t.reserved_until = DateTime.current + t.reservation_time
    end
    # describe_tickets user
  end

  def describe_tickets(user)
    puts "Got #{user.tickets.count} tickets:"
    user.tickets.each do |ticket|
      if ticket == nil
        puts 'nil ticket'
      else
        puts "#{ticket}, #{ticket.reserved_until}"
      end
    end
  end
end
