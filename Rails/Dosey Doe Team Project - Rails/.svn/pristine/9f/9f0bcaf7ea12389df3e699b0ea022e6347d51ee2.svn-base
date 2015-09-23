class Guest < User
  belongs_to :role

  def password_required?
    false
  end

  def email_required?
    false
  end

  def role
    NullRole.instance
  end

  def first_name
    'Guest'
  end

  def last_name
    ''
  end
end
