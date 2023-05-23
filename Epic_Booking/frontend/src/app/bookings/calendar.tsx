'use client'
import FullCalendar from '@fullcalendar/react' // must go before plugins
import timeGridPlugin from '@fullcalendar/timegrid'
import interactionPlugin from '@fullcalendar/interaction'

export default async function Calendar() {

    try {
    const response = await fetch('https://localhost:7050/api/bookings');
    const bookings = await response.json();
    console.log(bookings);
    } catch (error) {
        console.log(error);
    }

    return <FullCalendar
        plugins={[interactionPlugin, timeGridPlugin]}
        initialView="timeGridWeek"
        events={[
            {
                title: 'BCH237',
                start: '2023-05-21T10:30:00',
                end: '2023-05-21T11:30:00',
                extendedProps: {
                    department: 'BioChemistry'
                },
                description: 'Lecture'
            }
        ]}
    />
}
