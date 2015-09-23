class Customer < User
  validates :first_name, presence: true
  validates :last_name, presence: true
  validates :email, presence: true

  def role
    NullRole.instance
  end
end
