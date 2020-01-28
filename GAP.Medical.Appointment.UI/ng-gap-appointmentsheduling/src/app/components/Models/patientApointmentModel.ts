import { PatientModel } from './patientModel';
import { AppointmentModel } from './appointmentModel';

export interface PatientApointmentModel {
    patient: PatientModel;
    appointments: AppointmentModel[];
}