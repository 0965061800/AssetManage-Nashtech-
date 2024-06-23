import { PropaneSharp } from "@mui/icons-material";
import { TextField } from "@mui/material";
import { useController, UseControllerProps } from "react-hook-form";

interface Props extends UseControllerProps {
  id?: string
  label?: string;
  placeholder?: string;
  size?: "small" | "medium";
  multiline?: boolean;
  rows?: number;
  type?: string;
  error?: boolean;
  helperText?: string;
  className?: string;
  InputProps?: any | undefined;
  defaultValue?: string | "";
  value?: any | undefined;
  maxRows?: number;
  sx?: any;
  disabled?: boolean;
  onKeyDown?: any;
}

export default function AppTextInput(props: Props) {
  const { fieldState, field } = useController({ ...props, defaultValue: "" });

  return (
    <TextField
      {...props}
      {...field}
      id={props.id}
      label={props.label}
      sx={{
        ...props.sx,
        "& .Mui-disabled": {
          color: "slategray", // Change this to the desired slate color
          backgroundColor: "#eff1f5", // Optional: change the background color of the disabled state
        },
      }}
      multiline={props.multiline}
      rows={props.rows}
      maxRows={props.maxRows}
      type={props.type}
      size={props.size ?? "small"}
      placeholder={props.placeholder}
      disabled={props.disabled}
      variant="outlined"
      onKeyDown={props.onKeyDown}
      value={props.value}
      className={props.className}
      error={props.error || !!fieldState.error}
      helperText={props.error ? props.helperText : fieldState.error?.message}
      {...(props.InputProps && `inputProps=${props.InputProps}`)}
    />
  );
}
