var SeatingChart = (function() {
  function SeatingChart() {
    this.seats = [];
  }

  SeatingChart.prototype.addSeat = function(x, y, seatNumber, tableNumber) {
    var newSeat = new Seat(x, y, seatNumber, tableNumber);
    this.seats.push(newSeat);
    return newSeat;
  };

  SeatingChart.prototype.removeSeat = function(seat) {
    this.seats = this.seats.filter(function(eachSeat) {
      return(eachSeat !== seat);
    });
  };

  SeatingChart.prototype.toJSON = function() {
    return JSON.stringify(this.seats);
  };

  SeatingChart.prototype.reset = function() {
    this.seats = [];
  };

  return SeatingChart;
})();
