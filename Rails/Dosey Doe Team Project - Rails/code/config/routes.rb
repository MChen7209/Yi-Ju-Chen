Rails.application.routes.draw do
  # get 'checkout/index'

  resources :shows_price_sections

  get 'stored_questions/index'

  get 'static_pages/contact_us'
  get 'static_pages/privacy_policy'
  get 'static_pages/customer_service'
  namespace 'admin' do
    resources :shows, :venues, :users, :ticket_layouts, :seating_charts, :roles, :stored_questions, :price_sections
    patch '/users' => 'admin/users#update'
  end

  devise_for :users

  as :users do
    get '/users/checkout' => 'users#checkout'
    get '/users/purchases' => 'users#purchases'
    get '/users/account' => 'users#account'
    resources :checkout
  end

  resources :contactus, :account, :privacypolicy
  resources :shows, only: [:show, :index]
  resources :venues, only: [:show, :index]

  match '/admin/customers' => 'admin/users#customers', via: :get, as: :admin_customers
  match '/admin/admins' => 'admin/users#admins', via: :get, as: :admin_admins

  match 'tickets/reserve/:id' => 'tickets#reserve', via: :put, as: :reserve

  match 'admin' => 'admin/home#index', via: :get

  match 'admin/reports' => 'admin/reports#index', via: :get
  match 'admin/reports/:id' => 'admin/reports#report', via: :get, as: :report

  match '/admin/find_customers' => 'admin/users#find_customers', via: :get
  # match 'static_pages/customer_service' => 'admin/static_pages#customer_service', via: :get

  root 'shows#index'
end
