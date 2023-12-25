import { useEffect, useState } from "react";

export type IValidations<T> = Record<keyof T, () => string | null>;
export type IErrors<T> = Record<keyof T, string | null>;
interface ValidationResult {
    valid: boolean;
}

interface IFilterValidation<T> {
  validation: () => ValidationResult;
  errors: IErrors<T> | null;
}

export function toErrors<T>(validations: IValidations<T>): IErrors<T> | null {
  const tempErrors: IErrors<T> = {} as IErrors<T>;
  let isValid: boolean = true;

  for (const key in validations) {
    const error = validations[key]();

    if (typeof error !== "string" && error !== null) {
      console.error(
        `The validations functions must return either a string or null but recived: ${error}`
      );
    }

    tempErrors[key] = error;

    if (error) {
      isValid = false;
    }
  }

  return isValid ? null : tempErrors;
}

export function useValidation<T>(
  validations: IValidations<T>
): IFilterValidation<T> {
  const [errors, setErrors] = useState<IErrors<T> | null>(null);

  function validation(): ValidationResult {
    const newErrors: IErrors<T> | null = toErrors(validations);
    setErrors(newErrors);
    return {
        valid: newErrors === null ? true : false
    }
  }

  return {
    validation,
    errors,
  };
}
