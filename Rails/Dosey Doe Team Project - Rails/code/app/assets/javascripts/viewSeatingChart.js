//= require 'easeljs0.80.js'
//= require 'seating_chart/Seat'
//= require 'seating_chart/SeatingChart'
//= require 'seating_chart/SeatingChartView'
//= require 'seating_chart/SeatingChartController'

var seatingChartController = new SeatingChartController();
var seatingChartView = new SeatingChartView('seating_chart', seatingChartController, true);
seatingChartController.registerView(seatingChartView);
gon.seats.forEach(function(seat) {
  seatingChartController.addSeat(seat.x, seat.y, seat.seat_number, seat.table_number);
});
seatingChartView.setBackground(gon.background_image);
seatingChartController.registerView(seatingChartView);
