require 'rails_helper'

describe ShowsHelper, type: :helper do
  pending '#open_class'

  describe '#utc_datetime_from_time' do
    it 'creates a time in UTC' do
      datetime = utc_datetime_from_time('1:11 PM')
      expect(datetime.utc_offset).to eq 0
    end

    describe 'creates a time with the correct hour' do
      it 'when AM is specified' do
        datetime = utc_datetime_from_time('5:15 AM')
        expect(datetime.hour).to eq (5 - Time.zone.now.utc_offset)
      end

      it 'when PM is specified' do
        datetime = utc_datetime_from_time('6:34 PM')
        expect(datetime.hour).to eq (6 + 12 - Time.zone.now.utc_offset)
      end

      it 'when am is specified, just in case' do
        datetime = utc_datetime_from_time('7:00 am')
        expect(datetime.hour).to eq (7 - Time.zone.now.utc_offset)
      end
    end

    it 'creates a time with the correct minute' do
      datetime = utc_datetime_from_time('4:56 AM')
      expect(datetime.min).to eq 56
    end

  end
end
