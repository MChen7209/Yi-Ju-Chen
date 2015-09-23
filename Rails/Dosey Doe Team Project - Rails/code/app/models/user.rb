class User < ActiveRecord::Base
  devise :database_authenticatable, :registerable,
         :recoverable, :rememberable, :trackable, :validatable

  validates :type, presence: true
  validate :valid_type?

  has_many :tickets

  def valid_type?
    return unless type != 'Admin' && type != 'Customer' && type != 'Guest'
    errors.add :type, 'User must be of type Customer or Admin or Guest'
  end

  def customer?
    type == 'Customer'
  end

  def guest?
    type == 'Guest'
  end

  def admin?
    type == 'Admin'
  end
end
