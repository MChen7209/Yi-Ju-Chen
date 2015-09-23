//= require seating_chart/Seat
//= require seating_chart/SeatingChart

describe('Seating chart', function() {
  var seatingChart;
  var testSeat;

  beforeEach(function() {
    seatingChart = new SeatingChart();
    testSeat = seatingChart.addSeat(1, 2, 3, 4);
  });

  it('can add a seat to the seats array', function() {
    expect(seatingChart.seats).to.contain(testSeat);
  });

  it('adds the new seat with the input x', function() {
    expect(seatingChart.seats[0].x).to.equal(testSeat.x);
  });

  it('adds the new seat with the input y', function() {
    expect(seatingChart.seats[0].y).to.equal(testSeat.y);
  });

  it('adds the new seat with the input seat_number', function() {
    expect(seatingChart.seats[0].seat_number).to.equal(testSeat.seat_number);
  });

  it('adds the new seat with the input table_number', function() {
    expect(seatingChart.seats[0].table_number).to.equal(testSeat.table_number);
  });

  it('can remove a seat from the seats', function() {
    var newSeat = seatingChart.addSeat(5, 6, 7, 8);
    seatingChart.removeSeat(testSeat);
    expect(seatingChart.seats).not.to.contain(testSeat);
    expect(seatingChart.seats).to.contain(newSeat);
  });

  it('converts itself seating chart to JSON', function() {
    var newSeat = seatingChart.addSeat(5, 6, 7, 8);
    expect(seatingChart.toJSON()).to.equal("[{\"radius\":10,\"x\":1,\"y\":2,\"seat_number\":3,\"table_number\":4},{\"radius\":10,\"x\":5,\"y\":6,\"seat_number\":7,\"table_number\":8}]");
  });
});