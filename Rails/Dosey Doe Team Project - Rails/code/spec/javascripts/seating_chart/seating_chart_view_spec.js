//= require seating_chart/SeatingChartView

// *********************** Mocking ***********************
var createjs = {
  Stage: sinon.stub(),
  Shape: sinon.stub(),
  Bitmap: sinon.stub()
};
var canvasMock = {
  width: null,
  height: null
};
var circleMock = {
  graphics: { beginFill: sinon.stub() },
  on: sinon.spy(),
  seat: null,
  x: null,
  y: null
};

var stageMock = {
  update: sinon.spy(),
  addChild: sinon.spy(),
  removeChild: sinon.spy(),
  children: [circleMock],
  setChildIndex: sinon.spy(),
  canvas: canvasMock
};
var backgroundMock = {
  image: {
  width: 100,
  height: 100
  }
};
createjs.Stage.returns(stageMock);
createjs.Bitmap.returns(backgroundMock);
var drawCircleMock = { drawCircle: sinon.spy() };
circleMock.graphics.beginFill.returns(drawCircleMock);
createjs.Shape.returns(circleMock);

var resetCreatejs = function() {
  createjs.Stage.reset();
  createjs.Shape.reset();
  createjs.Bitmap.reset();
  canvasMock.width = null;
  canvasMock.height = null;
  stageMock.update.reset();
  stageMock.addChild.reset();
  stageMock.removeChild.reset();
  stageMock.setChildIndex.reset();
  stageMock.children = [circleMock];
  circleMock.graphics.beginFill.reset();
  circleMock.on.reset();
  circleMock.x = null;
  circleMock.y = null;
  circleMock.seat = null;
  circleMock.seat_number = null;
  circleMock.table_number = null;
  drawCircleMock.drawCircle.reset();
};

var controllerMock = {
  moveSeat: sinon.spy()
};

var resetControllerMock = function() {
  controllerMock.moveSeat.reset();
};

var formDialogMock = {
  find: sinon.stub(),
  dialog: sinon.spy()
};

// What is this?
var seatNumberFieldMock = {val: sinon.spy()};
var tableNumberFieldMock = {val: sinon.spy()};

var resetFieldMocks = function() {
  seatNumberFieldMock.val.reset();
  tableNumberFieldMock.val.reset();
};

// Mock jQuery
var $ = sinon.stub();
var dialogMock = {dialog: sinon.stub()};
dialogMock.dialog.returns(formDialogMock);
var addMock = {add: sinon.stub()};
addMock.add.returns(addMock);
$.returns(addMock);
$.withArgs('#edit_seat').returns(dialogMock);
$.withArgs('#fakeCanvas').returns(canvasMock);
$.withArgs('#form_seat_number').returns(seatNumberFieldMock);
$.withArgs('#form_table_number').returns(tableNumberFieldMock);

var resetjQery = function() {
  $.reset();
  dialogMock.dialog.reset();
  addMock.add.reset();
};

// Mock seat form


var seatMock = {
  x: 20,
  y: 30,
  seat_number: 11,
  table_number: 12
};

var resetSeatMock = function() {
  seatMock.x = 20;
  seatMock.y = 30;
  seatMock.seat_number = 11;
  seatMock.table_number = 12;
};

// *********************** Testing ***********************

