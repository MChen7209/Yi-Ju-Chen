toggleAdminType = ->
  checkTypeDropdown = ->
    if $('#user_type option:selected').text() == 'Admin'
      $('#admin_role').show()
    else
      $('#admin_role').hide()

  checkTypeDropdown()
  $('#user_type').change ->
    checkTypeDropdown()

$('admin.users.new').ready(toggleAdminType)