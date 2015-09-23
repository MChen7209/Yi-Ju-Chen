require 'rails_helper'

RSpec.describe Show, type: :model do
  it 'has a minimum valid factory' do
    expect(build :show).to be_valid
  end

  describe 'it has a show_with_tickets factory' do
    before :each do
      @show_with_tickets = build :show_with_tickets
    end

    it 'is valid' do
      expect(@show_with_tickets).to be_valid
    end

    it 'has tickets' do
      expect(@show_with_tickets.tickets.count).to be > 0
    end
  end

  it 'is invalid without an artist' do
    expect(build :show, artist: nil).not_to be_valid
  end

  it 'is invalid without a venue' do
    expect(build :show, venue: nil).not_to be_valid
  end

  it 'is invalid without a show_date' do
    expect(build :show, show_date: nil).not_to be_valid
  end

  it 'is invalid without a doors_open' do
    expect(build :show, doors_open: nil).not_to be_valid
  end

  it 'is invalid without a dinner_starts' do
    expect(build :show, dinner_starts: nil).not_to be_valid
  end

  it 'is invalid without a dinner_ends' do
    expect(build :show, dinner_ends: nil).not_to be_valid
  end

  it 'is invalid without a show_starts' do
    expect(build :show, show_starts: nil).not_to be_valid
  end

  it 'belongs_to a venue' do
    venue_association = Show.reflect_on_association :venue
    expect(venue_association.macro).to eq :belongs_to
  end

  it 'is a date in the future' do
    expect(build :show, show_date: (Date.yesterday - 3.days)).not_to be_valid
    expect(build :show, show_date: (Date.tomorrow + 3.days)).to be_valid
  end

  it 'has_many tickets' do
    ticket_association = Show.reflect_on_association :tickets
    expect(ticket_association.macro).to eq :has_many
  end

  it 'belongs_to a seating_chart' do
    seating_chart_association = Show.reflect_on_association :seating_chart
    expect(seating_chart_association.macro).to eq :belongs_to
  end

  describe 'it contains the proper default times' do
    shared_examples_for 'a Show with the correct default times' do
      it 'has the correct default doors_open time' do
        expect(test_show.doors_open.hour).to eq 18
        expect(test_show.doors_open.min).to eq 0
      end

      it 'has the correct default dinner_starts time' do
        expect(test_show.dinner_starts.hour).to eq 18
        expect(test_show.dinner_starts.min).to eq 0
      end

      it 'has the correct default dinner_ends time' do
        expect(test_show.dinner_ends.hour).to eq 19
        expect(test_show.dinner_ends.min).to eq 30
      end

      it 'has the correct default show_starts time' do
        expect(test_show.show_starts.hour).to eq 20
        expect(test_show.show_starts.min).to eq 30
      end
    end

    context 'when built via Show.new' do
      include_examples 'a Show with the correct default times' do
        let(:test_show) { Show.new }
      end
    end

    context 'when built by the Factory' do
      include_examples 'a Show with the correct default times' do
        let(:test_show) { build :show }
      end
    end

    context 'when built by the Factory with dinner_start time specified' do
      include ShowsHelper

      let(:test_show) { build(:show, dinner_starts: utc_datetime_from_time('5:15 PM')) }

      it 'contains the custom dinner_starts time' do
        expect(test_show.dinner_starts.hour).to eq 17
        expect(test_show.dinner_starts.min).to eq 15
      end

      it 'contains the default dinner_ends time' do
        expect(test_show.dinner_ends.hour).to eq 19
        expect(test_show.dinner_ends.min).to eq 30
      end
    end
  end
end
