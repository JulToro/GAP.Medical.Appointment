import { MedicalSpecialtyModel } from './medicalSpecialtyModel';

export interface AppointmentModel {
    id: string;
    PatientId: string;    
    AssignedDate: string;
    MedicalSpecialtyId: string;
    MedicalSpecialty: MedicalSpecialtyModel;
}       