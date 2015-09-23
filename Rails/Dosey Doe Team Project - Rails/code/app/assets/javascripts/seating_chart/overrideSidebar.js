var overrideSidebar = function(event) {
  event.preventDefault();
  var seatNumber = $('#sidebar_seat_number');
  var tableNumber = $('#sidebar_table_number');
  seatingChartController.newSeat(seatNumber.val(), tableNumber.val());
  tableNumber.val('');
  seatNumber.val('');
};

$(function() {
  $('#sidebar_add_seat').submit(overrideSidebar);
});