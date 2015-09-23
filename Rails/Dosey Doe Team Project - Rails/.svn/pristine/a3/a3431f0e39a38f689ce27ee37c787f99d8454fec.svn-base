var SeatingChartController = (function() {
  function SeatingChartController(inputView) {
    this.seatingChart = new SeatingChart();
    this.view = inputView;

    var _this = this;

    this.fileChangedCallback = function(event) {
      _this.view.setBackground(URL.createObjectURL(event.target.files[0]));
      _this.view.render();
    };

    $(function() {
      $('#seating_chart_file').change(_this.fileChangedCallback);
    });
  }

  SeatingChartController.prototype.moveSeat = function(seat, x, y) {
    seat.moveTo(x, y);
    this.view.render();
  };

  SeatingChartController.prototype.addSeat = function(x, y, seatNumber, tableNumber, id, status) {
    var newSeat = this.seatingChart.addSeat(x, y, seatNumber, tableNumber);
    if(id) { newSeat.id = id; }
    if(status) { newSeat.status = status; }
    if(this.view) {
      this.view.addSeat(newSeat);
      this.view.render();
    }
    return newSeat;
  };

  SeatingChartController.prototype.setSeats = function(seats) {
    this.seatingChart.reset();
    _this = this;
    seats.forEach(function(seat) {
      _this.addSeat(seat.x, seat.y, seat.seat_number, seat.table_number, seat.id, seat.status);
    });
    
    this.view.reset();
    this.seatingChart.seats.forEach(function(seat) {
      _this.view.addSeat(seat);
    });
  };


  SeatingChartController.prototype.newSeat = function(seatNumber, tableNumber) {
    if(seatNumber === '' || tableNumber === '') {
      alert("Seat and table number must not be empty!");
      return false;
    }
    return this.addSeat(10, 10, seatNumber, tableNumber);
  };

  SeatingChartController.prototype.updateSeatData = function(seat, seatNumber, tableNumber) {
    seat.seat_number = seatNumber;
    seat.table_number = tableNumber;
    //Send updated seat to views
  };

  SeatingChartController.prototype.removeSeat = function(seat) {
    this.seatingChart.removeSeat(seat);
    this.view.removeSeat(seat);
    this.view.render();
  };

  SeatingChartController.prototype.registerView = function(view) {
    this.view = view;
    this.seatingChart.seats.forEach(function(seat) {
      view.addSeat(seat);
    });
    this.view.render();
  };

  SeatingChartController.prototype.toJSON = function() {
    return this.seatingChart.toJSON();
  };

  return SeatingChartController;
})();
