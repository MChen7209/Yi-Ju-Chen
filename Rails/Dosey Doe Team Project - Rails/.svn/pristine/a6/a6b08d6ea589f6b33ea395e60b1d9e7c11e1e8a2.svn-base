//= require seating_chart/Seat

describe('Seat', function() {
  var seat;

  beforeEach(function() {
    seat = new Seat(10, 15, 20, 30);
  });

  it('assigns the x variable in the constructor', function() {
    expect(seat.x).to.equal(10);
  });

  it('assigns the y variable in the constructor', function() {
    expect(seat.y).to.equal(15);
  });

  it('assigns the seat_number variable in the constructor', function() {
    expect(seat.seat_number).to.equal(20);
  });

  it('assigns the table_number variable in the constructor', function() {
    expect(seat.table_number).to.equal(30);
  });

  it('can move the seat to a new positive y location', function() {
    seat.moveTo(30, 20);
    expect(seat.x).to.equal(30);
  });

  it('can move the seat to a new positive y location', function() {
    seat.moveTo(30, 20);
    expect(seat.y).to.equal(20);
  });

  it('will not move the seat if the x location is negative', function() {
    seat.moveTo(-100, 10);
    expect(seat.x).to.equal(10);
    expect(seat.y).to.equal(15);
  });

  it('will not move the seat if the y location is negative', function() {
    seat.moveTo(10, -10);
    expect(seat.x).to.equal(10);
    expect(seat.y).to.equal(15);
  });

  it('will not move the seat if the x and y locations are negative', function() {
    seat.moveTo(-10, -10);
    expect(seat.x).to.equal(10);
    expect(seat.y).to.equal(15);
  });
});