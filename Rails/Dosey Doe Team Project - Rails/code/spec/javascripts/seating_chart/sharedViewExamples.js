var addingSeatExamples = function(){
  it('calls createjs.Shape', function() {
    expect(createjs.Shape.called).to.equal(true);
  });

  xit('creates a black circle', function() {
    expect(circleMock.graphics.beginFill.calledWith('black')).to.equal(true);
  });

  it('draws the circle at 0, 0 with a radius of 10', function() {
    expect(drawCircleMock.drawCircle.calledWith(0, 0, 10)).to.equal(true);
  });

  it('sets the new circle x to the input seat x', function() {
    expect(circleMock.x).to.equal(seatMock.x);
  });

  it('sets the new circle y to the input seat y', function() {
    expect(circleMock.y).to.equal(seatMock.y);
  });

  it('assigns the new seat to the new circle', function() {
    expect(circleMock.seat).to.equal(seatMock);
  });

  it('adds the new circle to the stage', function() {
        expect(stageMock.addChild.calledWith(circleMock));
  });
};
