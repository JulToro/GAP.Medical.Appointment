import { UUID } from 'angular2-uuid';
import { MedicalSpecialtyModel } from './medicalSpecialtyModel';

export interface AppointmentModel {
    id?: UUID;
    patientId: string;    
    assignedDate: string;
    medicalSpecialtyId: UUID;
    medicalSpecialty?: MedicalSpecialtyModel;
}       