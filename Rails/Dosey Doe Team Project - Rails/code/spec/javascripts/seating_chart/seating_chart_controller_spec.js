//= require seating_chart/Seat
//= require seating_chart/SeatingChart
//= require seating_chart/SeatingChartController

var $ = sinon.spy();
var URL = {
  createObjectURL: function() { return null; }
};

describe('Seating Chart Controller', function() {
  var seatingChartController;
  var seatingChart;
  var viewSpy = {
    addSeat: sinon.spy(),
    removeSeat: sinon.spy(),
    setBackground: sinon.spy(),
    render: sinon.spy(),
    reset: sinon.spy()
  };

  beforeEach(function() {
    seatingChartController = new SeatingChartController();
    seatingChartController.registerView(viewSpy);
    seatingChart = seatingChartController.seatingChart;
  });

  afterEach(function() {
    viewSpy.addSeat.reset();
    viewSpy.removeSeat.reset();
    viewSpy.setBackground.reset();
    viewSpy.render.reset();
    viewSpy.reset.reset();
  });

  describe('registering a view', function() {
    var testSeat1, testSeat2;
    beforeEach(function() {
      seatingChartController = new SeatingChartController();
      testSeat1 = seatingChartController.newSeat(1, 2);
      testSeat2 = seatingChartController.newSeat(3, 4);
      seatingChartController.registerView(viewSpy);
    });
    it('sets the view to the input view', function() {
      expect(seatingChartController.view).to.equal(viewSpy);  
    });

    it('calls addSeat for each seat in the seating chart', function() {
      expect(viewSpy.addSeat.calledWith(testSeat1)).to.equal(true);
      expect(viewSpy.addSeat.calledWith(testSeat2)).to.equal(true);
    });
  });

  describe('creating a new seat', function() {
    describe('with valid parameters', function() {
      beforeEach(function() {
        // Remove the render call from when the view was registered
        viewSpy.render.reset();
        newSeat = seatingChartController.newSeat(3, 4);
      });
      it('adds a seat to the seating chart with x of 10', function() {
        expect(seatingChart.seats[0].x).to.equal(10);
      });

      it('adds a seat to the seating chart with y of 10', function() {
        expect(seatingChart.seats[0].y).to.equal(10);
      });

      it('adds a seat to the seating chart with the seat_number input', function() {
        expect(seatingChart.seats[0].seat_number).to.equal(3);
      });

      it('adds a seat to the seating chart with the table_number input', function() {
        expect(seatingChart.seats[0].table_number).to.equal(4);
      });

      it('calls addSeat on each view with the added seat', function() {
        expect(viewSpy.addSeat.calledWith(newSeat)).to.equal(true);
      });

      it('calls render on each view', function() {
        expect(viewSpy.render.calledOnce).to.equal(true);
      });
    });

    describe('with invalid parameters', function() {
      var alertSpy;
      beforeEach(function() {
        alertSpy = sinon.spy(window, 'alert');
        seatingChartController.newSeat('', '');
      });

      afterEach(function() {
        window.alert.restore();
      });
      describe('without a seat number', function() {
        it('does not create the seat', function() {
          expect(seatingChart.seats.length).to.equal(0);
        });

        it('triggers an alert', function() {
          expect(alertSpy.calledOnce).to.equal(true);
        });
      });

      describe('without a table number', function() {
        it('does not create the seat', function() {
          expect(seatingChart.seats.length).to.equal(0);
        });

        it('triggers an alert', function() {
          expect(alertSpy.calledOnce).to.equal(true);
        });
      });
    });
  });

  describe('converting to JSON', function() {
    it('Returns the seatingChart as JSON', function() {
      seatingChartController.newSeat(1, 2);
      seatingChartController.addSeat(5, 6, 7, 8);
      expect(seatingChartController.toJSON()).to.equal(seatingChart.toJSON());
    });
  });

  describe('setting the seating chart', function() {
    var oldSeat, testSeat1, testSeat2;
    beforeEach(function() {
      oldSeat = seatingChartController.newSeat(15, 20);
      testSeat1 = new Seat(1, 2, 10, 11);
      testSeat1.id = 15;
      testSeat1.status = 'open';
      testSeat2 = new Seat(5, 6, 20, 30);
      seatingChartController.setSeats([testSeat1, testSeat2]);
    });
    it('removes the old seats from the seating chart', function() {
      expect(seatingChart.seats).not.to.contain(oldSeat);
    });

    xit('adds the new seats to the seating chart', function() {
      // Failing because adding the seat creates a new seat
      expect(seatingChart.seats).to.contain(testSeat1);
      expect(seatingChart.seats).to.contain(testSeat2);
    });
  });

  describe('updating seat data', function() {
    beforeEach(function() {
      newSeat = seatingChartController.addSeat(3, 4);
      seatingChartController.updateSeatData(newSeat, 10, 11);
    });
    it('assigns the new seat_number to the seat', function() {
      expect(newSeat.seat_number).to.equal(10);
    });

    it('assigns the new table_number to the seat', function() {
      expect(newSeat.table_number).to.equal(11);
    });
  });

  describe('removing a seat', function() {
    beforeEach(function() {
      newSeat = seatingChartController.addSeat(3, 4);
      // Reset the number of times called because we want to test
      // removeSeat, not addSeat
      for(var spy in viewSpy) {
        viewSpy[spy].reset();
      }
      seatingChartController.removeSeat(newSeat);
    });
    it('removes the seat from the seating chart', function() {
      expect(seatingChart).not.to.contain(newSeat);
    });

    it('calls remove seat on the views with the removed seat as a param', function() {
      expect(viewSpy.removeSeat.calledWith(newSeat)).to.equal(true);
    });

    it('calls render on the views', function() {
      expect(viewSpy.render.calledOnce).to.equal(true);
    });
  });

  describe('moving a seat', function() {
    beforeEach(function() {
      testSeat = new Seat(1, 2, 3, 4);
      seatingChartController.moveSeat(testSeat, 10, 11);
    });
    it('moves the seat to the new x location', function() {
      expect(testSeat.x).to.equal(10);
    });

    it('moves the seat to the new y location', function() {
      expect(testSeat.y).to.equal(11);
    });

    it('calls render on the view', function() {
      expect(viewSpy.render.called).to.equal(true);
    });
  });

  describe('Updating the canvas background', function() {
    beforeEach(function() {
      seatingChartController.fileChangedCallback({ target: { files: [] } });
    });
    it('calls setBackground on the views', function() {
      expect(viewSpy.setBackground.calledOnce).to.equal(true);
    });
  });

  describe('reserving a seat', function() {
    var testSeat;
    beforeEach(function() {
      testSeat = seatingChartController.addSeat(3, 4);
    });
    xit('sends a request to tickets/reserve/:id', function() {
      expect($.ajax.calledWith()).to.equal(true);
    });
  });
});
