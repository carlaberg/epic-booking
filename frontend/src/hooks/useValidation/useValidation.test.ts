// import { useValidation, toErrors, IValidations } from "./useValidation";
// import { renderHook, act } from "@testing-library/react";

// describe("useValidation hook", () => {
//   const defaultFilters = {
//     odometer: { min: 0, max: 10 },
//   };

//   let mockFilters: typeof defaultFilters;

//   const validations = {
//     odometerRange: () =>
//       mockFilters.odometer.max >= mockFilters.odometer.min
//         ? null
//         : "Invalid range",
//   };

//   const initialProps = {
//     validationSchema: validations,
//   };

//   beforeEach(() => {
//     mockFilters = defaultFilters;
//   });

//   it("should return null for the errors property on inital render", () => {
//     const { result } = renderHook(
//       ({ validationSchema }) => useValidation(validationSchema),
//       {
//         initialProps,
//       }
//     );

//     expect(result.current.errors).toBe(null);
//   });

//   it("should return null for the errors property if all fields are valid", () => {
//     const { result } = renderHook(
//       ({ validationSchema }) => useValidation(validationSchema),
//       {
//         initialProps,
//       }
//     );

//     act(() => {
//       result.current.validate();
//     });

//     expect(result.current.errors).toBe(null);
//   });

//   it("should return an errors object with the correct shape if any fields are invalid", () => {
//     mockFilters = {
//       odometer: { min: 20, max: 10 },
//     };

//     const { result } = renderHook(
//       ({ validationSchema }) => useValidation(validationSchema),
//       {
//         initialProps,
//       }
//     );

//     act(() => {
//       result.current.validate();
//     });

//     expect(result.current.errors).toEqual({
//       odometerRange: "Invalid range",
//     });
//   });

//   it("should log correct error if validation functions return the wrong type", () => {
//     mockFilters = {
//       odometer: { min: 20, max: 10 },
//     };

//     const error = jest.spyOn(console, "error").mockImplementation(() => {});

//     const incorrectValidations = {
//       odometerRange: () => 3,
//     };

//     const { result } = renderHook(
//       // @ts-ignore
//       ({ validationSchema }) => useValidation(validationSchema),
//       {
//         initialProps: {
//           validationSchema: incorrectValidations,
//         },
//       }
//     );

//     act(() => {
//       result.current.validate();
//     });

//     expect(error).toBeCalledWith(
//       "The validations functions must return either a string or null but recived: 3"
//     );
//   });
// });

// describe("toErrors", () => {
//   const defaultValidations = {
//     odometerRange: () => null,
//     idleDaysRange: () => null,
//   };

//   let mockValidations: IValidations<keyof typeof defaultValidations>;

//   beforeEach(() => {
//     mockValidations = defaultValidations;
//   });

//   it("should return null if all of the validation functions return null", () => {
//     const errors = toErrors(mockValidations);

//     expect(errors).toEqual(null);
//   });

//   it("should return an error object with the correact shape if any of the validation functions returns an error message", () => {
//     mockValidations = {
//       odometerRange: () => null,
//       idleDaysRange: () => "Invalid",
//     };
//     const errors = toErrors(mockValidations);

//     expect(errors).toEqual({
//       odometerRange: null,
//       idleDaysRange: "Invalid",
//     });
//   });
// });