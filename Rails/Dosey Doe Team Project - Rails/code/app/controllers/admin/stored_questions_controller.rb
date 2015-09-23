class Admin::StoredQuestionsController < ApplicationController
  before_action :set_stored_question, only: [:show, :edit, :update, :destroy]
  before_action :require_admin_logged_in

  def index
    @stored_questions = StoredQuestion.all
  end

  def new
    @stored_question = StoredQuestion.new
  end

  def create
    @stored_question = StoredQuestion.new(questions_params)

    if @stored_question.save
      redirect_to admin_stored_questions_path, notice: 'Additional Question successfully added'
    else
      render :new
    end
  end

  def update
    if @stored_question.update(questions_params)
      redirect_to admin_stored_questions_path, notice: 'Additional Question successfully updated'
    else
      render :edit
    end
  end

  def destroy
    @stored_question.destroy
    redirect_to admin_stored_questions_path, notice: 'Question Deleted.'
  end

  private
 
  def set_stored_question
    begin
      @stored_question = StoredQuestion.find(params[:id])
    rescue ActiveRecord::RecordNotFound
      @stored_questions = StoredQuestion.all
      redirect_to admin_stored_questions_path, notice: 'Error locating answers, please try again.'
    end
  end

  def questions_params
    params.require(:stored_question).permit(:question, :venue_id)
  end
end
