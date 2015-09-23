var override = function(event) {
  $.ajax({
    url: '/checkout',
    type: 'POST',
    data: questionData(),
    contentType: "application/json",
    success: function(response) {
        if(response.redirect) {
            window.location.href = response.redirect
        }
    }
  });
  event.preventDefault();
}

var questionData = function() {
  answersAsJSON = [];
  $('.answer').each(function() {
    var newAnswer = {
      "question_id": this.dataset.questionId,
      "answer": this.value
    }
    answersAsJSON.push(newAnswer);
  });
    var answers = {'questions': answersAsJSON}
    return JSON.stringify(answers)
};

$(function() {
  $('#questions_form').submit(override);
});