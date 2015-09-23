var Seat = (function() {
  function Seat(startX, startY, inputSeatNumber, inputTableNumber) {
    this.radius = 10;
    this.x = startX; this.y = startY;
    this.seat_number = inputSeatNumber;
    this.table_number = inputTableNumber;
  }

  Seat.prototype.moveTo = function(newX, newY) {
    if(newX >= 0 && newY >= 0) {
      this.x = newX; this.y = newY;
    }
  };

  return Seat;
})();
