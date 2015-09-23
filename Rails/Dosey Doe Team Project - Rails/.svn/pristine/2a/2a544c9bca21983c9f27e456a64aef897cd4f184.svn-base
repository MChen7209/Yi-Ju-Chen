require 'rails_helper'

RSpec.describe TicketsController, type: :controller do
  describe 'reserving a ticket' do
    before :each do
      @test_customer = create :customer
      sign_in @test_customer
      # Remove @ variables that I don't need to be @
      @test_seating_chart = create :seating_chart
      @dtest_seat1 = create :seat, seating_chart: @test_seating_chart
      @test_seat2 = create :seat, seating_chart: @test_seating_chart
      @test_show = create :show, seating_chart: @test_seating_chart
      @test_ticket1 = create :ticket, seat: @dtest_seat1, show: @test_show
      @test_ticket2 = create :ticket, seat: @test_seat2, show: @test_show
      create :ticket
    end
    context 'with a valid ticket id' do
      before :each do
        put :reserve, id: @test_ticket1.id
        @test_ticket1.reload
      end
      it 'assigns the ticket to the current user' do
        expect(@test_ticket1.user).to eq @test_customer
      end

      it 'sets the ticket status to equal reserved' do
        expect(@test_ticket1.status).to eq 'reserved'
      end

      it 'reserves the ticket for 10 minutes' do
        # Convert to hours, minutes, and seconds string to test approximate
        # times, because milliseconds will not be equal
        reserved_until_string = @test_ticket1.reserved_until.strftime('%H:%M %S')
        current_time_string = (DateTime.current + @test_ticket1.reservation_time).strftime('%H:%M %S')
        expect(reserved_until_string).to eq(current_time_string)
      end

      it 'returns the tickets for the show as JSON' do
        response_array = JSON.parse response.body
        ticket1_json = @test_ticket1.as_json
        ticket1_json['status'] = 'user reserved'
        ticket2_json = @test_ticket2.as_json
        expect(response_array).to match_array([ticket1_json, ticket2_json])
      end
    end

    context 'when the user already has a ticket in cart', aj: true do
      before :each do
        @test_seat3 = create :seat, seating_chart: @test_seating_chart
        @test_ticket3 = create :ticket, seat: @test_seat3, show: @test_show
        put :reserve, id: @test_ticket1.id
        @test_ticket1.reload
        # puts DateTime.now
        Timecop.travel(DateTime.current + 8.minutes)
        # puts DateTime.now
        put :reserve, id: @test_ticket3.id
        @test_ticket1.reload
        @test_ticket3.reload
      end

      it 'it updates the reservation time of the new ticket' do
        reserved_until_string = @test_ticket3.reserved_until.strftime('%H:%M %S')
        current_time_string = (DateTime.current + @test_ticket3.reservation_time).strftime('%H:%M %S')
        expect(reserved_until_string).to eq(current_time_string)
      end

      it 'it updates the reservation time of the existing ticket' do
        pending 'The existing ticket isn\'t being updated. Seems to be nonexistent inside refresh_all_tickets (see debug puts in TicketsHelper).'
        reserved_until_string = @test_ticket1.reserved_until.strftime('%H:%M %S')
        current_time_string = (DateTime.current + @test_ticket1.reservation_time).strftime('%H:%M %S')
        expect(reserved_until_string).to eq(current_time_string)
      end
    end

    context 'without a valid ticket id' do
      it 'does not throw an error' do
        expect { put :reserve, id: -1 }.not_to raise_error
      end

      it 'renders null' do
        put :reserve, id: -1
        expect(response.body).to eq('null')
      end
    end
  end
end