describe('Seating Chart View', function() {
  var seatingChartView;

  beforeEach(function() {
    seatingChartView = new SeatingChartView('fakeID', controllerMock);
  });

  afterEach(function() {
    resetControllerMock();
  });

  describe("creating a SeatingChartView", function() {
    it('creates a new stage with the input canvasID', function() {
      expect(createjs.Stage.calledWith('fakeID')).to.equal(true);
    });

    it('assigns the controller to the input controller', function() {
      expect(seatingChartView.controller).to.equal(controllerMock);
    });
  });

  describe('adding a seat', function() {
    it('adds the circle to the stage', function() {
      seatingChartView = new SeatingChartView('fakeID', controllerMock);
      seatingChartView.addSeat(seatMock);
      expect(stageMock.addChild.called).to.equal(true);
    });
  });

  describe('instantiating a circle', function() {
    var testCircle;
    beforeEach(function() {
      testCircle = seatingChartView.instantiateCircle(seatMock);
    });

    afterEach(function() {
      resetCreatejs();
      resetSeatMock();
    });
    it('calls createjs.Shape to create a new circle', function() {
      expect(createjs.Shape.called).to.equal(true);
    });

    it("creates a new circle with position at the seat's x value", function() {
      expect(testCircle.x).to.equal(seatMock.x);
    });

    it("creates a new circle with position at the seat's y value", function() {
      expect(testCircle.y).to.equal(seatMock.y);
    });

    it("sets the seat for the new circle to the input seat", function() {
      expect(testCircle.seat).to.equal(seatMock);
    });

    context("with the functionFlag set to 'edit'", function() {
      it('sets the circle color to black', function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'edit');
        seatingChartView.instantiateCircle(seatMock);
        expect(circleMock.graphics.beginFill.calledWith('black'));
      });
    });

    context("with the function flag set to 'show'", function() {
      it('sets the circle color to black', function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'show');
        seatingChartView.instantiateCircle(seatMock);
        expect(circleMock.graphics.beginFill.calledWith('black'));
      });
    });

    context("with the function flag set to 'shop'", function() {
      beforeEach(function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'shop');
      });
      it("sets the circle color to green if its status is 'user reserved'", function() {
        seatMock.status = 'user reserved';
        seatingChartView.instantiateCircle(seatMock);
        expect(circleMock.graphics.beginFill.calledWith('green'));
      });

      it("sets the circle color to black if its status is 'open'", function() {
        seatMock.status = 'open';
        seatingChartView.instantiateCircle(seatMock);
        expect(circleMock.graphics.beginFill.calledWith('green'));
      });
    });
  });

  describe('setting the mouse functions for a circle', function() {
    afterEach(function() {
      resetCreatejs();
    });
    context("with the functionFlag set to 'edit'", function() {
      beforeEach(function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'edit');
        seatingChartView.assignMouseFunctions(circleMock);
      });
      it('sets a behavior for clicking the circle', function() {
        expect(circleMock.on.calledWith('click')).to.equal(true);
      });

      it('sets a behavior for dragging the circle', function() {
        expect(circleMock.on.calledWith('pressmove')).to.equal(true);
      });
    });

    context("with the functionFlag set to 'shop'", function() {
      it('sets the click behavior for the circle', function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'shop');
        seatingChartView.assignMouseFunctions(circleMock);
        expect(circleMock.on.calledWith('click')).to.equal(true);
      });
    });

    context('with the functionFlag set to anything else', function() {
      it('does not set any mouse behaviors for the circle', function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'whatever');
        seatingChartView.assignMouseFunctions(circleMock);
        expect(circleMock.on.called).to.equal(false);
      });
    });
  });

  describe('opening the form on right click', function() {
    beforeEach(function() {
      seatingChartView = new SeatingChartView('fakeID', controllerMock, 'whatever');
      seatingChartView.openForm = sinon.spy();
    });
    it('does not open the form if the event is a left click', function() {
      var clickEventMock = { nativeEvent: { button: 1 }, currentTarget: { seat: seatMock } };
      seatingChartView.openFormOnRightClick(clickEventMock);
      expect(seatingChartView.openForm.called).to.equal(false);
    });

    it('opens the form if the event is a right click', function() {
      var clickEventMock = { nativeEvent: { button: 2 }, currentTarget: { seat: seatMock } };
      seatingChartView.openFormOnRightClick(clickEventMock);
      expect(seatingChartView.openForm.calledWith(seatMock)).to.equal(true);
    });
  });

  describe('moving a seat on drag', function() {
    var dragEventMock;
    beforeEach(function() {
      circleMock.seat = seatMock;
      dragEventMock = { currentTarget: circleMock, stageX: 69, stageY: 70 };
      seatingChartView.moveOnDrag(dragEventMock);
    });

    afterEach(function() {
      resetControllerMock();
      resetSeatMock();
      resetCreatejs();
    });
    it('calls moveSeat in the controller', function() {
      expect(controllerMock.moveSeat.calledWith(seatMock, 69, 70)).to.equal(true);
    });

    it("sets the circle's x to the event's x", function() {
      expect(circleMock.x).to.equal(dragEventMock.stageX);
    });

    it("sets the circle's y to the event's y", function() {
      expect(circleMock.y).to.equal(dragEventMock.stageY);
    });
  });

  describe('reserving a seat', function() {
    xit('sends an AJAX  PUT request');
  });

  describe("checking a seat's color", function() {
    afterEach(function() {
      resetSeatMock();
      resetControllerMock();
    });
    it("returns black if the function flag is not set to 'shop'", function() {
      seatingChartView = new SeatingChartView('fakeID', controllerMock, 'blah');
      expect(seatingChartView.seatColor(seatMock)).to.equal('black');
    });

    context("with the function flag set to 'shop'", function() {
      beforeEach(function() {
        seatingChartView = new SeatingChartView('fakeID', controllerMock, 'shop');
      });
      it("returns green if the status is 'user reserved'", function() {
        seatMock.status = 'user reserved';
        expect(seatingChartView.seatColor(seatMock)).to.equal('green');
      });

      it("returns black if the status is 'open'", function() {
        seatMock.status = 'open';
        expect(seatingChartView.seatColor(seatMock)).to.equal('black');
      });

      it("returns red if the status is 'closed'", function() {
        seatMock.status = 'closed';
        expect(seatingChartView.seatColor(seatMock)).to.equal('red');
      });
    });
  });

  describe('resetting the seating chart', function() {
    afterEach(function() {
      resetCreatejs();
      circleMock.type = undefined;
    });
    it('calls removeChild if the child is a seat', function() {
      circleMock.type = 'seat';
      seatingChartView.reset();
      expect(stageMock.removeChild.calledWith(circleMock)).to.equal(true);
    });

    it('does not call removeChild if the child is not a seat', function() {
      seatingChartView.reset();
      expect(stageMock.removeChild.called).to.equal(false);
    });
  });

  describe('removing a seat', function() {
    afterEach(function() {
      resetCreatejs();
      resetSeatMock();
    });
    it('removes the input seat if it belongs to one of the circles', function() {
      circleMock.seat = seatMock;
      seatingChartView.removeSeat(seatMock);
      expect(stageMock.removeChild.calledWith(circleMock)).to.equal(true);
      circleMock.seat = undefined;
    });

    it('does not remove the seat if it does not belong to one of the circles', function() {
      seatingChartView.removeSeat(seatMock);
      expect(stageMock.removeChild.called).to.equal(false);
    });
  });

  describe('rendering the view', function() {
    it('calls update on the stage', function() {
      seatingChartView.render();
      expect(stageMock.update.called).to.equal(true);
      resetCreatejs();
    });
  });

  describe('setting the background', function() {
    var clock;
    beforeEach(function() {
      clock = sinon.useFakeTimers();
      seatingChartView.setBackground('fake location');

      // Uses Sinon's time-warping features to simulate the clock ticking
      // 600ms to trigger the 500 second timeout in the view
      clock.tick(600);
    });
    afterEach(function() {
      clock.restore();
      resetCreatejs();
    });

    it('updates the canvas width', function() {
      expect(canvasMock.width).to.equal(backgroundMock.image.width);
    });

    it('updates the canvas height', function() {
      expect(canvasMock.height).to.equal(backgroundMock.image.height);
    });

    it('adds the background to the stage', function() {
      expect(stageMock.addChild.calledWith(backgroundMock)).to.equal(true);
    });

    it('sets the index of the background to 0', function() {
      expect(stageMock.setChildIndex.calledWith(backgroundMock, 0)).to.equal(true);
    });

    context('with an existing background', function() {
      it("removes the existing background from the stage's children", function() {
        seatingChartView.setBackground('fake location 2');
        clock.tick(600);

        expect(stageMock.removeChild.called).to.equal(true);
      });
    });
  });

  describe('opening the form', function() {
    beforeEach(function() {
      seatingChartView.initializeForm();
      seatingChartView.openForm(seatMock);
    });

    afterEach(function() {
      resetFieldMocks();
    });
    it('assigns the seat_number of the selected seat', function() {
      expect(seatNumberFieldMock.val.calledWith(seatMock.seat_number)).to.equal(true);
    });

    it('assigns the table_number of the selected seat', function() {
      expect(tableNumberFieldMock.val.calledWith(seatMock.table_number)).to.equal(true);
    });

    it('opens the form', function() {
      expect(formDialogMock.dialog.calledWith('open')).to.equal(true);
    });
  });
});
