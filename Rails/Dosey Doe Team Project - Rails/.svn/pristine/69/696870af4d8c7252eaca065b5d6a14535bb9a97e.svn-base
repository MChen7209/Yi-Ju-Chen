require 'rails_helper'

describe ApplicationHelper, type: :helper do
  describe '#date_as_words' do
    it 'returns a string containing a date in the format
        day of the week, month day, year' do
      example_date = Date.new 2015, 2, 14
      expect(date_as_words example_date).to eq \
        'Saturday, February 14, 2015'
    end
  end

  describe '#time_from_datetime' do
    context 'it has the correct format' do
      it 'with a double-digit time' do
        example_time = DateTime.strptime('10:11 AM +0', '%I:%M %p %z')
        expect(time_from_datetime example_time).to eq '10:11 AM'
      end

      it 'with a single-digit time' do
        example_time = DateTime.strptime('3:28 PM +0', '%I:%M %p %z')
        expect(time_from_datetime example_time).to eq '3:28 PM'
      end
    end

    context 'it has the correct time' do
      it 'when created from a DateTime in Central Standard Time (UTC -6)' do
        datetime = DateTime.strptime('3:00 PM -6', '%I:%M %p %z')
        expect(time_from_datetime datetime).to eq '9:00 PM'
      end

      it 'when created from a DateTime in Central Daylight Time (UTC -5)' do
        datetime = DateTime.strptime('3:00 PM -5', '%I:%M %p %z')
        expect(time_from_datetime datetime).to eq '8:00 PM'
      end

      it 'when created from a DateTime in UTC' do
        datetime = DateTime.strptime('3:00 PM +0', '%I:%M %p %z')
        expect(time_from_datetime datetime).to eq '3:00 PM'
      end
    end
  end
end