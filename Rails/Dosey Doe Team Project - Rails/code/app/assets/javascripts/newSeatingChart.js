//= require 'seating_chart/Seat'
//= require 'seating_chart/SeatingChart'
//= require 'easeljs0.80.js'
//= require 'seating_chart/SeatingChartView'
//= require 'seating_chart/SeatingChartController'
//= require 'seating_chart/overrideSidebar'
//= require 'seating_chart/overrideSubmit'

overrideSubmit('#new_seating_chart');
var seatingChartController = new SeatingChartController();
var seatingChartView = new SeatingChartView('seating_chart', seatingChartController, 'edit');
seatingChartController.registerView(seatingChartView); 