import { PatientModel } from './patientModel';
import { AppointmentModel } from './appointmentModel';

export interface PatientApointmentModel {
    Patient: PatientModel;
    Appointments: AppointmentModel[];
}