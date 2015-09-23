module ApplicationHelper
  include AuthorizationHelper

  def new_user_path
    '/users/sign_up'
  end

  def date_as_words(datetime)
    datetime.to_date.strftime('%A, %B %e, %Y')
  end

  def time_from_datetime(datetime)
    hour_24 = datetime.hour
    minute = (datetime.min == 0 ? '00' : datetime.min)
    offset = datetime.utc_offset / 60 / 60

    hour_utc_24 = hour_24 - offset

    if hour_utc_24 == 0
      hour_utc = 12
      ampm = 'AM'
    elsif hour_utc_24 <= 11
      hour_utc = hour_utc_24
      ampm = 'AM'
    elsif hour_utc_24 == 12
      hour_utc = 12
      ampm = 'PM'
    else
      hour_utc = hour_utc_24 - 12
      ampm = 'PM'
    end

    "#{hour_utc}:#{minute} #{ampm}"
  end
end
