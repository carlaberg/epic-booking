import { useEffect, useState } from "react";
import DialogTitle from "@mui/material/DialogTitle";
import Dialog from "@mui/material/Dialog";
import TextField from "@mui/material/TextField";
import { apiFetcher } from "../hooks/useApi";
import Button from "@mui/material/Button";
import { EventApi } from "@fullcalendar/core";
import { ApiResult } from "@/Pages/calendar";
import DialogContent from "@mui/material/DialogContent";
import DialogActions from "@mui/material/DialogActions";

export interface EditBookingDialogProps {
  open: boolean;
  event: EventApi | undefined;
  onClose: () => void;
}

export default function EditBookingDialog(props: EditBookingDialogProps) {
  const { open, onClose, event } = props;
  const [error, setError] = useState<any>(undefined);
  const [title, setTitle] = useState(event?.title);

  useEffect(() => {
    setTitle(event?.title);
  }, [event]);

  return (
    <Dialog open={open} onClose={onClose} fullWidth={true}>
      <DialogTitle>Delete event</DialogTitle>
      <DialogContent dividers>
        <TextField
          id="standard-basic"
          label="Title"
          variant="outlined"
          value={title}
          onChange={(e) => {
            setTitle(e.target.value);
          }}
        />
      </DialogContent>
      <DialogActions>
        <Button
          color="error"
          onClick={async () => {
            try {
              const result = await apiFetcher<ApiResult>({
                path: `/bookings/${event?.id}`,
                method: "DELETE",
              });
              if (result.isSuccess) {
                event?.remove();
                onClose();
              } else {
                setError("Could not delete booking.");
              }
            } catch (error: any) {
              console.log("caught error", error.message);
              setError(error);
            }
          }}
        >
          Delete event
        </Button>
        <Button onClick={async () => onClose()}>Cancel</Button>
        <Button
          onClick={() => {
            event?.setProp("title", title);
            onClose();
          }}
        >
          Save
        </Button>
      </DialogActions>
    </Dialog>
  );
}
