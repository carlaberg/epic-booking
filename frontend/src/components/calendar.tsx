import { useState } from "react";
import FullCalendar from "@fullcalendar/react"; // must go before plugins
import { EventApi, DateSelectArg } from "@fullcalendar/core";
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import { apiFetcher, useApi } from "../hooks/useApi";
import EditBookingDialog from "@/components/EditBookingDialog";
import CreateBookingDialog from "@/components/CreateBookingDialog";
import { useUser } from "@/hooks/useUser/useUser";

export interface ApiResult<T = any> {
  errorMessages: string[];
  isSuccess: boolean;
  result: T;
  statusCode: number;
}

export interface Booking {
  id: string;
  title: string;
  start: Date;
  end: Date;
  creatorId: string;
  display?: string;
}

export default function Calendar() {
  const user = useUser();
  const { data: bookings, error } = useApi<ApiResult<Booking[]>>({
    path: "/bookings",
  });
  const [isEditBookingDialogOpen, setIsEditBookingDialogOpen] = useState(false);
  const [isCreateBookingDialogOpen, setIsCreateBookingDialogOpen] = useState(false);
  const [editedEvent, setEditedEvent] = useState<EventApi | undefined>(
    undefined
  );
  const [selectedEvent, setSelectedEvent] = useState<DateSelectArg | undefined>(undefined);

  const formatedBookings: Booking[] = bookings?.result.map((booking) => {
    if (booking.creatorId != user?.nameid) {
      booking.display = 'background'
    }
    return booking;
  });
  return (
    <>
      <FullCalendar
        plugins={[interactionPlugin, timeGridPlugin]}
        initialView="timeGridWeek"
        events={formatedBookings}
        selectMirror
        selectable
        // eventAdd={(event) => console.log("event added", event)}
        editable
        eventStartEditable
        unselectCancel=".MuiDialog-paper"
        eventDurationEditable
        selectOverlap={false}
        eventOverlap={false}
        eventClick={(arg) => {
          setEditedEvent(arg.event);
          setIsEditBookingDialogOpen(true);
        }}
        eventChange={async (arg) => {
          try {
            console.log("event id", arg.event);
            apiFetcher({
              path: `/bookings/${arg.event.id}`,
              method: "PUT",
              body: arg.event,
            });
          } catch (error) {
            console.error(error);
          }
        }}
        select={async (selection) => {
          setSelectedEvent(selection);
          setIsCreateBookingDialogOpen(true);
        }}
      />
      <CreateBookingDialog
        open={isCreateBookingDialogOpen}
        onClose={() => {
          setIsCreateBookingDialogOpen(false)
          setSelectedEvent(undefined);
        }}
        selection={selectedEvent}
      />
      <EditBookingDialog
        open={isEditBookingDialogOpen}
        onClose={() => {
          setIsEditBookingDialogOpen(false)
          setEditedEvent(undefined);
        }}
        event={editedEvent}
      />
    </>
  );
}