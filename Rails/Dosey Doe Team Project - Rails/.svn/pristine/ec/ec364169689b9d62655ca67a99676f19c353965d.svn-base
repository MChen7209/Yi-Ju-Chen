var SeatingChartView = (function() {
  function SeatingChartView(canvasID, inputController, functionFlag) {
    this.stage = new createjs.Stage(canvasID);
    this.controller = inputController;
    this.backgound = null;
    this.selectedSeat = null;
    this.function = functionFlag;

    this.disableRightClick(canvasID);
    if(this.function === 'edit') { this.initializeForm(); }
  }

  SeatingChartView.prototype.addSeat = function(newSeat) {
    var newCircle = this.instantiateCircle(newSeat);
    this.assignMouseFunctions(newCircle);

    this.stage.addChild(newCircle);
  };

  SeatingChartView.prototype.instantiateCircle = function(seat) {
    var newCircle = new createjs.Shape();
    newCircle.graphics.beginFill(this.seatColor(seat)).drawCircle(0, 0, 10);
    newCircle.x = seat.x;
    newCircle.y = seat.y;
    newCircle.seat = seat;
    newCircle.type = 'seat';
    return newCircle;
  };

  SeatingChartView.prototype.assignMouseFunctions = function(circle) {
    if(this.function === 'edit') {
      circle.on('click', this.openFormOnRightClick.bind(this));
      circle.on('pressmove', this.moveOnDrag.bind(this));
    }

    if(this.function === 'shop') {
      circle.on('click', this.reserveOnClick.bind(this));
    }
  };

  SeatingChartView.prototype.openFormOnRightClick = function(event) {
    if(event.nativeEvent.button == 2) {
      this.openForm(event.currentTarget.seat);
    }
  };

  SeatingChartView.prototype.moveOnDrag = function(event) {
    this.controller.moveSeat(event.currentTarget.seat, event.stageX, event.stageY);
    event.currentTarget.x = event.stageX; event.currentTarget.y = event.stageY;
  };

  SeatingChartView.prototype.reserveOnClick = function(event) {
    var controller = this.controller;
    $.ajax({
      url: '/tickets/reserve/' + event.currentTarget.seat.id,
      method: 'PUT',
      success: function(success_message) {
        controller.setSeats(success_message);
      }
    });
  };

  SeatingChartView.prototype.seatColor = function(seat) {
    if(this.function === 'shop') {
      switch(seat.status) {
        case 'user reserved':
          return 'green';
        case 'closed':
          return 'red';
        case 'open':
          return 'black';
      }
    }
    else { return 'black'; }
  };

  SeatingChartView.prototype.reset = function() {
    var stage = this.stage;
    stage.children.forEach(function(child) {
      if(child.type === 'seat') {
        stage.removeChild(child);
      }
    });
  };

  SeatingChartView.prototype.removeSeat = function(seat) {
    var stage = this.stage;
    stage.children.forEach(function(child) {
      if(child.seat === seat) { stage.removeChild(child); }
    });
  };

  SeatingChartView.prototype.render = function() {
    this.stage.update();
  };

  SeatingChartView.prototype.setBackground = function(imageLocation) {
    var stage = this.stage;
    var background = this.background;

    if(background !== null) {
      stage.removeChild(background);
    }
    background = new createjs.Bitmap(imageLocation);
    background.type = 'background';
    // Function is on a timer because for some reason
    // it will not render if you call it right away
    window.setTimeout(function() {
      stage.canvas.width = background.image.width;
      stage.canvas.height = background.image.height;
      stage.addChild(background);
      // EaselJS renders in order of the children array
      // setting the index of the background to 0 ensures
      // that circles will be rendered on top of the background
      stage.setChildIndex(background, 0);
      stage.update();
    }, 500);
  };

  SeatingChartView.prototype.disableRightClick = function(canvasID) {
    $(function() {
      $('#' + canvasID).bind('contextmenu', function(e) {
        return false;
      });
    });
  };

  SeatingChartView.prototype.initializeForm = function() {
    this.seatNumberField = $('#form_seat_number');
    this.tableNumberField = $('#form_table_number');
    var allFields = $([]).add(this.seatNumberField).add(this.tableNumberField);

    var _this = this;
    this.formDialog = $('#edit_seat').dialog({
      autoOpen: false,
      height: 300,
      width: 350,
      modal: true,
      buttons: {
        'Save Seat': function() {
          _this.controller.updateSeatData(_this.selectedSeat, _this.seatNumberField.val(),
                                    _this.tableNumberField.val());
          _this.formDialog.dialog('close');
        },
        'Delete Seat': function() {
          _this.controller.removeSeat.call(_this.controller, _this.selectedSeat);
          _this.formDialog.dialog('close');
        },
        Cancel: function() {
          _this.formDialog.dialog('close');
        }
      },
      close: function() {
        _this.form[0].reset();
      }
    });

    var form;
    form = this.form = this.formDialog.find('form');
  };

  SeatingChartView.prototype.openForm = function(seat) {
    this.selectedSeat = seat;
    this.seatNumberField.val(this.selectedSeat.seat_number);
    this.tableNumberField.val(this.selectedSeat.table_number);
    this.formDialog.dialog('open');
  };

  return SeatingChartView;
})();
