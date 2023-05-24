import FullCalendar from "@fullcalendar/react"; // must go before plugins
import timeGridPlugin from "@fullcalendar/timegrid";
import interactionPlugin from "@fullcalendar/interaction";
import { useApi } from "../hooks/useApi";

export default function Calendar() {
  const { data: bookings, error } = useApi<any>({ path: "/bookings" });

  return (
    <FullCalendar
      plugins={[interactionPlugin, timeGridPlugin]}
      initialView="timeGridWeek"
      events={bookings}
    />
  );
}
