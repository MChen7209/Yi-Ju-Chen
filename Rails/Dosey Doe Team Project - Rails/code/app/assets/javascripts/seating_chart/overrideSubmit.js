var overrideSubmit = function(formID) {
  var addParams = function() {
    $('<input />').attr('type', 'hidden')
      .attr('name', 'seating_chart[seats]')
      .attr('value', seatingChartController.toJSON())
      .appendTo(formID);
      return true;
  };

  $(function() {
    $(formID).submit(addParams);
  });
};