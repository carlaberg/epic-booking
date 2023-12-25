import { useState } from "react";
import DialogTitle from "@mui/material/DialogTitle";
import Dialog from "@mui/material/Dialog";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import DialogContent from "@mui/material/DialogContent";
import { apiFetcher } from "../hooks/useApi";
import { DateSelectArg } from "@fullcalendar/core";
import { ApiResult } from "@/Pages/calendar";
import { useValidation } from "@/hooks/useValidation/useValidation";
import DialogActions from "@mui/material/DialogActions";
import FormControl from "@mui/material/FormControl";
import FormLabel from "@mui/material/FormLabel";

export interface CreateBookingDialogProps {
  open: boolean;
  selection: DateSelectArg | undefined;
  onClose: () => void;
}

interface CreateBookingFormState {
  title: {
    value: string;
    error: boolean;
    errorMessage: string;
  };
}
const initialFormState: CreateBookingFormState = {
  title: {
    value: "",
    error: false,
    errorMessage: "",
  },
};

export default function CreateBookingDialog(props: CreateBookingDialogProps) {
  const { open, onClose, selection } = props;
  const [error, setError] = useState<any>(undefined);
  const [formState, setFormState] =
    useState<CreateBookingFormState>(initialFormState);

  const { validation, errors } = useValidation<CreateBookingFormState>({
    title: () => (!formState.title.value ? "Title can not be empty" : null),
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormState({
      ...formState,
      [name]: {
        ...formState[name as keyof CreateBookingFormState],
        value,
      },
    });
  };

  return (
    <Dialog
      open={open}
      fullWidth={true}
      onClose={() => {
        setFormState(initialFormState);
        onClose();
      }}
    >
      <DialogTitle>Create event</DialogTitle>
      <DialogContent dividers>
        <FormControl>
          <TextField
            id="standard-basic"
            required
            label="Title"
            variant="outlined"
            name="title"
            value={formState.title.value}
            error={!!errors?.title}
            helperText={errors?.title}
            onChange={handleChange}
          />
        </FormControl>
      </DialogContent>
      <DialogActions>
        <Button
          onClick={() => {
            selection?.view.calendar.unselect();
            onClose();
          }}
        >
          Cancel
        </Button>
        <Button
          onClick={async () => {
            if (!validation().valid) return;
            try {
              const booking = {
                title: formState.title.value,
                start: selection?.startStr,
                end: selection?.endStr,
              };

              const response = await apiFetcher<ApiResult>({
                path: "/bookings",
                method: "POST",
                body: booking,
              });

              if (response.isSuccess) {
                selection?.view.calendar.addEvent(booking);
                selection?.view.calendar.unselect();
                onClose();
                setFormState(initialFormState);
              } else {
                setError("Could not delete booking.");
              }
            } catch (error: any) {
              console.log("caught error", error.message);
              setError(error);
            }
          }}
        >
          Save
        </Button>
      </DialogActions>
    </Dialog>
  );
}
