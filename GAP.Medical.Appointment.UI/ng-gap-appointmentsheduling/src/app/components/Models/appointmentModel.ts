import { MedicalSpecialityModel } from './medicalSpecialityModel';

export interface AppointmentModel {
    id: string;
    PatientId: string;    
    AssignedDate: string;
    MedicalSpecialityId: string;
    MedicalSpeciality: MedicalSpecialityModel;
}       